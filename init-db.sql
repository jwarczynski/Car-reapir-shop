DROP DATABASE IF EXISTS `warsztat`;
CREATE DATABASE `warsztat`
    CHARACTER SET utf8mb4
    COLLATE utf8mb4_polish_ci;

USE `warsztat`;

CREATE TABLE `customers` (
    `customerId` int NOT NULL PRIMARY KEY AUTO_INCREMENT,
    `fullName` varchar(100) NOT NULL,
    `phoneNumber` varchar(16) NOT NULL,
    `email` varchar(100) DEFAULT NULL,
    `taxId` varchar(16) DEFAULT NULL
);

CREATE TABLE `employeeRoles` (
    `roleName` varchar(20) NOT NULL PRIMARY KEY,
    `minWage` decimal(5,2) NOT NULL,
    `maxWage` decimal(5,2) NOT NULL
);

CREATE TABLE `employees` (
    `fullName` varchar(40) NOT NULL PRIMARY KEY,
    `wage` decimal(5,2) NOT NULL,
    `roleName` varchar(20) NOT NULL,
    CONSTRAINT `employees_empRoles` FOREIGN KEY (`roleName`) REFERENCES `employeeRoles` (`roleName`)
);

CREATE TABLE `carManufacturers` (
    `manufacturerName` varchar(50) NOT NULL PRIMARY KEY
);

CREATE TABLE `carModels` (
    `modelName` varchar(50) NOT NULL,
    `manufacturerName` varchar(50) NOT NULL,
    PRIMARY KEY (`modelName`, `manufacturerName`),
    CONSTRAINT `carModels_carManufaturers_fk` FOREIGN KEY (`manufacturerName`) REFERENCES `carManufacturers`(`manufacturerName`) ON UPDATE CASCADE ON DELETE CASCADE
);


CREATE TABLE `cars` (
    `licensePlate` varchar(20) NOT NULL PRIMARY KEY,
    `manufacturerName` varchar(50),
    `modelName` varchar(50),
    CONSTRAINT `cars_carModel_fk` FOREIGN KEY (`modelName`, `manufacturerName`) REFERENCES `carModels`(`modelName`, `manufacturerName`) ON UPDATE CASCADE ON DELETE SET NULL
);

CREATE TABLE `orders` (
    `id` int NOT NULL PRIMARY KEY,
    `acceptDate` date NOT NULL,
    `finishDate` date,
    `comment` longtext DEFAULT NULL,
    `customerId` int NOT NULL,
    `carLicensePlate` varchar(10) NOT NULL,
    CONSTRAINT `order_customer_fk` FOREIGN KEY (`customerId`) REFERENCES `customers` (`customerId`),
    CONSTRAINT `order_car_fk` FOREIGN KEY (`carLicensePlate`) REFERENCES `cars` (`licensePlate`)
);

CREATE TABLE `shoppingLists` (
    `name` varchar(50) NOT NULL PRIMARY KEY,
    `isFulfilled` char(1) NOT NULL,
    `priority` int(1)
);

CREATE TABLE `parts` (
    `partCode` varchar(25) NOT NULL PRIMARY KEY,
    `name` varchar(50) NOT NULL,
    `cost` decimal(5,2) NOT NULL CHECK (cost >= 0),
    `currentlyInStock` int NOT NULL DEFAULT 0 CHECK (currentlyInStock >= 0),
    `maxInStock` int,
    CONSTRAINT chk_lessThanMax CHECK (currentlyInStock <= maxInStock)
);

CREATE TABLE `shoppingListsParts` (
    `quantity` int NOT NULL,
    `partCode` varchar(25) NOT NULL,
    `listName` char(50) NOT NULL,
    PRIMARY KEY (`partCode`, `listName`),
    CONSTRAINT `shoppingListsParts_part_fk` FOREIGN KEY (`partCode`) REFERENCES `parts` (`partCode`) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT `shoppingListsParts_shoppingList_fk` FOREIGN KEY (`listName`) REFERENCES `shoppingLists` (`name`) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE `partsToCarModels` (
    `modelName` varchar(50) NOT NULL,
    `manufacturerName` varchar(50) NOT NULL,
    `partCode` varchar(25) NOT NULL,
    CONSTRAINT `partsToCarModels_carModel_fk` FOREIGN KEY (`modelName`, `manufacturerName`) REFERENCES `carModels` (`modelName`, `manufacturerName`) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT `partsToCarModels_part_fk` FOREIGN KEY (`partCode`) REFERENCES `parts` (`partCode`) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE `services` (
    `name` varchar(100) NOT NULL PRIMARY KEY,
    `standardCost` decimal(5,2) NOT NULL
);

CREATE TABLE servicesToCarModels(
	`modelName` varchar(50) NOT NULL,
	`manufacturerName` varchar(50) NOT NULL,
	`serviceName` varchar(100) NOT NULL,
	CONSTRAINT `servicesToCarModels_carModels_fk` FOREIGN KEY (`modelName`) REFERENCES `carModels` (`modelName`) ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT `servicesToCarModels_services_fk` FOREIGN KEY (`serviceName`) REFERENCES `services` (`name`) ON UPDATE CASCADE ON DELETE CASCADE,
	PRIMARY KEY (`modelName`, `manufacturerName`, `serviceName`)
);

CREATE TABLE `serviceParts` (
    `quantity` int NOT NULL,
    `serviceName` varchar(100) NOT NULL,
    `partPartCode` varchar(25) NOT NULL,
    PRIMARY KEY (`serviceName`, `partPartCode`),
    CONSTRAINT `serviceParts_part_fk` FOREIGN KEY (`partPartCode`) REFERENCES `parts` (`partCode`),
    CONSTRAINT `serviceParts_service_fk` FOREIGN KEY (`serviceName`) REFERENCES `services` (`name`) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE `orderEntries` (
    `position` int NOT NULL,
    `isDone` char(1) NOT NULL,
    `date` date,
    `actualCost` decimal(5,2),
    `comment` longtext,
    `orderId` int NOT NULL,
    `employeeName` varchar(40), 
    `serviceName` varchar(100) NOT NULL,
    PRIMARY KEY (`position`, `orderId`),
    CONSTRAINT `orderEntry_order_fk` FOREIGN KEY (`orderId`) REFERENCES `orders` (`id`),
    CONSTRAINT `orderEntry_employee_fk` FOREIGN KEY (`employeeName`) REFERENCES `employees` (`fullName`),
    CONSTRAINT `orderEntry_service_fk` FOREIGN KEY (`serviceName`) REFERENCES `services` (`name`)
);


CREATE VIEW `shoppingListsWithPartCount` AS
    SELECT sl.`name` AS `name`, sl.`isFulfilled` AS `isFulfilled`, COUNT(slp.`partCode`) AS `partsCount`
        FROM `shoppingLists` sl
        LEFT JOIN `shoppingListsParts` slp ON sl.`name` = slp.`listName`
        GROUP BY sl.`name`;

CREATE VIEW `shoppingListsPartsWithNames` AS
    SELECT slp.`partCode` AS `partCode`, slp.`quantity` AS `quantity`, slp.`listName` AS `listName`, p.`name` AS `partName`
        FROM `shoppingListsParts` slp
        JOIN `parts` p ON slp.`partCode` = p.`partCode`;
        
CREATE VIEW servicesPartsView AS
    SELECT serviceName, p.name AS partName, partPartCode AS partCode, quantity
        FROM services s JOIN serviceParts ON s.name = serviceName
        JOIN parts p ON partPartCode = p.partCode;


DELIMITER $$
CREATE FUNCTION `countModelsByManufacturer` (
    manufacturer VARCHAR(50)
) RETURNS INT
BEGIN
    DECLARE manufacturerCount INT;
    SELECT COUNT(*) INTO manufacturerCount
        FROM `carModels`
        WHERE `manufacturerName` = manufacturer;
    RETURN manufacturerCount;
END$$

CREATE PROCEDURE `addShoppingListEntry` (
    IN listName CHAR(50),
    IN partCode VARCHAR(25),
    IN qty INT
)
BEGIN
    INSERT INTO `shoppingListsParts` (`listName`, `partCode`, `quantity`)
        VALUES (listName, partCode, qty)
        ON DUPLICATE KEY UPDATE `quantity` = `quantity` + qty;
END$$
DELIMITER ;

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
    `minimumWage` decimal(7,2) NOT NULL,
    `maximumWage` decimal(7,2) NOT NULL
);

CREATE TABLE `employees` (
    `fullName` varchar(40) NOT NULL PRIMARY KEY,
    `wage` decimal(7,2) NOT NULL,
    `roleName` varchar(20) NOT NULL,
    CONSTRAINT `employee_employeeRole_fk` FOREIGN KEY (`roleName`) REFERENCES `employeeRoles` (`roleName`) ON UPDATE CASCADE
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
    `id` int NOT NULL PRIMARY KEY AUTO_INCREMENT,
    `acceptDate` date NOT NULL DEFAULT NOW(),
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
    `cost` decimal(7,2) NOT NULL CHECK (cost >= 0),
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
    `standardCost` decimal(7,2) NOT NULL
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
    `isDone` char(1) NOT NULL DEFAULT "0",
    `date` date,
    `actualCost` decimal(7,2),
    `comment` longtext,
    `orderId` int NOT NULL,
    `employeeName` varchar(40), 
    `serviceName` varchar(100) NOT NULL,
    PRIMARY KEY (`position`, `orderId`),
    CONSTRAINT `orderEntry_order_fk` FOREIGN KEY (`orderId`) REFERENCES `orders` (`id`) ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT `orderEntry_employee_fk` FOREIGN KEY (`employeeName`) REFERENCES `employees` (`fullName`) ON UPDATE CASCADE ON DELETE SET NULL,
    CONSTRAINT `orderEntry_service_fk` FOREIGN KEY (`serviceName`) REFERENCES `services` (`name`) ON UPDATE CASCADE
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

CREATE VIEW ordersView AS
    SELECT o.`id` AS `orderId`, c.`fullName` AS `customerName`, o.`carLicensePlate` AS `carLicensePlate`,
        o.`acceptDate` AS `acceptDate`, o.`finishDate` AS `finishDate`
        FROM `orders` o
        JOIN `customers` c ON c.`customerId` = o.`customerId`
        ORDER BY o.`acceptDate` DESC, o.`id` DESC;

CREATE VIEW `orderEntriesView` AS
    SELECT oe.`orderId` AS `orderId`, oe.`position` AS `position`, oe.serviceName AS `serviceName`,
        oe.date AS `date`, IFNULL(oe.`actualCost`, s.`standardCost`) AS `cost`, (oe.`actualCost` IS NULL) AS `isCostStandard`,
        oe.employeeName AS `employeeName`, oe.`isDone` AS `isDone`, oe.comment AS `comment`
        FROM `orderEntries` oe
        JOIN `services` s ON oe.`serviceName` = s.`name`
        ORDER BY oe.`position` ASC;

CREATE VIEW `servicesForCar` AS
    SELECT s.`name` AS `serviceName`, s.`standardCost` AS `standardCost`, c.`licensePlate` AS `licensePlate`
        FROM `services` s
        JOIN `servicesToCarModels` sm ON s.`name` = sm.`serviceName`
        JOIN `cars` c ON c.`modelName` = sm.`modelName` AND c.`manufacturerName` = sm.`manufacturerName`;


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

CREATE FUNCTION `addOrder` (
    customerId INT,
    carLicensePlate VARCHAR(10)
) RETURNS INT
BEGIN
    DECLARE orderId INT;
    INSERT INTO `orders` (`customerId`, `carLicensePlate`)
        VALUES (customerId, carLicensePlate);
    SELECT LAST_INSERT_ID() INTO orderId;
    RETURN orderId;
END$$

CREATE FUNCTION `addOrderEntry` (
    orderId INT,
    serviceName VARCHAR(100),
    actualCost DECIMAL(7, 2)
) RETURNS INT
BEGIN
    DECLARE entryId INT;
    SELECT MAX(position) + 1 INTO entryId
        FROM `orderEntries`
        WHERE `orderId` = orderId;
    INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `actualCost`)
        VALUES (orderId, entryId, serviceName, actualCost);
    RETURN entryId;
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

CREATE TRIGGER `takeFromWarehouse`
    BEFORE UPDATE ON `orderEntries`
    FOR EACH ROW
BEGIN
    DECLARE missingParts INT;
    IF OLD.isDone = "0" AND NEW.isDone = "1" THEN
        SELECT COUNT(*) INTO missingParts FROM serviceParts
            JOIN parts ON partPartCode = partCode
            WHERE serviceName = NEW.serviceName
                AND quantity > currentlyInStock;
        IF missingParts > 0 THEN
            SIGNAL SQLSTATE "45000"
              SET MESSAGE_TEXT = "MISSING_PARTS";
        ELSE
            UPDATE parts
                SET currentlyInStock = currentlyInStock - IFNULL((
                    SELECT quantity FROM serviceParts
                        WHERE serviceName = NEW.serviceName
                            AND partPartCode = partCode
                ), 0);
        END IF;
    END IF;
END$$
DELIMITER ;

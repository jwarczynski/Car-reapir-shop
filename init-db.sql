DROP DATABASE IF EXISTS `warsztat`;
CREATE DATABASE `warsztat`;

USE `warsztat`;

CREATE TABLE `customers` (
    `customerId` int NOT NULL,
    `fullName` varchar(100) NOT NULL,
    `phoneNumber` varchar(16) NOT NULL,
    `email` varchar(100) DEFAULT NULL,
    `taxId` varchar(16) DEFAULT NULL,
    PRIMARY KEY (`customerId`)
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
    CONSTRAINT `carModels_carManufaturers_fk` FOREIGN KEY (`manufacturerName`) REFERENCES `carManufacturers`(`manufacturerName`)
);


CREATE TABLE `cars` (
    `licensePlate` varchar(20) NOT NULL PRIMARY KEY,
    `manufacturerName` varchar(50) NOT NULL,
    `modelName` varchar(50) NOT NULL,
    CONSTRAINT `cars_carModel_fk` FOREIGN KEY (`modelName`, `manufacturerName`) REFERENCES `carModels`(`modelName`, `manufacturerName`)
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

CREATE TABLE `serviceParts` (
    `quantity` int NOT NULL,
    `serviceName` varchar(100) NOT NULL,
    `partCode` varchar(25) NOT NULL,
    PRIMARY KEY (`serviceName`, `partCode`),
    CONSTRAINT `serviceParts_part_fk` FOREIGN KEY (`partCode`) REFERENCES `parts` (`partCode`),
    CONSTRAINT `serviceParts_service_fk` FOREIGN KEY (`serviceName`) REFERENCES `services` (`name`)
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
    SELECT sl.`name` AS `name`, sl.`isFulfilled` AS `isFulfilled`, COUNT(*) AS `partsCount`
        FROM `shoppingLists` sl
        JOIN `shoppingListsParts` slp ON sl.`name` = slp.`listName`
        GROUP BY sl.`name`;

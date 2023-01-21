-- Insert customers
INSERT INTO `customers` (`customerId`, `fullName`, `phoneNumber`, `email`, `taxId`) VALUES (1, "Jan Kowalski", "17 697 78 78", "jan.kowalski@email.com", "123-456-78-90");
INSERT INTO `customers` (`customerId`, `fullName`, `phoneNumber`, `email`, `taxId`) VALUES (2, "Piotr Nowak", "600 234 789", NULL, "473-799-67-15");
INSERT INTO `customers` (`customerId`, `fullName`, `phoneNumber`, `email`, `taxId`) VALUES (3, "Anna Malinowska", "11 222 33 44", "anna.m@pocz.ta", NULL);
INSERT INTO `customers` (`customerId`, `fullName`, `phoneNumber`, `email`, `taxId`) VALUES (4, "Grzegorz Brzeczyszczykiewicz", "19 123", NULL, NULL);

-- Insert employee roles
INSERT INTO `employeeRoles` (`roleName`, `minimumWage`, `maximumWage`) VALUES ("Stazysta", 1500, 2500);
INSERT INTO `employeeRoles` (`roleName`, `minimumWage`, `maximumWage`) VALUES ("Mechanik", 2000, 4000);
INSERT INTO `employeeRoles` (`roleName`, `minimumWage`, `maximumWage`) VALUES ("Kierownik", 3500, 5000);

-- Insert employees
INSERT INTO `employees` (`fullName`, `wage`, `roleName`) VALUES ("Bartosz Malinowski", 1700, "Stazysta");
INSERT INTO `employees` (`fullName`, `wage`, `roleName`) VALUES ("Stefan Karwowski", 2000, "Stazysta");
INSERT INTO `employees` (`fullName`, `wage`, `roleName`) VALUES ("Piotr Zimny", 2500, "Stazysta");
INSERT INTO `employees` (`fullName`, `wage`, `roleName`) VALUES ("Leszek Bialy", 2200, "Mechanik");
INSERT INTO `employees` (`fullName`, `wage`, `roleName`) VALUES ("Zdzislaw Stefanowski", 3800, "Mechanik");
INSERT INTO `employees` (`fullName`, `wage`, `roleName`) VALUES ("Marian Pazdzioch", 4900, "Kierownik");

-- Insert manufacturers
INSERT INTO `carManufacturers` (`manufacturerName`) VALUES ("Volkswagen");
INSERT INTO `carManufacturers` (`manufacturerName`) VALUES ("Ford");
INSERT INTO `carManufacturers` (`manufacturerName`) VALUES ("Opel");
INSERT INTO `carManufacturers` (`manufacturerName`) VALUES ("BMW");

-- Insert models
INSERT INTO `carModels` (`manufacturerName`, `modelName`) VALUES ("Volkswagen", "Passat");
INSERT INTO `carModels` (`manufacturerName`, `modelName`) VALUES ("Volkswagen", "Touran");
INSERT INTO `carModels` (`manufacturerName`, `modelName`) VALUES ("Volkswagen", "Golf");
INSERT INTO `carModels` (`manufacturerName`, `modelName`) VALUES ("Ford", "Focus");
INSERT INTO `carModels` (`manufacturerName`, `modelName`) VALUES ("Ford", "Fiesta");
INSERT INTO `carModels` (`manufacturerName`, `modelName`) VALUES ("Ford", "Mondeo");
INSERT INTO `carModels` (`manufacturerName`, `modelName`) VALUES ("Opel", "Astra");
INSERT INTO `carModels` (`manufacturerName`, `modelName`) VALUES ("Opel", "Corsa");
INSERT INTO `carModels` (`manufacturerName`, `modelName`) VALUES ("Opel", "Insignia");
INSERT INTO `carModels` (`manufacturerName`, `modelName`) VALUES ("BMW", "3");
INSERT INTO `carModels` (`manufacturerName`, `modelName`) VALUES ("BMW", "5");
INSERT INTO `carModels` (`manufacturerName`, `modelName`) VALUES ("BMW", "7");

-- Insert cars
INSERT INTO `cars` (`licensePlate`, `manufacturerName`, `modelName`) VALUES ("PO 12345", "Volkswagen", "Passat");
INSERT INTO `cars` (`licensePlate`, `manufacturerName`, `modelName`) VALUES ("O0 OOO00", "Volkswagen", "Passat");
INSERT INTO `cars` (`licensePlate`, `manufacturerName`, `modelName`) VALUES ("WF 12XU8", "Volkswagen", "Passat");
INSERT INTO `cars` (`licensePlate`, `manufacturerName`, `modelName`) VALUES ("HPU 12C5", "Volkswagen", "Passat");
INSERT INTO `cars` (`licensePlate`, `manufacturerName`, `modelName`) VALUES ("UG 1482T", "Volkswagen", "Passat");

-- Insert orders
INSERT INTO `orders` (`id`, `acceptDate`, `finishDate`, `comment`, `customerId`, `carLicensePlate`) VALUES (1, "2022-01-01", "2022-01-06", "", 1, "PO 12345");
INSERT INTO `orders` (`id`, `acceptDate`, `finishDate`, `comment`, `customerId`, `carLicensePlate`) VALUES (2, "2022-02-01", "2022-03-06", "Bedzie duzo pracy", 1, "O0 OOO00");
INSERT INTO `orders` (`id`, `acceptDate`, `finishDate`, `comment`, `customerId`, `carLicensePlate`) VALUES (3, "2022-08-24", "2022-08-25", "Zrobic na juz!!!", 2, "HPU 12C5");
INSERT INTO `orders` (`id`, `acceptDate`, `finishDate`, `comment`, `customerId`, `carLicensePlate`) VALUES (4, "2022-10-13", "2022-10-20", "", 3, "WF 12XU8");
INSERT INTO `orders` (`id`, `acceptDate`, `finishDate`, `comment`, `customerId`, `carLicensePlate`) VALUES (5, "2022-11-06", "2022-11-30", "Zamowil pedant - przylozyc sie!", 4, "UG 1482T");
INSERT INTO `orders` (`id`, `acceptDate`, `finishDate`, `comment`, `customerId`, `carLicensePlate`) VALUES (6, "2022-12-27", "2023-01-02", "", 1, "PO 12345");
INSERT INTO `orders` (`id`, `acceptDate`, `finishDate`, `comment`, `customerId`, `carLicensePlate`) VALUES (7, "2023-01-15", NULL, "", 2, "HPU 12C5");

-- Insert shopping lists
INSERT INTO `shoppingLists` (`name`, `isFulfilled`, `priority`) VALUES ("List 0", True, 0);
INSERT INTO `shoppingLists` (`name`, `isFulfilled`, `priority`) VALUES ("List 1", False, 0);
INSERT INTO `shoppingLists` (`name`, `isFulfilled`, `priority`) VALUES ("List 2", False, 0);

-- Insert parts
INSERT INTO `parts` (`partCode`, `name`, `cost`, `currentlyInStock`, `maxInStock`) VALUES ("000", "Part 0", 0, 10, 15);
INSERT INTO `parts` (`partCode`, `name`, `cost`, `currentlyInStock`, `maxInStock`) VALUES ("001", "Part 1", 1, 11, 25);
INSERT INTO `parts` (`partCode`, `name`, `cost`, `currentlyInStock`, `maxInStock`) VALUES ("002", "Part 2", 2, 12, 35);
INSERT INTO `parts` (`partCode`, `name`, `cost`, `currentlyInStock`, `maxInStock`) VALUES ("003", "Part 3", 3, 13, 45);
INSERT INTO `parts` (`partCode`, `name`, `cost`, `currentlyInStock`, `maxInStock`) VALUES ("004", "Part 4", 4, 14, 55);
INSERT INTO `parts` (`partCode`, `name`, `cost`, `currentlyInStock`, `maxInStock`) VALUES ("005", "Part 5", 5, 15, 65);
INSERT INTO `parts` (`partCode`, `name`, `cost`, `currentlyInStock`, `maxInStock`) VALUES ("006", "Part 6", 6, 16, 75);
INSERT INTO `parts` (`partCode`, `name`, `cost`, `currentlyInStock`, `maxInStock`) VALUES ("007", "Part 7", 7, 17, 85);
INSERT INTO `parts` (`partCode`, `name`, `cost`, `currentlyInStock`, `maxInStock`) VALUES ("008", "Part 8", 8, 18, 95);
INSERT INTO `parts` (`partCode`, `name`, `cost`, `currentlyInStock`, `maxInStock`) VALUES ("009", "Part 9", 9, 19, 105);

-- Add part to shopping lists
INSERT INTO `shoppingListsParts` (`quantity`, `partCode`, `listName`) VALUES  (5, "000", "List 0");
INSERT INTO `shoppingListsParts` (`quantity`, `partCode`, `listName`) VALUES  (15, "001", "List 1");
INSERT INTO `shoppingListsParts` (`quantity`, `partCode`, `listName`) VALUES  (25, "002", "List 2");

-- Insert services
INSERT INTO `services` (`name`, `standardCost`) VALUES ("Odkurzanie", 10);
INSERT INTO `services` (`name`, `standardCost`) VALUES ("Wymiana oleju", 20);
INSERT INTO `services` (`name`, `standardCost`) VALUES ("Wymiana filtra powietrza", 30);
INSERT INTO `services` (`name`, `standardCost`) VALUES ("Wymiana filtra oleju", 40);
INSERT INTO `services` (`name`, `standardCost`) VALUES ("Wymiana filtra paliwa", 50);
INSERT INTO `services` (`name`, `standardCost`) VALUES ("Wymiana filtra kabinowego", 60);
INSERT INTO `services` (`name`, `standardCost`) VALUES ("Wymiana plynu hamulcowego", 70);
INSERT INTO `services` (`name`, `standardCost`) VALUES ("Wymiana plynu chlodniczego", 80);
INSERT INTO `services` (`name`, `standardCost`) VALUES ("Wymiana plynu klimatyzacji", 90);
INSERT INTO `services` (`name`, `standardCost`) VALUES ("Wymiana plynu do skrzyni biegow", 100);

-- Insert service-car model relations
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Odkurzanie", "Opel", "Astra");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Odkurzanie", "BMW", "3");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Odkurzanie", "Volkswagen", "Passat");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Odkurzanie", "Opel", "Corsa");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana oleju", "BMW", "3");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana oleju", "Volkswagen", "Golf");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana oleju", "Volkswagen", "Golf");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana oleju", "BMW", "7");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra powietrza", "Volkswagen", "Golf");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra powietrza", "Opel", "Astra");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra powietrza", "Ford", "Fiesta");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra powietrza", "BMW", "5");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra oleju", "Opel", "Insignia");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra oleju", "Ford", "Fiesta");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra oleju", "Opel", "Insignia");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra oleju", "BMW", "3");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra oleju", "Ford", "Fiesta");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra oleju", "BMW", "5");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra paliwa", "Volkswagen", "Golf");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra paliwa", "BMW", "5");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra paliwa", "Opel", "Astra");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra paliwa", "Volkswagen", "Golf");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra kabinowego", "BMW", "5");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra kabinowego", "Ford", "Mondeo");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra kabinowego", "Opel", "Astra");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra kabinowego", "Volkswagen", "Passat");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra kabinowego", "Opel", "Astra");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu hamulcowego", "Opel", "Corsa");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu hamulcowego", "Volkswagen", "Passat");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu hamulcowego", "Opel", "Insignia");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu chlodniczego", "BMW", "5");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu chlodniczego", "Ford", "Focus");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu chlodniczego", "BMW", "3");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu chlodniczego", "Volkswagen", "Passat");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu chlodniczego", "Ford", "Focus");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu klimatyzacji", "Opel", "Corsa");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu klimatyzacji", "BMW", "5");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu klimatyzacji", "Ford", "Mondeo");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu do skrzyni biegow", "Volkswagen", "Touran");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu do skrzyni biegow", "Opel", "Corsa");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu do skrzyni biegow", "Volkswagen", "Golf");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu do skrzyni biegow", "Volkswagen", "Passat");

-- Insert car-part relations
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Volkswagen", "Golf", "000");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Volkswagen", "Passat", "000");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Opel", "Insignia", "001");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Opel", "Astra", "001");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("BMW", "5", "002");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("BMW", "7", "002");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Ford", "Focus", "003");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Ford", "Fiesta", "003");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("BMW", "3", "004");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("BMW", "5", "004");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Ford", "Fiesta", "005");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Ford", "Mondeo", "005");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("BMW", "7", "006");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("BMW", "3", "006");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Opel", "Corsa", "007");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Opel", "Insignia", "007");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Volkswagen", "Touran", "008");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Volkswagen", "Golf", "008");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("BMW", "5", "009");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("BMW", "7", "009");

-- Insert order entries
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (1, 1, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "PO 12345" ORDER BY RAND() LIMIT 1), "1", "2022-01-01", "Marian Pazdzioch");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (1, 2, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "PO 12345" ORDER BY RAND() LIMIT 1), "1", "2022-01-01", "Leszek Bialy");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (1, 3, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "PO 12345" ORDER BY RAND() LIMIT 1), "1", "2022-01-01", "Bartosz Malinowski");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (1, 4, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "PO 12345" ORDER BY RAND() LIMIT 1), "1", "2022-01-01", "Zdzislaw Stefanowski");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (2, 1, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "O0 OOO00" ORDER BY RAND() LIMIT 1), "1", "2022-02-01", "Marian Pazdzioch");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (2, 2, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "O0 OOO00" ORDER BY RAND() LIMIT 1), "1", "2022-02-01", "Stefan Karwowski");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (2, 3, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "O0 OOO00" ORDER BY RAND() LIMIT 1), "1", "2022-02-01", "Zdzislaw Stefanowski");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (3, 1, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "HPU 12C5" ORDER BY RAND() LIMIT 1), "1", "2022-08-24", "Bartosz Malinowski");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (3, 2, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "HPU 12C5" ORDER BY RAND() LIMIT 1), "1", "2022-08-24", "Leszek Bialy");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (3, 3, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "HPU 12C5" ORDER BY RAND() LIMIT 1), "1", "2022-08-24", "Stefan Karwowski");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (4, 1, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "WF 12XU8" ORDER BY RAND() LIMIT 1), "1", "2022-10-13", "Piotr Zimny");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (4, 2, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "WF 12XU8" ORDER BY RAND() LIMIT 1), "1", "2022-10-13", "Piotr Zimny");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (4, 3, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "WF 12XU8" ORDER BY RAND() LIMIT 1), "1", "2022-10-13", "Stefan Karwowski");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (5, 1, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "UG 1482T" ORDER BY RAND() LIMIT 1), "1", "2022-11-06", "Piotr Zimny");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (5, 2, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "UG 1482T" ORDER BY RAND() LIMIT 1), "1", "2022-11-06", "Leszek Bialy");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (5, 3, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "UG 1482T" ORDER BY RAND() LIMIT 1), "1", "2022-11-06", "Stefan Karwowski");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (5, 4, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "UG 1482T" ORDER BY RAND() LIMIT 1), "1", "2022-11-06", "Bartosz Malinowski");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (6, 1, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "PO 12345" ORDER BY RAND() LIMIT 1), "1", "2022-12-27", "Stefan Karwowski");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (6, 2, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "PO 12345" ORDER BY RAND() LIMIT 1), "1", "2022-12-27", "Zdzislaw Stefanowski");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (6, 3, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "PO 12345" ORDER BY RAND() LIMIT 1), "1", "2022-12-27", "Zdzislaw Stefanowski");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (7, 1, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "HPU 12C5" ORDER BY RAND() LIMIT 1), "0", NULL, NULL);
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (7, 2, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "HPU 12C5" ORDER BY RAND() LIMIT 1), "0", NULL, NULL);
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (7, 3, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "HPU 12C5" ORDER BY RAND() LIMIT 1), "0", NULL, NULL);
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (7, 4, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "HPU 12C5" ORDER BY RAND() LIMIT 1), "0", NULL, NULL);


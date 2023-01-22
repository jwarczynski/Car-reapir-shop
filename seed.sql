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
INSERT INTO `shoppingLists` (`name`, `isFulfilled`) VALUES ("List 0", True);
INSERT INTO `shoppingLists` (`name`, `isFulfilled`) VALUES ("List 1", False);
INSERT INTO `shoppingLists` (`name`, `isFulfilled`) VALUES ("List 2", False);

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
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Odkurzanie", "Volkswagen", "Golf");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Odkurzanie", "Opel", "Astra");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Odkurzanie", "Ford", "Mondeo");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana oleju", "BMW", "3");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana oleju", "BMW", "7");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana oleju", "Opel", "Insignia");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana oleju", "Ford", "Mondeo");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra powietrza", "Ford", "Mondeo");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra powietrza", "Volkswagen", "Golf");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra powietrza", "BMW", "5");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra oleju", "Volkswagen", "Passat");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra oleju", "Opel", "Insignia");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra oleju", "Volkswagen", "Passat");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra oleju", "BMW", "7");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra oleju", "Opel", "Astra");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra paliwa", "Ford", "Focus");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra paliwa", "Volkswagen", "Golf");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra paliwa", "Ford", "Mondeo");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra paliwa", "BMW", "7");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra paliwa", "Volkswagen", "Touran");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra paliwa", "Volkswagen", "Golf");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra kabinowego", "Volkswagen", "Passat");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra kabinowego", "BMW", "7");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra kabinowego", "Volkswagen", "Golf");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra kabinowego", "Volkswagen", "Passat");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra kabinowego", "Ford", "Mondeo");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana filtra kabinowego", "Volkswagen", "Passat");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu hamulcowego", "Ford", "Mondeo");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu hamulcowego", "BMW", "5");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu hamulcowego", "BMW", "5");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu hamulcowego", "Opel", "Corsa");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu chlodniczego", "Volkswagen", "Golf");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu chlodniczego", "BMW", "7");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu chlodniczego", "Volkswagen", "Passat");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu chlodniczego", "BMW", "5");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu chlodniczego", "BMW", "3");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu chlodniczego", "BMW", "3");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu klimatyzacji", "Volkswagen", "Golf");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu klimatyzacji", "Opel", "Corsa");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu klimatyzacji", "Volkswagen", "Passat");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu klimatyzacji", "Opel", "Insignia");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu klimatyzacji", "Ford", "Mondeo");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu klimatyzacji", "Opel", "Insignia");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu do skrzyni biegow", "Volkswagen", "Golf");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu do skrzyni biegow", "Ford", "Mondeo");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu do skrzyni biegow", "Volkswagen", "Passat");
INSERT INTO `servicesToCarModels` (`serviceName`, `manufacturerName`, `modelName`) VALUES ("Wymiana plynu do skrzyni biegow", "Ford", "Mondeo");

-- Insert car-part relations
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Ford", "Mondeo", "000");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Ford", "Focus", "000");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Ford", "Fiesta", "001");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Ford", "Mondeo", "001");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("BMW", "3", "002");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("BMW", "5", "002");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("BMW", "7", "003");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("BMW", "3", "003");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Volkswagen", "Touran", "004");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Volkswagen", "Golf", "004");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Opel", "Astra", "005");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Opel", "Corsa", "005");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("BMW", "5", "006");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("BMW", "7", "006");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("BMW", "5", "007");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("BMW", "7", "007");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("BMW", "7", "008");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("BMW", "3", "008");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Volkswagen", "Golf", "009");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Volkswagen", "Passat", "009");

-- Insert service-part relations
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Odkurzanie", "009", 4);
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Odkurzanie", "002", 3);
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Odkurzanie", "000", 2);
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Wymiana oleju", "003", 3);
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Wymiana oleju", "005", 1);
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Wymiana oleju", "002", 2);
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Wymiana filtra powietrza", "008", 2);
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Wymiana filtra powietrza", "003", 5);
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Wymiana filtra powietrza", "001", 5);
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Wymiana filtra oleju", "006", 5);
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Wymiana filtra oleju", "003", 3);
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Wymiana filtra oleju", "000", 1);
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Wymiana filtra paliwa", "002", 5);
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Wymiana filtra paliwa", "009", 5);
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Wymiana filtra paliwa", "002", 1);
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Wymiana filtra kabinowego", "005", 4);
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Wymiana filtra kabinowego", "005", 4);
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Wymiana filtra kabinowego", "006", 5);
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Wymiana plynu hamulcowego", "001", 1);
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Wymiana plynu hamulcowego", "007", 2);
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Wymiana plynu hamulcowego", "003", 1);
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Wymiana plynu chlodniczego", "009", 1);
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Wymiana plynu chlodniczego", "000", 2);
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Wymiana plynu chlodniczego", "005", 4);
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Wymiana plynu klimatyzacji", "004", 5);
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Wymiana plynu klimatyzacji", "005", 2);
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Wymiana plynu klimatyzacji", "005", 4);
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Wymiana plynu do skrzyni biegow", "005", 5);
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Wymiana plynu do skrzyni biegow", "001", 1);
INSERT INTO `serviceParts` (`serviceName`, `partPartCode`, `quantity`) VALUES ("Wymiana plynu do skrzyni biegow", "000", 4);

-- Insert order entries
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (1, 1, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "PO 12345" ORDER BY RAND() LIMIT 1), "1", "2022-01-01", "Bartosz Malinowski");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (1, 2, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "PO 12345" ORDER BY RAND() LIMIT 1), "1", "2022-01-01", "Bartosz Malinowski");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (2, 1, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "O0 OOO00" ORDER BY RAND() LIMIT 1), "1", "2022-02-01", "Leszek Bialy");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (2, 2, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "O0 OOO00" ORDER BY RAND() LIMIT 1), "1", "2022-02-01", "Piotr Zimny");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (3, 1, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "HPU 12C5" ORDER BY RAND() LIMIT 1), "1", "2022-08-24", "Marian Pazdzioch");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (3, 2, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "HPU 12C5" ORDER BY RAND() LIMIT 1), "1", "2022-08-24", "Stefan Karwowski");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (4, 1, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "WF 12XU8" ORDER BY RAND() LIMIT 1), "1", "2022-10-13", "Stefan Karwowski");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (4, 2, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "WF 12XU8" ORDER BY RAND() LIMIT 1), "1", "2022-10-13", "Bartosz Malinowski");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (4, 3, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "WF 12XU8" ORDER BY RAND() LIMIT 1), "1", "2022-10-13", "Bartosz Malinowski");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (4, 4, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "WF 12XU8" ORDER BY RAND() LIMIT 1), "1", "2022-10-13", "Stefan Karwowski");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (5, 1, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "UG 1482T" ORDER BY RAND() LIMIT 1), "1", "2022-11-06", "Stefan Karwowski");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (5, 2, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "UG 1482T" ORDER BY RAND() LIMIT 1), "1", "2022-11-06", "Leszek Bialy");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (6, 1, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "PO 12345" ORDER BY RAND() LIMIT 1), "1", "2022-12-27", "Bartosz Malinowski");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (6, 2, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "PO 12345" ORDER BY RAND() LIMIT 1), "1", "2022-12-27", "Marian Pazdzioch");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (6, 3, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "PO 12345" ORDER BY RAND() LIMIT 1), "1", "2022-12-27", "Stefan Karwowski");
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (7, 1, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "HPU 12C5" ORDER BY RAND() LIMIT 1), "0", NULL, NULL);
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (7, 2, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "HPU 12C5" ORDER BY RAND() LIMIT 1), "0", NULL, NULL);
INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES (7, 3, (SELECT `serviceName` FROM `servicesToCarModels` NATURAL JOIN `cars` WHERE `licensePlate` = "HPU 12C5" ORDER BY RAND() LIMIT 1), "1", "2023-01-15", "Marian Pazdzioch");


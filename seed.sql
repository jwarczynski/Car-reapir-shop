-- Insert customers
INSERT INTO `customers` (`customerId`, `fullName`, `phoneNumber`, `email`, `taxId`) VALUES (1, "Jan Kowalski", "17 697 78 78", "jan.kowalski@email.com", "123-456-78-90");
INSERT INTO `customers` (`customerId`, `fullName`, `phoneNumber`, `email`, `taxId`) VALUES (2, "Piotr Nowak", "600 234 789", NULL, "473-799-67-15");
INSERT INTO `customers` (`customerId`, `fullName`, `phoneNumber`, `email`, `taxId`) VALUES (3, "Anna Malinowska", "11 222 33 44", "anna.m@pocz.ta", NULL);
INSERT INTO `customers` (`customerId`, `fullName`, `phoneNumber`, `email`, `taxId`) VALUES (4, "Grzegorz Brzeczyszczykiewicz", "19 123", NULL, NULL);

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
INSERT INTO `orders` (`id`, `acceptDate`, `finishDate`, `comment`, `customerId`, `carLicensePlate`) VALUES (2, "2022-02-01", "2022-03-06", "Bêdzie du¿o pracy", 1, "O0 OOO00");
INSERT INTO `orders` (`id`, `acceptDate`, `finishDate`, `comment`, `customerId`, `carLicensePlate`) VALUES (3, "2022-08-24", "2022-08-25", "Zrobiæ na ju¿!!!", 2, "HPU 12C5");
INSERT INTO `orders` (`id`, `acceptDate`, `finishDate`, `comment`, `customerId`, `carLicensePlate`) VALUES (4, "2022-10-13", "2022-10-20", "", 3, "WF 12XU8");
INSERT INTO `orders` (`id`, `acceptDate`, `finishDate`, `comment`, `customerId`, `carLicensePlate`) VALUES (5, "2022-11-06", "2022-11-30", "Zamówi³ pedant - przy³o¿yæ siê!", 4, "UG 1482T");
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

-- Insert car-part relations
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Volkswagen", "Golf", "000");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Volkswagen", "Passat", "000");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Volkswagen", "Touran", "001");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Volkswagen", "Golf", "001");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Ford", "Focus", "002");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Ford", "Fiesta", "002");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Opel", "Corsa", "003");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Opel", "Insignia", "003");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Volkswagen", "Passat", "004");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Volkswagen", "Touran", "004");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Ford", "Fiesta", "005");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Ford", "Mondeo", "005");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Volkswagen", "Touran", "006");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Volkswagen", "Golf", "006");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Ford", "Focus", "007");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Ford", "Fiesta", "007");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Volkswagen", "Touran", "008");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Volkswagen", "Golf", "008");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Opel", "Insignia", "009");
INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES ("Opel", "Astra", "009");


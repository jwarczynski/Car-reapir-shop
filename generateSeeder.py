from random import randint

f = open('seed.sql', 'w')

customers = [
    (1, 'Jan Kowalski', '17 697 78 78', '"jan.kowalski@email.com"', '"123-456-78-90"'),
    (2, 'Piotr Nowak', '600 234 789', 'NULL', '"473-799-67-15"'),
    (3, 'Anna Malinowska', '11 222 33 44', '"anna.m@pocz.ta"', 'NULL'),
    (4, 'Grzegorz Brzeczyszczykiewicz', '19 123', 'NULL', 'NULL')
]
f.write('-- Insert customers\n')
for c in customers:
    f.write(f'INSERT INTO `customers` (`customerId`, `fullName`, `phoneNumber`, `email`, `taxId`) VALUES' +
        f' ({c[0]}, "{c[1]}", "{c[2]}", {c[3]}, {c[4]});\n')
f.write('\n')

manufacturers = [ 'Volkswagen', 'Ford', 'Opel', 'BMW' ]
f.write('-- Insert manufacturers\n')
for m in manufacturers:
    f.write(f'INSERT INTO `carManufacturers` (`manufacturerName`) VALUES ("{m}");\n')
f.write('\n')

models = [
    ['Passat', 'Touran', 'Golf'],
    ['Focus', 'Fiesta', 'Mondeo'],
    ['Astra', 'Corsa', 'Insignia'],
    ['3', '5', '7']
]
f.write('-- Insert models\n')
for manufacturer, modelList in zip(manufacturers, models):
    for model in modelList:
        f.write(f'INSERT INTO `carModels` (`manufacturerName`, `modelName`) VALUES ("{manufacturer}", "{model}");\n')
f.write('\n')

cars = [ 'PO 12345', 'O0 OOO00', 'WF 12XU8', 'HPU 12C5', 'UG 1482T' ]
f.write('-- Insert cars\n')
i = 0
for c in cars:
    f.write(f'INSERT INTO `cars` (`licensePlate`, `manufacturerName`, `modelName`) VALUES' +
        f' ("{c}", "{manufacturers[i % len(manufacturers)]}", "{models[i % len(models)][0]}");\n')
f.write('\n')

orders = [
    (1, '"2022-01-01"', '"2022-01-06"', "", 1, cars[0]),
    (2, '"2022-02-01"', '"2022-03-06"', "Będzie dużo pracy", 1, cars[1]),
    (3, '"2022-08-24"', '"2022-08-25"', "Zrobić na już!!!", 2, cars[3]),
    (4, '"2022-10-13"', '"2022-10-20"', "", 3, cars[2]),
    (5, '"2022-11-06"', '"2022-11-30"', "Zamówił pedant - przyłożyć się!", 4, cars[4]),
    (6, '"2022-12-27"', '"2023-01-02"', "", 1, cars[0]),
    (7, '"2023-01-15"', 'NULL', "", 2, cars[3]),
]
f.write('-- Insert orders\n')
for o in orders:
    f.write(f'INSERT INTO `orders` (`id`, `acceptDate`, `finishDate`, `comment`, `customerId`, `carLicensePlate`) VALUES' +
        f' ({o[0]}, {o[1]}, {o[2]}, "{o[3]}", {o[4]}, "{o[5]}");\n')
f.write('\n')

f.write('-- Insert shopping lists\n')
for i in range(3):
    f.write(f'INSERT INTO `shoppingLists` (`name`, `isFulfilled`, `priority`) VALUES' + 
        f' ("List {i}", {i == 0}, 0);\n')
f.write('\n')

f.write('-- Insert parts\n')
for i in range(10):
    f.write(f'INSERT INTO `parts` (`partCode`, `name`, `cost`, `currentlyInStock`, `maxInStock`) VALUES' + 
        f' ("{i:0>3}", "Part {i}", {i}, {10+i}, {10*i+15});\n')
f.write('\n')

f.write('-- Add part to shopping lists\n');
for i in range(3):
    f.write(f'INSERT INTO `shoppingListsParts` (`quantity`, `partCode`, `listName`) VALUES ' + 
        f' ({i*10+5}, "{i:0>3}", "List {i}");\n')
f.write('\n');


f.write('-- Insert car-part relations\n')
for i in range(10):
    manIdx = randint(0, len(manufacturers) - 1)
    modelIdx = randint(0, len(models[manIdx]) - 1)
    f.write(f'INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES' +
        f' ("{manufacturers[manIdx]}", "{models[manIdx][modelIdx]}", "{i:0>3}");\n')
    modelIdx = (modelIdx + 1) % len(models[manIdx])
    f.write(f'INSERT INTO `partsToCarModels` (`manufacturerName`, `modelName`, `partCode`) VALUES' +
        f' ("{manufacturers[manIdx]}", "{models[manIdx][modelIdx]}", "{i:0>3}");\n')
f.write('\n')

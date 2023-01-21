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

roles = [
    ('Stazysta', 1500, 2500),
    ('Mechanik', 2000, 4000),
    ('Kierownik', 3500, 5000)
]
f.write('-- Insert employee roles\n')
for r in roles:
    f.write(f'INSERT INTO `employeeRoles` (`roleName`, `minimumWage`, `maximumWage`) VALUES' +
        f' ("{r[0]}", {r[1]}, {r[2]});\n')
f.write('\n')

employees = [
    ('Bartosz Malinowski', 1700, roles[0][0]),
    ('Stefan Karwowski', 2000, roles[0][0]),
    ('Piotr Zimny', 2500, roles[0][0]),
    ('Leszek Bialy', 2200, roles[1][0]),
    ('Zdzislaw Stefanowski', 3800, roles[1][0]),
    ('Marian Pazdzioch', 4900, roles[2][0])
]
f.write('-- Insert employees\n')
for e in employees:
    f.write(f'INSERT INTO `employees` (`fullName`, `wage`, `roleName`) VALUES' +
        f' ("{e[0]}", {e[1]}, "{e[2]}");\n')
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
    (2, '"2022-02-01"', '"2022-03-06"', "Bedzie duzo pracy", 1, cars[1]),
    (3, '"2022-08-24"', '"2022-08-25"', "Zrobic na juz!!!", 2, cars[3]),
    (4, '"2022-10-13"', '"2022-10-20"', "", 3, cars[2]),
    (5, '"2022-11-06"', '"2022-11-30"', "Zamowil pedant - przylozyc sie!", 4, cars[4]),
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
f.write('\n')

services = [
    ('Odkurzanie', 10),
    ('Wymiana oleju', 20),
    ('Wymiana filtra powietrza', 30),
    ('Wymiana filtra oleju', 40),
    ('Wymiana filtra paliwa', 50),
    ('Wymiana filtra kabinowego', 60),
    ('Wymiana plynu hamulcowego', 70),
    ('Wymiana plynu chlodniczego', 80),
    ('Wymiana plynu klimatyzacji', 90),
    ('Wymiana plynu do skrzyni biegow', 100),
]
f.write('-- Insert services\n')
for s in services:
    f.write(f'INSERT INTO `services` (`name`, `standardCost`) VALUES ("{s[0]}", {s[1]});\n')
f.write('\n')

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

f.write('-- Insert order entries\n')
for o in orders:
    for i in range(randint(2, 4)):
        serviceName = services[randint(0, len(services) - 1)][0]
        isDone = '1' if o[2] != 'NULL' else str(0 if i == 0 else randint(0, 1))
        date = o[1] if isDone == '1' else 'NULL'
        employee = 'NULL' if isDone == '0' else f'"{employees[randint(0, len(employees) - 1)][0]}"'

        f.write(f'INSERT INTO `orderEntries` (`orderId`, `position`, `serviceName`, `isDone`, `date`, `employeeName`) VALUES' +
            f' ({o[0]}, {i+1}, "{serviceName}", "{isDone}", {date}, {employee});\n')
f.write('\n')

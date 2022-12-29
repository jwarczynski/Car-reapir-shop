from random import randint

f = open('seed.sql', 'w')

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

def main():
    f = open('input.txt', 'r')
    calories = []
    totalCals = 0
    maxCalsIndex = 0
    
    for line in f:
        if(f != ''):
            totalCals += int(f)
        else:
            calories.append(totalCals)
            
    print(calories.max)
    print(calories.index(calories.max))
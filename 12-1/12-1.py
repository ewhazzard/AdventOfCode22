def main():
    f = open('/Users/evanhazzard/Desktop/AdventOfCode22/12-1/input.txt', 'r')
    calories = []
    top3 = []
    totalCals = 0
    maxCalsIndex = 0
    
    for line in f:
        if(line != '\n'):
            totalCals += int(line)
        else:
            calories.append(totalCals)
            totalCals = 0
    totalCals = 0
    for i in range(0,3):
        top3.append(max(calories))
        totalCals += max(calories)
        calories.remove(max(calories))
        
    print(totalCals)
    
main()
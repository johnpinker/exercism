def convert(number):
    retVal = ""
    if (number % 3 == 0):
        retVal += "Pling"
    if (number % 5 == 0):
        retVal += "Plang"
    if (number % 7 == 0):
        retVal += "Plong"
    if (number % 3 != 0 and number % 5 != 0 and number % 7 != 0):
        retVal = str(number)
    return retVal

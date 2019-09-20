def recite(start_verse, end_verse):
    retVal = []
    for verse in range(start_verse, end_verse+1):
        retVal += ["On the " + getDay(verse) + " day of Christmas my true love gave to me: " + reciteLine(verse)]
    return retVal

def reciteLine(verse):
    if (verse == 1):
        return "a Partridge in a Pear Tree."
    if (verse == 2):
        return "two Turtle Doves, and " + reciteLine(verse-1)
    if (verse == 3):
        return "three French Hens, " + reciteLine(verse-1)
    if (verse == 4):
        return "four Calling Birds, " + reciteLine(verse-1)
    if (verse == 5):
        return "five Gold Rings, " + reciteLine(verse-1)
    if (verse == 6):
        return "six Geese-a-Laying, " + reciteLine(verse-1)
    if (verse == 7):
        return  "seven Swans-a-Swimming, " + reciteLine(verse-1)
    if (verse == 8):
        return "eight Maids-a-Milking, " + reciteLine(verse-1)
    if (verse == 9):
        return  "nine Ladies Dancing, " + reciteLine(verse-1)
    if (verse == 10):
        return "ten Lords-a-Leaping, " + reciteLine(verse-1)
    if (verse == 11):
        return "eleven Pipers Piping, " + reciteLine(verse-1)
    if (verse == 12):
        return "twelve Drummers Drumming, " + reciteLine(verse-1)

def getDay(verse):
    if (verse == 1): 
        return "first"
    elif (verse == 2):
        return "second"
    elif (verse == 3):
        return "third"
    elif (verse == 4):
        return "fourth"
    elif (verse == 5):
        return "fifth"
    elif (verse == 6):
        return "sixth"
    elif (verse == 7):
        return "seventh"
    elif (verse == 8):
        return "eighth"
    elif (verse == 9):
        return "ninth"
    elif (verse == 10):
        return "tenth"
    elif (verse == 11):
        return "eleventh"
    elif (verse == 12):
        return "twelfth"
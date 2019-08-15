class TwelveDays {
    String verse(int verseNumber) {

        return "On the " + getNameFromNumber(verseNumber)+ " day of Christmas my true love gave to me: " + getVerse(verseNumber) + ".\n";
    }

    private String getVerse(int verseNumber) {
        switch (verseNumber) {
            case 1:
                return "a Partridge in a Pear Tree";
            case 2:
                return "two Turtle Doves, and " + getVerse(verseNumber - 1) ;
            case 3:
                return "three French Hens, " + getVerse(verseNumber-1);
            case 4:
                return "four Calling Birds, " + getVerse(verseNumber-1);
            case 5:
                return "five Gold Rings, " + getVerse(verseNumber-1);
            case 6:
                return "six Geese-a-Laying, " + getVerse(verseNumber-1);
            case 7:
                return "seven Swans-a-Swimming, " + getVerse(verseNumber-1);
            case 8:
                return "eight Maids-a-Milking, " + getVerse(verseNumber-1);
            case 9:
                return "nine Ladies Dancing, " + getVerse(verseNumber-1);
            case 10:
                return "ten Lords-a-Leaping, " + getVerse(verseNumber-1);
            case 11:
                return "eleven Pipers Piping, " + getVerse(verseNumber-1);
            case 12:
                return "twelve Drummers Drumming, " + getVerse(verseNumber-1);
            default:
                return "";
        }
    }

    private String getNameFromNumber(int number) {
        switch (number) {
            case 1: return "first";
            case 2: return "second";
            case 3: return "third";
            case 4: return "fourth";
            case 5: return "fifth";
            case 6: return "sixth";
            case 7: return "seventh";
            case 8: return "eighth";
            case 9: return "ninth";
            case 10: return "tenth";
            case 11: return "eleventh";
            case 12: return "twelfth";
            default: return "";
        }
    }

    String verses(int startVerse, int endVerse) {
        StringBuilder sb = new StringBuilder();
        for (int i=startVerse; i<=endVerse; i++) {
            sb.append(verse(i));
            sb.append(i!=endVerse ? "\n" : "");
        }
        return sb.toString();
    }
    
    String sing() {
        return verses(1, 12);
    }
}

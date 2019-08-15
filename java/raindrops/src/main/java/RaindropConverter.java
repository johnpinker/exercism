class RaindropConverter {

    String convert(int number) {
        String retVal = "";
        if (number%3 == 0)
            retVal += "Pling";
        if (number%5 == 0)
            retVal += "Plang";
        if (number%7 == 0)
            retVal += "Plong";
        if (retVal == "")
            retVal = String.valueOf(number);
        return retVal;
    }

}

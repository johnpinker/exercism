class IsbnVerifier {

    boolean isValid(String stringToVerify) {
        String tmpStr = stringToVerify.replace("-", "");
        if (tmpStr.length() != 10)
            return false;
        Boolean isX = tmpStr.charAt(tmpStr.length()-1) == 'X';
        int retVal = 0;
        tmpStr = tmpStr.replace("X", "");
        for (int i=0, j=10; i < tmpStr.length(); i++, j--) {
            if (!Character.isDigit(tmpStr.charAt(i)))
                return false;
            retVal += Integer.parseInt(Character.toString(tmpStr.charAt(i))) * j;
        }
        if (isX)
            retVal += 10;
        return retVal%11 == 0;
    }

}

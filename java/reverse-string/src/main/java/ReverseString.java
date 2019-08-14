class ReverseString {

    String reverse(String inputString) {
        String retVal = "";
        for (int i=inputString.length()-1; i>=0; i--)
            retVal = retVal.concat(Character.toString(inputString.charAt(i)));
        return retVal;
    }
  
}
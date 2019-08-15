import java.util.stream.IntStream;

class LargestSeriesProductCalculator {
    int[] numArray;
    LargestSeriesProductCalculator(String inputNumber) {
        numArray = new int[inputNumber.length()];
        for (int i=0; i < inputNumber.length(); i++) {
            if (!Character.isDigit(inputNumber.charAt(i)))
                throw new IllegalArgumentException("String to search may only contain digits.");
            numArray[i] = Integer.parseInt(Character.toString(inputNumber.charAt(i)));
        }
    }

    long calculateLargestProductForSeriesLength(int numberOfDigits) {
        long retVal = 0;
        long tmpLong = 1;
        if (numberOfDigits < 0)
            throw new IllegalArgumentException("Series length must be non-negative.");
        if (numberOfDigits > numArray.length)
            throw new IllegalArgumentException("Series length must be less than or equal to the length of the string to search.");
        if (numArray.length == 0 || numberOfDigits == 0) return 1;
        for (int i=0; i <= numArray.length-numberOfDigits; i++) {
            tmpLong = numArray[i] == 0 ? 0 : 1;
            for (int j=i; j<i+numberOfDigits; j++)
                tmpLong *= numArray[j];
            if (tmpLong > retVal) retVal = tmpLong;
        }
        return retVal;
    }
}

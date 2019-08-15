import java.util.ArrayList;
import java.util.stream.*;

class NaturalNumber {

    private ArrayList<Integer> factors;
    private int numValue;
    NaturalNumber(int value) {
        if (value <= 0)
            throw new IllegalArgumentException("You must supply a natural number (positive integer)");
        numValue = value;
        factors = new ArrayList<Integer>();
        IntStream.range(1, value).forEach((s) ->{ if (value%s ==0) factors.add(s);});
    }

    public Classification getClassification() {
        int total = factors.stream().reduce(0, (a, b) -> a+b);
        Classification retValue;
        if (total == numValue)
            retValue = Classification.PERFECT;
        else if (total > numValue)
            retValue = Classification.ABUNDANT;
        else
            retValue = Classification.DEFICIENT;
        return retValue;
    }
}

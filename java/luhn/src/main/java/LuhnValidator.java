import java.util.Arrays;
import java.util.stream.*;

class LuhnValidator {

    boolean isValid(String candidate) {
        String tmpStr = candidate.replace(" ", "");
        if (tmpStr.length() <= 1)
            return false;
        Integer[] tmpArray = new Integer[tmpStr.length()];
        Integer tmpInt = 0;
        int j=1;
        for (int i = tmpStr.length() - 1; i >= 0; i--, j++) {
            if (!Character.isDigit(tmpStr.charAt(i)))
                return false;
            tmpArray[i] = Integer.parseInt(Character.toString(tmpStr.charAt(i)));
            tmpInt = tmpArray[i] * 2;
            if (j % 2 == 0 && j!=0)
                tmpArray[i] = tmpInt > 9 ? tmpInt - 9 : tmpInt;
        }
        tmpInt = Arrays.stream(tmpArray).reduce(0, Integer::sum);
        return tmpInt % 10 == 0;
    }

}

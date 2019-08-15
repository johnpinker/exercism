import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;


class Sieve {
    int[] numArray;
    Sieve(int maxPrime) {
        numArray = new int[maxPrime+1];
        numArray[0] = -1;
        numArray[1] = -1;
        for (int i=2; i<= maxPrime; i++)
            numArray[i] = i;
        for (int i=2; i<= maxPrime; i++)
            for (int j=2; j*i <= maxPrime; j++)
                numArray[j*i] = -1;

    }

    List<Integer> getPrimes() {
        if (numArray.length == 1)
            return new ArrayList<Integer>();
        return Arrays.stream(numArray).filter(j -> j != -1).boxed().collect(Collectors.toList());
    }
}

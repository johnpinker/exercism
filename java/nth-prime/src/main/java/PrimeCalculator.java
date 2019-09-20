import java.util.*;
import java.util.stream.*;


class PrimeCalculator {

    private List<Integer> sieve;

    int nth(int nth) {
        if (nth <=0) throw new IllegalArgumentException();
        sieve = Sieve(1000);
        int numPrimes = 0;
        int currPrime = 2;
        int loop = 2;
        while (numPrimes != nth) {
            if (isPrime(loop)) {
                currPrime = loop;
                numPrimes++;
            }
            loop++;
        }
        return currPrime;
    }

    private boolean isPrime(int n) {
        boolean isPrime = true;
        for (Integer i: sieve) {
            if (i >= n) return true;
            if (n%i == 0) return false;
        }
        return true;

    }


    private List<Integer> Sieve(int maxPrime) {
        int[] numArray;
        numArray = new int[maxPrime+1];
        numArray[0] = -1;
        numArray[1] = -1;
        for (int i=2; i<= maxPrime; i++)
            numArray[i] = i;
        for (int i=2; i<= maxPrime; i++)
            for (int j=2; j*i <= maxPrime; j++)
                numArray[j*i] = -1;
        return Arrays.stream(numArray).filter(j -> j != -1).boxed().collect(Collectors.toList());
    }


}

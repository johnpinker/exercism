import java.util.Arrays;
import java.util.stream.IntStream;
import java.util.stream.*;
class SumOfMultiples {

    private int _total;
    SumOfMultiples(int number, int[] set) {
        _total = IntStream.range(1, number).filter(s ->
                   Arrays.stream(set).filter(t -> (t != 0) && (s % t == 0)).count() != 0
        ).sum();
    }

    int getSum() {
        return _total;
    }

}

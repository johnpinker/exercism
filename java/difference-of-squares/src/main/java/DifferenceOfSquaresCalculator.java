import java.util.stream.*;
class DifferenceOfSquaresCalculator {

    int computeSquareOfSumTo(int input) {
        IntStream r = IntStream.rangeClosed(1, input);
        int retVal = 0;
        retVal = r.sum();
        return retVal*retVal;
    }

    int computeSumOfSquaresTo(int input) {
        IntStream r = IntStream.rangeClosed(1, input);
        int retVal = 0;
        retVal = r.map((n) -> n*n).sum();
        return retVal;
    }

    int computeDifferenceOfSquares(int input) {
        return computeSquareOfSumTo(input) - computeSumOfSquaresTo(input);
    }

}

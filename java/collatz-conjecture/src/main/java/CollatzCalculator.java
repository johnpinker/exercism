class CollatzCalculator {

    int computeStepCount(int start) {
        int tmpInt = start;
        int steps = 0;
        if (start <= 0)
            throw new IllegalArgumentException("Only natural numbers are allowed");
        while (tmpInt != 1) {
            tmpInt = tmpInt%2 == 0 ? tmpInt/2 : (tmpInt*3)+1;
            steps++;
        }
        return steps;
    }

}

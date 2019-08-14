class Darts {

    private int _score = 0;

    Darts(double x, double y) {
        double distance = Math.sqrt((x*x + y*y));
        if (distance >10)
            _score = 0;
        else if (distance <= 10 && distance > 5)
            _score = 1;
        else if (distance <= 5 && distance > 1)
            _score = 5;
        else
            _score = 10;
    }

    int score() {
        return _score;
    }

}

import java.util.Arrays;
class Yacht {

    private int _score;
    Yacht(int[] dice, YachtCategory yachtCategory) {
        switch (yachtCategory) {
            case ONES:
                _score = (int)Arrays.stream(dice).filter((s) -> s == 1).count();
                break;
            case TWOS:
                _score = (int)Arrays.stream(dice).filter((s) -> s == 2).count() * 2;
                break;
            case THREES:
                _score = (int)Arrays.stream(dice).filter((s) -> s == 3).count() * 3;
                break;
            case FOURS:
                _score = (int)Arrays.stream(dice).filter((s) -> s == 4).count() * 4;
                break;
            case FIVES:
                _score = (int)Arrays.stream(dice).filter((s) -> s == 5).count() * 5;
                break;
            case SIXES:
                _score = (int)Arrays.stream(dice).filter((s) -> s == 6).count() * 6;
                break;
            case FULL_HOUSE:
                for (Integer i: Arrays.stream(dice).distinct().toArray()) {
                    int tmpInt = (int)Arrays.stream(dice).filter((s) -> s == i).count();
                    if (tmpInt != 2 && tmpInt != 3)
                        _score = 0;
                    else
                        _score = (int)Arrays.stream(dice).sum();
                }
                break;
            case FOUR_OF_A_KIND:
                for (Integer i: Arrays.stream(dice).distinct().toArray()) {
                    if ((int)Arrays.stream(dice).filter((s) -> s == i).count() >= 4)
                        _score = (int)Arrays.stream(dice).filter((s) -> s == i).limit(4).sum();
                }
                break;
            case LITTLE_STRAIGHT:
                if ((int)Arrays.stream(dice).distinct().count() == 5 &&
                        (Arrays.stream(dice).min().getAsInt() == 1) &&
                        (Arrays.stream(dice).max().getAsInt() == 5))
                    _score = 30;
                break;
            case BIG_STRAIGHT:
                if ((int)Arrays.stream(dice).distinct().count() == 5 &&
                        (Arrays.stream(dice).min().getAsInt() == 2) &&
                        (Arrays.stream(dice).max().getAsInt() == 6))
                    _score = 30;
                break;
            case CHOICE:
                _score = (int)Arrays.stream(dice).sum();
                break;
            case YACHT:
                if ((int)Arrays.stream(dice).distinct().count() == 1)
                    _score = 50;
                break;
        }
    }

    int score() {
        return _score;
    }

}

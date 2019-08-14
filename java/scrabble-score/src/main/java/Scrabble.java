import java.util.stream.*;
class Scrabble {

    private String _word;
    Scrabble(String word) {
        _word=word;
    }

    int getScore() {
       return  _word.chars().map(s -> calcLetterScore(Character.toUpperCase((char)s))).sum();
    }

    private int calcLetterScore(char c) {
        String score1 = "A, E, I, O, U, L, N, R, S, T";
        String score2 = "D, G";
        String score3 = "B, C, M, P ";
        String score4 = "F, H, V, W, Y ";
        String score5 = "K";
        String score8 = "J, X";
        String score10 = "Q, Z";

        if (score1.indexOf(c) != -1)
            return 1;
        else if (score2.indexOf(c) != -1)
            return 2;
        else if (score3.indexOf(c) != -1)
            return 3;
        else if (score4.indexOf(c) != -1)
            return 4;
        else if (score5.indexOf(c) != -1)
            return 5;
        else if (score8.indexOf(c) != -1)
            return 8;
        else if (score10.indexOf(c) != -1)
            return 10;
        else
            return 0;
    }

}

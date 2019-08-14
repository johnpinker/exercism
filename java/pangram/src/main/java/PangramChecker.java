import java.util.stream.*;

public class PangramChecker {

    public boolean isPangram(String input) {
        return input.chars().filter((x) ->  Character.isAlphabetic(x))
                .map((s) -> Character.toLowerCase(s))
                .distinct().count() == 26 ? true : false;
    }

}

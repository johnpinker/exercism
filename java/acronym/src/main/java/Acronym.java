import java.util.logging.ConsoleHandler;

class Acronym {

    String acronym = "";
    Acronym(String phrase) {
        String[] sList = phrase.split("[_ -]");
        for (String s: sList)
            if (!s.isBlank() && !s.isEmpty())
                acronym += Character.toUpperCase(s.charAt(0));

    }

    String get() {
        return acronym;
    }

}

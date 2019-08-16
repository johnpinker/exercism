import java.util.stream.*;
class RotationalCipher {

    private int shiftKey;
    RotationalCipher(int shiftKey) {
        this.shiftKey = shiftKey;
    }

    String rotate(String data) {
        return data.chars().map(c -> {
            if (!Character.isAlphabetic(c)) return c;
            int tmpChar = Character.isLowerCase(c) ? c-'a' : c-'A';
            tmpChar = (tmpChar+shiftKey)%26;
            tmpChar = Character.isLowerCase(c) ? tmpChar + 'a' : tmpChar + 'A';
            return (char)tmpChar;
        }).collect(StringBuilder::new,
                StringBuilder::appendCodePoint,
                StringBuilder::append)
                .toString();
    }
}

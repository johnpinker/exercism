import java.util.stream.*;

class RnaTranscription {

    String transcribe(String dnaStrand) {
        StringBuilder sb = new StringBuilder();
        dnaStrand.chars().map(s -> (char)xForm((char)s)).forEach(y -> sb.append((char)y));
        return sb.toString();
    }

    char xForm(char c)
    {
        switch (c) {
            case 'C': return 'G';
            case 'G': return 'C';
            case 'T': return 'A';
            case 'A': return 'U';
            default: return '0';
        }
    }
}

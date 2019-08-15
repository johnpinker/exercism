class Proverb {

    String[] _words;

    Proverb(String[] words) {
        _words = words;
    }

    String recite() {
        StringBuilder sb = new StringBuilder();
        int level = _words.length-1;
        if (_words.length <1)
            return "";
        for (int i=0; i < level; i++)
            sb.append(reciteOne(i));
        sb.append(String.format("And all for the want of a %s.",  _words[0]));
        return sb.toString();
    }

    private String reciteOne(int level) {
        return String.format("For want of a %s the %s was lost.\n", _words[level], _words[level+1]);
    }

}

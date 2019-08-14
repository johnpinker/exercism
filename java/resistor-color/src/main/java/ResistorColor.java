class ResistorColor {

    enum ColorList {
        black(0),
        brown(1),
        red(2),
        orange (3),
        yellow (4),
        green (5),
        blue(6),
        violet (7),
        grey (8),
        white (9);

        final int resistorCode;
        ColorList(int resistorCode) {
            this.resistorCode = resistorCode;
        }
    }
    int colorCode(String color) {
        return ColorList.valueOf(color).resistorCode;
    }

    String[] colors() {
        String[] colorArray = new String[ColorList.values().length];
        for (ColorList color : ColorList.values()) {
            colorArray[ColorList.valueOf(color.name()).resistorCode] = color.name();
        }
        return colorArray;
    }
}

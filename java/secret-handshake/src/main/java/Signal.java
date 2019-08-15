enum Signal {

    WINK(1),
    DOUBLE_BLINK(2),
    CLOSE_YOUR_EYES(4),
    JUMP(8)
    ;

    private int signalValue;
    Signal(int value) {
        signalValue = value;
    }

    int GetSignalValue() {
        return signalValue;
    }
}

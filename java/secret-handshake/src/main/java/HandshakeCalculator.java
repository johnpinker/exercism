import java.util.*;
import java.util.stream.IntStream;
import java.util.stream.*;

class HandshakeCalculator {

    List<Signal> calculateHandshake(int number) {
        ArrayList<Signal> retVal = new ArrayList<Signal>();
        if ((Signal.WINK.GetSignalValue() & number) == Signal.WINK.GetSignalValue())
            retVal.add(Signal.WINK);
        if ((Signal.DOUBLE_BLINK.GetSignalValue() & number) == Signal.DOUBLE_BLINK.GetSignalValue())
            retVal.add(Signal.DOUBLE_BLINK);
        if ((Signal.CLOSE_YOUR_EYES.GetSignalValue() & number) == Signal.CLOSE_YOUR_EYES.GetSignalValue())
            retVal.add(Signal.CLOSE_YOUR_EYES);
        if ((Signal.JUMP.GetSignalValue() & number) == Signal.JUMP.GetSignalValue())
            retVal.add(Signal.JUMP);
        if ((16 & number) == 16) {
            Collections.reverse(retVal);
        }
        return retVal;
    }

}

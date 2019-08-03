
    var t;
    var tmpDigit = 0x80;
    t = tmpDigit & 0x7F;
    tmpDigit = tmpDigit >> 7;
    console.log(t + ":" + tmpDigit);

    while (tmpDigit != 0) {
    	t = tmpDigit & 0x7F;
    	console.log(t);
    	tmpDigit = tmpDigit<< 7;
    	
    }
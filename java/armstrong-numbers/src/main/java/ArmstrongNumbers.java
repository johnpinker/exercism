class ArmstrongNumbers {

	boolean isArmstrongNumber(int numberToCheck) {

		String s = Integer.toString(numberToCheck);
		int tmpNum = 0;
		for (int i=0; i< s.length(); i++) {
			tmpNum += (int)Math.pow((s.charAt(i))-'0', s.length());
		}
		return (tmpNum == numberToCheck);
	}

}

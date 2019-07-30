
export default class Pangram {

	private nums:number[] = new Array(26);
	private testStr: string;

	constructor(pgram: string) {
	  this.testStr = pgram.toUpperCase();	  
	  for (var i=0; i< this.nums.length; i++) {
	    this.nums[i] = 0;
	  }
	}


	checkChar(testSt: string, index: number) {
	  let i: number;
	  i = this.charAsInt(testSt, index);
	  return this.nums[i]++;
	}

	charAsInt(testSt: string, ind: number) {
	  return testSt.charCodeAt(ind) - "A".charCodeAt(0);
	}

	public isPangram() {
	  var i: number;
	  for (i =0; i< this.testStr.length; i++) {
	    this.checkChar(this.testStr, i)
	  }

	  for (i=0; i < this.nums.length; i++) {
	    if (this.nums[i] == 0) {
	      return false;
	    }
	  }
	  return true;
	}	
}

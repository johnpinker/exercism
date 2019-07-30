class RobotName {
	public name:string = "XX111";
	private prevNames:Set<string> = new Set<string>();

	constructor() {
		this.generateName();
		//this.prevNames = new Set();
		this.prevNames.add(this.name);
	}

	public resetName() {
		this.generateName();
		while (this.prevNames.has(this.name)) {
			this.generateName();
		}
		this.prevNames.add(this.name);
	}

	private getRandomInt(max: number) {
  		return Math.floor(Math.random() * Math.floor(max));
	}

	private generateName() {
		var tmpStr:string[] = new Array(5);
		for (let i=0; i<2; i++) {
			tmpStr[i] = String.fromCharCode(this.getRandomInt(25) + 'A'.charCodeAt(0));
		}
		for (let j=2; j<5; j++) {
			tmpStr[j] = this.getRandomInt(9).toString();
		}
		this.name = tmpStr.join('');
	}
}

export default RobotName;
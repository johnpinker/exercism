class SpaceAge {

	seconds: number;
	earthConst: number = 31557600;

	constructor(seconds: number) {
	  this.seconds = seconds;
	  ;
	}

	toTwoDigit(num: number) {
	  return parseFloat(num.toFixed(2));
	}

	onMercury() {
	  return this.toTwoDigit(this.seconds/(this.earthConst*0.2408467));
	}

	onEarth() {
	  return this.toTwoDigit(this.seconds/31557600);;
	}

	onVenus() {
	  return this.toTwoDigit(this.seconds/(this.earthConst*0.61519726));
	}

	onMars() {
	  return this.toTwoDigit(this.seconds/(this.earthConst*1.8808158));
	}

	onJupiter() {
	  return this.toTwoDigit(this.seconds/(this.earthConst*11.862615));
	}

	onSaturn() {
	  return this.toTwoDigit(this.seconds/(this.earthConst*29.447498));
	}

	onUranus() {
	  return this.toTwoDigit(this.seconds/(this.earthConst*84.016846));
	}

	onNeptune() {
	  return this.toTwoDigit(this.seconds/(this.earthConst*164.79132));
	}

}

export default SpaceAge;

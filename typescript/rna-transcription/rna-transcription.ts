class Transcriptor {
    toRna( ts: string ) {
        let i: number = 0;
	let j = new Array();
	while (i < ts.length) {
	  switch (ts[i]) {
	    case 'A': {
		j.push('U');
	 	break;
		}
	   case 'T': {
		j.push('A');
		break;
		}
	    case 'C': {
		j.push('G');
		break;
		}
	    case 'G': {
		j.push('C');
		break;
		}
	    default: {
		throw new Error("Invalid input DNA.");
		}
	  }
	  i++;
	}
	return j.join('');
    }
}

export default Transcriptor

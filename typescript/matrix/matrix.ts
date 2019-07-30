class Matrix {
    
	private _matrix:any [];

	get rows():any[] {
		return this._matrix;
	}

	get columns():any[] {
		let xdim = this._matrix.length;
		let ydim = this._matrix[0].length;
		let transMat:any[] = new Array(ydim);
		for (let i=0; i<xdim; i++) {
			transMat[i] = Array.from(this._matrix[i]);
		}
		//console.log(this._matrix);
		console.log(`rows: ${xdim}, columns: ${ydim}`);
		for (let i=0; i < xdim; i++) {
			//console.log(this._matrix[i]);
			for (let j=0; j< ydim; j++) {
				//console.log(`i: ${i}, j: ${j} = ${this._matrix[i][j]}`);
				transMat[j][i] = this._matrix[i][j];
			}
		}
		//console.log(transMat);
		return transMat;
	}
    constructor( textMatrix: string ) {
    	this._matrix = new Array(0);
        let tmpRows = textMatrix.split('\n');
        tmpRows.map((element) => {
        	//console.log(element);
        	this.splitRow(element);
        });
        //console.log(this._matrix);
    }

    splitRow(textRow: string) {
    	let tmpCol = textRow.split(' ');
    	let row = this._matrix.length;

    	this._matrix.push(new Array());
    	tmpCol.map((element) => { 
    		this._matrix[row].push(new Number(element));
    		//console.log(`pushing element: ${element}`);
    	});
    	//console.log(this._matrix[row]);
    	//console.log(`Row: ${row}`);
    }


}

export default Matrix

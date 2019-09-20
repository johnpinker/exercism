//
// This is only a SKELETON file for the 'Matrix' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

export class Matrix {
  
  constructor(rowString) {
    let rawRows = rowString.split('\n');
    let tmpRows = [];
    rawRows.forEach(element => {
      let tmpCol = [];
      let tmpCols = element.split(' ');
      tmpCols.forEach(c => tmpCol.push(Number(c)));
      tmpRows.push(tmpCol);
    });
    this.matrix = tmpRows;
  }

  get rows() {
    return this.matrix;
  }

  get columns() {
    let shiftedMatrix = [];
    for (let i=0; i < this.matrix[0].length; i++) {
      let tmpRow = [];
      for (let j=0; j < this.matrix.length; j++) {
        tmpRow.push(this.matrix[j][i]);
      }
      shiftedMatrix.push(tmpRow);
    }
    return shiftedMatrix;
  }
}

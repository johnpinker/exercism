
class Matrix {

    private int[][] matrix;
    Matrix(String matrixAsString) {
        String[] rowStrings = matrixAsString.split("\n");
        String[] colStrings = rowStrings[rowStrings.length-1].split(" ");
        matrix = new int[rowStrings.length][colStrings.length];
        for (int i=0; i<rowStrings.length; i++) {
            colStrings = rowStrings[i].split(" ");
            for (int j=0; j < colStrings.length; j++)
                matrix[i][j] = Integer.parseInt(colStrings[j]);
        }
    }

    int[] getRow(int rowNumber) {
        return matrix[rowNumber-1];
    }

    int[] getColumn(int columnNumber) {
        int[] tmpArray = new int[matrix.length];
        for (int i=0; i<tmpArray.length; i++)
            tmpArray[i] = matrix[i][columnNumber-1];
        return tmpArray;
    }
}

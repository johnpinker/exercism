

var i = 0;
var j =0;
var size =4;
var num = 1;

var matrix = new Array(size);               // 10 rows of the table
for(var i = 0; i < matrix.length; i++)
    matrix[i] = new Array(size);    


var start = 0;
var end = size-1;

i=start;
j=start;
while (start <= end)
{
	if (start == end)
		matrix[start][end] = num;
	console.log(start + ":" + end + "\n");
	for (j =start; j<end; j++)
	{
		//console.log(i + ":" + j);
		matrix[i][j] = num;
		num++;
	}
	for (i=start; i<end; i++)
	{
		matrix[i][j] = num;
		num++;
	}
	for (1; j >start; j--)
	{
		//console.log(i + ":" + j);
		matrix[i][j] = num;
		num++;
	}
	for (1; i>start; i--)
	{
		matrix[i][j] = num;
		num++;
	}
	console.log(matrix);
	start++;
	end--;
	i=start;j=start;
}


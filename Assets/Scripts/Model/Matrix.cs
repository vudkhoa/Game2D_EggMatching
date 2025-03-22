public class Matrix
{
    public int[,] matrix;

    public Matrix(int rows, int cols)
    {
        this.matrix = new int[rows, cols];
    }

    public void SetMatrix(int[,] newMatrix)
    {
        this.matrix = newMatrix;
    }

    public int GetValue(int row, int col)
    {
        return this.matrix[row, col];
    }

    public void SetValue(int row, int col, int value)
    {
        this.matrix[row, col] = value;
    }

    public void PrintMatrix()
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            string rowStr = "";
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                rowStr += this.matrix[i, j] + " ";
            }
            //UnityEngine.Debug.Log(rowStr);
        }
    }
}

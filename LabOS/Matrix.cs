internal class Matrix
{
    private double[,] _matrix;

    public Matrix(int n, int m)
    {
        _matrix = new double[n, m];
    }

    public Matrix(int n, int m, bool fillRandom)
    {
        _matrix = new double[n, m];
        Random rnd = new Random();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                _matrix[i, j] = rnd.Next(0, 10);
            }
        }
    }
    public int Rows
    {
        get { return _matrix.GetLength(0); }
    }
    public int Cols
    {
        get { return _matrix.GetLength(1); }
    }

    public double this[int i, int j]
    {
        get
        {
            return _matrix[i, j];
        }
        set
        {
            _matrix[i, j] = value;
        }
    }

    public static Matrix operator *(Matrix a, Matrix b)
    {
        if (a.Cols != b.Rows)
        {
            throw new ArgumentException("Матрицы несовместимы!");
        }

        Matrix result = new Matrix(a.Rows, b.Cols);

        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < b.Cols; j++)
            {
                double sum = 0;
                for (int t = 0; t < a.Cols; t++)
                {
                    sum += a[i, t] * b[t, j];
                }
                result[i, j] = sum;
            }
        }
        return result;
    }


    
    public long CalculateChecksum()
    {
        long sum = 0;
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                sum += (long)_matrix[i, j];
            }
        }
        return sum;
    }




    public override string ToString()
    {
        string rez = "";
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                rez += _matrix[i, j] + "\t";
            }
            rez += "\n";
        }
        return rez;
    }
}
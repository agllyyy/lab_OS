using System;
using System.Threading;

internal class CalculatorMatrix
{
    private readonly object _lock;
    private int _count;
    private int _last;

    public CalculatorMatrix()
    {
        _lock = new object();
        _count = 0;
        _last = -1;
    }

    public Matrix Mul(Matrix A, Matrix B, int th)
    {
        if (A.Cols != B.Rows)
        {
            throw new ArgumentException("Матрицы несовместимы!");
        }

        Matrix C = new Matrix(A.Rows, B.Cols);

        lock (_lock)
        {
            _count = 0;
            _last = -1;
        }

        Thread[] threads = new Thread[th];
        int perTh = A.Rows / th;
        int rem = A.Rows % th;
        int current = 0;

        for (int i = 0; i < th; i++)
        {
            int start = current;
            int end = start + perTh + (i == th - 1 ? rem : 0);
            current = end;

            threads[i] = new Thread(() => Multiply(A, B, C, start, end));
            threads[i].Start();
        }

        for (int i = 0; i < th; i++)
        {
            threads[i].Join();
        }

        return C;
    }


    private void Multiply
        (Matrix A, Matrix B, Matrix C, int start, int end)
    {
        for (int i = start; i < end; i++)
        {
            for (int t = 0; t < A.Cols; t++)
            {
                double valA = A[i, t];
                for (int j = 0; j < B.Cols; j++)
                {
                    C[i, j] += valA * B[t, j];
                }
            }
            Prog(A.Rows);
        }
    }

    private void Prog(int total)
    {
        lock (_lock)
        {
            _count++;
            int pct = (int)((double)_count / total * 100);
            if (pct != _last)
            {
                _last = pct;
                Console.WriteLine($"Прогресс: {pct}%");
            }
        }
    }
}
using System.Diagnostics;

internal class Program
{
    static void Main(string[] args)
    {
        int n, m, k, threadsToUse;

        if (args.Length >= 4)
        {
            n = int.Parse(args[0]);
            m = int.Parse(args[1]);
            k = int.Parse(args[2]);
            threadsToUse = int.Parse(args[3]);
            Console.WriteLine($"Параметры: n = {n}, m = {m}, k = {k}, потоки = {threadsToUse}");
        }
        else
        {
            n = Checked.NaturalReadInt("Введите кол-во строк матрицы А: ");
            m = Checked.NaturalReadInt("Введите кол-во столбцов А / строк Б: ");
            k = Checked.NaturalReadInt("Введите кол-во столбцов матрицы Б: ");
            Console.WriteLine();

            threadsToUse = Checked.NaturalReadInt("Введите кол-во потоков для вычислений: ");
            Console.WriteLine();
        }

        Matrix matrixA = new Matrix(n, m, true);
        Matrix matrixB = new Matrix(m, k, true);

        if (n <= 10 && m <= 10 && k <= 10)
        {
            Console.WriteLine("Матрица А:");
            Console.WriteLine(matrixA);
            Console.WriteLine("Матрица Б:");
            Console.WriteLine(matrixB);
        }

        Console.WriteLine();

        CalculatorMatrix calculate = new CalculatorMatrix();
        Console.WriteLine($"\nНачало параллельных вычислений в {threadsToUse} потока(ов)...");

        Stopwatch sw = Stopwatch.StartNew();
        Matrix matrixC = calculate.Mul(matrixA, matrixB, threadsToUse);
        sw.Stop();

        Console.WriteLine();

        if (n <= 10 && k <= 10)
        {
            Console.WriteLine("Результат умножения (Матрица С):");
            Console.WriteLine($"\n{matrixC}");
        }

        long checksum = matrixC.CalculateChecksum();
        Console.WriteLine($"Умножение завершено за: {sw.ElapsedMilliseconds} мс");
        Console.WriteLine($"Контрольная сумма результирующей матрицы: {checksum}");
    }
}
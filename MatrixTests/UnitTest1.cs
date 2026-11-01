using Xunit;

namespace MatrixTests
{
    public class UnitTest1
    {
        private readonly CalculatorMatrix _calc = new CalculatorMatrix();

        [Fact]
        public void Test1()
        {
            Matrix A = new Matrix(2, 3);
            A[0, 0] = 1; A[0, 1] = 2; A[0, 2] = 3;
            A[1, 0] = 4; A[1, 1] = 5; A[1, 2] = 6;

            Matrix B = new Matrix(3, 2);
            B[0, 0] = 7; B[0, 1] = 8;
            B[1, 0] = 9; B[1, 1] = 10;
            B[2, 0] = 11; B[2, 1] = 12;

            CalculatorMatrix calculator = new CalculatorMatrix();

            Matrix C = calculator.Mul(A, B, 2);

            Assert.Equal(58, C[0, 0]);
            Assert.Equal(64, C[0, 1]);
            Assert.Equal(139, C[1, 0]);
            Assert.Equal(154, C[1, 1]);
        }

        [Fact]
        public void Test2()
        {
            Matrix A = new Matrix(2, 2, true);
            Matrix B = new Matrix(2, 2); 

            CalculatorMatrix calculator = new CalculatorMatrix();

            Matrix C = calculator.Mul(A, B, 2);

            Assert.Equal(0, C[0, 0]);
            Assert.Equal(0, C[0, 1]);
            Assert.Equal(0, C[1, 0]);
            Assert.Equal(0, C[1, 1]);
        }
        [Fact] 
        public void Test3()
        {
            Matrix A = new Matrix(2, 2);
            A[0, 0] = 1; A[0, 1] = 2; 
            A[1, 0] = 4; A[1, 1] = 5;

            Matrix B = new Matrix(2, 2);
            B[0, 0] = 1; B[0, 1] = 0;
            B[1, 0] = 0; B[1, 1] = 1;

            CalculatorMatrix calculator = new CalculatorMatrix();

            Matrix C = calculator.Mul(A, B, 2);

            Assert.Equal(1, C[0, 0]);
            Assert.Equal(2, C[0, 1]);
            Assert.Equal(4, C[1, 0]);
            Assert.Equal(5, C[1, 1]);
        }

        [Fact]
        public void Test4()
        {
            Matrix A = new Matrix(2, 3);
            Matrix B = new Matrix(2, 2);

            CalculatorMatrix calculator = new CalculatorMatrix();

            bool exceptionCaught = false;
            try
            {
                calculator.Mul(A, B, 2);
            }
            catch (ArgumentException)
            {
                exceptionCaught = true; 
            }

            Assert.True(exceptionCaught);
        }

        [Fact]
        public void Tesr5()
        {
            Matrix A = new Matrix(10, 10, true);
            Matrix B = new Matrix(10, 10, true);

            CalculatorMatrix calculator = new CalculatorMatrix();

            Matrix result1 = calculator.Mul(A, B, 1);
            Matrix result3 = calculator.Mul(A, B, 3);
            Matrix result12 = calculator.Mul(A, B, 12);

           
            long checksum1 = result1.CalculateChecksum();
            long checksum3 = result3.CalculateChecksum();
            long checksum12 = result12.CalculateChecksum();

            Assert.Equal(checksum1, checksum3);
            Assert.Equal(checksum1, checksum12);
        }

        [Fact]
        public void Test6_BoundaryCases()
        {
            Matrix A = new Matrix(1, 1);
            A[0, 0] = 5;

            Matrix B = new Matrix(1, 1);
            B[0, 0] = 6;

            CalculatorMatrix calculator = new CalculatorMatrix();

            Matrix C = calculator.Mul(A, B, 2);

            Assert.Equal(30, C[0, 0]);
        }


        [Fact]
        public void Test7_ProgressReachesOneHundredPercent()
        {
            Matrix A = new Matrix(5, 5, true);
            Matrix B = new Matrix(5, 5, true);
            CalculatorMatrix calculator = new CalculatorMatrix();

            System.IO.StringWriter sw = new System.IO.StringWriter();
            Console.SetOut(sw);

            calculator.Mul(A, B, 3);

            string consoleOutput = sw.ToString();

            bool hasOneHundredPercent = consoleOutput.Contains("Прогресс: 100%");

            StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput());
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);

            Assert.True(hasOneHundredPercent);
        }

    }
}
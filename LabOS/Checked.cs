using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal static class Checked
{
    public static bool ReadBool(string prompt)
    {
        Console.Write(prompt);
        string input = Console.ReadLine();

        bool x = true;
        while (true)
        {
            if (bool.TryParse(input, out x))
            {
                return x;
            }
            else
            {
                Console.WriteLine("Ошибка ввода! Повторите ввод:");
                input = Console.ReadLine();
            }
        }
    }

    public static int ReadInt(string prompt)
    {
        Console.Write(prompt);
        string input = Console.ReadLine();

        int x = 0;
        while (true)
        {
            if (int.TryParse(input, out x))
            {
                return x;
            }
            else
            {
                Console.Write("Ошибка ввода! Повторите ввод:");
                input = Console.ReadLine();
            }
        }
    }


    public static int NaturalReadInt(string prompt)
    {
        Console.Write(prompt);
        string input = Console.ReadLine();

        int x = 0;
        while (true)
        {
            if (int.TryParse(input, out x) && x > 0)
            {
                return x;
            }
            else
            {
                Console.WriteLine("Ошибка ввода! Повторите ввод:");
                input = Console.ReadLine();
            }
        }
    }


    public static double ReadDouble(string prompt)
    {
        Console.Write(prompt);
        string input = Console.ReadLine();

        double x = 0;
        while (true)
        {
            if (double.TryParse(input, out x))
            {
                return x;
            }
            else
            {
                Console.WriteLine("Ошибка ввода! Повторите ввод:");
                input = Console.ReadLine();
            }
        }
    }

}

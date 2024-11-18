using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FunctionSolver
{
    internal class Program
    {


        static void Main(string[] args)
        {
                bool validInput = false;
                double x = 0, y = 0, n = 0;
                int choice = 0;
                while (!validInput)
                {
                    try
                    {
                        Console.Write("Введите значение x: ");
                        x = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Введите значение y: ");
                        y = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Значение интервала (n): ");
                        n = Convert.ToDouble(Console.ReadLine());
                        if (n <= 0)
                        {
                            throw new ArgumentException("Интервал должен быть больше 0");
                        }
                        validInput = true;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                        Console.WriteLine("Введите корректное число.");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                        if (n <= 0)
                        {
                            Console.WriteLine("ВВведите интервал значения которого больше нуля.");
                        }
                        else
                        {
                            Console.WriteLine("Неверное условие.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
                        break;
                    }
                }
                if (!validInput)
                    return;
                while (true)
                {
                    try
                    {
                        Console.Write("Выберите вариант решаемой функции (1, 2, или 3): ");
                        choice = Convert.ToInt32(Console.ReadLine());
                        if (choice < 1 || choice > 3)
                        {
                            throw new ArgumentException("Неверный выбор функции");
                        }
                        break;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                        Console.WriteLine("Введите корректное значение.");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Ошибка {ex.Message}");
                        Console.WriteLine("Введите корректное значение (1, 2, или 3).");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
                        break;
                    }
                }
                double[] results = new double[(int)((10 / n) + 1)];
                int index = 0;
                for (double i = x; i <= x + 10; i += n)
                {
                    try
                    {
                        double f = CalculateF(choice, i, y);
                        results[index] = f;
                        Console.WriteLine($"f({i}, {y}) = {f}");
                        index++;
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                        break;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Неожиданная: {ex.Message}");
                        break;
                    }
                }
            Console.ReadLine();
            }
        
        
        static double CalculateF(int choice, double x, double y)
        {
            switch (choice)
            {
                case 1:
                    if (x > y)
                        return (Math.Pow((Math.Pow(x, 2) - y), 3)) + (Math.Atan(Math.Pow(x, 2)));
                    else
                        throw new ArgumentException("Некорректное значение для варианта 1");
                case 2:
                    if (x < y)
                        return (Math.Pow((y - Math.Pow(x, 2)), 3)) + (Math.Atan(Math.Pow(x, 2)));
                    else
                        throw new ArgumentException("Некорректное значение для варианта 2");
                case 3:
                    if (x == y)
                        return (Math.Pow((y + Math.Pow(x, 2)), 3)) + 0.5;
                    else
                        throw new ArgumentException("Некорректное значение для варианта 3");
                default:
                    throw new ArgumentException("Некорректный выбор");
            }
        }

       
    }
}

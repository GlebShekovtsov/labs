using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReworkedFunctionSolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    double x = GetInput("x");
                    double y = GetInput("y");
                    double n = GetInput("n");

                    if (n <= 0)
                    {
                        throw new ArgumentException("Интервал должен быть больше 0");
                    }

                    int choice = GetUserChoice();

                    double[] results = CalculateResults(x, y, n, choice);
                    DisplayResults(results);

                    Console.WriteLine("\nХотите продолжить? (да/нет): ");
                    string continueInput = Console.ReadLine().ToLower();
                    if (continueInput != "да")
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }

                Console.WriteLine("\nНажмите Enter для продолжения...");
                Console.ReadLine();
            }
        }

        static double GetInput(string variableName)
        {
            bool validInput = false;
            double value = 0;

            while (!validInput)
            {
                try
                {
                    Console.Write($"Введите значение {variableName}: ");
                    value = Convert.ToDouble(Console.ReadLine());
                    validInput = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("Введите корректное число.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
                    break;
                }
            }

            return value;
        }

        static int GetUserChoice()
        {
            bool validInput = false;
            int choice = 0;

            while (!validInput)
            {
                try
                {
                    Console.Write("Выберите вариант решаемой функции (1, 2, или 3): ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    if (choice < 1 || choice > 3)
                    {
                        throw new ArgumentException("Неверный выбор функции");
                    }
                    validInput = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("Введите корректное значение.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("Введите корректное значение (1, 2, или 3).");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
                    break;
                }
            }

            return choice;
        }

        static double[] CalculateResults(double x, double y, double n, int choice)
        {
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
                    Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
                    break;
                }
            }

            return results;
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

        static void DisplayResults(double[] results)
        {
            Console.WriteLine("\nРезультаты:");
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserType
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите данные о программном продукте:");

            // Ввод данных для ПрограммныйПродукт
            Console.Write("Название продукта: ");
            string название = Console.ReadLine();
            Console.Write("Цена продукта: ");
            double цена = Convert.ToDouble(Console.ReadLine());
            Console.Write("Название компании-разработчика: ");
            string разработчикНазвание = Console.ReadLine();

            ПрограммныйПродукт продукт = new ПрограммныйПродукт(название, цена, разработчикНазвание);

            Console.WriteLine("\nВведите данные о компании-разработчике:");

            // Ввод данных для КомпанияРазработчик
            Console.Write("Название компании: ");
            string компанияНазвание = Console.ReadLine();
            Console.Write("Описание компании: ");
            string описание = Console.ReadLine();

            КомпанияРазработчик компания = new КомпанияРазработчик(компанияНазвание, описание);

            // Вывод данных на экран
            Console.WriteLine("\nДанные о продукте:");
            Console.WriteLine($"Название: {продукт.Название}");
            Console.WriteLine($"Цена: {продукт.Цена: Рублей}");
            Console.WriteLine($"Разработчик: {продукт.РазработчикНазвание}");

            Console.WriteLine("\nДанные о компании-разработчике:");
            Console.WriteLine($"Название: {компания.Название}");
            Console.WriteLine($"Описание: {компания.Описание}");

            Console.ReadKey();
        }

    }

    public class ПрограммныйПродукт
    {
        public string Название { get; set; }
        public double Цена { get; set; }
        public string РазработчикНазвание { get; set; }

        // Конструктор для инициализации объекта
        public ПрограммныйПродукт(string название, double цена, string разработчикНазвание)
        {
            Название = название;
            Цена = цена;
            РазработчикНазвание = разработчикНазвание;
        }
    }
    public class КомпанияРазработчик
    {
        public string Название { get; set; }
        public string Описание { get; set; }

        // Конструктор для инициализации объекта
        public КомпанияРазработчик(string название, string описание)
        {
            Название = название;
            Описание = описание;
        }
    }
}

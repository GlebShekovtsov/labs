using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string inputText = GetInputText(args);
        ProcessAndOutput(inputText);

        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }

    //Этот метод проверяет, передан ли аргумент командной строки и существует ли файл с этим именем.
   
    static string GetInputText(string[] args)
    {
        //Если да, он читает весь текст из файла.
        if (args.Length > 0 && File.Exists(args[0]))
        {
            return File.ReadAllText(args[0]);
        }
        //Если нет аргументов или файл не существует, программа запрашивает пользователя ввести количество строк и сами строки.
        else
        {
            int lineCount;
            Console.Write("Введите количество строк: ");
            while (!int.TryParse(Console.ReadLine(), out lineCount) || lineCount <= 0)
            {
                Console.WriteLine("Неверный ввод. Пожалуйста, введите положительное число.");
                Console.Write("Введите количество строк: ");
            }

            string inputText = "";
            for (int i = 0; i < lineCount; i++)
            {
                Console.Write($"Введите строку {i + 1}: ");
                inputText += Console.ReadLine() + Environment.NewLine;
            }
            //Возвращает текст со знаком разделителя среды
            return inputText;
        }
    }

    //Этот метод разбивает входной текст на строки и обрабатывает каждую строку с помощью метода ProcessLine
    static void ProcessAndOutput(string inputText)
    {
        string[] lines = inputText.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string line in lines)
        {
            string processedLine = ProcessLine(line);
            //Вывод строк
            Console.WriteLine(processedLine);
        }
    }

    //Метод разбивает строку на слова и обрабатывает каждое слово с помощью метода ProcessWord.
    static string ProcessLine(string line)
    {
        string[] words = line.Split(' ');
        StringBuilder result = new StringBuilder();

        foreach (string word in words)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {
                string processedWord = ProcessWord(word);
                result.Append(processedWord + " ");
            }
        }

        return result.ToString().Trim();
    }
    //В этом методе переставляются символы в слове так, чтобы сперва следовали цифры, затем гласные буквы, а затем согласные.
    static string ProcessWord(string word)
    {
        List<char> digits = new List<char>();
        List<char> vowels = new List<char>();
        List<char> consonants = new List<char>();

        foreach (char c in word)
        {
            if (char.IsDigit(c))
                digits.Add(c);
            else if ("aeiouAEIOUауоиэыяюеёАУОИЭЫЯЮЕЁ".Contains(c))
                vowels.Add(c);
            else
                consonants.Add(c);
        }

        StringBuilder result = new StringBuilder();
        result.Append(new string(digits.ToArray()));
        result.Append(new string(vowels.ToArray()));
        result.Append(new string(consonants.ToArray()));

        return result.ToString();
    }
}
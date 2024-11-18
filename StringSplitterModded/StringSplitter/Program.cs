using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Отсутствует третий аргумент");
            Console.ReadKey();
            return;
        }

        string fileName = args[0];
        int lineCount;
        if (!int.TryParse(args[1], out lineCount) || lineCount <= 0)
        {
            Console.WriteLine("Неверный ввод. Пожалуйста, введите положительное число для количества строк.");
            Console.ReadKey();
            return;
        }

        int chunkSize;
        if (!int.TryParse(args[2], out chunkSize) || chunkSize <= 0)
        {
            Console.WriteLine("Неверный ввод. Пожалуйста, введите положительное число для размера порции.");
            Console.ReadKey();
            return;
        }

        if (File.Exists(fileName))
        {
            ProcessFileWithChunks(fileName, lineCount, chunkSize);
        }
        else
        {
            ProcessInputWithChunks(lineCount, chunkSize);
        }
        Console.ReadKey();
    }

    static void ProcessFileWithChunks(string fileName, int lineCount, int chunkSize)
    {
        using (StreamReader reader = new StreamReader(fileName))
        {
            for (int i = 0; i < lineCount; i++)
            {
                string inputChunk;
                do
                {
                    inputChunk = reader.ReadLine();
                } while (inputChunk == null);

                string processedLine = ProcessChunk(inputChunk.TrimEnd());
                Console.WriteLine(processedLine);
            }
        }
    }

    static void ProcessInputWithChunks(int lineCount, int chunkSize)
    {
        List<string> lines = new List<string>();

        for (int i = 0; i < lineCount; i++)
        {
            string inputChunk;
            do
            {
                Console.Write($"Введите строку {i + 1} (размер порции: {chunkSize}): ");
                inputChunk = Console.ReadLine().Substring(0, Math.Min(Console.ReadLine().Length, chunkSize));
            } while (inputChunk == null);

            lines.Add(ProcessChunk(inputChunk.TrimEnd()));
        }

        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
    }

    static string ProcessChunk(string chunk)
    {
        List<char> digits = new List<char>();
        List<char> vowels = new List<char>();
        List<char> consonants = new List<char>();

        foreach (char c in chunk)
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
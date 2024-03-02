// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics;
Console.WriteLine("Hello, World!");


class Project
{
    static void Main(string[] args)
    {
        Console.Write("n: ");
        int n = int.Parse(Console.ReadLine());

        int[,] array = new int[n, n];

        Console.Write("\nввести вручну(1), згенерувати автоматично(2): ");
        byte action = byte.Parse(Console.ReadLine());

        switch (action)
        {
            case 1:
                ByHands(array, n);
                Operation(array);
                break;
            case 2:
                Automatic(array, n);
                Operation(array);
                break;

            default:
                Console.WriteLine("Такого варианта нет");
                break;

        }
    }

    static int[,] ByHands(int[,] array, int n)
    {
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();
        StreamWriter sw = new StreamWriter("C:\\Users\\JA JA\\OneDrive\\Изображения");

        Console.WriteLine("Ввести через пробiл");
        for (int i = 0; i < n; i++) // ввод чисел
        {
            Console.WriteLine($"Ряд {i + 1}:");
            string input = Console.ReadLine();
            string[] numbers = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < n; j++)
            {
                array[i, j] = int.Parse(numbers[j]);
                sw.Write(array[i, j] + " ");
            }
            sw.WriteLine();
        }

        sw.Close();

        StreamReader sr = new StreamReader("C:\\Users\\JA JA\\OneDrive\\Изображения\\1.txt");
        string file = sr.ReadToEnd();
        Console.WriteLine("\nМатриця з файлу: ");
        Console.WriteLine(file);
        sr.Close();
        stopwatch.Stop();
        Console.WriteLine($"Час виконання вручну: {stopwatch.ElapsedMilliseconds} мс");

        return array;
    }

    static int[,] Automatic(int[,] array, int n)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        Random rnd = new Random();

        StreamWriter sw = new StreamWriter("C:\\Users\\JA JA\\OneDrive\\Изображения\\1.txt");

        for (int i = 0; i < n; i++) // ввод чисел
        {

            for (int j = 0; j < n; j++)
            {
                array[i, j] = rnd.Next(0, 10);
                sw.Write(array[i, j] + " ");
            }

            sw.WriteLine();
        }

        sw.Close();

        StreamReader sr = new StreamReader("C:\\Users\\JA JA\\OneDrive\\Изображения\\1.txt");
        string file = sr.ReadToEnd();
        Console.WriteLine("\nМатриця з файлу: ");
        Console.WriteLine(file);
        sr.Close();

        stopwatch.Stop();
        Console.WriteLine($"Час виконання вручну: {stopwatch.ElapsedMilliseconds} мс");
        return array;
    }


    static void Operation(int[,] array)
    {
        int SumMainDig = 0;
        int SumSecondDig = 0;

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (i == j) // главная диагональ
                {
                    SumMainDig += array[i, j];
                }

                if (i + j == array.GetLength(0) - 1) // побочная диагональ
                {
                    SumSecondDig += array[i, j];
                }
            }
        }


        Console.WriteLine("\nСума головної дiагоналi: {0} ", SumMainDig);
        Console.WriteLine("Сума побiчної дiагоналi: {0} ", SumSecondDig);
        Console.WriteLine("Сума всiх дiагональних елементiв: {0}", SumMainDig + SumSecondDig);
    }
}
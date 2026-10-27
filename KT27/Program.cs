using System;
using System.Collections.Generic;

namespace KT27
{
    class Container<T>
    {
        protected List<T> items = new();

        public virtual void Add(T item)
        {
            items.Add(item);
        }

        public int Count => items.Count;
    }

    class StringContainer : Container<string>
    {
        public void PrintAllUpper()
        {
            foreach (string item in items)
            {
                Console.WriteLine(item.ToUpper());
            }
        }
    }

    class CountingContainer<T> : Container<T>
    {
        public int TotalAdded { get; private set; }

        public override void Add(T item)
        {
            base.Add(item);
            TotalAdded++;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("StringContainer");

            StringContainer strings = new StringContainer();

            Console.Write("Сколько строк добавить: ");
            int stringCount = int.Parse(Console.ReadLine()!);

            for (int i = 0; i < stringCount; i++)
            {
                Console.Write($"Введите строку {i + 1}: ");
                strings.Add(Console.ReadLine()!);
            }

            Console.WriteLine("\nСтроки в верхнем регистре:");
            strings.PrintAllUpper();

            Console.WriteLine("\nCountingContainer<int>");

            CountingContainer<int> numbers = new CountingContainer<int>();

            Console.Write("Сколько чисел добавить: ");
            int numberCount = int.Parse(Console.ReadLine()!);

            for (int i = 0; i < numberCount; i++)
            {
                Console.Write($"Введите число {i + 1}: ");
                int number = int.Parse(Console.ReadLine()!);
                numbers.Add(number);
            }

            Console.WriteLine($"Count = {numbers.Count}");
            Console.WriteLine($"TotalAdded = {numbers.TotalAdded}");

            Console.WriteLine("\nCountingContainer<string>");

            CountingContainer<string> words = new CountingContainer<string>();

            Console.Write("Сколько слов добавить: ");
            int wordCount = int.Parse(Console.ReadLine()!);

            for (int i = 0; i < wordCount; i++)
            {
                Console.Write($"Введите слово {i + 1}: ");
                words.Add(Console.ReadLine()!);
            }

            Console.WriteLine($"Count = {words.Count}");
            Console.WriteLine($"TotalAdded = {words.TotalAdded}");
        }
    }
}
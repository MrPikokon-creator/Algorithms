using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApp
{
    public static class Program
    {
        private static HashSet<int> _listsLengths = new HashSet<int> {10_000_000, 20_000_000, 50_000_000, 100_000_000};
        private static Stopwatch _stopwatch = new Stopwatch(); // Секундомер
        private static double _workTime;

        public static void Main()
        {
            int[] numbersArray;

            Generator generator = new Generator(1_000_000);
            generator.Best(); // Холостой прогон
            
            foreach (int length in _listsLengths)
            {
                generator = new Generator(length);

                numbersArray = generator.Best(); // Лучший случай
                Stopwatch(numbersArray);
                Console.WriteLine($"Лучший случай - элементов: {length}, время: {_workTime}");

                numbersArray = generator.Average(); // Средний случай
                Stopwatch(numbersArray);
                Console.WriteLine($"Средний случай - элементов: {length}, время: {_workTime}");

                numbersArray = generator.Worst(); // Худший случай
                Stopwatch(numbersArray);
                Console.WriteLine($"Худший случай - элементов: {length}, время: {_workTime}\n");
            }
        }

        // Поиск нулевых значений в массиве
        private static void FindingNullsInArray(int[] numbersArray)
        {
            for (int i = 0; i < numbersArray.Length; i++)
            {
                if (numbersArray[i] == 0)
                {
                    return;
                }
            }
        }

        // Секундомер
        private static void Stopwatch(int[] numbersArray)
        {
            _workTime = 0; // Секундомер
            _stopwatch.Reset();
            _stopwatch.Start();
            FindingNullsInArray(numbersArray);
            _stopwatch.Stop();
            _workTime = _workTime + _stopwatch.ElapsedMilliseconds;
        }
    }
}

using System;
using System.Diagnostics;

namespace Sorting
{
    internal static class Program
    {
        private static readonly int[] lengthsArray = { 100, 1_000, 2_500, 5_000, 10_000 }; // Длины генерируемых массивов
        private static readonly Random random = new Random();
        private delegate int[] SortMethod(int[] array);

        public static void Main()
        {
            foreach (var length in lengthsArray)
            {
                int[] array = new int[length];
                
                for (var i = 0; i < length; i++) // Заполнение массива
                    array[i] = random.Next(1, length); // Случайное число от 1 до количества элементов массива

                Console.WriteLine($"- - - {length} ЭЛЕМЕНТОВ - - -");
                
                double ticks = CustomStopwatch(array, Sorter.Bubble);
                Console.WriteLine("{0,-16}{1,-8}", "Пузырьковая: ", ticks);
                
                ticks = CustomStopwatch(array, Sorter.Shaker);
                Console.WriteLine("{0,-16}{1,-8}", "Шейкерная: ", ticks);
                
                ticks = CustomStopwatch(array, Sorter.EvenOdd);
                Console.WriteLine("{0,-16}{1,-8}", "Чёт/нечет: ", ticks);
                
                ticks = CustomStopwatch(array, Sorter.Comb);
                Console.WriteLine("{0,-16}{1,-8}", "Расчёской: ", ticks);
                
                ticks = CustomStopwatch(array, Sorter.Choice);
                Console.WriteLine("{0,-16}{1,-8}", "Выбором: ", ticks);
                
                ticks = CustomStopwatch(array, Sorter.Inserts);
                Console.WriteLine("{0,-16}{1,-8}", "Вставками: ", ticks);
                
                ticks = CustomStopwatch(array, Sorter.Shell);
                Console.WriteLine("{0,-16}{1,-8}", "Шелла: ", ticks);
                
                ticks = CustomStopwatch(array, Sorter.Dwarf);
                Console.WriteLine("{0,-16}{1,-8}", "Гномья: ", ticks);
                
                Console.WriteLine();
            }
        }
        
        // Выполнение метода и вычисление затраченного времени в тиках
        private static double CustomStopwatch(int[] array, SortMethod sortMethod)
        {
            Stopwatch stopwatch = new Stopwatch();
            
            stopwatch.Start();
            sortMethod(array); // Сортировка
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }
    }
}
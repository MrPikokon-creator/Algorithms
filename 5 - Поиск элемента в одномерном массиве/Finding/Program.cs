using System;
using System.Diagnostics;

namespace Finding
{
    public static class Program
    {
        private static readonly int[] _arraysLengths = {1_000_000, 2_000_000, 3_000_000, 4_000_000, 5_000_000}; // Количество генерируемых элементов

        public static void Main()
        {
            foreach (int length in _arraysLengths)
            {
                int numberToFind = length / 2; // Число для поиска
                int[] array; // Неупорядоченный массив
                
                Console.WriteLine($"СРЕДНИЙ СЛУЧАЙ - {length} элементов, ищем {numberToFind}");
                array = Generator.Average(length);
                Find(array, numberToFind);

                Console.WriteLine($"ХУДШИЙ СЛУЧАЙ - {length} элементов, ищем {numberToFind}");
                array = Generator.Worst(length, numberToFind);
                Find(array, numberToFind);

                Console.WriteLine();
            }

            Console.ReadKey();
        }
        
        // Запуск всех поисков
        private static void Find(int[] array, int numberToFind)
        {
            int numberIndex; // Индекс найденного элемента
            double workTime; // Время работы

            // Линейный
            workTime = CustomStopwatch(Finder.Linear, array, numberToFind, out numberIndex);
            Console.WriteLine($"Линейный\tИндекс:\t{numberIndex}\t\tВремя:\t{workTime}");
                
            // Линейный с барьером
            int[] arrayWithBarrier = Generator.LinearWithBarrier(array, numberToFind);
            workTime = CustomStopwatch(Finder.LinearWithBarrier, arrayWithBarrier, numberToFind, out numberIndex);
            Console.WriteLine($"C барьером\tИндекс:\t{numberIndex}\t\tВремя:\t{workTime}");

            // Бинарный
            Array.Sort(array); // Сортировка массива
            workTime = CustomStopwatch(Finder.Binary, array, numberToFind, out numberIndex);
            Console.WriteLine($"Бинарный\tИндекс:\t{numberIndex}\t\tВремя:\t{workTime}");
                
            // Прыжковый
            workTime = CustomStopwatch(Finder.Jumper, array, numberToFind, out numberIndex);
            Console.WriteLine($"Прыжковый\tИндекс:\t{numberIndex}\t\tВремя:\t{workTime}\n");
        }
        
        private static double CustomStopwatch(Func<int[], int, int> method, int[] array, int numberToFind, out int result)
        {
            Stopwatch stopwatch = new Stopwatch();
            double workTime = 0; // Секундомер
            
            stopwatch.Start();
            result = method(array, numberToFind);
            stopwatch.Stop();
            workTime += stopwatch.ElapsedMilliseconds;

            return workTime;
        }
    }
}
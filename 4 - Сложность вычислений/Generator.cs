using System;
using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp
{
    internal class Generator
    {
        private readonly Random _random = new Random();
        private readonly int _numbersCount;
        private int[] numbersArray;

        [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
        public Generator(int numbersCount)
        {
            _numbersCount = numbersCount;
            numbersArray = new int[numbersCount];
        }

        // Лучший вариант, первый элемент нулевой
        internal int[] Best()
        {
            numbersArray[0] = 0; // Первый элемент нулевой
            
            for (int i = 1; i < numbersArray.Length; i++) // Далее заполнение случайными числами
            {
                numbersArray[i] = _random.Next(1, _numbersCount);
            }
            
            return numbersArray;
        }
        
        // Худший вариант, нулевых элементов нет
        internal int[] Worst()
        {
            for (int i = 0; i < numbersArray.Length; i++) // Все элементы не нулевые
            {
                numbersArray[i] = _random.Next(1, _numbersCount);
            }
            
            return numbersArray;
        }
        
        // Средний случай, случайные элементы
        internal int[] Average()
        {
            for (int i = 0; i < numbersArray.Length; i++) // Все элементы случайные от 0 до количества элементов массива
            {
                numbersArray[i] = _random.Next(0, _numbersCount);
            }
            
            return numbersArray;
        }
    }
}
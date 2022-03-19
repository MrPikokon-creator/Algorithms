using System;
using System.Diagnostics.CodeAnalysis;

namespace Finding
{
    internal static class Generator
    {
        private static Random _random = new Random();

        // Средний случай, случайные элементы от 0 до длины массива
        [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
        internal static int[] Average(int numbersCount)
        {
            int[] array = new int[numbersCount];
            
            for (int i = 0; i < numbersCount; i++)
            {
                int randomNumber = _random.Next(0, numbersCount);
                array[i] = randomNumber;
            }
            
            return array;
        }
        
        // Худший случай, все элементы отличаются от искомого числа
        [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
        internal static int[] Worst(int numbersCount, int numberToFind)
        {
            int[] array = new int[numbersCount];
            int badNumber = numberToFind + 1; // Число, отличное от искомого
            
            for (int i = 0; i < numbersCount; i++)
            {
                array[i] = badNumber;
            }
            
            return array;
        }
        
        // Средний случай с барьером
        [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
        internal static int[] LinearWithBarrier(int[] array, int numberToFind)
        {
            int[] arrayWithBarrier = new int[array.Length + 1]; // Новый массив с барьером в конце
            array.CopyTo(arrayWithBarrier, 0);
            arrayWithBarrier[arrayWithBarrier.Length - 1] = numberToFind; // Установка последнего элемента искомым

            return arrayWithBarrier;
        }
    }
}
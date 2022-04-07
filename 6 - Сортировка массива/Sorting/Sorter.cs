using System;

namespace Sorting
{
    public static class Sorter
    {
        // Пузырьковая сортировка
        public static int[] Bubble(int[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                for (var j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                        (array[j], array[j + 1]) = (array[j + 1], array[j]); // Взаимная замена переменных
                }
            }
            
            return array;
        }
        
        // Шейкерная сортировка
        public static int[] Shaker(int[] array)
        {
            for (var i = 0; i < array.Length / 2; i++)
            {
                var swapFlag = false;
                
                for (var j = i; j < array.Length - i - 1; j++) // Проход слева направо
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        swapFlag = true;
                    }
                }

                for (var j = array.Length - 2 - i; j > i; j--) // Проход справа налево
                {
                    if (array[j - 1] > array[j])
                    {
                        (array[j - 1], array[j]) = (array[j], array[j - 1]);
                        swapFlag = true;
                    }
                }
                
                if (!swapFlag) // Выход, если обменов не было
                    break;
            }
            
            return array;
        }
        
        // Сортировка чёт/нечет
        public static int[] EvenOdd(int[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                for (var j = (i % 2 == 0 ? 1 : 0); j < array.Length - 1; j += 2)
                {
                    if (array[j] > array[j + 1])
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }

            return array;
        }
        
        // Сортировка расчёской
        public static int[] Comb(int[] array)
        {
            var arrayLength = array.Length;
            var currentStep = arrayLength - 1;
        
            while (currentStep > 1)
            {
                for (int i = 0; i + currentStep < array.Length; i++)
                {
                    if (array[i] > array[i + currentStep])
                        (array[i], array[i + currentStep]) = (array[i + currentStep], array[i]);
                }

                currentStep = GetNextStep(currentStep);
            }
            
            return Bubble(array); // Пузырьковая сортировка
            
            int GetNextStep(int step) // Метод для генерации следующего шага
            {
                step = step * 1000 / 1247;
                return step > 1 ? step : 1;
            }
        }
        
        // Сортировка выбором
        public static int[] Choice(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                // Поиск минимального числа
                var min = i;
                for (var j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                        min = j;
                }
                
                (array[i], array[min]) = (array[min], array[i]);
            }

            return array;
        }
        
        // Сортировка вставками
        public static int[] Inserts(int[] array)
        {
            int[] copiedArray = new int[array.Length];
            Array.Copy(array, copiedArray, array.Length);
            
            for (int i = 0; i < copiedArray.Length; i++)
            {
                int j = i;
                while (j > 0 && array[j - 1] > copiedArray[i])
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = copiedArray[i];
            }
            
            return array;
        }
        
        // Сортировка Шелла
        public static int[] Shell(int[] array)
        {
            int step = array.Length / 2;
            
            while (step > 0)
            {
                for (int i = step; i < array.Length; i++)
                {
                    int value = array[i];
                    int j;
                    for (j = i - step; (j >= 0) && (array[j] > value); j -= step)
                        array[j + step] = array[j];
                    
                    array[j + step] = value;
                }
                step /= 2;
            }

            return array;
        }
        
        // Гномья сортировка
        public static int[] Dwarf(int[] array)
        {
            int i = 1;
            int j = 2;
            
            while (i < array.Length)
            {
                if (array[i - 1] < array[i])
                {
                    i = j;
                    j++;
                }
                else
                {
                    (array[i - 1], array[i]) = (array[i], array[i - 1]);
                    i -= 1;
                    if (i == 0)
                    {
                        i = j;
                        j++;
                    }
                }
            }

            return array;
        }
    }
}
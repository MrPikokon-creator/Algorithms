using System;

namespace Finding
{
    public static class Finder
    {
        // Линейный поиск
        public static int Linear(int[] array, int numberToFind)
        {
            int counter = 0;

            while (counter < array.Length - 1 && array[counter] != numberToFind)
            {
                counter++;
            }

            if (array[counter] == numberToFind)
            {
                return counter;
            }

            return -1;
        }
        
        // Линейный поиск с барьером
        public static int LinearWithBarrier(int[] array, int numberToFind)
        {
            int counter = 0;
            
            while (array[counter] != numberToFind)
            {
                counter++;
            }

            if (counter == array.Length - 1)
            {
                return -1;
            }
            
            return counter;
        }
        
        // Бинарный поиск
        public static int Binary(int[] sortedArray, int numberToFind)
        {
            int rangeStart = 0;
            int rangeEnd = sortedArray.Length - 1;
            int result = -1;

            while (rangeStart <= rangeEnd)
            {
                int middleIndex = (rangeEnd + rangeStart) / 2;
                
                if (numberToFind <= sortedArray[middleIndex])
                {
                    if (numberToFind == sortedArray[middleIndex])
                    {
                        result = middleIndex;
                    }
                    
                    rangeEnd = middleIndex - 1;
                }
                else
                {
                    rangeStart = middleIndex + 1;
                }
            }

            return result;
        }
        
        // Прыжковый поиск
        public static int Jumper(int[] sortedArray, int numberToFind)
        {
            int rangeStart = 0;
            int step = Convert.ToInt32(Math.Sqrt(sortedArray.Length));
            int rangeEnd = step;
            
            while (rangeEnd < sortedArray.Length)
            {
                if (numberToFind < sortedArray[rangeEnd])
                {
                    for (int i = rangeStart; i < rangeEnd; i++)
                    {
                        if (numberToFind == sortedArray[i])
                        {
                            return i;
                        }
                    }

                    return -1;
                }

                rangeStart += step;
                rangeEnd += step;
            }

            for (int i = rangeStart; i < sortedArray.Length; i++)
            {
                if (numberToFind == sortedArray[i])
                {
                    return i;
                }
            }
            
            return -1;
        }
    }
}
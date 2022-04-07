using Sorting;
using Xunit;

namespace SortingTests
{
    public class InsertsTests
    {
        [Fact]
        public void AllTheSame_Tests() // Все значения равны 0
        {
            int[] sortedArray = Sorter.Inserts(Arrays.allTheSameArray);
            Assert.Equal(sortedArray, Arrays.allTheSameArray);
        }
        
        [Fact]
        public void From10To1_Tests() // От 10 до 1
        {
            int[] sortedArray = Sorter.Inserts(Arrays.from10To1Array);
            Assert.Equal(sortedArray, Arrays.sorted1Array);
        }
        
        [Fact]
        public void AlreadySorted_Tests() // Уже отсортированный массив
        {
            int[] sortedArray = Sorter.Inserts(Arrays.sorted1Array);
            Assert.Equal(sortedArray, Arrays.sorted1Array);
        }
    }
}
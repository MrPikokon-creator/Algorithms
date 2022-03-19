using Finding;
using Xunit;

namespace FindingTests
{
    public class FinderLinearWithBarrierTests
    {
        private static int[] _array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 0 };
        
        [Fact]
        public void LinearWithBarrier_Find1_From1To16() // Линейный поиск с барьером 1 в массиве [1, 16]
        {
            _array[16] = 1;
            
            // Act
            int result = Finder.LinearWithBarrier(_array, 1);
            
            // Assert
            Assert.Equal(result, 0);
        }
        
        [Fact]
        public void LinearWithBarrier_Find16_From1To16() // Линейный поиск с барьером 16 в массиве [1, 16]
        {
            _array[16] = 16;
            
            // Act
            int result = Finder.LinearWithBarrier(_array, 16);
            
            // Assert
            Assert.Equal(result, 15);
        }
        
        [Fact]
        public void LinearWithBarrier_Find0_From1To16() // Линейный поиск с барьером 0 в массиве [1, 16]
        {
            _array[16] = 0;
            
            // Act
            int result = Finder.LinearWithBarrier(_array, 0);
            
            // Assert
            Assert.Equal(result, -1);
        }
        
        [Fact]
        public void LinearWithBarrier_Find17_From1To16() // Линейный поиск с барьером 17 в массиве [1, 16]
        {
            _array[16] = 17;
            
            // Act
            int result = Finder.LinearWithBarrier(_array, 17);
            
            // Assert
            Assert.Equal(result, -1);
        }
    }
}
using Finding;
using Xunit;

namespace FindingTests
{
    public class FinderLinearTests
    {
        private static int[] _array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        
        [Fact]
        public void Linear_Find1_From1To16() // Линейный поиск 1 в массиве [1, 16]
        {
            
            
            // Act
            int result = Finder.Linear(_array, 1);
            
            // Assert
            Assert.Equal(result, 0);
        }
        
        [Fact]
        public void Linear_Find16_From1To16() // Линейный поиск 16 в массиве [1, 16]
        {
            // Act
            int result = Finder.Linear(_array, 16);
            
            // Assert
            Assert.Equal(result, 15);
        }
        
        [Fact]
        public void Linear_Find0_From1To16() // Линейный поиск 0 в массиве [1, 16]
        {
            // Act
            int result = Finder.Linear(_array, 0);
            
            // Assert
            Assert.Equal(result, -1);
        }
        
        [Fact]
        public void Linear_Find17_From1To16() // Линейный поиск 17 в массиве [1, 16]
        {
            // Act
            int result = Finder.Linear(_array, 17);
            
            // Assert
            Assert.Equal(result, -1);
        }
    }
}
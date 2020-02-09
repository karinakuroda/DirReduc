namespace VestasApp.Tests
{
    using System;
    using Xunit;

    public class ReductTests
    {
        [Theory]
        [InlineData(new object[] { "NORTH", "SOUTH", "EAST", "WEST", "WEST" })]
        public void DirReduc_WithValidArray_ShouldReduct(params string[] instructions)
        {
            // Arrange
            var expected = "WEST";
            var reduct = new Reduct(instructions);

            // Act
            var result = reduct.DirReduc();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Reduct_WithInvalidArray_ShouldThrowException()
        {
            // Arrange
            var instructions = new[] { "NORTH", "SOUTHH", "EAST", "WEST", "WEST" };
            
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Reduct(instructions));
        }

        [Fact]
        public void DirReduc_WithValidCaseSensitiveArray_ShouldReduct()
        {
            // Arrange
            var instructions = new[] { "north", "south", "east", "west", "west" };
            var expected = "WEST";
            var reduct = new Reduct(instructions);

            // Act
            var result = reduct.DirReduc();

            // Assert
            Assert.Equal(expected, result);
        }
    }
}

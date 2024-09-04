using Avalonia.Headless.XUnit;
using AvaloniaMultiplatform.ViewModels;

namespace AvaloniaMultiplatform.XUnitTest
{
    public class CalculatorTests
    {
        [AvaloniaFact]
        public void AddCommand_ShouldReturnCorrectSum()
        {
            // Arrange
            var viewModel = new MainViewModel
            {
                Input1 = "10",
                Input2 = "20"
            };

            // Act
            viewModel.AddCommand.Execute(null);

            // Assert
            Assert.Equal("Result: 30", viewModel.Result);
        }
        [AvaloniaFact]
        public void SubtractCommand_ShouldReturnCorrectDifference()
        {
            // Arrange
            var viewModel = new MainViewModel
            {
                Input1 = "30",
                Input2 = "10"
            };

            // Act
            viewModel.SubtractCommand.Execute(null);

            // Assert
            Assert.Equal("Result: 20", viewModel.Result);
        }
        [AvaloniaFact]
        public void MultiplyCommand_ShouldReturnCorrectProduct()
        {
            // Arrange
            var viewModel = new MainViewModel
            {
                Input1 = "10",
                Input2 = "5"
            };

            // Act
            viewModel.MultiplyCommand.Execute(null);

            // Assert
            Assert.Equal("Result: 50", viewModel.Result);
        }
        [AvaloniaFact]
        public void DivideCommand_ShouldReturnCorrectQuotient()
        {
            // Arrange
            var viewModel = new MainViewModel
            {
                Input1 = "50",
                Input2 = "10"
            };

            // Act
            viewModel.DivideCommand.Execute(null);

            // Assert
            Assert.Equal("Result: 5", viewModel.Result);
        }

        [AvaloniaFact]
        public void DivideCommand_ShouldHandleDivideByZero()
        {
            // Arrange
            var viewModel = new MainViewModel
            {
                Input1 = "50",
                Input2 = "0"
            };

            // Act
            viewModel.DivideCommand.Execute(null);

            // Assert
            Assert.Equal("Cannot divide by zero", viewModel.Result);
        }
    }
}
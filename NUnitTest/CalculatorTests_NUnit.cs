using Avalonia.Headless.NUnit;
using AvaloniaMultiplatform.ViewModels;

//Namespace TestExplorer'da görünen namespace olur ve test edilen metodlar bu namespace'in altýnda bulunur
namespace NUnitCalculatorTests;
[TestFixture]
public class CalculatorCommandTests
{
    private MainViewModel _viewModel;

    [SetUp]
    public void Setup()
    {
        _viewModel = new MainViewModel();
    }

    [AvaloniaTest]
    public void AddCommand_ShouldCalculateCorrectResult()
    {
        // Arrange
        _viewModel.Input1 = "10";
        _viewModel.Input2 = "20";

        // Act
        _viewModel.AddCommand.Execute(null);

        // Assert
        Assert.That(_viewModel.Result, Is.EqualTo("Result: 30"));
    }
    [AvaloniaTest]
    public void SubstractCommand_ShouldHandleCorrectResult()
    {
        _viewModel.Input1 = "30";
        _viewModel.Input2 = "20";

        _viewModel.SubtractCommand.Execute(null);
    }
    [AvaloniaTest]
    public void MultiplyCommand_ShouldHandleCorrectResult()
    {
        _viewModel.Input1 = "2";
        _viewModel.Input2 = "5";

        _viewModel.MultiplyCommand.Execute(null);
    }
    [AvaloniaTest]
    public void DivideCommand_ShouldHandleDivideByZero()
    {
        // Arrange
        _viewModel.Input1 = "50";
        _viewModel.Input2 = "0";

        // Act
        _viewModel.DivideCommand.Execute(null);

        // Assert
        Assert.That(_viewModel.Result, Is.EqualTo("Cannot divide by zero"));
    }
}

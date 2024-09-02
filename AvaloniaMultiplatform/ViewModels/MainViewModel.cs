using System;
using System.ComponentModel;
using System.Windows.Input;

namespace AvaloniaMultiplatform.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string? _input1;
        private string? _input2;
        private string? _result;
        public ICommand AddCommand { get; }
        public ICommand SubtractCommand { get; }
        public ICommand DivideCommand { get; }
        public ICommand MultiplyCommand { get; }

        public MainViewModel()
        {
            AddCommand = new RelayCommand(OnAddButtonClick, CanExecuteCalculation);
            SubtractCommand = new RelayCommand(OnSubtractButtonClick, CanExecuteCalculation);
            DivideCommand = new RelayCommand(OnDivideButtonClick, CanExecuteCalculation);
            MultiplyCommand = new RelayCommand(OnMultiplyButtonClick, CanExecuteCalculation);
        }

        public string Input1
        {
            get => _input1;
            set
            {
                if (_input1 != value)
                {
                    _input1 = value;
                    OnPropertyChanged(nameof(Input1));
                    OnCanExecuteChanged(); // Notify that CanExecute might have changed
                }
            }
        }

        public string Input2
        {
            get => _input2;
            set
            {
                if (_input2 != value)
                {
                    _input2 = value;
                    OnPropertyChanged(nameof(Input2));
                    OnCanExecuteChanged(); // Notify that CanExecute might have changed
                }
            }
        }

        public string Result
        {
            get => _result;
            set
            {
                if (_result != value)
                {
                    _result = value;
                    OnPropertyChanged(nameof(Result));
                }
            }
        }

    
        private bool CanExecuteCalculation()
        {
            // Ensure that both inputs are valid numbers
            return double.TryParse(Input1, out _) && double.TryParse(Input2, out _);
        }

        private void OnAddButtonClick()
        {
            if (double.TryParse(Input1, out double num1) && double.TryParse(Input2, out double num2))
            {
                Result = $"Result: {num1 + num2}";
            }
        }

        private void OnSubtractButtonClick()
        {
            if (double.TryParse(Input1, out double num1) && double.TryParse(Input2, out double num2))
            {
                Result = $"Result: {num1 - num2}";
            }
        }

        private void OnMultiplyButtonClick()
        {
            if (double.TryParse(Input1, out double num1) && double.TryParse(Input2, out double num2))
            {
                Result = $"Result: {num1 * num2}";
            }
        }

        private void OnDivideButtonClick()
        {
            if (double.TryParse(Input1, out double num1) && double.TryParse(Input2, out double num2))
            {
                if (num2 != 0)
                    Result = $"Result: {num1 / num2}";
                else
                    Result = "Cannot divide by zero";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Notify the commands that their CanExecute state might have changed
        private void OnCanExecuteChanged()
        {
            (AddCommand as RelayCommand)?.RaiseCanExecuteChanged();
            (SubtractCommand as RelayCommand)?.RaiseCanExecuteChanged();
            (DivideCommand as RelayCommand)?.RaiseCanExecuteChanged();
            (MultiplyCommand as RelayCommand)?.RaiseCanExecuteChanged();
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter) => _canExecute == null || _canExecute();

        public void Execute(object? parameter) => _execute();

        public event EventHandler CanExecuteChanged;
        
        public void RaiseCanExecuteChanged()
        {
            //Canasdasd
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}

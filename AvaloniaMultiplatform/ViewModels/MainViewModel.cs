using System;
using System.ComponentModel;
using System.Windows.Input;

namespace AvaloniaMultiplatform.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged // Viewdaki datada bir değişiklik olunca ViewModel ile bunu View'a bildirmek için bu interface //PropertyChangedEventHandler
    {
        private string? _input1;
        private string? _input2;
        private string? _result;

        public string Input1
        {
            get => _input1;
            set
            {
                //value is a NEW VALUE that you want to set instead _input1
                if (_input1 != value)
                {
                    _input1 = value;
                    OnPropertyChanged(nameof(Input1));
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

        public ICommand AddCommand { get; }
        public ICommand SubstractCommand { get; }
        public ICommand DivideCommand { get; }
        public ICommand MultiplyCommand { get; }


        public MainViewModel()
        {
            AddCommand = new RelayCommand(OnAddButtonClick);
            SubstractCommand = new RelayCommand(OnSubstractButtonClick);
            DivideCommand = new RelayCommand(OnDivideButtonClick);
            MultiplyCommand = new RelayCommand(OnMultiplyButtonClick);
        }

        private void OnAddButtonClick()
        {
            if (double.TryParse(Input1, out double num1) && double.TryParse(Input2, out double num2))
            {
                Result = $"Result: {num1 + num2}";
            }
            else
            {
                Result = "Please enter valid numbers.";
            }
        }
        private void OnSubstractButtonClick()
        {
            if (double.TryParse(Input1, out double num1) && double.TryParse(Input2, out double num2))
            {
                Result = $"Result: {num1 - num2}";
            }
            else
            {
                Result = "Please enter valid numbers.";
            }
        }
        private void OnMultiplyButtonClick()
        {
            if (double.TryParse(Input1, out double num1) && double.TryParse(Input2, out double num2))
            {
                Result = $"Result: {num1 * num2}";
            }
            else
            {
                Result = "Please enter valid numbers.";
            }
        }
        private void OnDivideButtonClick()
        {
            if (double.TryParse(Input1, out double num1) && double.TryParse(Input2, out double num2))
            {
                if (num2 != 0)
                    Result = $"Result: {num1 / num2}";
                else
                    Result = "Divide by Zero error";
            }
            else
            {
                Result = "Please enter valid numbers.";
            }
        }
        //ViewModel'daki data değiştiğinde hemen güncelleyip View'a yansıtmaya yarayan kod.
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
    }
}

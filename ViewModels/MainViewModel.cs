using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AvaloniaApp.Models;
using System.Globalization;

namespace AvaloniaApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _input1;
        private string _input2;
        private string _result;

        public string Input1
        {
            get => _input1;
            set { _input1 = value; OnPropertyChanged(); }
        }

        public string Input2
        {
            get => _input2;
            set { _input2 = value; OnPropertyChanged(); }
        }

        public string Result
        {
            get => _result;
            set { _result = value; OnPropertyChanged(); }
        }

        public ICommand AddCommand { get; }
        public ICommand SubtractCommand { get; }
        public ICommand MultiplyCommand { get; }
        public ICommand DivideCommand { get; }

        public MainViewModel()
        {
            Input1 = "2.5";
            Input2 = "3.0";

            AddCommand = new RelayCommand(Add);
            SubtractCommand = new RelayCommand(Subtract);
            MultiplyCommand = new RelayCommand(Multiply);
            DivideCommand = new RelayCommand(Divide);
        }

        private RealNumber ParseInput(string input)
{
    if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
        return RealNumber.FromDouble(value);

    throw new ArgumentException("Неверный формат числа");
}

        private void Add(object parameter)
        {
            try
            {
                var a = ParseInput(Input1);
                var b = ParseInput(Input2);
                var res = a + b;
                Result = res.ToString();
            }
            catch (Exception ex)
            {
                Result = "Ошибка: " + ex.Message;
            }
        }

        private void Subtract(object parameter)
        {
            try
            {
                var a = ParseInput(Input1);
                var b = ParseInput(Input2);
                var res = a - b;
                Result = res.ToString();
            }
            catch (Exception ex)
            {
                Result = "Ошибка: " + ex.Message;
            }
        }

        private void Multiply(object parameter)
        {
            try
            {
                var a = ParseInput(Input1);
                var b = ParseInput(Input2);
                var res = a * b;
                Result = res.ToString();
            }
            catch (Exception ex)
            {
                Result = "Ошибка: " + ex.Message;
            }
        }

        private void Divide(object parameter)
        {
            try
            {
                var a = ParseInput(Input1);
                var b = ParseInput(Input2);
                var res = a / b;
                Result = res.ToString();
            }
            catch (Exception ex)
            {
                Result = "Ошибка: " + ex.Message;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
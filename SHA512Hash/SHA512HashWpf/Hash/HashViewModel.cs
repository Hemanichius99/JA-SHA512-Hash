using CommonServiceLocator;
using GalaSoft.MvvmLight.Command;
using SHA512HashWpf.History;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace SHA512HashWpf.Hash
{
    public class HashViewModel : INotifyPropertyChanged
    {
        private const string TextsFilePath = "C:\\Users\\heman\\Documents\\Text\\news.txt";
        private string _input = string.Empty;
        private string _output = string.Empty;
        private int _numberOfThreads = 1;
        private bool _isAsmDllChoosen = false;
        private HashContext _hashContext;
        // private ObservableCollection<AlgoRecord> _history;
        public string Input

        {
            get { return _input; }
            set
            {
                if (_input != value)
                {
                    _input = value;
                    OnPropertyChanged(nameof(Input));
                }
            }
        }
        public string Output
        {
            get { return _output; }
            set
            {
                if (_output != value)
                {
                    _output = value;
                    OnPropertyChanged(nameof(Output));
                }
            }
        }

        public int  MaximumNumberOfThreads { get; } = Environment.ProcessorCount;
        public int SelectedNumberOfThreads
        {
            get { return _numberOfThreads; }
            set
            {
                if (_numberOfThreads != value)
                {
                    _numberOfThreads = value;
                    OnPropertyChanged(nameof(SelectedNumberOfThreads));
                }
            }
        }

        public bool IsAsmDllChoosen
        {
            get { return _isAsmDllChoosen; }
            set
            {
                if (_isAsmDllChoosen != value)
                {
                    _isAsmDllChoosen = value;
                    OnPropertyChanged(nameof(IsAsmDllChoosen));
                    _hashContext.setStrategy(_isAsmDllChoosen ? new HashAsm() : new HashCsharp());
                }
            }
        }
        public ICommand HashCommand { get; }
        public ICommand GenerateCommand { get; }
        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<AlgoRecord> History { get; } = new();

        public HashViewModel()
        {
            _hashContext = new HashContext();
            HashCommand = new RelayCommand(ComputeHash);
            GenerateCommand = new RelayCommand(GenerateText);
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void ComputeHash()
        {
            try {
                HashResult result = _hashContext.Hash(Input, SelectedNumberOfThreads);

                Output = result.Hash;
                History.Add(new AlgoRecord(_hashContext.getMethod(), result.TimeInMilliseconds, SelectedNumberOfThreads)); // TODO na razie czas = 0,001, można później dodać pomiar czasu
            }
            catch (Exception ex)
            {
                Output = "Błąd podczas obliczania hasha: " + ex.Message;
            }
        }

        private void GenerateText()
        {
            try
            {
                var textGenerator = new Generate.TextGenerator(TextsFilePath);
                Input = textGenerator.getSentence();
            }
            catch (Exception ex)
            {
                Output = "Błąd podczas generowania tekstu: " + ex.Message;
            }
        }

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string? propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }
    }
}
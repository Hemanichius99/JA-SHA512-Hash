using CommonServiceLocator;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                Output = _hashContext.Hash(Input, SelectedNumberOfThreads);
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

    }
}
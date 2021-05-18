using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MVVMSample010.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        public IRelayCommand ViewLoadedCommand { get; }
        public IRelayCommand<CancelEventArgs> ViewClosingCommand { get; }

        private bool _isCloseDeny;
        public bool IsCloseDeny
        {
            get => _isCloseDeny;
            set => SetProperty(ref _isCloseDeny, value);
        }

        private ObservableCollection<string> _eventLogs;
        public ObservableCollection<string> EventLogs
        {
            get => _eventLogs;
            set => SetProperty(ref _eventLogs, value);
        }

        /// <summary>
        /// constructor
        /// </summary>
        public MainWindowViewModel()
        {
            IsCloseDeny = true;
            EventLogs = new ObservableCollection<string>();

            ViewLoadedCommand = new RelayCommand(() =>
            {
                EventLogs.Add("Loaded");
            });

            ViewClosingCommand = new RelayCommand<CancelEventArgs>(e =>
            {
                EventLogs.Add("Closing");

                if (IsCloseDeny)
                {
                    e.Cancel = true;
                }
            });
        }
    }
}

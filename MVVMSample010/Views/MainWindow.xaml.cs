using MVVMSample010.ViewModels;
using System.Windows;

namespace MVVMSample010.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}

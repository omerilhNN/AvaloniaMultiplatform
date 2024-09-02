using Avalonia.Controls;
using AvaloniaMultiplatform.ViewModels;

namespace AvaloniaMultiplatform.Views
{
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
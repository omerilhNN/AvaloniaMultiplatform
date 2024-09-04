using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using AvaloniaMultiplatform.ViewModels;
using AvaloniaMultiplatform.Views;

namespace AvaloniaMultiplatform
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (BindingPlugins.DataValidators.Count > 0)
            {
                BindingPlugins.DataValidators.RemoveAt(0);
            }
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                desktop.MainWindow = new MainWindow();
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleView)
                singleView.MainView = new MainSingleView();
            base.OnFrameworkInitializationCompleted();
        }
    }
}
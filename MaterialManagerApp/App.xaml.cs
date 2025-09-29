using Microsoft.Maui.Controls;

namespace MaterialManagerApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new AppShell();
    }
}

using Microsoft.Maui.Controls;

namespace memorygame;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new MainPage();
        this.FixKeyboardCovering();
    }
}

﻿using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace memorygame.WinUI;
/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : MauiWinUIApplication
{
    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        this.InitializeComponent();

        #if DEBUG
        //        AddDebugMobileWindow();
#endif
            }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    static void AddDebugMobileWindow()
    {
        Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
        {
            var mauiWindow = handler.VirtualView;
            var nativeWindow = handler.PlatformView;
            nativeWindow.Activate();

            // allow Windows to draw a native titlebar which respects IsMaximizable/IsMinimizable
            nativeWindow.ExtendsContentIntoTitleBar = false;

            IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
            WindowId windowId = Win32Interop.GetWindowIdFromWindow(windowHandle);
            AppWindow appWindow = AppWindow.GetFromWindowId(windowId);

            // set a specific window size
            appWindow.Resize(new SizeInt32(480, 720));

            if (appWindow.Presenter is OverlappedPresenter p)
            {
                p.IsResizable = false;

                // these only have effect if XAML isn't responsible for drawing the titlebar.
                p.IsMaximizable = false;
                p.IsMinimizable = false;
            }
        });
    }
}


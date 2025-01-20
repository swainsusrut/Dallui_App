using System.Diagnostics;
using Foundation;
using Microsoft.Maui.Controls.PlatformConfiguration;
using UIKit;

namespace DalluiApp;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp()
    {
        AddChildHandlers();
        return MauiProgram.CreateMauiApp();
    }

    [Export("application:supportedInterfaceOrientationsForWindow:")]
    public UIInterfaceOrientationMask GetSupportedInterfaceOrientations(UIApplication application, UIWindow forWindow)
    {
        return UIInterfaceOrientationMask.Portrait;
    }

    private void AddChildHandlers()
    {
        Microsoft.Maui.Handlers.EditorHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
        {
            handler.PlatformView.TintColor = UIColor.Clear;
        });
    }
}


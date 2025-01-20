using System;
using Microsoft.Maui.Platform;
#if IOS
using CoreGraphics;
using UIKit;
using DalluiApp.Platforms.iOS.Utils;
#endif

namespace DalluiApp.Controls
{
    public class KeyboardAutoScroll : ScrollView
    {
        public KeyboardAutoScroll()
        {
#if IOS
            UIKeyboard.Notifications.ObserveWillShow(OnKeyboardShowing!);
            UIKeyboard.Notifications.ObserveWillHide(OnKeyboardHiding!);
#endif
        }

#if IOS
        private void OnKeyboardShowing(object sender, UIKeyboardEventArgs args)
        {
            try
            {
                if (DeviceInfo.Current.Idiom == DeviceIdiom.Tablet)
                    return;

                if (Shell.Current.CurrentPage != null && Shell.Current.CurrentPage is ContentPage page)
                {
                    UIView? control = this.ToPlatform(Handler.MauiContext).FindFirstResponder();
                    if (control == null)
                        return;

                    UIView rootUiView = page.Content.ToPlatform(Handler.MauiContext);
                    CGRect kbFrame = UIKeyboard.FrameEndFromNotification(args.Notification);
                    //Margin = new Thickness(Margin.Left, -kbFrame.Height/2.5, Margin.Right, kbFrame.Height/2.5);
                    double distance = control.GetOverlapDistance(rootUiView, kbFrame);
                    if (distance > 0)
                    {
                        Margin = new Thickness(Margin.Left, -distance, Margin.Right, distance);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void OnKeyboardHiding(object sender, UIKeyboardEventArgs args)
        {
            Margin = new Thickness(Margin.Left, 0, Margin.Right, 0);
        }
#endif
    }

}


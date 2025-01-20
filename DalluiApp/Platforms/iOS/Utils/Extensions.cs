using System;
using CoreGraphics;
using UIKit;

namespace DalluiApp.Platforms.iOS.Utils
{
    public static class UIViewExtensions
    {
        /// <summary>
        /// Find the first responder in the <paramref name="view"/>'s subview hierarchy
        /// </summary>
        /// <param name="view">
        /// A <see cref="UIView"/>
        /// </param>
        /// <returns>
        /// A <see cref="UIView"/> that is the first responder or null if there is no first responder
        /// </returns>
        public static UIView? FindFirstResponder(this UIView view)
        {
            try
            {
                if (view.IsFirstResponder)
                {
                    return view;
                }
                foreach (UIView subView in view.Subviews)
                {
                    var firstResponder = subView.FindFirstResponder();
                    if (firstResponder != null)
                        return firstResponder;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Returns the view Bottom (Y + Height) coordinates relative to the rootView
        /// https://developer.apple.com/documentation/uikit/uiview/1622424-convertpoint
        /// </summary>
        /// <returns>The view relative bottom.</returns>
        /// <param name="view">View.</param>
        /// <param name="rootView">Root view.</param>
        private static double GetViewRelativeBottom(this UIView view, UIView rootView)
        {
            try
            {
                var viewRelativeCoordinates = rootView.ConvertPointFromView(new CGPoint(0, 0), view);
                var activeViewRoundedY = Math.Round(viewRelativeCoordinates.Y, 2);

                return activeViewRoundedY + view.Frame.Height;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0.0;
            }
        }

        private static double GetOverlapDistance(double relativeBottom, UIView rootView, CGRect keyboardFrame)
        {
            try
            {
                var safeAreaBottom = rootView.Window.SafeAreaInsets.Bottom;
                var pageHeight = rootView.Frame.Height;
                var keyboardHeight = keyboardFrame.Height;
                return relativeBottom - (pageHeight + safeAreaBottom - keyboardHeight);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0.0;
            }
        }

        /// <summary>
        /// Returns the distance between the bottom of the View and the top of the keyboard
        /// </summary>
        /// <param name="activeView">View.</param>
        /// <param name="rootView">Root view.</param>
        /// <param name="keyboardFrame">Keyboard Frame.</param>
        /// <returns>The distance, positive if the keyboard overlaps with the View, negative otherwise</returns>
        public static double GetOverlapDistance(this UIView activeView, UIView rootView, CGRect keyboardFrame)
        {
            try
            {
                double bottom = activeView.GetViewRelativeBottom(rootView);
                return GetOverlapDistance(bottom, rootView, keyboardFrame);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0.0;
            }
        }
    }

}


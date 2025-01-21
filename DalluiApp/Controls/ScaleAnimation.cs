using System;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Animations;
using CommunityToolkit.Maui.Extensions;

namespace DalluiApp.Controls
{
	public class ScaleAnimation: BaseAnimation
    {
        public override async Task Animate(VisualElement view, CancellationToken token = default)
        {
            await view.ScaleTo(1, Length);
        }
    }
}


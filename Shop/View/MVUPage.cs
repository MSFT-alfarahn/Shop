
using CommunityToolkit.Maui.Markup;
using Microsoft.Maui.Layouts;

namespace Shop;

public class MVUPage : ContentPage
{
    public MVUPage(MVUViewModel vm)
    {
        Content = new AbsoluteLayout
        {
            Children =
            {
                new Label
                {
           

                }.LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
                .LayoutBounds(0.5, 0, 100, 200)
                ,

                new BoxView
                {
                    Color = Colors.Green,
                    WidthRequest = 25,
                    HeightRequest = 100,
                }.LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
                .LayoutBounds(0, 0.5),

                new BoxView
                {
                    Color = Colors.Red,
                    WidthRequest = 25,
                    HeightRequest = 100,
                }.LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
                .LayoutBounds(new Point(1, 0.5)),

                new BoxView
                {
                    Color = Colors.Grey,
                }.LayoutFlags(AbsoluteLayoutFlags.PositionProportional)
                .LayoutBounds(new Point(0.5, 1), new Size(100, 25)),

                new BoxView
                {
                    Color = Colors.Tan,
                }.LayoutFlags(AbsoluteLayoutFlags.All)
                .LayoutBounds(new Rect(0.5, 0.5, 1d/3d, 1d/3d))
            }
        };
    }
}

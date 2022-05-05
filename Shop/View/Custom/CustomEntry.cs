
#if ANDROID
using Android.Content.Res;
using Microsoft.Maui.Platform;
#endif


namespace Shop.View.Custom;

public class CustomEntry : Entry
{
    public CustomEntry()
    {
#if ANDROID
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (h, v) =>
        {
            h.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
        });
#endif
    }
}

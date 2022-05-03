namespace Shop;

public partial class NativePage : ContentPage
{
	public NativePage(NativeViewModel nativeViewModel)
	{
		InitializeComponent();
		BindingContext = nativeViewModel;
	}
}
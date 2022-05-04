using Shop.Resources;

namespace Shop;

public partial class FormPage : ContentPage
{
	public FormPage()
	{
		InitializeComponent();
		namelabal.Text = AppResources.Welcome;
	}
}
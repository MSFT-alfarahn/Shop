namespace Shop;

public partial class BoundServicePage : ContentPage
{
	public BoundServicePage(BoundServiceViewModel boundServiceViewModel)
	{
		InitializeComponent();
		BindingContext = boundServiceViewModel;
	}
}
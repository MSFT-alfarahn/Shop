namespace Shop;

public partial class DeepPage : ContentPage
{
	public DeepPage(DeepViewModel deepViewModel)
	{
		InitializeComponent();
		BindingContext = deepViewModel;
	}
}
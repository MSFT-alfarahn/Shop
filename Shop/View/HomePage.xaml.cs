
namespace Shop;

public partial class HomePage : ContentPage
{
	public HomePage(HomeViewModel homeViewModel)
	{
		InitializeComponent();
		BindingContext = homeViewModel;
	}
}
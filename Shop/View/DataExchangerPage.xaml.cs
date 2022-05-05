namespace Shop;

public partial class DataExchangerPage : ContentPage
{
	public DataExchangerPage(DataExchangerViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
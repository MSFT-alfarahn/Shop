namespace Shop;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new MyTabs(); //The tabs are now based on Shell and all the benefits!
	}
}

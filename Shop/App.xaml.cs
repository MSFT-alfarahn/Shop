namespace Shop;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new MyTabs();//new AppShell();
	}
}

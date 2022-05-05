namespace Shop;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new MyTabs(); //The tabs are now based on Shell and all the benefits!
	}

    protected override void OnStart()
    {
        base.OnStart();

        // here you look up local db and sync with online db
        
        
        // Hook up to an event whenever there is connectivity then you can resume sync
        // You could use Essentials for this:
        //    // Register for connectivity changes, be sure to unsubscribe when finished
        //Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
    }

    protected override void OnSleep()
    {
        base.OnSleep();

        // here you will pause the offline sync 
    }
}

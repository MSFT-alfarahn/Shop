using Android.Content;

namespace Shop;

public partial class BoundServiceAbstraction
{
    TimestampServiceConnection serviceConnection;
    public partial async Task<bool> DoBindService()
    {
        try
        {
            if (serviceConnection == null)
            {
                serviceConnection = new TimestampServiceConnection(MainActivity.Instance);
            }

            Intent serviceToStart = new Intent(MainActivity.Instance, typeof(TimestampService));
            MainActivity.Instance.BindService(serviceToStart, serviceConnection, Bind.AutoCreate);
            await Task.Delay(500);
            return true;
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public partial void DoUnBindService()
    {
        MainActivity.Instance.UnbindService(serviceConnection);
        serviceConnection = null;
    }

    public partial string GetDataFromBoundService()
    {
        return serviceConnection.Binder.Service.GetFormattedTimestamp();
    }
}



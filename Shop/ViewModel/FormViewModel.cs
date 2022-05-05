
namespace Shop.ViewModel;

public partial class FormViewModel : BaseViewModel
{
    private bool _runThread;

    [ICommand]
    private async void Submit()
    {
        NotBusy = false;
        IsBusy = true;
        await Task.Delay(10000);
        NotBusy = true;
        IsBusy = false;
    }

    [ICommand]
    private async void KillCPU()
    {
        await App.Current.MainPage.DisplayAlert("CPU", "High Usage Starts", "ok");
        _runThread = true;

        List<Thread> threads = new List<Thread>();
        for (int i = 0; i < 1000000; i++)
        {
            threads.Add(new Thread(new ThreadStart(KillCore)));
        }

        _runThread = false;
        await App.Current.MainPage.DisplayAlert("CPU", "High Usage Stopped", "ok");
    }
    public void KillCore()
    {
        Random rand = new Random();
        long num = 0;
        while (_runThread)
        {
            num += rand.Next(100, 1000);
            if (num > 1000000) { num = 0; }
        }
    }

    [ICommand]
    public void ThrowUnhandled()
    {
        try
        {
            int.Parse("invalid");
        }
        catch (Exception e)
        {
            MauiProgram.Telemetry.TrackException(e);        
        }
    }
}


namespace Shop.ViewModel;

public partial class FormViewModel : BaseViewModel
{
    [ICommand]
    private async void Submit()
    {
        NotBusy = false;
        IsBusy = true;
        await Task.Delay(10000);
        NotBusy = true;
        IsBusy = false;
    }
}

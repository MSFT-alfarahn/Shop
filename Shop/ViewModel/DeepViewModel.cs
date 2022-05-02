
namespace Shop.ViewModel;
    
    [QueryProperty("Price","Price")]
    public partial class DeepViewModel : BaseViewModel    
    {
        [ObservableProperty]
        private string price;
    }

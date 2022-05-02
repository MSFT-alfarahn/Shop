

namespace Shop.ViewModel;
   
    [QueryProperty("Token", nameof(Token))]
    public partial class DetailViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string token;
    }



namespace Shop.ViewModel;

    public partial class HomeViewModel : BaseViewModel
    {
        [ObservableProperty]
        public string someData;

        [ICommand]
        private void GoToDetail() // But on the page you have use => GoToDetailCommand
         => Shell.Current.GoToAsync($"{nameof(DetailPage)}?Token={Guid.NewGuid()}");
    }

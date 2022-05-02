

using CommunityToolkit.Mvvm.ComponentModel;

namespace Shop.ViewModel;

    public partial class HomeViewModel : BaseViewModel
    {
        [ObservableProperty]
        public string someData;

        public HomeViewModel()
        {
            Console.WriteLine(SomeData);
        }
    }

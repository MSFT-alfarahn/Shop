
namespace Shop.ViewModel;

    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool notBusy = true;
        [ObservableProperty]
        private bool isBusy;
        public virtual void OnAppearing() { }
        public virtual void OnDisAppearing() { }
    }

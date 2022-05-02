
namespace Shop.ViewModel;

    public abstract class BaseViewModel : ObservableObject
    {
        public virtual void OnAppearing() { }
        public virtual void OnDisAppearing() { }
    }

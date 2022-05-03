
using Shop;

namespace Shop.ViewModel;
   
    [QueryProperty("Token", nameof(Token))]
    public partial class DetailViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string token;
        public StateManager Manager { get; }
        public DetailViewModel(StateManager stateManager  )
        {
            Manager = stateManager; 
        }
}

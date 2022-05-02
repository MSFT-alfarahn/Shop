﻿

namespace Shop.ViewModel;

    public partial class HomeViewModel : BaseViewModel
    {
        [ObservableProperty]
        public string someData;

        [ICommand]
        private async void GoToDetail()
        {  // But on the page you have use => GoToDetailCommand
           await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Token={Guid.NewGuid()}");
           await Shell.Current.GoToAsync($"{ nameof(DeepPage)}?Price={32}");
        }
    }

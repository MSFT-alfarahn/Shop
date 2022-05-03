using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ViewModel
{
    public partial class BoundServiceViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string dataFromBoundService;
        private BoundServiceAbstraction _boundServiceAbstraction;

        public BoundServiceViewModel(BoundServiceAbstraction boundServiceAbstraction)
        {
            _boundServiceAbstraction = boundServiceAbstraction;
        }

        [ICommand]
        private async void GetDataFromBoundService()
        {
            await _boundServiceAbstraction.DoBindService();
            DataFromBoundService = _boundServiceAbstraction.GetDataFromBoundService();
            _boundServiceAbstraction.DoUnBindService();
        }
    }
}

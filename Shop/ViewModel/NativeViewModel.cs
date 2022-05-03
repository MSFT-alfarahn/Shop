using Shop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ViewModel
{
    public partial class NativeViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string platform;

        public NativeViewModel(NativeService service)
        {
            Platform = service.GetPlatform();
        }
    }
}

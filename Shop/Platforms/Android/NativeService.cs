using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if ANDROID
namespace Shop.Platforms
{
    public class NativeService
    {
        public string Platform => "Android";
    }
}
#endif
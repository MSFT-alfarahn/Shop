
namespace Shop;


public partial class BoundServiceAbstraction
{
    public partial Task<bool> DoBindService();

    public partial void DoUnBindService();

    public partial string GetDataFromBoundService();
}
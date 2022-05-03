
namespace Shop;

public partial class BoundServiceAbstraction
{
    public partial async Task<bool> DoBindService()
    {
        await Task.Delay(100);
        return false;
    }

    public partial void DoUnBindService()
    {
    }

    public partial string GetDataFromBoundService()
    {
        return "Windows Not Implemented";
    }
}



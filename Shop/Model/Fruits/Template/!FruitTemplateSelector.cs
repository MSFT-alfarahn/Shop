
namespace Shop.Model.Fruits.Template;

public class TechItemTemplateSelector : DataTemplateSelector
{
    public DataTemplate DefaultTemplate { get; set; }
    public DataTemplate GuavaTemplate { get; set; }
    public DataTemplate WatermelonTemplate { get; set; }
    public DataTemplate BananasTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        if (item.GetType() == typeof(Guava))
            return GuavaTemplate;
        else if (item.GetType() == typeof(WatermelomTemplate))
             return WatermelonTemplate;
        else if (item.GetType() == typeof(BananasTemplate))
            return BananasTemplate;
        else
            return BananasTemplate;
    }
}

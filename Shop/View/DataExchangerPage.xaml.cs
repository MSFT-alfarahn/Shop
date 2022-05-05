using CommunityToolkit.Maui.Behaviors;

namespace Shop;

public partial class DataExchangerPage : ContentPage
{
	public DataExchangerPage(DataExchangerViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

		AddEntryValidation();
	}

    private void AddEntryValidation()
    {
        var entry = new Entry
        {
            Keyboard = Keyboard.Numeric
        };

        var validStyle = new Style(typeof(Entry));
        validStyle.Setters.Add(new Setter
        {
            Property = Entry.TextColorProperty,
            Value = Colors.Green
        });

        var invalidStyle = new Style(typeof(Entry));
        invalidStyle.Setters.Add(new Setter
        {
            Property = Entry.TextColorProperty,
            Value = Colors.Red
        });

        var numericValidationBehavior = new NumericValidationBehavior
        {
            InvalidStyle = invalidStyle,
            ValidStyle = validStyle,
            Flags = ValidationFlags.ValidateOnValueChanged,
            MinimumValue = 1.0,
            MaximumValue = 100.0,
            MaximumDecimalPlaces = 2
        };

        entry.Behaviors.Add(numericValidationBehavior);
      //  stack.Children.Add(entry);
    }
}
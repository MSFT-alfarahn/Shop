
using Shop.Model.Fruits;

namespace Shop.ViewModel;

public partial class DynamicFruitViewModel :  BaseViewModel
{
    [ObservableProperty]
    private Fruit chosenFruit;

    [ICommand]
    private void ChooseWatermelon()
        => ChosenFruit = new Watermelon();

    [ICommand]
    private void ChooseGuava()
    => ChosenFruit = new Guava();

    [ICommand]
    private void ChooseBananas()
    => ChosenFruit = new Bananas();
}

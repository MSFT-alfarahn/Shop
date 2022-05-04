
using Shop.Model.Fruits;

namespace Shop.ViewModel;

public partial class DynamicFruitViewModel :  BaseViewModel
{
    [ObservableProperty]
    private List<Fruit> chosenFruit;

    [ICommand]
    private void ChooseWatermelon()
        => ChosenFruit = new List<Fruit> { new Watermelon() };

    [ICommand]
    private void ChooseGuava()
    => ChosenFruit = new List<Fruit> { new Guava() };

    [ICommand]
    private void ChooseBananas()
    => ChosenFruit = new List<Fruit> { new Bananas() };
}

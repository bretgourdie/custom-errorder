namespace customerrorder.Common;
internal struct Offering
{
    public readonly FoodItem CheapItem;
    public readonly FoodItem MidItem;
    public readonly FoodItem ExpensiveItem;

    public Offering(
        FoodItem cheapItem,
        FoodItem midItem,
        FoodItem expensiveItem)
    {
        CheapItem = cheapItem;
        MidItem = midItem;
        ExpensiveItem = expensiveItem;
    }
}

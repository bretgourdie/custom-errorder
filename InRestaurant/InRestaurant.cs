using customerrorder.Common;
using Godot;
using System;
using customerrorder.RestaurantSelection;

namespace customerrorder.InRestaurant;
public partial class InRestaurant : Node2D
{
    private Restaurant clickedRestaurant;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        clickedRestaurant = Context.LastClickedRestaurant ?? getDemoRestaurant();
        loadFoodChoice(FoodChoice.Cheap, clickedRestaurant.Offering.CheapItem);
        loadFoodChoice(FoodChoice.Mid, clickedRestaurant.Offering.MidItem);
        loadFoodChoice(FoodChoice.Expensive, clickedRestaurant.Offering.ExpensiveItem);

        findFoodChoiceButton(FoodChoice.Cheap).Pressed += foodChoiceCheapPressed;
        findFoodChoiceButton(FoodChoice.Mid).Pressed += foodChoiceMidPressed;
        findFoodChoiceButton(FoodChoice.Expensive).Pressed += foodChoiceExpensivePressed;

        GetNode<Button>("BackButton").Pressed += backButtonPressed;

        Context.LoadHUD(GetNode<Control>("HUD"));
        GD.Print($"Clicked Restaurant: {clickedRestaurant}");
    }

    private void backButtonPressed()
    {
        GetTree().ChangeSceneToFile("RestaurantSelection/RestaurantSelection.tscn");
    }

    private void loadFoodChoice(FoodChoice foodChoice, FoodItem foodItem)
    {
        var foodChoiceButton = findFoodChoiceButton(foodChoice);

        foodChoiceButton.Icon = ResourceLoader.Load<Texture2D>($"Resources/Food/{foodItem.Picture}.png");
        var priceLabel = foodChoiceButton.FindChild("Price") as Label;
        priceLabel.Text = "$ " + foodItem.Price.ToString();
    }

    private Restaurant getDemoRestaurant()
    {
        return new Restaurant(
            "Demo",
            new Offering(
                new FoodItem(1.0M, "The Cheap One"),
                new FoodItem(2.0M, "The Mid One"),
                new FoodItem(3.0M, "The Expensive One")
            )
        );
    }

    private Button findFoodChoiceButton(FoodChoice foodChoice)
    {
        return GetNode<Button>($"FoodChoice{foodChoice}");
    }

    private void foodChoiceMidPressed()
    {
        GD.Print(nameof(foodChoiceMidPressed));
    }

    private void foodChoiceExpensivePressed()
    {
        GD.Print(nameof(foodChoiceExpensivePressed));
    }

    private void foodChoiceCheapPressed()
    {
        GD.Print(nameof(foodChoiceCheapPressed));
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}

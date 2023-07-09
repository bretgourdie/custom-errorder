using customerrorder.Common;
using Godot;
using System;

namespace customerrorder.RestaurantSelection;
public partial class RestaurantSelection : Node2D
{
    private const string pressed = "pressed";
    private const string InRestaurantScene = "InRestaurant/InRestaurant.tscn";

    private Restaurant fastFood;
    private Restaurant casual;
    private Restaurant sitDown;
    private Restaurant highDining;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        fastFood = new Restaurant(
            "FastFood",
            new Offering(
                new FoodItem(1.5m, "Milkshake"),
                new FoodItem(2.0m, "Fries"),
                new FoodItem(4.0m, "Burger")
            )
        );

        casual = new Restaurant(
            "Casual",
            new Offering(
                new FoodItem(2.3m, "Chips and Queso"),
                new FoodItem(4.0m, "The Guac"),
                new FoodItem(7.5m, "Burrito")
            )
        );

        sitDown = new Restaurant(
            "SitDown",
            new Offering(
                new FoodItem(5.25m, "Loaded Fries"),
                new FoodItem(7.85m, "Craft Beer"),
                new FoodItem(12.05m, "The Craft Hot Dog")
            )
        );

        highDining = new Restaurant(
            "HighDining",
            new Offering(
                new FoodItem(6.50m, "Hummus and Pita"),
                new FoodItem(15.00m, "Old Fashioned (our way)"),
                new FoodItem(23.00m, "The Half Chicken")
            )
        );

        findRestaurantButton(fastFood).Pressed += onFastFoodPressed;
        findRestaurantButton(casual).Pressed += onCasualPressed;
        findRestaurantButton(sitDown).Pressed += onSitDownPressed;
        findRestaurantButton(highDining).Pressed += onHighDiningPressed;
        Context.LoadHUD(GetNode<Control>("HUD"));
    }

    private Button findRestaurantButton(Restaurant restaurant)
    {
        return GetNode<Button>(restaurant.ToString());
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    public void onFastFoodPressed()
    {
        Context.ClickedRestaurant(fastFood);
        GetTree().ChangeSceneToFile(InRestaurantScene);
    }

    public void onCasualPressed()
    {
        Context.ClickedRestaurant(casual);
        GetTree().ChangeSceneToFile(InRestaurantScene);
    }

    public void onSitDownPressed()
    {
        Context.ClickedRestaurant(sitDown);
        GetTree().ChangeSceneToFile(InRestaurantScene);
    }

    public void onHighDiningPressed()
    {
        Context.ClickedRestaurant(highDining);
        GetTree().ChangeSceneToFile(InRestaurantScene);
    }
}

using customerrorder.Common;
using Godot;
using System;

namespace customerrorder.RestaurantSelection;
public partial class RestaurantSelection : Node2D
{
    private const string pressed = "pressed";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        findRestaurantButton(Restaurant.FastFood).Pressed += onFastFoodPressed;
        findRestaurantButton(Restaurant.Casual).Pressed += onCasualPressed;
        findRestaurantButton(Restaurant.SitDown).Pressed += onSitDownPressed;
        findRestaurantButton(Restaurant.HighDining).Pressed += onHighDiningPressed;
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
        GD.Print(nameof(onFastFoodPressed));
        GetTree().ChangeSceneToFile("InRestaurant/InRestaurant.tscn");
    }

    public void onCasualPressed()
    {
        GD.Print(nameof(onCasualPressed));
        GetTree().ChangeSceneToFile("InRestaurant/InRestaurant.tscn");
    }

    public void onSitDownPressed()
    {
        GD.Print(nameof(onSitDownPressed));
        GetTree().ChangeSceneToFile("InRestaurant/InRestaurant.tscn");
    }

    public void onHighDiningPressed()
    {
        GD.Print(nameof(onHighDiningPressed));
        GetTree().ChangeSceneToFile("InRestaurant/InRestaurant.tscn");
    }
}

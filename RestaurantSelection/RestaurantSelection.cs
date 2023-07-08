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
        Context.ClickedRestaurant(Restaurant.FastFood);
        GetTree().ChangeSceneToFile("InRestaurant/InRestaurant.tscn");
    }

    public void onCasualPressed()
    {
        Context.ClickedRestaurant(Restaurant.Casual);
        GetTree().ChangeSceneToFile("InRestaurant/InRestaurant.tscn");
    }

    public void onSitDownPressed()
    {
        Context.ClickedRestaurant(Restaurant.SitDown);
        GetTree().ChangeSceneToFile("InRestaurant/InRestaurant.tscn");
    }

    public void onHighDiningPressed()
    {
        Context.ClickedRestaurant(Restaurant.HighDining);
        GetTree().ChangeSceneToFile("InRestaurant/InRestaurant.tscn");
    }
}

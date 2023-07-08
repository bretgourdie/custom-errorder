using Godot;
using System;

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
	}

	public void onCasualPressed()
	{
		GD.Print(nameof(onCasualPressed));
	}

	public void onSitDownPressed()
	{
		GD.Print(nameof(onSitDownPressed));
	}

	public void onHighDiningPressed()
	{
		GD.Print(nameof(onHighDiningPressed));
	}

	private enum Restaurant
	{
		FastFood,
		Casual,
		SitDown,
		HighDining
	}
}

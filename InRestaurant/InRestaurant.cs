using Godot;
using System;

public partial class InRestaurant : Node2D
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        findFoodChoiceButton(FoodChoice.Cheap).Pressed += foodChoiceCheapPressed;
        findFoodChoiceButton(FoodChoice.Mid).Pressed += foodChoiceMidPressed;
        findFoodChoiceButton(FoodChoice.Expensive).Pressed += foodChoiceExpensivePressed;
    }

    private Button findFoodChoiceButton(FoodChoice foodChoice)
    {
        return GetNode<Button>($"MenuBackground/FoodChoice{foodChoice}");
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

    private enum FoodChoice
    {
        Cheap,
        Mid,
        Expensive
    }
}
using customerrorder.Common;
using Godot;
using System;
using customerrorder.RestaurantSelection;
using System.Collections.Generic;
using System.Linq;

namespace customerrorder.InRestaurant;
public partial class InRestaurant : Node2D
{
    private Restaurant clickedRestaurant;

    private Stack<FoodItem> cart = new Stack<FoodItem>();
    private Label totalDisplay;

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

        GetNode<Button>("RemoveLastItemButton").Pressed += removeLastItemButtonPressed;
        totalDisplay = GetNode<Label>("TotalWordLabel/TotalDisplay");

        Context.LoadHUD(GetNode<Control>("HUD"));

    }

    private void removeLastItemButtonPressed()
    {
        if (cart.Any())
        {
            cart.Pop();
        }

        recalculateTotal();
    }

    private void recalculateTotal()
    {
        totalDisplay.Text = $"${cart.Sum(x => x.Price)}";
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
        cart.Push(clickedRestaurant.Offering.MidItem);
        recalculateTotal();
    }

    private void foodChoiceExpensivePressed()
    {
        cart.Push(clickedRestaurant.Offering.ExpensiveItem);
        recalculateTotal();
    }

    private void foodChoiceCheapPressed()
    {
        cart.Push(clickedRestaurant.Offering.CheapItem);
        recalculateTotal();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}

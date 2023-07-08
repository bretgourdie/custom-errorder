using Godot;
using customerrorder.RestaurantSelection;

namespace customerrorder.Common;
internal class Context
{
    private static Context _instance;

    private int happiness;
    private int money;
    private Restaurant lastClickedRestaurant;

    public static int Happiness => _instance.happiness;
    public static int Money => _instance.money;
    public static Restaurant LastClickedRestaurant => _instance.lastClickedRestaurant;

    public static Context Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Context();
            }

            return _instance;
        }
    }

    public Context()
    {
        happiness = 65;
        money = 30;
    }

    public static void LoadHUD(Control hud)
    {
        var happinessBarNode = hud.FindChild("HappinessBar");
        var happinessTextureProgressBar = (TextureProgressBar)happinessBarNode.FindChild("HappinessBar");
        happinessTextureProgressBar.Value = Instance.happiness;

        var moneyDisplayNode = hud.FindChild("MoneyDisplay");
        var amountLabel = (Label)moneyDisplayNode.FindChild("Amount", recursive: true);
        amountLabel.Text = Instance.money.ToString();
    }

    public static void ClickedRestaurant(Restaurant restaurant)
    {
        _instance.lastClickedRestaurant = restaurant;
    }

    public static void Reset()
    {
        _instance = new Context();
    }
}

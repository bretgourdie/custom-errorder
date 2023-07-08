using Godot;

namespace customerrorder.Common;
internal class Context
{
    private static Context _instance;

    public int Happiness { get; private set; }
    public int Money { get; private set; }

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
        Happiness = 25;
        Money = 30;
    }

    public static void LoadHUD(Control hud)
    {
        var happinessBarNode = hud.FindChild("HappinessBar");
        var happinessTextureProgressBar = (TextureProgressBar)happinessBarNode.FindChild("HappinessBar");
        happinessTextureProgressBar.Value = Instance.Happiness;

        var moneyDisplayNode = hud.FindChild("MoneyDisplay");
        var amountLabel = (Label)moneyDisplayNode.FindChild("Amount", recursive: true);
        amountLabel.Text = Instance.Money.ToString();
    }

    public static void Reset()
    {
        _instance = new Context();
    }
}

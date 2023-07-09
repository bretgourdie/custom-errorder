using customerrorder.Common;

namespace customerrorder.RestaurantSelection;
internal struct Restaurant
{
    public readonly string Name;
    public readonly Offering Offering;

    public Restaurant(
        string name,
        Offering offering)
    {
        Name = name;
        Offering = offering;
    }

    public override string ToString()
    {
        return Name;
    }
}

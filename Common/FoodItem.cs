namespace customerrorder.Common;
internal struct FoodItem
{
    public readonly decimal Price;
    public readonly string Picture;

    public FoodItem(decimal price, string picture)
    {
        Price = price;
        Picture = picture;
    }
}

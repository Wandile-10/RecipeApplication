class Ingredient
{
    public string Name { get; }
    public double Quantity { get; set; }
    public string Unit { get; }

    public Ingredient(string name, double quantity, string unit)
    {
        Name = name;
        Quantity = quantity;
        Unit = unit;
    }
}



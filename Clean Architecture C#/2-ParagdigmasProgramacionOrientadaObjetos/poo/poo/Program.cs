
Beer beer = new Beer
{
    Name = "Heineken",
    Price = 5.99m
};

var coronaBeer = new Beer();
coronaBeer.Name = "Corona";
coronaBeer.Price = 6.99m;

Console.WriteLine(beer.Name);
Console.WriteLine(coronaBeer.Name + " $ " + coronaBeer.Price);
Console.WriteLine(beer.GetInfo());

public class Beer
{
    public string Name { get; set; }
    public decimal Price { get; set; } 

    public string GetInfo() 
    {
        return "Nombre:" + Name + ", Precio: $ " + Price;
    }
}
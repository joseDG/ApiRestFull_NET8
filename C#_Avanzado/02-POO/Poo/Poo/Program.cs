
Beer biela = new Beer("biela", 20);
{
    
};

biela.Name = "Biela";
biela.Price = 3;

Console.WriteLine(biela.Name + " $ " + biela.Price);
Console.WriteLine(biela.GetInfo());

public class Beer
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Beer(string Name, decimal price) 
    {
        this.Name = Name;
        this.Price = price;
    }

    public string GetInfo() {
        return "Nombre: " + Name + ", Precio: " + Price;
    }
    
}
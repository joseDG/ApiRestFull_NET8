
LimitedBeerData beerData = new LimitedBeerData(2);
beerData.Add("Corona");
beerData.Add("Delirium");
beerData.Add("Heineken"); 
//Generar reporte
var reportGeneratorBeer = new ReportGeneratorBeer(beerData);
var reportGeneratorBeerHtml = new ReportGeneratorBeerHtml(beerData);
var report = new Report();
var data = reportGeneratorBeer.Generate();
//report.Save(reportGeneratorBeer, "cervezas.txt");
report.Save(reportGeneratorBeerHtml, "cervezas.html");

//Crear un interfaz se usa en el segundo principio
public interface IReportGenerator
{
    public string Generate();
}

public class BeerData
{
    protected List<string> _beers;
    
    public BeerData()
    {
        _beers = new List<string>();
    }

    public virtual void Add(string beer)
        => _beers.Add(beer);

    public List<string> Get()
        => _beers;

}

//aplicando la 3 principio
public class  LimitedBeerData : BeerData
{
    private int _limit;

    public LimitedBeerData(int limit)
    {
        _limit = limit;
    }

    public override void Add(string beer)
    {
        if (_beers.Count < _limit)
        {
            base.Add(beer);
        }
        else
        {
            throw new Exception("No se pueden agregar más cervezas");
        }
    }
}

//aplicando composicion
public class LimitedBeerData2
{
   private BeerData _beerData = new BeerData();
   private int _limit;
   private int _count = 0;

   public LimitedBeerData2(int limit)
   {
        _limit = limit;
   }

   public void Add(string beer)
   {
        if (_count < _limit)
        {
            _beerData.Add(beer);
            _count++;
        }
        else
        {
            throw new Exception("No se pueden agregar más cervezas");
        }
   }
}

public class ReportGeneratorBeer : IReportGenerator
{
    private BeerData _beerData;

    public ReportGeneratorBeer(BeerData beerData)
    {
        _beerData = beerData;
    }

    public string Generate()
    {
        string data = "";
        foreach (var beer in _beerData.Get())
        {
            data += "Cerveza: " + beer + Environment.NewLine;
        }
        return data;
    }
}

//crear un repoirte en html
public class ReportGeneratorBeerHtml : IReportGenerator
{
    private BeerData _beerData;
    public ReportGeneratorBeerHtml(BeerData beerData)
    {
        _beerData = beerData;
    }
    public string Generate()
    {
        string data = "<html><body>";
        foreach (var beer in _beerData.Get())
        {
            data += "<h1>Cerveza: " + beer + "</h1>";
        }
        data += "</body></html>";
        return data;
    }
}

//aplicando al segundo principio
public class Report
{
    public void Save(IReportGenerator reportGenerator, string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        {
            string data = reportGenerator.Generate();
            writer.WriteLine(data);
        }
    }
}

// 1 - Single Responsibility Principle 
//Se trata que una clase tenga una sola responsabilidad, es decir, que una clase no debe tener más de una razón para cambiar. En este caso, la clase Beer tiene dos responsabilidades: almacenar cervezas y generar un reporte. Para cumplir con este principio, se ha creado una nueva clase llamada ReportGeneratorBeer que se encarga de generar el reporte de las cervezas almacenadas en la clase Beer. De esta manera, la clase Beer solo se encarga de almacenar cervezas y la clase ReportGeneratorBeer se encarga de generar el reporte.

//2- Open / Closed Principle
//El principio de abierto/cerrado establece que una clase debe estar abierta para su extensión, pero cerrada para su modificación. En este caso, la clase Beer es cerrada para su modificación, ya que no se puede modificar su comportamiento sin cambiar su código. Sin embargo, la clase ReportGeneratorBeer es abierta para su extensión, ya que se puede extender para generar diferentes tipos de reportes sin modificar la clase Beer.

//3- Liskov Substitution Principle
//El principio de sustitución de Liskov establece que los objetos de una clase base deben poder ser reemplazados por objetos de una clase derivada sin afectar el comportamiento del programa. En este caso, la clase ReportGeneratorBeer es una clase base y la clase ReportGeneratorBeerHtml es una clase derivada. La clase ReportGeneratorBeerHtml puede ser utilizada en lugar de la clase ReportGeneratorBeer sin afectar el comportamiento del programa.

//4- Interface Segregation Principle
//El principio de segregación de interfaces establece que una clase no debe ser forzada a implementar interfaces que no utiliza. En este caso, la interfaz IReportGenerator es una interfaz que solo tiene un método, por lo que cumple con este principio. Si la interfaz tuviera más métodos, se podría dividir en varias interfaces más pequeñas para cumplir con este principio.

//5-  Dependency Inversion Principle
// El principio de inversión de dependencias establece que las clases de alto nivel no deben depender de clases de bajo nivel, sino que ambas deben depender de abstracciones. En este caso, la clase ReportGeneratorBeer depende de la clase BeerData, que es una clase de bajo nivel. Para cumplir con este principio, se ha creado una interfaz IReportGenerator que es una abstracción y la clase ReportGeneratorBeer depende de esta interfaz en lugar de depender directamente de la clase BeerData. De esta manera, se cumple con el principio de inversión de dependencias.
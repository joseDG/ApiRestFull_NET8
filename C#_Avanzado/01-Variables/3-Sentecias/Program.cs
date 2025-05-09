
var edad = 12;

if(edad >= 18)
{
    Console.WriteLine("Eres mayor de edad");
}
else
{
    Console.WriteLine("Eres menor de edad");
}


switch (edad)
{
    case 18:
        Console.WriteLine("Eres mayor de edad");
        break;
    case 17:
        Console.WriteLine("Eres menor de edad");
        break;
    default:
        Console.WriteLine("No se puede determinar la edad");
        break;
}
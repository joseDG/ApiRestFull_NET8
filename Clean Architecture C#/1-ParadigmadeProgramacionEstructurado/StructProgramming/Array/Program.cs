int[] numbers = new int[5];

numbers[0] = 1;
numbers[1] = 2;
numbers[2] = 3;
numbers[3] = 4;

//Otra forma declarar
var numbers2 = new int[5]
{
    1,2,3,4,5
};

Console.WriteLine(numbers[2]);


//if
var age = 12;

if(age > 60)
{
    Console.WriteLine("es dela tercera edad");
}
else
{
    Console.WriteLine("No es de la tercera edad");
}
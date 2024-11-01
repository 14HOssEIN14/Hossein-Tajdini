string food = "";
string sides = "";

Console.WriteLine("Be restorane ma khosh amadid!");
Console.WriteLine("Aya koobide mikhori? (y/n)");
var answer = Console.ReadKey().KeyChar;
Console.WriteLine();

if (answer == 'y')
{
    food = "Koobide";
}
else
{
    Console.WriteLine("Pas joje mikhori? (y/n)");
    answer = Console.ReadKey().KeyChar;
    Console.WriteLine();

    if (answer == 'y')
    {
        food = "Joje";
    }
    else
    {
        Console.WriteLine("ghorme sabzi chetor?? (y/n)");
        answer = Console.ReadKey().KeyChar;
        Console.WriteLine();
        if (answer == 'y')
        {
            food = "Ghorme Sabzi";
        }
        else
        {
            Console.WriteLine("koft mikhori???? pasho gomsho biron!!!");
            return;
        }
    }
}

Console.WriteLine("Aya sabzi mikhori? (y/n)");
answer = Console.ReadKey().KeyChar;
Console.WriteLine();
if (answer == 'y')
{
    sides += "Sabzi, ";
}

Console.WriteLine("Aya mast mikhori? (y/n)");
answer = Console.ReadKey().KeyChar;
Console.WriteLine();
if (answer == 'y')
{
    sides += "Mast, ";
}

Console.WriteLine("Aya salad mikhori? (y/n)");
answer = Console.ReadKey().KeyChar;
Console.WriteLine();
if (answer == 'y')
{
    sides += "Salad, ";
}


Console.WriteLine($"Shoma ghazaye {food} ba mokhalafate {sides} sefaresh dadi. Alan Hazer Mishe!");
    
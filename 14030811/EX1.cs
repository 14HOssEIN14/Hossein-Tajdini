int n;
int m;
while (true)
{
    n = GetNum("Please Enter n");
    m = GetNum("Please Enter m");
    if(n<=0||m<=0)
        Console.WriteLine("Please enter a positive integer for n&m");
    else if(n==m)
        Console.WriteLine("n Should not be equal to m");
    else
    {
        break;
    }
}
Console.Clear();
Console.WriteLine($"n={n}\nm={m}");
if (n > m)
{
    for (int i =m ; i < n; i++)
    {
        if (i != 1&&i!=2)
            IsPrime(i);
        else if(i==2)
            Console.WriteLine("2 is prime");
    }
}
else
{
    for (int i =n ; i <= m; i++)
    {
        if (i != 1&&i!=2)
            IsPrime(i);
        else if(i==2)
            Console.WriteLine("2 is prime");
    }
}

void IsPrime(int number)
{
    for (int j = 2; j <= Math.Sqrt(number); j++)
    {
        if (number%j==0)
        {
            return; 
        }
    }
    Console.WriteLine($"{number} is prime");
}
int GetNum(string message)
{
    char key;
    ConsoleKeyInfo keyboard;
    string number="";
    Console.WriteLine(message);
    do
    {
   
        keyboard= Console.ReadKey(true);
        if (keyboard.Key == ConsoleKey.Backspace&&number!="")
        {
            number=number.Remove(number.Length-1,1);
            Console.Clear();
            Console.Write(number);
        }
        key = keyboard.KeyChar;
        if (IsNum(key))
        {
            Console.Clear();
            Console.WriteLine(message);
            number += key.ToString();
            Console.Write(number);
      
        }
   
    }while(keyboard.Key!=ConsoleKey.Enter); 
    Console.Clear();
    if (number != "")
        return Convert.ToInt32(number);
    else
        return 0;
}

bool IsNum(char Key)
{
    for (int i = 0; i < 10; i++)
    {
        if (Key == (i + 48))
        {
            return true;
        }
    }

    return false;
}
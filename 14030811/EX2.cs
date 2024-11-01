int n;
int m;
while (true)
{
    n = GetNum("Please Enter n");
    m = GetNum("Please Enter m");
    if (n <= 0 || m <= 0)
    {
        Console.Clear();
        Console.WriteLine("Please enter a positive integer for n&m");
    }
    else if (n == m)
    {
        Console.Clear();
        Console.WriteLine("n Should not be equal to m");
    }
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
        if (i >=10)
            IsPalindrome(i);
        else 
            Console.WriteLine($"{i} is palindrome");
    }
}
else
{
    for (int i =n ; i <= m; i++)
    {
        if (i >=10)
            IsPalindrome(i);
        else 
            Console.WriteLine($"{i} is palindrome");
    }
}


void IsPalindrome(int number)
{
    int m = 0;
    int R=number;
    while (R>0)
    {
        int LN = R % 10;
        m = (m * 10) + LN;
        R = R / 10;
    }

    if (m == number)
    {
        Console.WriteLine($"{number} is palindrome");  
    }
    
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
        if (Key == (i+48))
        {
            return true;
        }
    }
    return false;
}
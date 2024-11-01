int a1 = GetNum("Please Enter a1");
int a2 = GetNum("Please Enter a2");
int n = GetNum("Please Enter n");

Console.WriteLine($"n={n}\na1={a1}\na2={a2}");
      
CheckN();


void CheckN()
{

    int a3 = 0;
    while (n >= a3)
    {
        a3 = a1 + a2;
         if (n == a3)
        {
            Console.WriteLine($"{n} is Exsist in your Fibonacci Sequence");
            return;
            
        }

        a1 = a2;
        a2 = a3;

    } 
    Console.WriteLine($"{n} is not Exsist in your Fibonacci Sequence");
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
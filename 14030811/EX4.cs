char key;
ConsoleKeyInfo keyboard;
string number="";
Console.WriteLine("Please Enter Number....");
do
{
   
    keyboard= Console.ReadKey(true);
    if (keyboard.Key == ConsoleKey.Backspace&&number!="")
    {
        number=number.Remove(number.Length-1,1);
        Console.Clear();
        Console.WriteLine("Please Enter Number....");
        Console.Write(number);
    }
    else
    { 
        key = keyboard.KeyChar;
        if (IsNum(key))
        {
            Console.Clear();
            number += key.ToString();
            Console.WriteLine("Please Enter Number....");
            Console.Write(number);

        }
    }

}while(keyboard.Key!=ConsoleKey.Enter);

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
char key;
ConsoleKeyInfo keyboard;
string text="";
Console.WriteLine("Please Enter Text....");
do
{
   
    keyboard= Console.ReadKey(true);
    if (keyboard.Key == ConsoleKey.Backspace&&text!="")
    {
        text=text.Remove(text.Length-1,1);
        Console.Clear();
        Console.WriteLine("Please Enter Text....");
        Console.Write(text);
    }
    else
    {
        key = keyboard.KeyChar;
        if (!IsNum(key))
        {
            Console.Clear();
            text += key.ToString();
            Console.WriteLine("Please Enter Text....");
            Console.Write(text);

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
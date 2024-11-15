using System.Numerics;
using System;
using TopLevelStatements;

namespace ConsoleApp2;

public class Keyboard
{
  //  public Program program=new Program();
   public BigInteger GetNum()
    {
        ConsoleKeyInfo keyboard = default;
        string number = "";
        Console.WriteLine("Please Enter Number....");
        do
        {
            keyboard = Console.ReadKey(true);
            if (keyboard.Key == ConsoleKey.Backspace && number != "")
            {
                number = number.Remove(number.Length - 1, 1);
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(number);
            }
            else
            {
                if (char.IsDigit(keyboard.KeyChar))
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    number += keyboard.KeyChar.ToString();
                    Console.Write(number);
                }
            }
        } while (keyboard.Key != ConsoleKey.Enter);

        return Convert.ToInt64(number);
    }

    public bool GetYorN()
    {
        ConsoleKeyInfo Keyboard = default;

        do
        {
            Console.WriteLine("Please Enter y For(Yes) n For (No)");
            Keyboard = Console.ReadKey(true);
            if (Keyboard.KeyChar == 'y')
            {
                Console.WriteLine(Keyboard.KeyChar);
                return true;
            }
            else if (Keyboard.KeyChar == 'n')
            {
                Console.WriteLine(Keyboard.KeyChar);
                return false;
            }
        } while (true);
    }

    public void GetHomeKey()
    { 
        Console.Clear();
        ConsoleKeyInfo Keyboard = default;
        Console.WriteLine("A: Calculate PrimeNumber Section \n" +
                          "B: Calculate PalindromeNumber Section \n" +
                          "C: DecisionTree Section \n" +
                          "E: Exit ");
        do
        {
            Keyboard = Console.ReadKey(true);
            switch (Keyboard.Key)
            {
                case ConsoleKey.A:
                   Program.PrimeChecker();
                    break;
                case ConsoleKey.B:
                    Program.PalinChecker();
                    break;
                case ConsoleKey.C:
                    Program.DecisionTree();
                    break;
                case ConsoleKey.E:
                    Console.Beep();
                    Console.Beep();
                    Environment.Exit(0);
                    break;
            }
        } while (ConsoleKey.E != Keyboard.Key);
        
    }

   
}
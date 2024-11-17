using System.Numerics;
using System;
using TopLevelStatements;

namespace ConsoleApp2;

public static class Keyboard
{
    public static Program program=new Program();
   public static uint GetNum()
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

        return Convert.ToUInt32(number);
    }

    public static bool GetYorN()
    {
        ConsoleKeyInfo Keyboard = default;

        do
        {
            Console.WriteLine("Please Enter y For(Yes) n For (No)");
            Keyboard = Console.ReadKey(true);
            if (Keyboard.Key == ConsoleKey.Y)
            {
                Console.WriteLine(Keyboard.KeyChar);
                return true;
            }
            else if (Keyboard.Key == ConsoleKey.N)
            {
                Console.WriteLine(Keyboard.KeyChar);
                return false;
            }
        } while (true);
    }

    public static void GetHomeKey()
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
                   program.PrimeChecker();
                    break;
                case ConsoleKey.B:
                    program.PalinChecker();
                    break;
                case ConsoleKey.C:
                    program.DecisionTree();
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
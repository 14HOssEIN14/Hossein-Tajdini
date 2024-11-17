using ConsoleApp2;
using System;
using System.Threading;

namespace TopLevelStatements;

public class Program
{
    public Calculator MyCalc;
    private static DecisionTree tree = new DecisionTree();

    public static void Main(string[] args)
    {
        Keyboard.GetHomeKey();
    }

    public void PrimeChecker()
    {
        Console.Clear();
        Console.WriteLine("PRIME CHECKER");
        int num = (int)Keyboard.GetNum();
        if (num < 1000)
        {
            MyCalc = CalcFactory.CreateCalculator("SimplePrime"); 
        }
        else
        {
            MyCalc = CalcFactory.CreateCalculator("ProPrime"); 
        }
        
        bool Check = MyCalc.IsTrue(num);
        FunnySound();
        if (Check)
        {
            Console.WriteLine($"{num} IsPrime");
        }
        else
        {
            Console.WriteLine($"{num} IsNotPrime");
        }

        Console.WriteLine("Do you want to back HomePage(y) or Test another number?(n)");
        if (!Keyboard.GetYorN())
        {
            Console.Clear();
            PrimeChecker();
        }
        else
        {
            Keyboard.GetHomeKey();
        }
    }

    public void PalinChecker()
    {
        Console.Clear();
        Console.WriteLine("Palindrome CHECKER");
        Console.WriteLine("Do you want to use the initial method to calculate palindrome numbers? (Yes/No)");
        if (Keyboard.GetYorN())
        {
            MyCalc = CalcFactory.CreateCalculator("Palin1");
        }
        else
        {
            MyCalc = CalcFactory.CreateCalculator("Palin2");
        }
        
        
        int num = (int) Keyboard.GetNum();
        bool Check = MyCalc.IsTrue(num);
        FunnySound();
        if (Check)
        {
            Console.WriteLine($"{num} IsPalindrome");
        }
        else
        {
            Console.WriteLine($"{num} IsNotPalindrome");
        }

        Console.WriteLine("Do you want to back HomePage(y) or Test another number?(n)");
        if (!Keyboard.GetYorN())
        {
            Console.Clear();
            PalinChecker();
        }
        else
        {
            Keyboard.GetHomeKey();
        }
    }

    public void DecisionTree()
    {
        Loading();
        Console.Clear();
        tree.MyTree();
        Console.WriteLine("Do you want to back HomePage(y) or PlayAgain?(n)");
        if (!Keyboard.GetYorN())
        {
            Console.Clear();
            DecisionTree();
        }
        else
        {
            Keyboard.GetHomeKey();
        }
    }

    static void FunnySound()
    {
        Console.Clear();
        string[] messages =
        {
            "Calculating",
            "Calculating.",
            "Calculating..",
            "Calculating...",
            "Calculating",
            "Calculating.",
            "Calculating..",
            "Calculating...",
            "Calculating",
            "Calculating.",
        };
        for (int i = 0; i < 10; i++)
        {
            int frequency = new Random().Next(300, 1500);
            int duration = new Random().Next(50, 200);
            Console.Beep(frequency, duration);


            Thread.Sleep(new Random().Next(50, 150));
        }

        foreach (var msg in messages)
        {
            Console.WriteLine(msg);
            Thread.Sleep(150);
            Console.Clear();
        }
    }

    static void Loading()
    {
        Console.Clear();
        string[] messages =
        {
            "Loading",
            "Loading.",
            "Loading..",
            "Loading...",
            "Loading",
            "Loading.",
            "Loading..",
            "Loading...",
            "Loading",
            "Loading.",
        };
        foreach (var msg in messages)
        {
            Console.WriteLine(msg);
            Thread.Sleep(150);
            Console.Clear();
        }
    }
}
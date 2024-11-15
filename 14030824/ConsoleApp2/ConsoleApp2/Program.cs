using ConsoleApp2;
using System;
using System.Threading;

namespace TopLevelStatements;

public class Program
{
    static Keyboard key = new Keyboard();
    static Prime prime = new Prime();
    static Palindrome palin = new Palindrome();
    private static DecisionTree tree = new DecisionTree();

    public static void Main(string[] args)
    {
        key.GetHomeKey();
    }

    public static void PrimeChecker()
    {
        Console.Clear();
        Console.WriteLine("PRIME CHECKER");
        int num = (int) key.GetNum();
        bool Check = prime.IsTrue(num);
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
        if (!key.GetYorN())
        {
            Console.Clear();
            PrimeChecker();
        }
        else
        {
            key.GetHomeKey();
        }
    }

    public static void PalinChecker()
    {
        Console.Clear();
        Console.WriteLine("Palindrome CHECKER");
        int num = (int) key.GetNum();
        bool Check = palin.IsTrue(num);
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
        if (!key.GetYorN())
        {
            Console.Clear();
            PalinChecker();
        }
        else
        {
            key.GetHomeKey();
        }
    }

    public static void DecisionTree()
    {
        Loading();
        Console.Clear();
        tree.MyTree();
        Console.WriteLine("Do you want to back HomePage(y) or PlayAgain?(n)");
        if (!key.GetYorN())
        {
            Console.Clear();
            DecisionTree();
        }
        else
        {
            key.GetHomeKey();
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
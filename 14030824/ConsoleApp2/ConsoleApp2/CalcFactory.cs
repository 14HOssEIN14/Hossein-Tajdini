using System;

namespace ConsoleApp2;

public class CalcFactory
{
    public static Calculator CreateCalculator(string myType)
    {
        switch (myType)
        {
            case "Palin1":
                return new Palindrome_1();
                break;
            case "Palin2":
                return new Palindrome_2();
                break;
            case "SimplePrime":
                return new SimplePrime();
                break;
            case "ProPrime":
                return new ProPrime();
                break;

            default:
                throw new Exception("YourType isnot Valid");
        }
    }
}
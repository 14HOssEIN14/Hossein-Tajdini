using System;

namespace ConsoleApp2;

public class Prime : Calculator
{
    private Keyboard key = new Keyboard();

    public override bool IsTrue(int Num)
    {
        if (Num < 1000)
        {
            return IsPrime01(Num);
        }
        else
        {
            return IsPrime02(Num);
        }
    }

    public bool IsPrime02(int Num)
    {
        for (int i = 2; i < Math.Sqrt(Num); i++)
        {
            if (Num % i == 0)
            {
                return false;
            }
        }

        return true;
    }

    public bool IsPrime01(int Num)
    {
        for (int i = 2; i < Num; i++)
        {
            if (Num % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}
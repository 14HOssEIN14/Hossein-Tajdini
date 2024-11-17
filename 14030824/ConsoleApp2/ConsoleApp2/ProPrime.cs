using System;

namespace ConsoleApp2;

public class ProPrime:Calculator
{
    public override bool IsTrue(int Num)
    {
        bool _result=true;
        for (int i = 2; i < Math.Sqrt(Num); i++)
        {
            if (Num % i == 0)
            {
                _result= false;
            }
        }

        return _result;
    }
}
using System;

namespace ConsoleApp2;

public class SimplePrime : Calculator
{
  

    public override bool IsTrue(int Num)
    {
        bool _result=true;
        for (int i = 2; i < Num; i++)
        {
            if (Num % i == 0)
            {
               _result= false;
            }
        }

        return _result;
    }

    

   
}
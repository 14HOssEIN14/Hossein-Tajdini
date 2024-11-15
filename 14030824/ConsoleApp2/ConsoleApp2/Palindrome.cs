using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp2;

public class Palindrome : Calculator
{
    public override bool IsTrue(int Num)
    {
        if (Num < 10000)
        {
            return Palin02(Num);//bekhatere converting kond tare
        }
        else
        {
          return  Palin01(Num);//behine tare
        }
    }

    public bool Palin01(int Num)
    { 
       
        int reversedHalf = 0;

        while (Num > reversedHalf)
        {
          
            reversedHalf = reversedHalf * 10 + Num % 10;
            Num /= 10;
        }

        if (Num == reversedHalf || Num == reversedHalf / 10)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool Palin02(int Num)
    {
        if (Num < 0 || (Num <= 10))
        {
            return false;
        }
        string num = Num.ToString();
        return num.SequenceEqual(num.Reverse());
    }
}
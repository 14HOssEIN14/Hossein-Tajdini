using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp2;

public class Palindrome_1 : Calculator
{ 
    public override bool IsTrue(int Num)
    {
        bool _result = false;
        int reversedHalf = 0;

        while (Num > reversedHalf)
        {
          
            reversedHalf = reversedHalf * 10 + Num % 10;
            Num /= 10;
        }

        if (Num == reversedHalf || Num == reversedHalf / 10)
        {
            _result=true;
        }

        return _result;

    }
    
}
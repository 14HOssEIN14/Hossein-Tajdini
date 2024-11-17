
using System.Linq;

namespace ConsoleApp2;

public class Palindrome_2 : Calculator
{
    public override bool IsTrue(int Num)
    {
        bool _result=true;
        if (Num < 0 || (Num <= 10))
        {
            _result= false;
        }
        string num = Num.ToString();
        _result= num.SequenceEqual(num.Reverse());
        return _result;
    }
}
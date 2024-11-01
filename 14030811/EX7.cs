string txt = "Hello, my phone number is 0123456789, my address is rue Voltaire 145 the number 1234567890 is not va+" +
             " Contact the number 0147258369 if you have any question the number 012345678 is not valid anymore." +
             "Contact the number 0999999888 if you have any question Our customer care representatives are available"+
             " to assist you 24 hours a day, 7 days a week on : 0000000000, 9999999999 and 0777778899";
int counter = 0;
string numberTXT=string.Empty;
foreach (char letter in txt+" ")
{
    if (IsNum(letter))
    {
        numberTXT += letter;
        counter++;
    }else if(counter == 10)
    {
            if (numberTXT[0] == '0')
            {
                char firstChar = numberTXT[0];
                foreach (char c in numberTXT)
                {
                    if (c != firstChar)
                    {
                        if (numberTXT != string.Empty)
                        {
                            Console.WriteLine(numberTXT);
                        }
                        counter = 0;
                        numberTXT = string.Empty; 
                    } 
                }
            }
            counter = 0;
            numberTXT = string.Empty; 
    }
    else
    {
        counter = 0;
        numberTXT = string.Empty; 
    }
    
  
}

bool IsNum(char Key)
{
    for (int i = 0; i < 10; i++)
    {
        if (Key == (i+48))
        {
            return true;
        }
    }
    return false;
}
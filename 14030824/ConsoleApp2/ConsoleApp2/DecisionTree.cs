using System;

namespace ConsoleApp2;

public class DecisionTree
{
    public void MyTree()
    {
        int i = 0;
        do
        {
            switch (i)
            {
                case 0:
                    Console.WriteLine("Ye Mashinhesab bezar dame dastet");
                    break;
                case 1:
                    Console.WriteLine("Be sen khodet fekr kon vali be man nagoo.");
                    break;
                case 2:
                    Console.WriteLine("Sento dar 5 zarb kon.");
                    break;
                case 3:
                    Console.WriteLine("Hale be natije 8 ta ezafe kon.");
                    break;
                case 4:
                    Console.WriteLine("Hale natije ro dar 2 zarb kon.");
                    break;
                case 5:
                    Console.WriteLine("Hale az natije 10 ta kam kon.");
                    break;
                case 6:
                    Console.WriteLine("Hale be ye adade 3raghami residi ");
                    break;
                case 7:
                    Console.WriteLine("2 ragham samte chap senete hal kardi.");
                    break;
                default:
                    return;
            }

            Console.ReadKey();
            Console.WriteLine();
            i++;
        } while (true);
    }
}
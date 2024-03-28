using System.Linq.Expressions;

namespace Exercise2___hadasim
{
    internal class Exercise2
    {
        static void Main(string[] args)
        {
            
            TwitterTowers();


            void TwitterTowers()
            {
                int choice = 0, towerHeight, towerWidth;
                Console.WriteLine("to a rectangular tower - press 1, to a triangle tower - press 2");
                choice = int.Parse(Console.ReadLine());
                while (choice == 1 || choice == 2) 
                {


                    Console.WriteLine("enter the height of the tower.");
                    towerHeight = int.Parse(Console.ReadLine());
                    while (towerHeight < 2)
                    {
                        Console.WriteLine("enter the height of the tower.(minimum 2)");
                        towerHeight = int.Parse(Console.ReadLine());
                    }
                    Console.WriteLine("enter the width  of the tower.");
                    towerWidth = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            {
                                if (towerHeight > towerWidth + 5 || towerWidth > towerHeight + 5)
                                {
                                    Console.WriteLine("the perimeter is: " + 2 * (towerWidth + towerHeight));
                                }
                                else
                                {
                                    Console.WriteLine("the area is: " + towerHeight * towerWidth);
                                }
                                break;
                            }
                        case 2:
                            {
                                int res;
                                Console.WriteLine("Calculate the perimeter of the triangle? yes - press 1, no - press 2");
                                res = int.Parse(Console.ReadLine());
                                if (res == 1)
                                {
                                    Console.WriteLine("the perimeter of the triangle is: " + (2 * towerHeight + towerWidth));
                                }
                                Console.WriteLine("print the triangle? yes - press 1, no - press 2");
                                res = int.Parse(Console.ReadLine());
                                if (res == 1)
                                {
                                    if (towerWidth % 2 == 0 || towerWidth > towerHeight * 2)
                                    {
                                        Console.WriteLine("the triangle cannot be printed");
                                    }
                                    else
                                    {
                                        for (int i = 1; i <= towerWidth; i += 2)
                                        {
                                            if (i == 1)
                                            {
                                                for (int k = 0; k < towerWidth / 2; ++k) Console.Write(' ');
                                                Console.Write('*');
                                                for (int k = 0; k < towerWidth / 2; ++k) Console.Write(' ');
                                                Console.WriteLine();
                                            }
                                            else if (i == towerWidth)
                                            {
                                                for (int j = 0; j < towerWidth; ++j) Console.Write('*');
                                                Console.WriteLine();
                                            }
                                            else
                                            {
                                                for (int j = 0; j < (towerHeight - 2) / (towerWidth / 2 - 1); ++j)
                                                {
                                                    for (int k = 0; k < (towerWidth - i) / 2; ++k) Console.Write(' ');
                                                    for (int k = 0; k < i; ++k) Console.Write('*');
                                                    for (int k = 0; k < (towerWidth - i) / 2; ++k) Console.Write(' ');
                                                    Console.WriteLine();
                                                }
                                            }
                                            if (i == 1 && (towerHeight - 2) % (towerWidth / 2 - 1) != 0)
                                            {
                                                for (int j = 0; j < (towerHeight - 2) % (towerWidth / 2 - 1); ++j)
                                                {
                                                    for (int k = 0; k < (towerWidth - (i + 2)) / 2; ++k) Console.Write(' ');
                                                    for (int k = 0; k < i + 2; ++k) Console.Write('*');
                                                    for (int k = 0; k < (towerWidth - (i + 2)) / 2; ++k) Console.Write(' ');
                                                    Console.WriteLine();
                                                }
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                        default:
                            break;
                    }
                    Console.WriteLine("to a rectangular tower - press 1, to a triangle tower - press 2");
                    choice = int.Parse(Console.ReadLine());
                }

            }
        }
    }
}
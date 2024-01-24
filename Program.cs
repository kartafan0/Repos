using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prakt10._1._1
{
    class Program
    {
        static void Main (string[] args)
        {
            try
            {
                string ans;
                int a, b;
                Random ra = new Random();
                Console.WriteLine("Введите количество строк масива");
                a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите количество столбцов масива");
                b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("1)заполнить вручную\n2)заполнить автоматический");
                ans = Console.ReadLine();
                double[,] mass = new double[a, b];
                ans = fillmass(ans, a, b, ra, mass);
                seeMass(a, b, mass);
                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        mass[i, j] = Math.Round(mass[i, j] / 7, 2);
                    }
                }
                seeMass(a, b, mass);
                Console.WriteLine("Введите значение \"k\"");
                int k = Convert.ToInt32(Console.ReadLine());
                int kk = 0;
                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        if (mass[i, j] > 0 && mass[i, j] % k == 0)
                            kk++;
                    }
                }
                Console.WriteLine($"количество положительных чисел кратных {k}:{kk}");
                Console.WriteLine("Введите k1 и k2 через пробел");
                string[] kkk = Console.ReadLine().Split(' ');
                int k1 = Convert.ToInt32(kkk[0]) - 1;
                int k2 = Convert.ToInt32(kkk[1]) - 1;
                double sum = 0;
                for (int i = k1; i <= k2; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        sum += mass[i, j];
                    }
                }
                Console.WriteLine($"Сумма элементов строк с {k1 + 1} по {k2 + 1} = {Math.Round(sum, 2)}");
                Console.WriteLine("Введите a и b через пробел");
                kkk = Console.ReadLine().Split(' ');
                int z = Convert.ToInt32(kkk[0]) - 1;
                int x = Convert.ToInt32(kkk[1]) - 1;
                int kkab = 0;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("");
                for (int i = 0; i <= a; i++)
                {
                    Console.Write("\n");
                    for (int j = 0; j <= b; j++)
                    {
                        if (mass[i, j] % z == 0 || mass[i, j] % x == 0)
                        {
                            kkab++;
                            Console.BackgroundColor = ConsoleColor.Blue;
                        }
                        else if (i % 2 == 0)
                            Console.BackgroundColor = ConsoleColor.Gray;
                        else
                            Console.BackgroundColor = ConsoleColor.White;
                        Console.Write($"|{mass[i, j],7} ");
                    }
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n");
                Console.WriteLine($"количество положительных чисел кратных {a + 1} или {b + 1}:{kkab}");
                Console.WriteLine("Введите k1 и k2 через пробел");
                kkk = Console.ReadLine().Split(' ');
                k1 = Convert.ToInt32(kkk[0]) - 1;
                k2 = Convert.ToInt32(kkk[1]) - 1;
            }
            catch {
                Console.WriteLine("error");
            }
            Console.ReadLine();
        }

        private static string fillmass (string ans, int a, int b, Random ra, double[,] mass)
        {
            if (ans == "1")
            {
                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        Console.WriteLine($"Введите значение строки:{i + 1} , столбца {j + 1}");
                        ans = Console.ReadLine();
                        mass[i, j] = Convert.ToInt32(ans);
                    }
                }
            }
            else if (ans == "2")
            {
                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        mass[i, j] = ra.Next(-70, 71);
                    }
                }
            }

            return ans;
        }

        private static void seeMass (int a, int b, double[,] mass)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("");
            for (int i = 0; i < a; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < b; j++)
                {
                    if (i % 2 == 0)
                        Console.BackgroundColor = ConsoleColor.Gray;
                    else
                        Console.BackgroundColor = ConsoleColor.White;
                    Console.Write($"|{mass[i, j],7} ");
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_10_02_23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] number = { 8, 17, 24, 5, 25 };
            int[] divisor = { 2, 0, 0, 5 };
            int n;
            for (int j = 0; j < number.Length; j++)
            {
                //DivideByZeroException and IndexOutOfRangeException 
                try
                {
                    Console.WriteLine("Number: " + number[j]);
                    Console.WriteLine("Divisor: " + divisor[j]);
                    Console.WriteLine("Quotient: " + number[j] / divisor[j]);
                    if (divisor[j] % 2 != 0)
                    {
                        throw new OddNumberException();
                    }
                    //n = int.Parse(Console.ReadLine());
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Not possible to Divide by zero");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Index is Out of Range");
                }
                catch (FormatException FE)
                {
                    Console.WriteLine("Enter Only Integer Numbers");
                }
                catch (OddNumberException one)
                {
                    Console.WriteLine("Divisor cannot be zero");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
                finally
                {
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
    }
}

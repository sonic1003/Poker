using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PokerApplication
{
    class Program
    {

        static void Main(string[] args)
        {
            Stack<int> st = new Stack<int>();

            for (int n = 0; n < 1; ++n)
            {
                Stopwatch sp = new Stopwatch();
                Random num = new Random();

                sp.Reset();
                sp.Start();
                List<int> list = new List<int>();

                for (int i = 0; i < 100000; ++i)
                {
                    list.Add(num.Next());
                }
                sp.Stop();
                Console.WriteLine(sp.ElapsedMilliseconds + " , " + sp.ElapsedTicks);



                sp.Reset();
                sp.Start();
                int[] array = new int[100000];
                for (int i = 0; i < 100000; ++i)
                {
                    array[i] = num.Next();
                }
                sp.Stop();
                Console.WriteLine(sp.ElapsedMilliseconds + " , " + sp.ElapsedTicks);

                sp.Reset();
                sp.Start();
                PokerBizCore.Sort(array);
                sp.Stop();
                Console.WriteLine(sp.ElapsedMilliseconds + " , " + sp.ElapsedTicks);

                sp.Reset();
                sp.Start();
                list.Sort();
                sp.Stop();
                Console.WriteLine(sp.ElapsedMilliseconds + " , " + sp.ElapsedTicks);

            

                Console.WriteLine("\n-------------------------\n");
            }
        }
            
    }
}

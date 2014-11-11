using System;
using System.Collections.Generic;

using System.Diagnostics;

namespace PokerApplication
{
    class PokerDemo
    {

        static void Main(string[] args)
        {
            /*
            Random random = new Random();
            Stopwatch st = new Stopwatch();
            st.Reset();
            st.Start();
            */

            Console.WriteLine("Please input 5 cards of first player.");
            Console.WriteLine("Valid input will be points from 2 to 14 (2-A respectively)");
            Console.WriteLine("and suits from 0-3 (stands for spade, heart, diamond, club respectively).");
            Console.WriteLine("For example, input 12-0 means spade Q.");
            Console.WriteLine("Press enter after input each card.\n");
            Console.WriteLine("Please enter the first 5 cards now:");

            InputController input = new InputController();

            int[][] inputArray1 = new int[5][];
            input.ReadInputAsArray(inputArray1);

            Console.WriteLine("\n");
            Console.WriteLine("Please enter the second 5 cards now:");

            int[][] inputArray2 = new int[5][];
            input.ReadInputAsArray(inputArray2);
            

            PokerController pokerController = new PokerController();
            pokerController.GetInput(inputArray1,inputArray2);
            pokerController.CompareHands();
            pokerController.DisplayResult();

            /*
            st.Stop();
            Console.WriteLine(st.ElapsedMilliseconds + " " + st.ElapsedTicks);
            */

            /*
            st.Reset();
            st.Start();
            for (int i = 0; i < 10000; i++)
            {
                List<int> value = new List<int>() { random.Next(2, 14), random.Next(2, 14), random.Next(2, 14), random.Next(2, 14), random.Next(2, 14) };
                value.Sort();
            }
            st.Stop();
            Console.WriteLine(st.ElapsedMilliseconds + " " + st.ElapsedTicks);



            st.Reset();
            st.Start();
            for (int i = 0; i < 10000; i++)
            {
                int[] array = new int[5] { random.Next(2, 14), random.Next(2, 14), random.Next(2, 14), random.Next(2, 14), random.Next(2, 14) };
                QuickSort.Sort(array);
            }
            st.Stop();
            Console.WriteLine(st.ElapsedMilliseconds + " " + st.ElapsedTicks);
            */
        }
            
    }
}

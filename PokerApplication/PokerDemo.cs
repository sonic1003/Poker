using System;
using System.Collections.Generic;

using System.Diagnostics;

namespace PokerApplication
{
    class PokerDemo
    {

        static void Main(string[] args)
        {
            Random random = new Random();
            Stopwatch st = new Stopwatch();
            st.Reset();
            st.Start();

            int[][] inputArray1 = new int[][]
            {
                new int[]{ 2, 2 }, 
                new int[]{ 6, 0 },
                new int[]{ 8, 1 },
                new int[]{ 13, 3 },
                new int[]{ 10, 2 }
            };

            int[][] inputArray2 = new int[][]
            {
                new int[]{ 9, 1 }, 
                new int[]{ 11, 3 },
                new int[]{ 12, 0 },
                new int[]{ 13, 2 },
                new int[]{ 2, 3 }
            };

            InputController input = new InputController();
            Card[] cards1 = input.ProcessUserInput(inputArray1);
            Card[] cards2 = input.ProcessUserInput(inputArray2);

            PokerController pokerController = new PokerController();
            pokerController.CompareHands(cards1, cards2);

            st.Stop();
            Console.WriteLine(st.ElapsedMilliseconds + " " + st.ElapsedTicks);


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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            InputController input = new InputController();
            Card[] cards = input.GetUserInput();
            
            Evaluator mediator = new Evaluator();
            mediator.InitializeCards(cards);


            Console.WriteLine(mediator.HasFlush());

            st.Stop();
            Console.WriteLine(st.ElapsedMilliseconds + " " + st.ElapsedTicks);



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

        }
            
    }
}

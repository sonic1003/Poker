using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerApplication
{
    class OutputController
    {
        public void OutputCards(Evaluator evaluator, RankLevel cardsResult)
        {
            for (int i = 0; i < evaluator.suits.Count; i++)
            {
                Console.Write(evaluator.points[i] +"-"+evaluator.suits[i] +"  ");
            }
            Console.WriteLine(cardsResult.ToString());
            Console.WriteLine();
        }

        public void OutputVerdict(int verdict)
        {
            if (verdict == -1)
            {
                Console.WriteLine("Draw!");
            }
            else if (verdict == 0)
            {
                Console.WriteLine("Player1 wins!");
            }
            else if (verdict == 1)
            {
                Console.WriteLine("Player2 wins!");
            }

            Console.WriteLine("\n\n");
        }
    }
}

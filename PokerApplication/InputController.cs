using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerApplication
{
    class InputController
    {
        Card[] cards = new Card[5];

        int[][] inputArray = new int[][]
        {
            new int[]{ 2, 2 }, 
            new int[]{ 9, 2 },
            new int[]{ 11, 2 },
            new int[]{ 13, 2 },
            new int[]{ 5, 2 }
        };

        public Card[] GetUserInput()
        {
            int length = inputArray.Length;
            for (int i = 0; i < length; i++)
            {
                cards[i] = new Card(inputArray[i][0], inputArray[i][1]);
            }
            return cards;
        }
    }
}

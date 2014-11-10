using System;
using System.Collections.Generic;

namespace PokerApplication
{
    class InputController
    {

        public Card[] ProcessUserInput(int[][] inputArray)
        {
            int length = inputArray.Length;
            Card[] cards = new Card[length];

            for (int i = 0; i < length; i++)
            {
                cards[i] = new Card(inputArray[i][0], inputArray[i][1]);
            }
            return cards;
        }
    }
}

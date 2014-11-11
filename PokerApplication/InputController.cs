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

        public int[][] ReadInputAsArray(int[][] inputArray)
        {
            for (int i = 0; i < 5; i++)
            {
                string inputCard = Console.ReadLine();
                inputArray[i] = new int[2];
                inputArray[i][0] = int.Parse(inputCard.Split('-')[0]);
                inputArray[i][1] = int.Parse(inputCard.Split('-')[1]);
            }
            return inputArray;
        }
    }
}

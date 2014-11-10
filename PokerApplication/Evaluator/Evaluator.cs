using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerApplication
{
    public abstract class Evaluator
    {
        List<int> suits = new List<int>();
        List<int> points = new List<int>();

        public void InitializeCards(Card[] cards)
        {
            int length = cards.Length;
            for (int i = 0; i < length; i++)
            {
                suits.Add(cards[i].Suit);
                points.Add(cards[i].Point);
            }

            suits.Sort();
            points.Sort();
        }


        public bool CheckFlush(List<int> suits)
        {
            return (suits[0] - suits[suits.Count - 1]) == 0 ? true : false;
        }

        public bool CheckStraight(List<int> points)
        {
            if ((points[points.Count - 1] - points[0]) != 4)
                return false;


            return true;
        }





        public bool HasPair(List<int> points)
        {
            return true;
        }

        public bool HasTwoPair(List<int> points)
        {
            return true;
        }

        public bool HasThreeOfAKind(List<int> points)
        {
            return true;
        }

        public bool HasStraight(List<int> points)
        {
            string templateString = "2345678910111213142345";
            if (templateString.Contains(points.ToString()))
                return true;
            else
                return false;
        }

        public bool HasFlush()
        {
            return (suits[0] - suits[suits.Count - 1]) == 0 ? true : false;
        }

        public bool HasFullHouse(List<int> points)
        {
            return true;
        }

        public bool HasFourOfAKind(List<int> points)
        {
            return true;
        }

        public bool HasStraightFlush(Card[] cards)
        {
            return true;
        }


    }
}

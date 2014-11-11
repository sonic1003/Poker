using System;
using System.Collections.Generic;

namespace PokerApplication
{

    public class Card
    {
        private int _point;
        private int _suit;

        public Card(int point, int suit)
        {
            _point = point;
            _suit = suit;
        }

        public int Point
        {
            get { return _point; }
        }

        public int Suit
        {
            get { return _suit; }
        }
    }
}

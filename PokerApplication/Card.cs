using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerApplication
{

    public class Card
    {
        private Value _value;
        private Suit _suit;

        public Card (Value value, Suit suit)
        {
            _value = value;
            _suit = suit;
        }
    }
}

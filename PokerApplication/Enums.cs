using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerApplication
{
    public enum Suit
    {
        spade,
        heart,
        diamond,
        club,
    };

    public enum Value
    {
        one,
        two,
        three,
        four,
        five,
        six,
        seven,
        eight,
        nine,
        ten,
        J,
        Q,
        K,
        A,
    };

    public enum RankLevel
    {
        HIGH_CARD,
        ONE_PAIR,
        TWO_PAIR,
        THREE_OF_A_KIND,
        STRAIGHT,
        FLUSH,
        FULL_HOUSE,
        FOUR_OF_A_KIND,
        STRAIGHT_FLUSH,
    }
}

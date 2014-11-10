using System;
using System.Collections.Generic;


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
        HIGH_CARD = 0,
        ONE_PAIR = 20,
        TWO_PAIR = ONE_PAIR | ONE_PAIR,       //40 equals ONE_PAIR + ONE_PAIR
        THREE_OF_A_KIND =50,
        STRAIGHT = 55 ,
        FLUSH = 65,
        FULL_HOUSE = THREE_OF_A_KIND | ONE_PAIR,     //70 equals THREE_OF_A_KIND + TWO_PAIRS
        FOUR_OF_A_KIND = 100,
        STRAIGHT_FLUSH = STRAIGHT | FLUSH, // 120 equals STRAIGHT + FLUSH
    }
}

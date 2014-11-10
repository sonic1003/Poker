using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PokerApplication
{
    public class Evaluator
    {
        public List<int> suits = new List<int>();
        public List<int> points = new List<int>();
        public Dictionary<RankLevel, int> cardIndex = new Dictionary<RankLevel, int>();

        /// <summary>
        /// store card Point and Suit in two lists.
        /// And sort them from low to high.
        /// </summary>
        /// <param name="cards"></param>
        public void InitializeCards(Card[] cards)
        {
            suits.Clear();
            points.Clear();
            int length = cards.Length;
            for (int i = 0; i < length; i++)
            {
                suits.Add(cards[i].Suit);
                points.Add(cards[i].Point);
            }

            suits.Sort();
            points.Sort();
        }


        /// <summary>
        /// If list string matches the template, 
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public RankLevel HasStraight()
        {
            string result = string.Join("",points.ToArray());
            string templateString1 = "1234567891011121314";
            string templateString2 = "234514";

            if (templateString1.Contains(result) || templateString2.Contains(result))
                return RankLevel.STRAIGHT;
            else
                return 0;
        }


        public string ConvertListToString()
        {
            return string.Join("", points.ToArray());
        }

        /// <summary>
        /// if lowest suit == highest suit, all cards has same suit
        /// which means it's a Flush
        /// </summary>
        /// <returns></returns>
        public RankLevel HasFlush()
        {
            return (suits[0] == suits[suits.Count - 1]) ? RankLevel.FLUSH : 0;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public RankLevel HasDuplicatedCards()
        {
            int num = 0;
            RankLevel result = 0;
            List<int> distinctPoints = points.Distinct().ToList();

            foreach (int point in distinctPoints)
            {
                num = points.Count(n => n.Equals(point));
                switch (num)
                {
                    case 4:
                        result |= RankLevel.FOUR_OF_A_KIND;
                        cardIndex[RankLevel.FOUR_OF_A_KIND]=point;
                        break;
                    case 3:
                        result |= RankLevel.THREE_OF_A_KIND;
                        cardIndex[RankLevel.THREE_OF_A_KIND] = point;
                        break;
                    case 2:
                        result |= RankLevel.ONE_PAIR;
                        cardIndex[RankLevel.ONE_PAIR] = point;
                        break;
                    default:
                        result |= 0;
                        break;
                }
            }

            //make sure high rank is in front
            cardIndex=SortCardIndex(cardIndex);

            return result;
        }



        /// <summary>
        /// Sort dictionary from High Rank to Low Rank
        /// </summary>
        Dictionary<RankLevel, int> SortCardIndex(Dictionary<RankLevel, int> dict)
        {
            List<int> rankOrder = new List<int>();
            foreach (RankLevel rank in dict.Keys)
            {
                rankOrder.Add((int)rank);
            }

            rankOrder.Sort();

            Dictionary<RankLevel, int> tmpDict = new Dictionary<RankLevel, int>();
            for (int i = rankOrder.Count - 1; i >= 0; i--)
            {
                RankLevel level = (RankLevel)rankOrder[i];
                tmpDict[level] = dict[level];
            }

            dict.Clear();
            dict = tmpDict;
            return dict;
        }
    }
}

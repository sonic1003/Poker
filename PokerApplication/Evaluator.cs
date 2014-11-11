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
        public List<int[]> cardIndex = new List<int[]>();

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
            string result = string.Join("", points.ToArray());
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
            int result = 0;
            List<int> distinctPoints = points.Distinct().ToList();

            
            cardIndex.Clear();
            foreach (int point in distinctPoints)
            {
                int[] tmp = new int[2];
                num = points.Count(n => n.Equals(point));
                //Console.WriteLine(num + " " + point);
                switch (num)
                {
                    case 4:
                        result += (int)RankLevel.FOUR_OF_A_KIND;
                        tmp[0] = result;
                        tmp[1] = point;
                        cardIndex.Add(tmp);
                        break;
                    case 3:
                        result += (int)RankLevel.THREE_OF_A_KIND;
                        tmp[0] = result;
                        tmp[1] = point;
                        cardIndex.Add(tmp);
                        break;
                    case 2:
                        result += (int)RankLevel.ONE_PAIR;
                        tmp[0] = result;
                        tmp[1] = point;
                        cardIndex.Add(tmp);
                        break;
                    default:
                        result += 0;
                        tmp[0] = 0;
                        tmp[1] = point;
                        //Console.WriteLine("result " + tmp[0] + " " + tmp[1]);
                        cardIndex.Add(tmp);
                        break;
                }
            }

            //make sure high rank is in front
            QuickSort.Sort(cardIndex);
            return (RankLevel)result;
        }
    }
}

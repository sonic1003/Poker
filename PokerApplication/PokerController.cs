using System;
using System.Collections.Generic;

namespace PokerApplication
{
    class PokerController
    {
        public void CompareHands(Card[] cards1, Card[] cards2)
        {
            RankLevel cardsResult1, cardsResult2;
            Evaluator cardsEvaluator1, cardsEvaluator2;

            cardsEvaluator1 = InstantiateEvaluator(cards1);
            cardsEvaluator2 = InstantiateEvaluator(cards2);

            if(cardsEvaluator1.ConvertListToString() == cardsEvaluator2.ConvertListToString())
            {
                Console.WriteLine("Draw");
                return;
            }

            cardsResult1 = RankCards(cardsEvaluator1);
            cardsResult2 = RankCards(cardsEvaluator2);


            if (cardsResult1 == cardsResult2)
            {// rank levels are the same

                if (cardsResult1 == RankLevel.STRAIGHT_FLUSH ||
                    cardsResult1 == RankLevel.STRAIGHT ||
                    cardsResult1 == RankLevel.FLUSH ||
                    cardsResult1 == RankLevel.HIGH_CARD
                  )
                {// no duplicated cards
                 // compare high cards

                    for (int i = cardsEvaluator1.points.Count - 1; i >= 0; i--)
                    {
                        if (cardsEvaluator1.points[i] > cardsEvaluator2.points[i])
                        {
                            //player1 wins
                            Console.WriteLine("Player1 wins" + "  " + cardsResult1.ToString() + "  " + cardsResult2.ToString());
                            break;
                        }
                        else
                        {
                            //player2 wins
                            Console.WriteLine("Player2 wins" + "  " + cardsResult1.ToString() + "  " + cardsResult2.ToString());
                            break;
                        }
                    }
                }
                else // handle duplicated cards
                {
                    foreach (RankLevel rank in cardsEvaluator1.cardIndex.Keys)
                    {
                        if (cardsEvaluator1.cardIndex[rank] == cardsEvaluator2.cardIndex[rank])
                            continue;

                        if(cardsEvaluator1.cardIndex[rank]>cardsEvaluator2.cardIndex[rank])
                        {
                            //player1 wins
                            Console.WriteLine("Player1 wins" + "  " + cardsResult1.ToString() + "  " + cardsResult2.ToString());
                            break;
                        }
                        else
                        {
                            //player2 wins
                            Console.WriteLine("Player2 wins" + "  " + cardsResult1.ToString() + "  " + cardsResult2.ToString());
                            break;
                        }
                    }
                }
            }
            else
            {// one player's rank > another

                if (cardsResult1 > cardsResult2)
                {
                    //player1 wins
                    Console.WriteLine("Player1 wins" + "  " + cardsResult1.ToString() + "  " + cardsResult2.ToString());
                }
                else
                {
                    //player2 wins
                    Console.WriteLine("Player2 wins" + "  " + cardsResult1.ToString() + "  " + cardsResult2.ToString());
                }
            }
        }




        /// <summary>
        /// Instantiate evaluator for each hands
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public Evaluator InstantiateEvaluator(Card[] cards)
        {
            Evaluator evaluator = new Evaluator();
            evaluator.InitializeCards(cards);
            return evaluator;
        }



        /// <summary>
        /// calculate Rank of each hands
        /// </summary>
        /// <param name="evaluator"></param>
        /// <returns></returns>
        public RankLevel RankCards(Evaluator evaluator)
        {
            RankLevel result = 0;
            result = evaluator.HasStraight() | evaluator.HasFlush();
            if (result != 0) 
                return result;
            else
                return evaluator.HasDuplicatedCards();
        }
    }
}
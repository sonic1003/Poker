using System;
using System.Collections.Generic;

namespace PokerApplication
{
    class PokerController
    {
        int FinalVerdict = -9999;
        Card[] cards1, cards2;
        Evaluator cardsEvaluator1, cardsEvaluator2;
        RankLevel cardsResult1, cardsResult2;

        public void CompareHands()
        {
            cardsEvaluator1 = InstantiateEvaluator(cards1);
            cardsEvaluator2 = InstantiateEvaluator(cards2);

            if(cardsEvaluator1.ConvertListToString() == cardsEvaluator2.ConvertListToString())
            {
                //Console.WriteLine("Draw");
                FinalVerdict = -1;
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
                            //Console.WriteLine("Player1 wins" + "  " + cardsResult1.ToString() + "  " + cardsResult2.ToString());
                            FinalVerdict = 0;
                            break;
                        }
                        else
                        {
                            //player2 wins
                            //Console.WriteLine("Player2 wins" + "  " + cardsResult1.ToString() + "  " + cardsResult2.ToString());
                            FinalVerdict = 1;
                            break;
                        }
                    }
                }
                else // handle duplicated cards
                {
                    for (int i = cardsEvaluator1.cardIndex.Count - 1; i >= 0; i--)
                    {
                        if (cardsEvaluator1.cardIndex[i][1] == cardsEvaluator2.cardIndex[i][1])
                            continue;

                        if (cardsEvaluator1.cardIndex[i][1] > cardsEvaluator2.cardIndex[i][1])
                        {
                            //player1 wins
                            //Console.WriteLine("Player1 wins" + "  " + cardsResult1.ToString() + "  " + cardsResult2.ToString());
                            FinalVerdict = 0;
                            break;
                        }
                        else
                        {
                            //player2 wins
                            //Console.WriteLine("Player2 wins" + "  " + cardsResult1.ToString() + "  " + cardsResult2.ToString());
                            FinalVerdict = 1;
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
                    //Console.WriteLine("Player1 wins" + "  " + cardsResult1.ToString() + "  " + cardsResult2.ToString());
                    FinalVerdict = 0;
                }
                else
                {
                    //player2 wins
                    //Console.WriteLine("Player2 wins" + "  " + cardsResult1.ToString() + "  " + cardsResult2.ToString());
                    FinalVerdict = 1;
                }
            }
        }


        public void GetInput(int[][] inputArray1, int[][] inputArray2)
        {
            InputController input = new InputController();
            cards1 = input.ProcessUserInput(inputArray1);
            cards2 = input.ProcessUserInput(inputArray2);
        }


        public void DisplayResult()
        {
            OutputController output = new OutputController();
            Console.WriteLine();
            output.OutputCards(cardsEvaluator1, cardsResult1);
            output.OutputCards(cardsEvaluator2, cardsResult2);
            output.OutputVerdict(FinalVerdict);
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
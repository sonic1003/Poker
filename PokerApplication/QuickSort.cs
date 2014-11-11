using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerApplication
{
    class QuickSort
    {
        public static void Sort(List<int[]> numbers)
        {
            Sort(numbers, 0, numbers.Count - 1);
        }

        private static void Sort(List<int[]> numbers, int left, int right)
        {
            if (left < right)
            {
                int middle = numbers[(left + right) / 2][0];
                int i = left - 1;
                int j = right + 1;
                while (true)
                {
                    while (numbers[++i][0] < middle)
                        ;

                    while (numbers[--j][0] > middle)
                        ;

                    if (i >= j)
                        break;

                    Swap(numbers, i, j);
                }

                Sort(numbers, left, i - 1);
                Sort(numbers, j + 1, right);
            }
        }


        public static void Swap(List<int[]> numbers, int i, int j)
        {
            int number = numbers[i][0];
            numbers[i][0] = numbers[j][0];
            numbers[j][0] = number;
        }

    }
}

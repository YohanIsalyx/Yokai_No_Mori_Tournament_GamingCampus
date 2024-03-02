using System;
using System.Collections.Generic;


public static class ShuffleList
{
    public static void Shuffle<T>(this IList<T> list)
    {
        Random randomGenerator = new Random();

        int elementsMaxIndex = list.Count;
        while (elementsMaxIndex > 1)
        {
            elementsMaxIndex--;
            int changePosition = randomGenerator.Next(elementsMaxIndex + 1);

            T swapValue = list[changePosition];
            list[changePosition] = list[elementsMaxIndex];
            list[elementsMaxIndex] = swapValue;
        }
    }
}

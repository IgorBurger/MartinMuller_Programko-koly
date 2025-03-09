using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] coins = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int sum = int.Parse(Console.ReadLine());
        List<List<int>> results = new List<List<int>>();

        Backtrack(coins, sum, 0, new List<int>(), results);

        foreach (var result in results)
        {
            Console.WriteLine(string.Join(" ", result));
        }
    }

    static void Backtrack(int[] coins, int remaining, int index, List<int> current, List<List<int>> results)
    {
        if (remaining == 0)
        {
            results.Add(new List<int>(current));
            return;
        }

        for (int i = index; i < coins.Length; i++)
        {
            if (coins[i] <= remaining)
            {
                current.Add(coins[i]);
                Backtrack(coins, remaining - coins[i], i, current, results);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}

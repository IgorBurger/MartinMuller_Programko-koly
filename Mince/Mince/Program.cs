using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] coins = Array.ConvertAll(Console.ReadLine().Split(), int.Parse); //input
        int sum = int.Parse(Console.ReadLine());
        List<List<int>> results = new List<List<int>>(); //list obsahující listy vhodných kombinací (všechny výsledky)

        Backtrack(coins, sum, 0, new List<int>(), results);


        if (results[0].Count == 0) //pokud první list v listu results má velikost 0 --> je prázdný --> neexistuje žádné řešení 
        {
            Console.WriteLine("Nelze :(");
        }
        else
        {
            foreach (var result in results)
            {
                Console.WriteLine(string.Join(" ", result)); // vypsání výsledků
            }
        }
        

        
    }
    //int[] coins - seznam zadaných mincí
    // int remaining - zvývající hodnota, která se musí ještě z mincí složit (zadaná suma - suma z vybraných mincí)
    // int index - index pro průchod
    //List<int> current - list právě zkoumané sekvence mincí
    // List<List<int>> - výsledky
    static void Backtrack(int[] coins, int remaining, int index, List<int> current, List<List<int>> results) 
    {
        if (remaining == 0) //pokud zbývající potřebná suma, kterou je potřeba složit je 0, tak to znamená, že součet hodnot mincí v sekvenci uložené v "current" úspěšně složil požadovanou sumu
        {
            results.Add(new List<int>(current)); //přidá sekvenci do listu výsledků
            return; //vrátí se zpět z rekurze
        }

        for (int i = index; i < coins.Length; i++) //prochází každou minci v listu coins
        {
            if (coins[i] <= remaining) //pokud není hodnota mince větší než požadovaná zbývající suma
            {
                current.Add(coins[i]); //tak ji přidáme do zkoumané sekvence current

                //vyvoláme znovu fuknci Backtrack
                //remaining - coins[i] -> odečteme od zbývající hledané sumy hodnotu právě přidané mince
                //ta bude probíhat array coins od indexu i, což je index aktuální zkoumané mince, což znamená, že se nebudou zkoumat mince větší než coins[i]
                //jakmile se pomocí for cyklu změní hodnota i, tak se začne zkoumat další mince
                Backtrack(coins, remaining - coins[i], i, current, results);

                current.RemoveAt(current.Count - 1);
                //až se vrátíme z funkce Backtrack (tím že najdeme vyhovující sekvenci nebo ne), tak se ze zkoumané sekvence "current" odstraní poslední přidaná hodnota,
                //aby se mohla zkoumat nová sekvence
                //jakmile se vrátí z rekurze, tak se zvýší index i ve for cyklu funkce do níž se vrací, čímž se začne zkoumat další možnost (coins[i])

                //Pokud součet sekvence "current" a nově přidaného zkoumané mince překročí požadovanou zbývající sumu, tak se číslo ignoruje a zvýšením hodnoty i ve for loopu se vyzkouší další mince z array coins[]

            }
        }
    }
}

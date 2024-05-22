using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

class Algorytmy
{
    public static void QuickSort(int[] tab, int lewy, int prawy)
    {
        if (lewy < prawy)
        {
            int indeksPivot = Podziel(tab, lewy, prawy);
            QuickSort(tab, lewy, indeksPivot - 1);
            QuickSort(tab, indeksPivot + 1, prawy);
        }
    }
    private static int Podziel(int[] tab, int lewy, int prawy)
    {
        int pivot = tab[prawy];
        int i = lewy -1;
        for (int j = lewy; j< prawy; j++)
        {
            if (tab[j] <= pivot)
            {
                i++;
                Zamien(tab, i, j);
            }
        }
        Zamien(tab, i+1, prawy);
        return i + 1;
    }
    private static void Zamien(int[] tab, int i, int j)
    {
        int temp = tab[i];
        tab[i] = tab[j];
        tab[j] = temp;
    }
    public static void MergeSort(int[] tab, int lewy, int prawy)
    {
        if (lewy < prawy)
        {
            int srodek = (lewy + prawy) / 2;
            MergeSort(tab, lewy, srodek);
            MergeSort(tab, srodek+1, prawy);
            Scal(tab, lewy, srodek, prawy);
        }
    }
    private static void Scal(int[] tab, int lewy, int srodek, int prawy)
    {
        int n1 = srodek - lewy + 1;
        int n2 = prawy - srodek;
        int[] lewyTab = new int[n1]; 
        int[] prawyTab = new int[n2];
        Array.Copy(tab, lewy, lewyTab, 0, n1);
        Array.Copy(tab, srodek + 1, prawyTab, 0, n2);
        int i = 0, j = 0, k = lewy;
        while(i<n1 && j<n2)
        {
            if (lewyTab[i] <= prawyTab[j])
            {
                tab[k] = lewyTab[i];
                i++;
            }
            else
            {
                tab[k] = prawyTab[j];
                j++;
            }
            k++;
        }
        while (i < n1)
        {
            tab[k] = lewyTab[i];
            i++;
            k++;
        }
    }
    public static void BombelSort(int[] tab)
    {
        int n = tab.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j<n - 1 -i ; j++)
            {
                if (tab[j] > tab[j + 1])
                {
                    Zamien(tab, j, j + 1);
                }
            }
        }
    }
    public static int[] RanTab(int rozmiar)
    {
        Random random = new Random();
        int[] tab = new int[rozmiar];
        for (int i = 0; i< rozmiar; i++)
        {
            tab[i] = random.Next(1,100);
        }
        return tab;
    }
    public static void Main(string[] args)
    {
        int rozmiar = 10000;
        int[] tab = RanTab(rozmiar);

        int[] tabQuickSort = (int[])tab.Clone();
        int[] tabMergeSort = (int[])tab.Clone();
        int[] tabBombelSort = (int[])tab.Clone();   
         Stopwatch stoper = new Stopwatch();

        stoper.Start();
        QuickSort(tabQuickSort, 0, tabQuickSort.Length-1);
        stoper.Stop();
        Console.WriteLine($"Czas QuickSort: {stoper.ElapsedMilliseconds} ms");

        stoper.Start();
        MergeSort(tabMergeSort, 0, tabMergeSort.Length - 1);
        stoper.Stop();
        Console.WriteLine($"Czas MergeSort: {stoper.ElapsedMilliseconds} ms");

        stoper.Start();
        BombelSort(tabBombelSort);
        stoper.Stop();
        Console.WriteLine($"Czas BombelSort: {stoper.ElapsedMilliseconds} ms");
    }
}
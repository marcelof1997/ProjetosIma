using System;
using System.Security.Cryptography;

public class program
{
    static void Main(string[] args)
    {
        string[,] jogoDaVelha = new string[3, 3];
        do
        {
            string[] vet = Console.ReadLine().Split();
            int l = int.Parse(vet[0]);
            int c = int.Parse(vet[1]);
            jogoDaVelha[l, c] = "X";

            Console.Write(jogoDaVelha[l, c]);
            Console.WriteLine("  |  |  ");
            Console.WriteLine("--|--|--");
            Console.WriteLine("--|--|--");
            Console.WriteLine("  |  |  ");

        } while (true);

    }

}

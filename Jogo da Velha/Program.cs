using System;
using System.Security.Cryptography;

public class program
{
    private static void menuPlacar()
    {
        Console.WriteLine("Para PLACAR digite -------(1)");
        Console.WriteLine("Para sair digite ---------(0)");
    }
    static void Main(string[] args)
    {
        string[,] jogoDaVelha = new string[3, 3];
        int opcao = 5;
        int jogador = 0;
        int jogador01 = 0;
        int jogador02 = 0;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Nome do primeiro jogador: ");
        string jogador1 = Console.ReadLine();
        Console.Write("Nome do segundo jogador: ");
        string jogador2 = Console.ReadLine();
        Console.WriteLine();

        Console.WriteLine("           INSTRUCAO DO JOGO \n" +
                          "* O primeiro jogador ficara com o  X \n" +
                          "* O segundo jogador ficara com a  O \n" +
                          "* Digite a localizacao que sera colocado \n" +
                          "* Sabendo que o primeiro numero e para linhas e o segundo para as colunas \n" +
                          "* Com um espaco entre os numeros \n" +
                 "         Ex:    Colunas  \n" +
                 "              0   1   2  \n" +
                 "                |   |    \n" +
                 " linha 0     ---|---|--- \n" +
                 " Linha 1     ___|___|___ \n" +
                 " Linha 2        │ X │    \n" +
            "                              \n" +
            "  Nesse caso iria digitar os numeros ( 2 1 ) o numero 2 e o numero da linha e o 1 o numero da coluna  \n");

        do
        {
            if (jogador % 2 == 1) { Console.WriteLine("Vez do jogador 2"); }
            else { Console.WriteLine("Vez do jogador 1"); }

            string[] vet = Console.ReadLine().Split();

            int l = int.Parse(vet[0]);
            int c = int.Parse(vet[1]);

            jogador++;
            Console.ForegroundColor = ConsoleColor.Blue;

            if (jogador % 2 == 1)
            {
                jogoDaVelha[l, c] = "X";
            }
            else
            {
                jogoDaVelha[l, c] = "O";
            }

            for (l = 0; l <= 2; l++)
            {
                for (c = 0; c <= 2; c++)
                {
                    Console.Write(" ");
                    Console.Write($"{jogoDaVelha[l, c]} ");
                }
                Console.WriteLine("\n");
            }
            Console.ForegroundColor = ConsoleColor.Green;

            if (jogoDaVelha[0, 0] == jogoDaVelha[0, 1] && jogoDaVelha[0, 2] == jogoDaVelha[0, 0])
            {
                jogoDaVelha = new string[3, 3];
                if (jogoDaVelha[0, 0] == "X")
                {
                    Console.WriteLine($"jogador {jogador1} ganhou \nFim de jogo ");
                    jogador01++;

                    menuPlacar();
                    opcao = int.Parse(Console.ReadLine());
                    if (opcao == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(" PLACAR \n" +
                        $"{jogador1} com {jogador01} VITORIAS \n" +
                        $"{jogador1} com {jogador01} VITORIAS");
                    }
                    else if (opcao == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("JOGO ENCERRADO");
                    }
                }
                else
                {
                    Console.WriteLine($"jogador {jogador2} ganhou \nFim de jogo ");
                    jogador02++;

                }
            }


            if (jogoDaVelha[0, 0] != " ") { }


        } while (opcao != 0);


    }


}

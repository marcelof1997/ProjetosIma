using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Security.Cryptography;

public class program
{
    private static void menuPlacar()
    {
        Console.WriteLine("Para novo jogo digite ----(1)");
        Console.WriteLine("Para PLACAR digite -------(2)");
        Console.WriteLine("Para sair digite ---------(0)");
    }

    /* int resul = FindAll.jogadores   tal na posicao do jogador
     * 
     * writeLine(resul) == posicao 4
     * 
     * vitorias[resu] para a vitoria do jogador..*/

    static void AddJogadores(List<string> jogadores, List<int> vitorias, List<int> derrotas, List<int> empates, List<int> quantidadeDeJogadas)
    {
        jogadores.Add(Console.ReadLine());
        vitorias.Add(0);
        derrotas.Add(0);
        empates.Add(0);
        quantidadeDeJogadas.Add(0);

    }
    static void Main(string[] args)
    {

        string[,] jogoDaVelha = new string[3, 3];
        int pontuacao;
        int quantidadeJogadas = 0;
        int opcao = 1;
        int jogador = 0;
        int proximo = -1;
        int proximo2 = -1, jog1 = -1, jog2 = 0;



        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine("           INSTRUCAO DO JOGO \n" +
                          "* O primeiro jogador ficara com  X \n" +
                          "* O segundo jogador ficara com  O \n" +
                          "* Digite a localizacao que sera colocado \n" +
                          "* Digite apenas o numero do local que deseja jogar \n" +

                 "              1   4   7  \n" +
                 "             ---│---│--- \n" +
                 "              2   5   8  \n" +
                 "             ---│---│--- \n" +
                 "              3   6   9  \n" +
                 "Vez do jogador 1 \n");

        Console.Write("Quantos jogadores: ");
        int QuantidadeDeJogadores = int.Parse(Console.ReadLine());
        List<string> jogadores = new List<string>();
        List<int> vitorias = new List<int>();
        List<int> derrotas = new List<int>();
        List<int> empates = new List<int>();
        List<int> quantidadeDeJogadas = new List<int>();

        for (int i = 1; i < QuantidadeDeJogadores + 1; i++)
        {
            Console.Write($"Nome do {i} jogador: ");
            AddJogadores(jogadores, vitorias, derrotas, empates, quantidadeDeJogadas);
        }
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("    GUIA \n" +
              "      1   4   7  \n" +
              "     ---│---│--- \n" +
              "      2   5   8  \n" +
              "     ---│---│--- \n" +
              "      3   6   9  \n");

        do
        {
      
            proximo++;
            proximo2 += 2;
            jog1 += 2;
            jog2 += 2;

                inicio:
            do
            {
                pontuacao = 0;
                int l = 0;
                int c = 0;
                int number = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Clear();
                Console.WriteLine("    GUIA \n" +
                "      1   4   7  \n" +
                "     ---│---│--- \n" +
                "      2   5   8  \n" +
                "     ---│---│--- \n" +
                "      3   6   9  \n");
                Console.ForegroundColor = ConsoleColor.Green;
                if (jogador % 2 == 1)
                {
                    
                    Console.WriteLine();
                    Console.WriteLine($"Vez do jogador {jog1}");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"Vez do jogador {jog2}");
                }
                if (number >= 1 && number < 4)
                {
                    l = number - 1;
                    c = 0;
                }
                if (number >= 4 && number < 7)
                {
                    l = number - 4;
                    c = 1;
                }
                if (number >= 7 && number < 10)
                {
                    l = number - 7;
                    c = 2;
                }


                if (l < 0 || l > 2 || c < 0 || c > 2 || jogoDaVelha[l, c] == "X" || jogoDaVelha[l, c] == "O")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Posicao Invalida , Tente outra..");
                    jogador--;
                    quantidadeJogadas--;
                }      ///ok


                jogador++;
                Console.ForegroundColor = ConsoleColor.Blue;

                if (jogador % 2 == 1)
                {
                    jogoDaVelha[l, c] = "X";
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    jogoDaVelha[l, c] = "O";
                }

                Console.ForegroundColor = ConsoleColor.Yellow;      //nao estou usando essa matriz ainda
                string temp = jogoDaVelha[l, c];

                for (l = 0; l <= 2; l++)
                {
                    for (c = 0; c <= 2; c++)
                    {
                        if (jogoDaVelha[l, c] == null)
                        {
                            jogoDaVelha[l, c] = " ";
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
                Console.WriteLine($"                       {jogoDaVelha[0, 0]}   {jogoDaVelha[0, 1]}   {jogoDaVelha[0, 2]}");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("                      ---│---│---");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"                       {jogoDaVelha[1, 0]}   {jogoDaVelha[1, 1]}   {jogoDaVelha[1, 2]}");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("                      ---│---│---");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"                       {jogoDaVelha[2, 0]}   {jogoDaVelha[2, 1]}   {jogoDaVelha[2, 2]}");

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine();                                                                                   //Vitorias Horizontal
                quantidadeJogadas++;

                if (jogoDaVelha[0, 0] == jogoDaVelha[0, 1] && jogoDaVelha[0, 2] == jogoDaVelha[0, 0])
                {
                    if (jogoDaVelha[0, 0] == "X")
                    {
                        Console.WriteLine($"jogador {jogadores[proximo]} ganhou na horiontal linha 0 \nFim de jogo ");
                        vitorias[proximo]++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                    else if (jogoDaVelha[0, 0] == "O")
                    {
                        Console.WriteLine($"jogador {jogadores[proximo2]} ganhou na horizontal linha 0 \nFim de jogo ");
                        vitorias[proximo2]++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                }

                if (jogoDaVelha[1, 0] == jogoDaVelha[1, 1] && jogoDaVelha[1, 2] == jogoDaVelha[1, 0])
                {
                    if (jogoDaVelha[1, 0] == "X")
                    {
                        Console.WriteLine($"jogador {jogadores[proximo]} ganhou na horiontal linha 1 \nFim de jogo ");
                        vitorias[proximo]++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                    else if (jogoDaVelha[1, 0] == "O")
                    {
                        Console.WriteLine($"jogador {jogadores[proximo2]} ganhou na horizontal linha 1 \nFim de jogo ");
                        vitorias[proximo2]++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                }

                if (jogoDaVelha[2, 0] == jogoDaVelha[2, 1] && jogoDaVelha[2, 2] == jogoDaVelha[2, 0])
                {
                    if (jogoDaVelha[2, 0] == "X")
                    {
                        Console.WriteLine($"jogador {jogadores[proximo]} ganhou na horiontal linha 2 \nFim de jogo ");
                        vitorias[proximo]++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                    else if (jogoDaVelha[2, 0] == "O")
                    {
                        Console.WriteLine($"jogador {jogadores[proximo2]} ganhou na horizontal linha 2 \nFim de jogo ");
                        vitorias[proximo2]++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                }

                //Vitorias vertical
                if (jogoDaVelha[0, 0] == jogoDaVelha[1, 0] && jogoDaVelha[2, 0] == jogoDaVelha[0, 0])
                {
                    if (jogoDaVelha[0, 0] == "X")
                    {
                        Console.WriteLine($"jogador {jogadores[proximo]} ganhou na vertical coluna 0 \nFim de jogo ");
                        vitorias[proximo]++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                    else if (jogoDaVelha[0, 0] == "O")
                    {
                        Console.WriteLine($"jogador {jogadores[proximo2]} ganhou na vertical coluna 0 \nFim de jogo ");
                        vitorias[proximo2]++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                }

                if (jogoDaVelha[0, 1] == jogoDaVelha[1, 1] && jogoDaVelha[2, 1] == jogoDaVelha[0, 1])
                {
                    if (jogoDaVelha[0, 1] == "X")
                    {
                        Console.WriteLine($"jogador {jogadores[proximo]} ganhou na vertical coluna 1 \nFim de jogo ");
                        vitorias[proximo]++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                    else if (jogoDaVelha[0, 1] == "O")
                    {
                        Console.WriteLine($"jogador {jogadores[proximo2]} ganhou na vertical coluna 1 \nFim de jogo ");
                        vitorias[proximo2]++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                }

                if (jogoDaVelha[0, 2] == jogoDaVelha[1, 2] && jogoDaVelha[2, 2] == jogoDaVelha[0, 2])
                {
                    if (jogoDaVelha[0, 2] == "X")
                    {
                        Console.WriteLine($"jogador {jogadores[proximo]} ganhou na vertical coluna 2 \nFim de jogo ");
                        vitorias[proximo]++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                    else if (jogoDaVelha[0, 2] == "O")
                    {
                        Console.WriteLine($"jogador {jogadores[proximo2]} ganhou na vertical coluna 2 \nFim de jogo ");
                        vitorias[proximo2]++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                }
                //Vitorias diagonal
                if (jogoDaVelha[0, 0] == jogoDaVelha[1, 1] && jogoDaVelha[2, 2] == jogoDaVelha[0, 0])
                {
                    if (jogoDaVelha[0, 0] == "X")
                    {
                        Console.WriteLine($"jogador {jogadores[proximo]} ganhou na diagonal \nFim de jogo ");
                        vitorias[proximo]++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                    else if (jogoDaVelha[0, 0] == "O")
                    {
                        Console.WriteLine($"jogador {jogadores[proximo2]} ganhou na diagonal \nFim de jogo ");
                        vitorias[proximo2]++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                }

                if (jogoDaVelha[0, 2] == jogoDaVelha[1, 1] && jogoDaVelha[2, 0] == jogoDaVelha[0, 2])
                {
                    if (jogoDaVelha[0, 2] == "X")
                    {
                        Console.WriteLine($"jogador {jogadores[proximo]} ganhou na diagonal \nFim de jogo ");
                        vitorias[proximo]++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                    else if (jogoDaVelha[0, 2] == "O")
                    {
                        Console.WriteLine($"jogador {jogadores[proximo2]} ganhou na diagonal \nFim de jogo ");
                        vitorias[proximo2]++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                }
                if (quantidadeJogadas == 9)
                {
                    Console.WriteLine("Velha");
                    empates[proximo]++;
                    empates[proximo2]++;
                    pontuacao++;
                }

            } while (pontuacao == 0);

            quantidadeJogadas = 0;
            menuPlacar();
            opcao = int.Parse(Console.ReadLine());
            Console.Clear();

            if (opcao == 3)
            {
                for (int i = 0; i < vitorias.Count; i++)
                {
                    if (vitorias[i] > 0)
                    {
                        string posicao = jogadores[i];
                        Console.WriteLine("jogador " + posicao);
                    }
                }
                Console.WriteLine("Passam para proxima etapa");
                goto inicio;
            }
            if (opcao == 1)
            {

                jogoDaVelha = new string[3, 3];
                if (jogador % 2 == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Vez do jogador {proximo}");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"Vez do jogador {proximo2}");
                }
            }
            if (opcao == 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" PLACAR \n");
                for (int i = 0; i < QuantidadeDeJogadores; i++)
                {
                    Console.WriteLine($"{jogadores[i]} com {vitorias[i]} VITORIAS \n");
                }
                Console.ForegroundColor = ConsoleColor.Green;
                menuPlacar();
                opcao = int.Parse(Console.ReadLine());
            }

            else if (opcao == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("JOGO ENCERRADO");
            }

        } while (opcao == 1);
    }


}


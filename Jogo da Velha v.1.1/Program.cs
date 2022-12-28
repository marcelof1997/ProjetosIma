using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

public class program
{
    private static void menuPlacar()
    {
        Console.WriteLine("Para novo jogo digite ----(1)");
        Console.WriteLine("Para PLACAR digite -------(2)");
        Console.WriteLine("Para sair digite ---------(0)");
    }
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        string[,] jogoDaVelha = new string[3, 3];
        int pontuacao;
        int quantidadeJogadas = 0;
        int opcao = 1;
        int jogador = 0;
        int pontuacaoJogador1 = 0;
        int pontuacaoJogador2 = 0;
        int empate = 0;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Nome do primeiro jogador: ");
        string jogador1 = Console.ReadLine();
        Console.Write("Nome do segundo jogador: ");
        string jogador2 = Console.ReadLine();
        Console.WriteLine();


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

        do
        {
            // Proxima dupla de jogadores
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
                    Console.WriteLine("Vez do jogador 1");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Vez do jogador 2");
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
                }


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
                Console.ForegroundColor = ConsoleColor.Yellow;
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
                        Console.WriteLine($"jogador {jogador1} ganhou na horiontal linha 0 \nFim de jogo ");
                        pontuacaoJogador1++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                    else if (jogoDaVelha[0, 0] == "O")
                    {
                        Console.WriteLine($"jogador {jogador2} ganhou na horizontal linha 0 \nFim de jogo ");
                        pontuacaoJogador2++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                }

                if (jogoDaVelha[1, 0] == jogoDaVelha[1, 1] && jogoDaVelha[1, 2] == jogoDaVelha[1, 0])
                {
                    if (jogoDaVelha[1, 0] == "X")
                    {
                        Console.WriteLine($"jogador {jogador1} ganhou na horiontal linha 1 \nFim de jogo ");
                        pontuacaoJogador1++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                    else if (jogoDaVelha[1, 0] == "O")
                    {
                        Console.WriteLine($"jogador {jogador2} ganhou na horizontal linha 1 \nFim de jogo ");
                        pontuacaoJogador2++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                }

                if (jogoDaVelha[2, 0] == jogoDaVelha[2, 1] && jogoDaVelha[2, 2] == jogoDaVelha[2, 0])
                {
                    if (jogoDaVelha[2, 0] == "X")
                    {
                        Console.WriteLine($"jogador {jogador1} ganhou na horiontal linha 2 \nFim de jogo ");
                        pontuacaoJogador1++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                    else if (jogoDaVelha[2, 0] == "O")
                    {
                        Console.WriteLine($"jogador {jogador2} ganhou na horizontal linha 2 \nFim de jogo ");
                        pontuacaoJogador2++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                }

                //Vitorias vertical
                if (jogoDaVelha[0, 0] == jogoDaVelha[1, 0] && jogoDaVelha[2, 0] == jogoDaVelha[0, 0])
                {
                    if (jogoDaVelha[0, 0] == "X")
                    {
                        Console.WriteLine($"jogador {jogador1} ganhou na vertical coluna 0 \nFim de jogo ");
                        pontuacaoJogador1++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                    else if (jogoDaVelha[0, 0] == "O")
                    {
                        Console.WriteLine($"jogador {jogador2} ganhou na vertical coluna 0 \nFim de jogo ");
                        pontuacaoJogador2++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                }

                if (jogoDaVelha[0, 1] == jogoDaVelha[1, 1] && jogoDaVelha[2, 1] == jogoDaVelha[0, 1])
                {
                    if (jogoDaVelha[0, 1] == "X")
                    {
                        Console.WriteLine($"jogador {jogador1} ganhou na vertical coluna 1 \nFim de jogo ");
                        pontuacaoJogador1++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                    else if (jogoDaVelha[0, 1] == "O")
                    {
                        Console.WriteLine($"jogador {jogador2} ganhou na vertical coluna 1 \nFim de jogo ");
                        pontuacaoJogador2++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                }

                if (jogoDaVelha[0, 2] == jogoDaVelha[1, 2] && jogoDaVelha[2, 2] == jogoDaVelha[0, 2])
                {
                    if (jogoDaVelha[0, 2] == "X")
                    {
                        Console.WriteLine($"jogador {jogador1} ganhou na vertical coluna 2 \nFim de jogo ");
                        pontuacaoJogador1++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                    else if (jogoDaVelha[0, 2] == "O")
                    {
                        Console.WriteLine($"jogador {jogador2} ganhou na vertical coluna 2 \nFim de jogo ");
                        pontuacaoJogador2++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                }
                //Vitorias diagonal
                if (jogoDaVelha[0, 0] == jogoDaVelha[1, 1] && jogoDaVelha[2, 2] == jogoDaVelha[0, 0])
                {
                    if (jogoDaVelha[0, 0] == "X")
                    {
                        Console.WriteLine($"jogador {jogador1} ganhou na diagonal \nFim de jogo ");
                        pontuacaoJogador1++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                    else if (jogoDaVelha[0, 0] == "O")
                    {
                        Console.WriteLine($"jogador {jogador2} ganhou na diagonal \nFim de jogo ");
                        pontuacaoJogador2++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                }

                if (jogoDaVelha[0, 2] == jogoDaVelha[1, 1] && jogoDaVelha[2, 0] == jogoDaVelha[0, 2])
                {
                    if (jogoDaVelha[0, 2] == "X")
                    {
                        Console.WriteLine($"jogador {jogador1} ganhou na diagonal \nFim de jogo ");
                        pontuacaoJogador1++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                    else if (jogoDaVelha[0, 2] == "O")
                    {
                        Console.WriteLine($"jogador {jogador2} ganhou na diagonal \nFim de jogo ");
                        pontuacaoJogador2++;
                        pontuacao++;
                        jogoDaVelha = new string[3, 3];
                    }
                }
                if (quantidadeJogadas == 9)
                {
                    Console.WriteLine("Velha");
                    empate++;
                    pontuacao++;
                }
            } while (pontuacao == 0);

            quantidadeJogadas = 0;
            menuPlacar();
            opcao = int.Parse(Console.ReadLine());
            Console.Clear();
            if (opcao == 1)
            {

                jogoDaVelha = new string[3, 3];
                if (jogador % 2 == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Vez do jogador 2");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Vez do jogador 1");
                }
            }
            if (opcao == 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" PLACAR \n" +
                $"{jogador1} com {pontuacaoJogador1} VITORIAS \n" +
                $"{jogador2} com {pontuacaoJogador2} VITORIAS \n");
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

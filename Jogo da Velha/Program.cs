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
                          "* Sabendo que o primeiro numero e para linhas e o segundo para as colunas \n" +
                          "* Com um espaco entre os numeros \n" +
                 "         Ex:    Colunas  \n" +
                 "              0   1   2  \n" +
                 " linha 0                 \n" +
                 "             ---│---│--- \n" +
                 " linha 1                 \n" +
                 "             ---│---│--- \n" +
                 " Linha 2          X      \n" +
            "                              \n" +
            "  Nesse caso iria digitar os numeros ( 2 1 ) o numero 2 e o numero da linha e o 1 o numero da coluna  \n");
        do
        {
            do
            {
                pontuacao = 0;
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

                string[] vet = Console.ReadLine().Split();

                int l = int.Parse(vet[0]);
                int c = int.Parse(vet[1]);

                if (l < 0 || l > 2 || c < 0 || c > 2 || jogoDaVelha[l, c] == "X" || jogoDaVelha[l, c] == "O")
                {
                    Console.WriteLine("Posicao Invalida");
                    jogador--;
                }

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
                    if (l != 2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("--│---│--");
                    }
                }
         
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

            menuPlacar();
            opcao = int.Parse(Console.ReadLine());
            if (opcao == 1)
            {
                break;
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

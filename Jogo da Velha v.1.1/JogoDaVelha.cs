using FuncionamentoJogo;
using JogadoresGerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JogadoresGerais;
using GeralJogo;

namespace JogoDaVelhaA
{
    public class JogoDaVelha
    {

        public static void jogo(int p0, int p1)
        {
            string[,] jogoDaVelha = new string[3, 3];
            int pontuacao, quantidadeJogadas = 0, opcao, jogador = 0;

            Console.WriteLine("           INSTRUCAO DO JOGO \n" +
                             "* O primeiro jogador ficara com  X \n" +
                             "* O segundo jogador ficara com  O \n" +
                             "* Digite a localizacao que sera colocado \n" +
                             "* Digite apenas o numero do local que deseja jogar \n" +

                    "              1   4   7  \n" +
                    "             ---│---│--- \n" +
                    "              2   5   8  \n" +
                    "             ---│---│--- \n" +
            "              3   6   9  \n\n" +
                 $"   Vez do jogador {Jogador.jogadores[p0].Nome}\n");

            do
            {
                // Proxima dupla de jogadores
                do
                {
                    pontuacao = 0;
                    int l = 0;
                    int c = 0;
                    int number = int.Parse(Console.ReadLine());
                    Jogo.guia();
                    if (jogador % 2 == 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Vez do jogador {Jogador.jogadores[p0].Nome}");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Vez do jogador {Jogador.jogadores[p1].Nome}");
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
                    //Console.ForegroundColor = ConsoleColor.Yellow;
                    //string temp = jogoDaVelha[l, c];

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

                    Console.WriteLine();       //Vitorias Horizontal ok

                    quantidadeJogadas++;
                    for (int linha = 0; linha < 3; linha++)
                    {
                        if (jogoDaVelha[linha, 0] == jogoDaVelha[linha, 1] && jogoDaVelha[linha, 2] == jogoDaVelha[linha, 0])
                        {
                            if (jogoDaVelha[linha, 0] == "X")
                            {
                                Console.WriteLine($"jogador {Jogador.jogadores[p0].Nome} ganhou na horiontal \nFim de jogo ");
                                Jogador.ganhadorJogador1();
                                pontuacao++;
                            }
                            else if (jogoDaVelha[linha, 0] == "O")
                            {
                                Console.WriteLine($"jogador {Jogador.jogadores[p1].Nome} ganhou na horizontal \nFim de jogo ");
                                Jogador.ganhadorJogador2();
                                pontuacao++;
                            }
                        }
                    }
                    //Vitorias vertical
                    for (int coluna = 0; coluna < 3; coluna++)
                    {
                        if (jogoDaVelha[0, coluna] == jogoDaVelha[1, coluna] && jogoDaVelha[2, coluna] == jogoDaVelha[0, coluna])
                        {
                            if (jogoDaVelha[0, coluna] == "X")
                            {
                                Console.WriteLine($"jogador {Jogador.jogadores[p0].Nome} ganhou na vertical coluna 0 \nFim de jogo ");
                                Jogador.ganhadorJogador1();
                                pontuacao++;

                            }
                            else if (jogoDaVelha[0, coluna] == "O")
                            {
                                Console.WriteLine($"jogador {Jogador.jogadores[p1].Nome} ganhou na vertical coluna 0 \nFim de jogo ");
                                Jogador.ganhadorJogador2();
                                pontuacao++;
                            }
                        }
                    }
                    //Vitorias diagonal
                    if (jogoDaVelha[0, 0] == jogoDaVelha[1, 1] && jogoDaVelha[2, 2] == jogoDaVelha[0, 0])
                    {
                        if (jogoDaVelha[0, 0] == "X")
                        {
                            Console.WriteLine($"jogador {Jogador.jogadores[p0].Nome} ganhou na diagonal \nFim de jogo ");
                            Jogador.ganhadorJogador1();
                            pontuacao++;
                        }
                        else if (jogoDaVelha[0, 0] == "O")
                        {
                            Console.WriteLine($"jogador {Jogador.jogadores[p1].Nome} ganhou na diagonal \nFim de jogo ");
                            Jogador.ganhadorJogador2();
                            pontuacao++;
                        }
                    }
                    if (jogoDaVelha[2, 0] == jogoDaVelha[1, 1] && jogoDaVelha[0, 2] == jogoDaVelha[1, 1])
                    {
                        if (jogoDaVelha[1, 1] == "X")
                        {
                            Console.WriteLine($"jogador {Jogador.jogadores[p0].Nome} ganhou na diagonal \nFim de jogo ");
                            Jogador.ganhadorJogador1();
                            pontuacao++;

                        }
                        else if (jogoDaVelha[1, 1] == "O")
                        {
                            Console.WriteLine($"jogador {Jogador.jogadores[p1].Nome} ganhou na diagonal \nFim de jogo ");
                            Jogador.ganhadorJogador2(); ;
                            pontuacao++;
                        }
                    }

                    if (quantidadeJogadas == 9)
                    {
                        Console.WriteLine("Velha");
                        Jogador.empate();

                        pontuacao++;
                    }

                } while (pontuacao == 0);

                quantidadeJogadas = 0;

            inicio:
                Program.menuPlacar();

                opcao = int.Parse(Console.ReadLine());
                Console.Clear();
                if (opcao == 1)
                {
                    Program.escolhaDoJogo(p0, p1);
                }

                if (opcao == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" PLACAR \n");
                    Jogador.mostrarJogadores();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Program.menuPlacar();
                    opcao = int.Parse(Console.ReadLine());
                }
                if (opcao == 3)
                {
                    Console.WriteLine("Qual a quantidade de jogadores");
                    int quantidadeDeJogadores = int.Parse(Console.ReadLine());

                    for (int i = 1; i <= quantidadeDeJogadores; i++)
                    {
                        Console.Write($"Nome do {i} jogador: ");
                        string jogador1 = Console.ReadLine();
                        Jogador.adicionarJogador(jogador1);
                    }
                    goto inicio;
                }
                else if (opcao == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("JOGO ENCERRADO");
                }

            } while (opcao == 1);

        }
    }
}

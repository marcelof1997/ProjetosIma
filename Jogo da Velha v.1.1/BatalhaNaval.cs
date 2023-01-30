using FuncionamentoJogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JogadoresGerais;
using GeralJogo;
using System.Security.Cryptography.X509Certificates;

namespace JogoBatalhaNaval
{
    public class BatalhaNaval
    {
        private static void menuPlacar()
        {
            Console.WriteLine("Para novo jogo digite ----(1)");
            Console.WriteLine("Para PLACAR digite -------(2)");
            Console.WriteLine("Para sair digite ---------(0)");
        }
        public BatalhaNaval()
        {

        }
        public static void jogo()
        {

            string[,] Naval = new string[8, 8];
            int pontuacao = 0, quantidadeJogadas = 0, opcao = 1, jogador = 0;

            Console.WriteLine(Jogador.jogadores[0].Nome);
            Console.WriteLine();

            string a = "#";


            Console.WriteLine("           INSTRUCAO DO JOGO \n" +
                "* Para escolher o local onde deseja ver se tem navio digite uma letra correspondente as linhas e aperte enter\n" +
                "* Digite um numero correspondente as colunas e aperte enter\n" +
                "* Apos escolher sera destampado e vc vera se acertou o navio ou nao\n" +
                "* Esse é o navio ±\n" +
                "* Quando acerta a bomba so na agua ≈ caso nao tenha navio\n\n " +
                "* Ao final de 15 jogadas sera encerrado e contabilizado os pontos de cada jogador\n" +
                "            BOA SORTE\n\n");
            static void tabuleiroNaval()
            {

                Console.ResetColor();
                Console.WriteLine("                      1   2   3   4   5   6   7   8  \n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("                    |---│---│---|---|---│---│---|---|");
                Console.ResetColor();
                Console.WriteLine("               a                                 ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("                    |---│---│---|---|---│---│---|---|");
                Console.ResetColor();
                Console.WriteLine("               b                                      ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("                    |---│---│---|---|---│---│---|---|");
                Console.ResetColor();
                Console.WriteLine("               c                                     ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("                    |---│---│---|---|---│---│---|---|");
                Console.ResetColor();
                Console.WriteLine("               d                                     ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("                    |---│---│---|---|---│---│---|---|");
                Console.ResetColor();
                Console.WriteLine("               e                                     ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("                    |---│---│---|---|---│---│---|---|");
                Console.ResetColor();
                Console.WriteLine("               f                                     ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("                    |---│---│---|---|---│---│---|---|");
                Console.ResetColor();
                Console.WriteLine("               g                                     ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("                    |---│---│---|---|---│---│---|---|");
                Console.ResetColor();
                Console.WriteLine("               h                                          ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("                    |---│---│---|---|---│---│---|---|\n\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Digite uma letra enter e um numero e enter");
            }
            tabuleiroNaval();
            pontuacao = 0;
            int l = 0;




            do
            {

                do
                {
                    string letra = Console.ReadLine();
                    int c = int.Parse(Console.ReadLine());
                    Console.Clear();

                    if (jogador % 2 == 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Vez do jogador {Jogador.jogadores[0].Nome}");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Vez do jogador {Jogador.jogadores[1].Nome}");
                    }


                    switch (letra)
                    {
                        case "a":
                            l = 0;
                            break;
                        case "b":
                            l = 1;
                            break;
                        case "c":
                            l = 2;
                            break;
                        case "d":
                            l = 3;
                            break;
                        case "e":
                            l = 4;
                            break;
                        case "f":
                            l = 5;
                            break;
                        case "g":
                            l = 6;
                            break;
                        case "h":
                            l = 7;
                            break;
                    }

                    if (l < 0 || l > 7 || c < 0 || c > 7 || Naval[l, c] == "±" || Naval[l, c] == "*")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Posicao Invalida , Tente outra..");
                        jogador--;
                        quantidadeJogadas--;
                    }

                    jogador++;

                    Console.ForegroundColor = ConsoleColor.Blue;

                    if (l == 0 && c == 0 || l == 1 && c == 1 || l == 2 && c == 2 || l == 2 && c == 5 || l == 3 && c == 6 || l == 7 && c == 7 || l == 7 && c == 3 || l == 4 && c == 4 || l == 5 && c == 4 || l == 2 && c == 4 || l == 1 && c == 5 || l == 1 && c == 3 || l == 2 && c == 6 || l == 5 && c == 2 || l == 3 && c == 4 || l == 7 && c == 5)
                    {
                        Naval[l, c] = "±";
                        if (jogador % 2 == 1)
                        {
                            Jogador.pontosJogador1();
                        }
                        else
                        {
                            Jogador.pontosJogador2();
                        }
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Boaaa um Navio");
                        pontuacao++;
                    }
                    else
                    {
                        Naval[l, c] = "≈";
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("BOMBA NA AGUA!!!!!");
                    }

                    for (l = 0; l <= 7; l++)
                    {
                        for (c = 0; c <= 7; c++)
                        {
                            if (Naval[l, c] == null)
                            {
                                Naval[l, c] = " ";
                            }
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.WriteLine("                       0   1   2   3   4    5   6   7\n");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("                      |---│---│---|---|---│---│---|---|");
                    Console.ResetColor();
                    Console.WriteLine($"                a       {Naval[0, 0]}   {Naval[0, 1]}   {Naval[0, 2]}   {Naval[0, 3]}   {Naval[0, 4]}   {Naval[0, 5]}   {Naval[0, 6]}   {Naval[0, 7]}");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("                      |---│---│---|---|---│---│---|---|");
                    Console.ResetColor();
                    Console.WriteLine($"                b       {Naval[1, 0]}   {Naval[1, 1]}   {Naval[1, 2]}   {Naval[1, 3]}   {Naval[1, 4]}   {Naval[1, 5]}   {Naval[1, 6]}   {Naval[1, 7]}");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("                      |---│---│---|---|---│---│---|---|");
                    Console.ResetColor();
                    Console.WriteLine($"                c       {Naval[2, 0]}   {Naval[2, 1]}   {Naval[2, 2]}   {Naval[2, 3]}   {Naval[2, 4]}   {Naval[2, 5]}   {Naval[2, 6]}   {Naval[2, 7]}");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("                      |---│---│---|---|---│---│---|---|");
                    Console.ResetColor();
                    Console.WriteLine($"                d       {Naval[3, 0]}   {Naval[3, 1]}   {Naval[3, 2]}   {Naval[3, 3]}   {Naval[3, 4]}   {Naval[3, 5]}   {Naval[3, 6]}   {Naval[3, 7]}");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("                      |---│---│---|---|---│---│---|---|");
                    Console.ResetColor();
                    Console.WriteLine($"                e       {Naval[4, 0]}   {Naval[4, 1]}   {Naval[4, 2]}   {Naval[4, 3]}   {Naval[4, 4]}   {Naval[4, 5]}   {Naval[4, 6]}   {Naval[4, 7]}");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("                      |---│---│---|---|---│---│---|---|");
                    Console.ResetColor();
                    Console.WriteLine($"                f       {Naval[5, 0]}   {Naval[5, 1]}   {Naval[5, 2]}   {Naval[5, 3]}   {Naval[5, 4]}   {Naval[5, 5]}   {Naval[5, 6]}   {Naval[5, 7]}");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("                      |---│---│---|---|---│---│---|---|");
                    Console.ResetColor();
                    Console.WriteLine($"                g       {Naval[6, 0]}   {Naval[6, 1]}   {Naval[6, 2]}   {Naval[6, 3]}   {Naval[6, 4]}   {Naval[6, 5]}   {Naval[6, 6]}   {Naval[6, 7]}");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("                      |---│---│---|---|---│---│---|---|");
                    Console.ResetColor();
                    Console.WriteLine($"                h       {Naval[7, 0]}   {Naval[7, 1]}   {Naval[7, 2]}   {Naval[7, 3]}   {Naval[7, 4]}   {Naval[7, 5]}   {Naval[7, 6]}   {Naval[7, 7]}");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("                      |---│---│---|---|---│---│---|---|");

                    Console.ForegroundColor = ConsoleColor.Green;

                    quantidadeJogadas++;

                } while (quantidadeJogadas < 4);

                quantidadeJogadas = 0;

                menuPlacar();

                opcao = int.Parse(Console.ReadLine());
                Console.Clear();
                if (opcao == 1)
                {
                    Naval = new string[3, 3];

                    if (jogador % 2 == 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Vez do jogador {Jogador.jogadores[0].Nome}");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Vez do jogador {Jogador.jogadores[1].Nome}");
                    }
                }
                if (opcao == 2)
                {

                    if (Jogador.jogadores[0].Pontos > Jogador.jogadores[1].Pontos)
                    {
                        Jogador.jogadores[0].Vitoria++;
                        Jogador.jogadores[1].Derrota++;
                        Console.WriteLine($"{Jogador.jogadores[0].Nome} Ganhou");
                    }
                    else if (Jogador.jogadores[1].Pontos > Jogador.jogadores[0].Pontos)
                    {
                        Jogador.jogadores[1].Vitoria++;
                        Jogador.jogadores[0].Derrota++;
                        Console.WriteLine($"{Jogador.jogadores[1].Nome} Ganhou");
                    }
                    else
                    {
                        Jogador.jogadores[1].Empate++;
                        Jogador.jogadores[0].Empate++;
                        Console.WriteLine("Deu Empate");
                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" PLACAR \n");
                    Jogador.mostrarJogadores();

                    Console.ForegroundColor = ConsoleColor.Green;
                    menuPlacar();
                    opcao = int.Parse(Console.ReadLine());
                }
                if (opcao == 1)
                {
                    Naval = new string[8, 8];
                    tabuleiroNaval();
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
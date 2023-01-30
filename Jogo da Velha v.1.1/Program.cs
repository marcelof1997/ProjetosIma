using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using JogadoresGerais;
using FuncionamentoJogo;
using JogoBatalhaNaval;
using JogoDaVelhaA;

namespace GeralJogo
{

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
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Nome do primeiro jogador: ");
            string jogador1 = Console.ReadLine();
            Jogador.adicionarJogador(jogador1);

            Console.Write("Nome do segundo jogador: ");
            string jogador2 = Console.ReadLine();
            Jogador.adicionarJogador(jogador2);
            Console.WriteLine();

            Console.WriteLine("Escolha o jogo \n" +
                              "Batalha Naval --- (1)\n" +
                              "Jogo da Velha --- (2)\n");
            int escolhaDeJogo = int.Parse(Console.ReadLine());
            Console.Clear();

            if(escolhaDeJogo == 1)
            {
                BatalhaNaval.jogo();
            }
            else if(escolhaDeJogo==2)
            {
                JogoDaVelha.jogo();
            }

           
        }


    }

}
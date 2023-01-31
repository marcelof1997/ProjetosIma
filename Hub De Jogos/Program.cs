using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using JogadoresGerais;
using FuncionamentoJogo;
using JogoBatalhaNaval;
using JogoDaVelhaA;
using System.Reflection.PortableExecutable;

namespace GeralJogo
{
    public class Program
    {
        public static void escolhaDoJogo(int posicao, int posicao2)
        {

            Console.WriteLine("Escolha o jogo \n" +
                              "Batalha Naval --- (1)\n" +
                              "Jogo da Velha --- (2)\n");
            int escolhaDeJogo = int.Parse(Console.ReadLine());

            if (escolhaDeJogo == 1)
            {
                BatalhaNaval.jogo(posicao, posicao2);
            }
            else if (escolhaDeJogo == 2)
            {
                JogoDaVelha.jogo(posicao, posicao2);
            }

        }
        public static void menuPlacar()
        {
            Console.WriteLine("Para novo jogo digite -------------(1)");
            Console.WriteLine("Para PLACAR digite ----------------(2)");
            Console.WriteLine("Para adicionar novos jogadores --- (3)");
            Console.WriteLine("Para sair digite ------------------(0)");
        }
        public static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Green;

            string jogador1;
            string jogador2;

            Console.WriteLine("Qual a quantidade de jogadores");
            int quantidadeDeJogadores = int.Parse(Console.ReadLine());

            for (int i = 1; i <= quantidadeDeJogadores; i++)
            {
                Console.Write($"Nome do {i} jogador: ");
                jogador1 = Console.ReadLine();
                Jogador.adicionarJogador(jogador1);
            }

            Console.Clear();

            Console.Write("Nome do primeiro jogador que vai jogar: ");
            jogador1 = Console.ReadLine();


            int posicao = Jogador.jogadores.FindIndex(j => j.Nome == jogador1);

            while (posicao < 0)
            {
                Console.WriteLine("nao existe");
                jogador1 = Console.ReadLine();
                posicao = Jogador.jogadores.FindIndex(j => j.Nome == jogador1);
            }

            Console.Write("Nome do segundo jogador que vai jogar: ");
            jogador1 = Console.ReadLine();

            int posicao2 = Jogador.jogadores.FindIndex(j => j.Nome == jogador1);

            while (posicao < 0)
            {
                Console.WriteLine("nao existe");
                jogador1 = Console.ReadLine();
                posicao2 = Jogador.jogadores.FindIndex(j => j.Nome == jogador1);
            }

            escolhaDoJogo(posicao, posicao2);


        }


    }
}
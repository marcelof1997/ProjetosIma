using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogadoresGerais
{
    public class Jogador
    {
        public static List<Jogador> jogadores = new List<Jogador>();
        public string Nome { get; set; }
        public int Vitoria {get; set; }
        public int Derrota { get; set; }
        public int Empate { get; set; }
        public int Pontos { get; set; }

        public Jogador(string nome, int vitoria, int derrota,int empate, int pontos)
        {
            Nome = nome;
            Vitoria = vitoria;
            Derrota = derrota;
            Empate = empate;
            Pontos = pontos;
        }
        public static void adicionarJogador(string nome)
        {
            
          jogadores.Add(new Jogador ( nome, 0, 0, 0, 0 ));
            
        }

        public static void mostrarJogadores()
        {
            foreach(Jogador jogador in jogadores)
            {
                Console.WriteLine($"Nome: {jogador.Nome} | Vitorias: {jogador.Vitoria} | Derrotas: {jogador.Derrota} | Empates: {jogador.Empate}");
            }
               
        }
        public static void ganhadorJogador1()
        {
            jogadores[0].Vitoria++;
            jogadores[1].Derrota++;
        }
        public static void ganhadorJogador2()
        {
            jogadores[1].Vitoria++;
            jogadores[0].Derrota++;
        }

        public static void empate()
        {
            jogadores[0].Empate++;
            jogadores[1].Empate++;
        }
        public static void pontosJogador1()
        {
            jogadores[0].Pontos++;
        }
        public static void pontosJogador2()
        {
            jogadores[1].Pontos++;
        }
    }
}

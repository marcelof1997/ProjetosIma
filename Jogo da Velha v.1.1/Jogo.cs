using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionamentoJogo
{
    public class Jogo
    {
        public static void mostrarJogo()
        {
            var jogo = new Jogo();

            
        } 
       public static void guia()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.WriteLine("    GUIA \n" +
            "      1   4   7  \n" +
            "     ---│---│--- \n" +
            "      2   5   8  \n" +
            "     ---│---│--- \n" +
            "      3   6   9  \n");

            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}


using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

namespace NewBank
{
    public class Program
    {

        static void menuPrincipal()
        {
            Console.WriteLine("Inserir novo usuario -----------------------(1)");
            Console.WriteLine("Deletar um usuario -------------------------(2)");
            Console.WriteLine("Listar todas as contas registradas ---------(3)");
            Console.WriteLine("Detalhes de um usuario ---------------------(4)");
            Console.WriteLine("Quantia armazenado no banco digite ---------(5)");
            Console.WriteLine("Manipular conta ----------------------------(6)");
            Console.WriteLine("Quantidade de usuarios armazenada no banco -(7)");
            Console.WriteLine("Sair do sistema ----------------------------(9)");
            Console.Write("Digite a opcao desejada : ");
        } // ok
        static void menu()         //funcao menu principal funcionando//
        {
            Console.WriteLine("         Escolha uma das opcoes abaixo           ");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine("Para olhar seu saldo digite -------------------(1)");
            Console.WriteLine("Para realizar um saque digite -----------------(2)");
            Console.WriteLine("Para realizar uma transferencia digite --------(3)");
            Console.WriteLine("Para realizar um deposito digite --------------(4)");
            Console.WriteLine("Para simular investimentos digite -------------(5)");
            Console.WriteLine("Para comprar cryptos moedas -------------------(6)"); // ainda em producao feito apenas aqui ainda falta fazer o menu//
            Console.WriteLine("Para solicitar um cartao ----------------------(7)");
            Console.WriteLine("Para Retornar ao menu principal ---------------(8)\n");
            return;
        }
        static void opcaoInvalida()       //funcao opcaoInvalida funcionando//
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("________________________________");
            Console.WriteLine("│Opcao invalida tente novamente│");
            Console.WriteLine("--------------------------------\n");
            Console.ForegroundColor = ConsoleColor.Green;
        }

        static void retornoEncerrar()                  //funcao retorno funcionando ok 
        {
            Console.WriteLine("Para retornar para o menu do usuario digite ---(0)");
            Console.WriteLine("Para retornar para o menu principal -----------(8)\n");
        }

        static void RegistrarNovoUsusario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Write("Digite o cpf: ");
            cpfs.Add(Console.ReadLine());
            Console.Write("Digite o titular: ");
            titulares.Add(Console.ReadLine());
            Console.Write("Digite a senha: ");
            Console.ForegroundColor = ConsoleColor.Black;
            senhas.Add(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            saldos.Add(0);
        } // ok
        static void ListarTodasAsContas(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            for (int i = 0; i < cpfs.Count; i++)
            {
                Console.WriteLine($"CPF = {cpfs[i]} | Titular = {titulares[i]} | Saldo = R${saldos[i]:F2}");
            }
        }     // listar contas ok
        public static void cpfNaoEncontrado()
        {
            Console.BackgroundColor= ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("CPF nao encontrado na base de dados\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor= ConsoleColor.Black;
        }

        static void nomeBanco()
        {
            Console.WriteLine("\r\n /$$$$$$$  /$$     /$$/$$$$$$$$/$$$$$$$$       /$$$$$$$   /$$$$$$  /$$   /$$ /$$   /$$" +
                              "\r\n| $$__  $$|  $$   /$$/__  $$__/ $$_____/      | $$__  $$ /$$__  $$| $$$ | $$| $$  /$$/" +
                              "\r\n| $$  \\ $$ \\  $$ /$$/   | $$  | $$            | $$  \\ $$| $$  \\ $$| $$$$| $$| $$ /$$/ " +
                              "\r\n| $$$$$$$   \\  $$$$/    | $$  | $$$$$         | $$$$$$$ | $$$$$$$$| $$ $$ $$| $$$$$/  " +
                              "\r\n| $$__  $$   \\  $$/     | $$  | $$__/         | $$__  $$| $$__  $$| $$  $$$$| $$  $$  " +
                              "\r\n| $$  \\ $$    | $$      | $$  | $$            | $$  \\ $$| $$  | $$| $$\\  $$$| $$\\  $$ " +
                              "\r\n| $$$$$$$/    | $$      | $$  | $$$$$$$$      | $$$$$$$/| $$  | $$| $$ \\  $$| $$ \\  $$" +
                              "\r\n|_______/     |__/      |__/  |________/      |_______/ |__/  |__/|__/  \\__/|__/  \\__/" +                  
                              "\r\n");

        }          // nome do bank ok

        static void Main(string[] args)
        {
            double totalDeSaldos = 0;
            int opcaoPrincipal;
            int quantidade = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            int n = 0;

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            nomeBanco();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            string cont = "......................................................................................................";
            for (int i = 0; i <cont.Length; i++) 
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($"Progress {i}% ");
                Console.ResetColor();

                cont = cont.Substring(0, i) + "#" + cont.Substring(i + 1);
                Console.WriteLine(cont);                
                Thread.Sleep(30);
                Console.Clear();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Vamos configurar o sitema ");

            Console.Write("Digite a quantidade de usuarios : ");
            int quantidadeDeUsuarios = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Clear();

            List<string> cpfs = new List<string>();
            List<string> titulares = new List<string>();
            List<double> saldos = new List<double>();
            List<string> senhas = new List<string>();
            do
            {
                do
                {
                    do
                    {
                        menuPrincipal();                                  //Menu principal
                        opcaoPrincipal = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.Clear();
                        if (opcaoPrincipal < 0 || opcaoPrincipal > 9 || opcaoPrincipal == 8 ) { opcaoInvalida(); Console.WriteLine(); }
                    } while (opcaoPrincipal < 0 || opcaoPrincipal > 9 || opcaoPrincipal == 8);                                 // ok


                    if (opcaoPrincipal == 1)
                    {
                        for (int i = 0; i < quantidadeDeUsuarios; i++)
                        {
                            RegistrarNovoUsusario(cpfs, titulares, senhas, saldos);
                        }
                    }          //ok
                    if (opcaoPrincipal == 2)
                    {
                        Console.WriteLine("Qual o cpf do usuario que sera deletado ?");  
                        string remove = Console.ReadLine();
                        int cpfARemover = cpfs.FindIndex(x => x == remove);
                        
                        if (cpfARemover == -1)
                        {
                            Console.WriteLine();
                            cpfNaoEncontrado();
                        }       //ok
                        else
                        {
                            cpfs.Remove(remove);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("CPF removido com sucesso\n");
                            Console.ForegroundColor = ConsoleColor.Green;
                        }

                    }         //ok
                    if (opcaoPrincipal == 3)
                    {
                        ListarTodasAsContas(cpfs, titulares, saldos);
                        Console.WriteLine();
                    }        //ok
                    if (opcaoPrincipal == 4)
                    {
                        Console.Write("Qual o CPF do usuario : ");
                        int cpf = cpfs.IndexOf(Console.ReadLine());                                                                   // ok

                        if (cpf == -1)
                        {
                            cpfNaoEncontrado();
                        }     
                        else
                        {
                            Console.WriteLine($"CPF = {cpfs[cpf]} | Titular = {titulares[cpf]} | Saldo = R${saldos[cpf]:F2}");
                        }

                    }        //ok
                    if (opcaoPrincipal == 5)
                    {
                        for (int i = 0; i < cpfs.Count; i++)
                        {
                            totalDeSaldos = totalDeSaldos + saldos[i];
                        }
                        Console.WriteLine($"Quantia Armazenada no banco é R${totalDeSaldos:F2}");
                        totalDeSaldos = 0;
                    }        //ok
                    if (opcaoPrincipal == 7)
                    {
                        for (int i = 0; i < cpfs.Count; i++)
                        {
                            quantidade++;
                        }
                        Console.WriteLine($"A quantidade armazenada no banco é de {quantidade} usuarios");
                        quantidade = 0;
                    }        //ok

                } while (opcaoPrincipal != 6 && opcaoPrincipal != 9);

                if (opcaoPrincipal == 9)
                { Console.WriteLine("Encerrando sistema ...."); }             //ok

                if (opcaoPrincipal == 6)
                {
                    double deposito = 0, transferencia = 0, saque = 0, Breackcoin = 0, Meccoin = 0, Newcoin = 0;
                    int opcao = 0;
                    Console.Write("Digite o CPF do usuario: ");
                    string cod = Console.ReadLine();
                    Console.Clear();

                    int result = cpfs.FindIndex(x => x == cod);

                        int acess = 0;
                    while (result == -1 && acess != 2)
                    {
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("\nCPF incorreta*");
                        Console.ForegroundColor= ConsoleColor.Green;
                        cod = Console.ReadLine();
                        result = cpfs.FindIndex(x => x == cod);
                        acess++;
                        Console.Clear();
                    }
                    if (result >= 0 && result < cpfs.Count)            
                    {
                        acess= 0;
                        Console.WriteLine("CPF aceito\n");
                        Console.WriteLine("Digite a senha ");
                        Console.Write("***");
                        Console.ForegroundColor = ConsoleColor.Black;
                        string senhaInformada = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Green;

                            while (senhaInformada != senhas[result] && acess != 2) 
                        {
                            Console.ForegroundColor= ConsoleColor.Red;
                            Console.WriteLine("Senha invalida");
                            Console.ForegroundColor= ConsoleColor.Black;
                            senhaInformada = Console.ReadLine();
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            acess++;
                        }
                        if (acess >= 2)
                        {  
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("TENTATIVAS EXCEDIDAS\n");
                            Console.ForegroundColor =  ConsoleColor.Green;
                        }

                        if (senhas[result] == senhaInformada)
                        {
                            acess= 0;
                            Console.WriteLine("Senha Aceita\n");
                            Console.Clear();
                            Console.WriteLine("-------------------------------------------------");
                            Console.WriteLine("*******OLA SEJA BEM VINDO(A) AO BYTE BANK*********");
                            Console.WriteLine("-------------------------------------------------");
                            string nome = (titulares[result]);                       
                           
                            do                                                   
                            {
                                menu();
                                opcao = int.Parse(Console.ReadLine());
                                Console.Clear();

                                if (opcao > 9 || opcao < 0)
                                {
                                    opcaoInvalida();
                                }
                            } while (opcao > 9 || opcao < 0);                                             // nao precisa desse retorno

                            do
                            {
                                if (opcao == 1)  // saldo ok upgrade//
                                {
                                    Console.WriteLine($"{titulares[result]} Seu saldo atual é R$ {saldos[result]:F2}\n");
                                    Console.WriteLine("Suas criptomoedas:");
                                    Console.WriteLine($"Breackcoin B¢ {Breackcoin:F2}\nMeccoin M¢ {Meccoin:F2}\nNewcoin N¢ {Newcoin:F2}");
                                    retornoEncerrar(); opcao = int.Parse(Console.ReadLine());
                                    Console.Clear();
                                }
                                else if (opcao == 2)    // Area saque ok confirmar upgrade//
                                {
                                    
                                    Console.WriteLine($"{titulares[result]} Qual valor do saque ?");
                                    Console.Write("R$ ");
                                    saque = double.Parse(Console.ReadLine());
                                    while (saque <= 0)
                                    {
                                        Console.WriteLine("Valor invalido, tente novamente");
                                        saque = double.Parse(Console.ReadLine());
                                    }
                                    saldos[result] -= saque;
                                    Console.WriteLine("Saque realizado com sucesso...");
                                    Console.WriteLine($"{titulares[result]} Saldo atual é R$ {saldos[result]:F2}\n");
                                    retornoEncerrar(); opcao = int.Parse(Console.ReadLine());
                                    Console.Clear();

                                }       // Area de transferencia ok 
                                else if (opcao == 3)
                                {
                                    Console.WriteLine("Digite o cpf para quem a transferencia sera enviada ?");
                                    Console.Write("CPF: ");
                                    string cpfTransferencia = Console.ReadLine();
                                    int transfer = cpfs.FindIndex(x => x == cpfTransferencia);
                                    int trans = 2;
                                    while (transfer == -1 || cpfTransferencia == cpfs[result] && trans != 2)
                                    {
                                        trans++;
                                        Console.WriteLine("Usuario invalido, Tente novamente");
                                        cpfTransferencia = Console.ReadLine();
                                        transfer = cpfs.FindIndex(x => x == cpfTransferencia);
                                    }

                                    Console.WriteLine($"{titulares[result]} Qual valor da tranferencia?");
                                    Console.Write("R$ ");
                                    transferencia = double.Parse(Console.ReadLine());
                                    while (transferencia <= 0)
                                    {
                                        Console.WriteLine("Valor invalido, tente novamente");
                                        transferencia = double.Parse(Console.ReadLine());
                                    }
                                    Console.WriteLine($"Transferencia de {transferencia:F2} para {titulares[transfer]} confirma ? (s) ou (n) ");
                                    string resposta = Console.ReadLine();
                                    Console.Clear();                                                // usar variavel char
                                    if (resposta == "s")
                                    {
                                        saldos[result] -= transferencia;
                                        saldos[transfer] += transferencia;
                                        Console.WriteLine("Transferencia realizada com sucesso");
                                        Console.WriteLine($"{titulares[result]} Saldo atual é R$ {saldos[result]:F2}\n");
                                        retornoEncerrar(); opcao = int.Parse(Console.ReadLine());
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Transferencia nao efetivada");
                                        Console.WriteLine($"Saldo atual é R$ {saldos[result]:F2}\n");
                                        retornoEncerrar(); opcao = int.Parse(Console.ReadLine());
                                        Console.Clear();
                                    }
                                }
                                else if (opcao == 4)                                 // Area de deposito ok confirmar depois upgrade//
                                {
                                    Console.WriteLine($"{titulares[result]} Qual valor do deposito ?");
                                    Console.Write("R$ ");
                                    deposito = double.Parse(Console.ReadLine());
                                while(deposito <= 0 )
                                { 
                                    Console.WriteLine("Valor invalido, tente novamente");
                                    deposito = double.Parse(Console.ReadLine());
                                }
                                    saldos[result] += deposito;
                                    Console.WriteLine($"{titulares[result]} Saldo atual é R$ {saldos[result]:F2}\n");
                                    retornoEncerrar(); opcao = int.Parse(Console.ReadLine());
                                    Console.Clear();
                                }   
                                //Area de Investimentos ok
                                if (opcao == 5)
                                {
                                    Console.Write("Quanto gostaria de investir ?\nR$: ");
                                    int valorInvestido = int.Parse(Console.ReadLine());
                                    Console.Write("Quanto tempo seu dinheiro ficara investido ?\nMeses: ");
                                    int tempoInvestido = int.Parse(Console.ReadLine());
                                    Console.WriteLine("");

                                    double poupanca = valorInvestido * 0.005 * tempoInvestido;
                                    double rendaVariavel = valorInvestido * 0.01 * tempoInvestido;
                                    double fundosImobiliarios = valorInvestido * 0.015 * tempoInvestido;
                                    Console.WriteLine($"{titulares[result]} se investido em poupanca o retorno sera de R$ {poupanca:F2} = Totalizando R$ {valorInvestido + poupanca:F2}...");
                                    Console.WriteLine($"Se investido em renda variavel o retorno sera de R$ {rendaVariavel:F2} = Totalizando R$ {valorInvestido + rendaVariavel:F2}...");
                                    Console.WriteLine($"Se investido em fundos imobiliarios o retorno sera de R$ {fundosImobiliarios:F2} = Totalizando  R$ {valorInvestido + fundosImobiliarios:F2}...\n -----------------------------------");
                                    retornoEncerrar(); opcao = int.Parse(Console.ReadLine());
                                    Console.Clear();

                                }

                                else if (opcao == 6)
                                {
                                    Console.WriteLine("Qual crypto deseja comprar ?");
                                    Console.WriteLine("Breackcoin valor R$ 1.59 digite (1)\nMeccoin valor R$ 4.57 digite (2)\nNewcoin valor R$ 15.46 digite (3)");
                                    int crypto = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Quantos reais quer usar par comprar ?");
                                    double valor = double.Parse(Console.ReadLine());

                                    saldos[result] -= valor;

                                    if (crypto == 1)
                                    {
                                        Console.WriteLine($"Voce acaba de comprar B¢ {valor / 1.59:F2} de Breackcoin");
                                        Breackcoin = valor / 1.59;
                                    }
                                    else if (crypto == 2)
                                    {
                                        Console.WriteLine($"Voce acaba de comprar M¢ {valor / 4.57:F2} de Meccoin");
                                        Meccoin = valor / 4.57;
                                    }
                                    else if (crypto == 3)
                                    {
                                        Console.WriteLine($"Voce acaba de comprar N¢ {valor / 15.46:F2} de Newcoin");
                                        Newcoin = valor / 15.46;
                                    }
                                    Console.WriteLine($"Saldo atual é R$ {saldos[result]:F2}\n");
                                    retornoEncerrar(); opcao = int.Parse(Console.ReadLine());
                                }
                                else if (opcao == 7)
                                {
                                    Console.WriteLine("Qual cartao gostaria de fazer digite  (1) para (credito) ou (2) para (debito)");
                                    int tipoCartao = int.Parse(Console.ReadLine());

                                    if (tipoCartao == 1)
                                    {
                                        Console.WriteLine("Seu primeiro nome e um sobrenome por favor");
                                        string nomeCompleto = Console.ReadLine();

                                        Console.WriteLine("                                           SEU CARTAO ESTA PRONTO ");
                                        Console.WriteLine("                                    __________________________________________________________");
                                        Console.WriteLine("                                    │/////                                                   │");
                                        Console.WriteLine("                                    │///                                    BYTE BANK        │");
                                        Console.WriteLine("                                    │//******************************************************│");
                                        Console.WriteLine("                                    │/                BBBBBBB     BBBBBBB                    │");
                                        Console.WriteLine("                                    │                 BB     B    BB     B                   │");
                                        Console.WriteLine("                                    │                 BB B BB     BB B BB                    │");
                                        Console.WriteLine("                                    │                 BB B BB     BB B BB                    │");
                                        Console.WriteLine("                                    │                 BB     B    BB     B                   │");
                                        Console.WriteLine("                                    │                 BBBBB B     BBBBB B                    │");
                                        Console.WriteLine("                                    │  08/30                                                 │");
                                        Console.WriteLine("                                    │_______________________________________CREDITO__________│");
                                        Console.WriteLine("                                    │    ♥  " + nomeCompleto + "                   ////////////");
                                        Console.WriteLine("                                    │________________________________________________________│\n");
                                        retornoEncerrar(); opcao = int.Parse(Console.ReadLine());
                                    }                //cartao 1 ok
                                    else if (tipoCartao == 2)
                                    {
                                        Console.WriteLine("Seu primeiro nome e um sobrenome por favor");
                                        string nomeCompleto = Console.ReadLine();
                                        Console.ForegroundColor = ConsoleColor.Red;

                                        Console.WriteLine("                                           SEU CARTAO ESTA PRONTO ");
                                        Console.WriteLine("                                    __________________________________________________________");
                                        Console.WriteLine("                                    │/////                                                   │");
                                        Console.WriteLine("                                    │///                                    BYTE BANK        │");
                                        Console.WriteLine("                                    │//******************************************************│");
                                        Console.WriteLine("                                    │/                BBBBBBB     BBBBBBB                    │");
                                        Console.WriteLine("                                    │                 BB     B    BB     B                   │");
                                        Console.WriteLine("                                    │                 BB B BB     BB B BB                    │");
                                        Console.WriteLine("                                    │                 BB B BB     BB B BB                    │");
                                        Console.WriteLine("                                    │                 BB     B    BB     B                   │");
                                        Console.WriteLine("                                    │                 BBBBB B     BBBBB B                    │");
                                        Console.WriteLine("                                    │  05/31                                                 │");
                                        Console.WriteLine("                                    │_______________________________________DEBITO___________│");
                                        Console.WriteLine("                                    │    ♥  " + nomeCompleto + "                   ////////////");
                                        Console.WriteLine("                                    │________________________________________________________│\n");
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        retornoEncerrar(); opcao = int.Parse(Console.ReadLine()); ;
                                    }           //cartao 2 ok
                                }
                                if (opcao == 0)
                                {
                                    do
                                    {
                                        menu(); opcao = int.Parse(Console.ReadLine());   
                                        if (opcao > 9 || opcao < 0)
                                        {
                                            opcaoInvalida();
                                        }
                                    } while (opcao > 9 || opcao < 0);  // retorno ok
                                }
                            } while (opcao != 8);
                        }
                    }
                }
            } while (opcaoPrincipal != 9);
        }
        
    }

}
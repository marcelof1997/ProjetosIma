using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Xml;

namespace NewBank;
public class Program
{
    static void menuPrincipal()               
    {
        Console.WriteLine("Inserir novo usuario ---------------------(1)");
        Console.WriteLine("Deletar um usuario -----------------------(2)");
        Console.WriteLine("Listar todas as contas registradas -------(3)");
        Console.WriteLine("Detalhes de um usuario -------------------(4)");
        Console.WriteLine("Quantia armazenado no banco digite -------(5)");
        Console.WriteLine("Manipular conta --------------------------(6)");
        Console.WriteLine("Quantidade armazenada no banco------------(7)");
        Console.WriteLine("Sair do sistema --------------------------(9)");
        Console.Write("Digite a opcao desejada : ");
    }
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
        Console.WriteLine("________________________________");
        Console.WriteLine("│Opcao invalida tente novamente│");
        Console.WriteLine("--------------------------------\n");
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
        senhas.Add(Console.ReadLine());
        Console.WriteLine();
        saldos.Add(0);
    }
    static void ListarTodasAsContas(List<string> cpfs, List<string> titulares, List<double> saldos)
    {
        for (int i = 0; i < cpfs.Count; i++)
        {
            Console.WriteLine($"CPF = {cpfs[i]} | Titular = {titulares[i]} | Saldo = R${saldos[i]:F2}");
        }
    }
    static void Main(string[] args)
    {
        double totalDeSaldos = 0;
        int opcaoPrincipal;
        int quantidade = 0;
        Console.ForegroundColor = ConsoleColor.Green;



        Console.WriteLine("Vamos configurar o sitema ");

        Console.Write("Digite a quantidade de usuarios : ");
        int quantidadeDeUsuarios = int.Parse(Console.ReadLine());
        Console.WriteLine();

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
                    if (opcaoPrincipal < 0 || opcaoPrincipal > 9) { Console.WriteLine("Opcao invalida\n"); }
                } while (opcaoPrincipal < 0 || opcaoPrincipal > 9);

                if (opcaoPrincipal == 1)
                {
                    for (int i = 0; i < quantidadeDeUsuarios; i++)
                    {
                        RegistrarNovoUsusario(cpfs, titulares, senhas, saldos);
                    }
                }
                if (opcaoPrincipal == 2)
                {
                    Console.WriteLine("Qual o cpf do usuario que sera deletado ?");
                    cpfs.Remove(Console.ReadLine());

                    menuPrincipal();                                  //Menu principal
                    opcaoPrincipal = int.Parse(Console.ReadLine());
                    Console.WriteLine();                                                      
                }
                if (opcaoPrincipal == 3)
                {
                    ListarTodasAsContas(cpfs, titulares, saldos);
                    menuPrincipal();                                  //Menu principal
                    opcaoPrincipal = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                }
                if (opcaoPrincipal == 4)
                {
                    Console.Write("Qual o CPF do usuario : ");
                    int cpf = cpfs.IndexOf(Console.ReadLine());                                                                   // procurando cpf ok
                    Console.WriteLine($"CPF = {cpfs[cpf]} | Titular = {titulares[cpf]} | Saldo = R${saldos[cpf]:F2}");

                    menuPrincipal();                                  //Menu principal
                    opcaoPrincipal = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                }
                if (opcaoPrincipal == 5)
                {
                    for (int i = 0; i < cpfs.Count; i++)
                    {
                        totalDeSaldos = totalDeSaldos + saldos[i];
                        Console.WriteLine($"Quantia Armazenada no banco é R${totalDeSaldos}");
                        menuPrincipal();                                  //Menu principal
                        opcaoPrincipal = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                    }
                    if (opcaoPrincipal == 7)
                    {
                        for (int i = 0; i < cpfs.Count; i++)
                        {
                            quantidade++;
                            Console.WriteLine($"A quantidade de usuarios no banco é {quantidade} usuarios");
                        }
                    }
                }
            } while (opcaoPrincipal != 6 && opcaoPrincipal != 9);

            if (opcaoPrincipal == 9)
            { Console.WriteLine("Encerrando sistema ...."); }



            if (opcaoPrincipal == 6)
            {
                Console.Write("Qual cpf do usuario: ");
                int cpf = cpfs.IndexOf(Console.ReadLine());
                Console.Write("Qual a senha do usuario: ");
                int senha = senhas.IndexOf(Console.ReadLine());


                double saldo = 0, deposito = 0, transferencia = 0, saque = 0, Breackcoin = 0, Meccoin = 0, Newcoin = 0;
                int opcao = 0;
                Console.WriteLine("Digite a senha de acesso");
                Console.Write("*****");
                string cod = Console.ReadLine();

                int result = cpfs.FindIndex(x => x == cod);

                Console.WriteLine(result);
                Console.WriteLine("aqui");

                while (result == -1)
                {
                    Console.WriteLine(" CPF incorreta*");
                    cod = Console.ReadLine();
                    result = cpfs.FindIndex(x => x == cod);
                }
                if (result >= 0 && result < cpfs.Count)
                {
                    Console.WriteLine("***\nCPF aceito");
                    Console.WriteLine("Digite a senha ");
                    string senhaInformada = Console.ReadLine();
                    if (senhas[result] == senhaInformada)
                    {
                        Console.WriteLine("Senha Aceita");


                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine("*******OLA SEJA BEM VINDO(A) AO NEW BANK*********");
                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine("Seu nome por favor");
                        string nome = Console.ReadLine();

                        do     // returno confirmar//
                        {
                            menu();
                            opcao = int.Parse(Console.ReadLine());

                            if (opcao > 9 || opcao < 0)
                            {
                                opcaoInvalida();
                            }
                        } while (opcao > 9 || opcao < 0);

                        do
                        {
                            if (opcao == 1)  // saldo ok upgrade//
                            {
                                Console.WriteLine($"{nome} Seu saldo atual é R$ {saldo}\n");
                                Console.WriteLine($"Voce tem de Breackcoin B¢ {Breackcoin}\nMeccoin M¢ {Meccoin}\nNewcoin N¢ {Newcoin}");
                                retornoEncerrar(); opcao = int.Parse(Console.ReadLine());
                            }
                            else if (opcao == 2)    // Area saque ok confirmar upgrade//
                            {
                                Console.WriteLine($"{nome} Qual valor do saque ?");
                                Console.Write("R$ ");
                                saque = double.Parse(Console.ReadLine());
                                saldo -= saque;
                                Console.WriteLine("Sque realizado com sucesso...");
                                Console.WriteLine($"{nome} Saldo atual é R$ {saldo}\n");
                                retornoEncerrar(); opcao = int.Parse(Console.ReadLine());

                            }       // Area de transferencia ok 
                            else if (opcao == 3)
                            {
                                Console.WriteLine("Para quem a transferencia sera enviada ?");
                                Console.Write("NOME: ");
                                string nomeTransferencia = Console.ReadLine();
                                Console.WriteLine($"{nome} Qual valor da tranferencia?");
                                Console.Write("R$ ");
                                transferencia = double.Parse(Console.ReadLine());
                                Console.WriteLine($"Transferencia de {transferencia} para {nomeTransferencia} confirma ? (s) ou (n) ");
                                string resposta = Console.ReadLine();                                                                     // usar variavel char
                                if (resposta == "s")
                                {
                                    saldo -= transferencia;
                                    Console.WriteLine("Transferencia realizada com sucesso");
                                    Console.WriteLine($"{nome} Saldo atual é R$ {saldo}\n");
                                    retornoEncerrar(); opcao = int.Parse(Console.ReadLine());
                                }
                                else
                                {
                                    Console.WriteLine("Transferencia nao efetivada");
                                    Console.WriteLine($"Saldo atual é R$ {saldo}\n");
                                    retornoEncerrar(); opcao = int.Parse(Console.ReadLine());
                                }
                            }
                            else if (opcao == 4)  // Area de deposito ok confirmar depois upgrade//
                            {
                                Console.WriteLine($"{nome} Qual valor do deposito ?");
                                Console.Write("R$ ");
                                deposito = double.Parse(Console.ReadLine());
                                saldo += deposito;
                                Console.WriteLine($"{nome} Saldo atual é R$ {saldo}\n");
                                retornoEncerrar(); opcao = int.Parse(Console.ReadLine());
                            }
                            //Area de Investimentos ok
                            else if (opcao == 5)
                            {
                                Console.Write("Quanto gostaria de investir ?\nR$: ");
                                int valorInvestido = int.Parse(Console.ReadLine());
                                Console.Write("Quanto tempo seu dinheiro ficara investido ?\nMeses: ");
                                int tempoInvestido = int.Parse(Console.ReadLine());
                                Console.WriteLine("");

                                double poupanca = valorInvestido * 0.005 * tempoInvestido;
                                double rendaVariavel = valorInvestido * 0.01 * tempoInvestido;
                                double fundosImobiliarios = valorInvestido * 0.015 * tempoInvestido;
                                Console.WriteLine($"{nome} se investido em poupanca o retorno sera de R$ {poupanca} = Totalizando R$ {valorInvestido + poupanca}...");
                                Console.WriteLine($"Se investido em renda variavel o retorno sera de R$ {rendaVariavel} = Totalizando R$ {valorInvestido + rendaVariavel}...");
                                Console.WriteLine($"Se investido em fundos imobiliarios o retorno sera de R$ {fundosImobiliarios} = Totalizando  R$ {valorInvestido + fundosImobiliarios}...\n -----------------------------------");
                                retornoEncerrar(); opcao = int.Parse(Console.ReadLine());

                            }

                            else if (opcao == 6)
                            {
                                Console.WriteLine("Qual crypto deseja comprar ?");
                                Console.WriteLine("Breackcoin valor R$ 1.59 digite (1)\nMeccoin valor R$ 4.57 digite (2)\nNewcoin valor R$ 15.46 digite (3)");
                                int crypto = int.Parse(Console.ReadLine());
                                Console.WriteLine("Quantos reais quer usar par comprar ?");
                                double valor = double.Parse(Console.ReadLine());
                                saldo -= valor;

                                if (crypto == 1)
                                {
                                    Console.WriteLine($"Voce acaba de comprar B¢ {valor / 1.59} de Breackcoin");
                                    Breackcoin = valor / 1.59;
                                }
                                else if (crypto == 2)
                                {
                                    Console.WriteLine($"Voce acaba de comprar M¢ {valor / 4.57} de Meccoin");
                                    Meccoin = valor / 4.57;
                                }
                                else if (crypto == 3)
                                {
                                    Console.WriteLine($"Voce acaba de comprar N¢ {valor / 15.46} de Newcoin");
                                    Newcoin = valor / 15.46;
                                }
                                Console.WriteLine($"Saldo atual é R$ {saldo}\n");
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
                                    Console.WriteLine("                                    │///                                     NEW BANK        │");
                                    Console.WriteLine("                                    │//******************************************************│");
                                    Console.WriteLine("                                    │/                       NN   BBBBBBB                    │");
                                    Console.WriteLine("                                    │               NNNNN   NN    BB     B                   │");
                                    Console.WriteLine("                                    │               NN  NN NN     BB B BB                    │");
                                    Console.WriteLine("                                    │               NN   NNN      BB B BB                    │");
                                    Console.WriteLine("                                    │               NN            BB     B                   │");
                                    Console.WriteLine("                                    │               NN            BBBBB B                    │");
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
                                    Console.WriteLine("                                    │///                                     NEW BANK        │");
                                    Console.WriteLine("                                    │//******************************************************│");
                                    Console.WriteLine("                                    │/                       NN   BBBBBBB                    │");
                                    Console.WriteLine("                                    │               NNNNN   NN    BB     B                   │");
                                    Console.WriteLine("                                    │               NN  NN NN     BB B BB                    │");
                                    Console.WriteLine("                                    │               NN   NNN      BB B BB                    │");
                                    Console.WriteLine("                                    │               NN            BB     B                   │");
                                    Console.WriteLine("                                    │               NN            BBBBB B                    │");
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
                                } while (opcao > 9 || opcao < 0);
                            }
                            else if (opcao < 0 || opcao > 9)
                            {
                                do                    // retorno ok funcionando tudo certo//
                                {
                                    menu(); opcao = int.Parse(Console.ReadLine());
                                    if (opcao > 9 || opcao < 0)
                                    {
                                        opcaoInvalida();
                                    }
                                } while (opcao < 0 || opcao > 9);
                            }
                            else if (opcao == 8)
                            {
                                do
                                {
                                    menuPrincipal();                                  //Menu principal
                                    opcaoPrincipal = int.Parse(Console.ReadLine());
                                    Console.WriteLine();
                                    if (opcaoPrincipal < 0 || opcaoPrincipal > 6) { Console.WriteLine("Opcao invalida\n"); }
                                } while (opcaoPrincipal < 0 || opcaoPrincipal > 6);
                            }

                        } while (opcao != 8);
                    }
                }
            }
        } while (opcaoPrincipal != 9);
    }

}


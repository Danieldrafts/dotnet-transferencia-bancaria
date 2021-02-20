using System;
using DIO.Bank.Classes;
using DIO.Bank.Enum;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoSelecionada;
            opcaoSelecionada = Opcoes();

            while(opcaoSelecionada.ToLower() != "x")
            {
                switch(opcaoSelecionada)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "c":
                        Console.Clear();
                        break;
                }

                opcaoSelecionada = Opcoes();

            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadKey();
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor do deposito: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia: valorTransferencia
                                                    , contaDestino: listContas[indiceContaDestino]);

            Console.ReadKey();
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor do deposito: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
            Console.ReadKey();
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valod do saque: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
            Console.ReadKey();
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");

            if(listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i=0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }

            Console.ReadKey();
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova Conta");

            Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o Saldo Inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o Credito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta
                                         ,saldo: entradaSaldo
                                         ,credito: entradaCredito
                                         ,nome: entradaNome);

            listContas.Add(novaConta);
        }

        private static string Opcoes()
        {
            Console.Clear();
            string opcoes = "", resposta;

            opcoes += "1 - Listar\n";
            opcoes += "2 - Nova Conta\n";
            opcoes += "3 - Trasferir\n";
            opcoes += "4 - Sacar\n";
            opcoes += "5 - Depositar\n";
            opcoes += "x - Fechar\n";

            Console.WriteLine(opcoes);
            resposta = Console.ReadLine();

            return resposta;
        }
    }
}

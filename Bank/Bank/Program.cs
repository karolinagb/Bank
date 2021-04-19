using Bank;
using System;
using Bank.Enums;
using System.Collections.Generic;

namespace DIO.Bank
{
	class Program
	{
		static List<Account> listAccounts = new List<Account>();
		static void Main(string[] args)
		{
			string optionUser = GetUserOption();

			while (optionUser.ToUpper() != "X")
			{
				switch (optionUser)
				{
					case "1":
						ListAccounts();
						break;
					case "2":
						InsertAccounts();
						break;
					case "3":
						Transfer();
						break;
					case "4":
						Withdraw();
						break;
					case "5":
						Deposit();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				optionUser = GetUserOption();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

		private static void Deposit()
		{
			Console.Write("Digite o número da conta: ");
			int indexAccount = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser depositado: ");
			double valueDeposit = double.Parse(Console.ReadLine());

			listAccounts[indexAccount].Deposit(valueDeposit);
		}

		private static void Withdraw()
		{
			Console.Write("Digite o número da conta: ");
			int indexAccount = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser sacado: ");
			double valueWithdraw = double.Parse(Console.ReadLine());

			listAccounts[indexAccount].Withdraw(valueWithdraw);
		}

		private static void Transfer()
		{
			Console.Write("Digite o número da conta de origem: ");
			int indexOriginAccount = int.Parse(Console.ReadLine());

			Console.Write("Digite o número da conta de destino: ");
			int indexDestinyAccount = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser transferido: ");
			double valueTransfer = double.Parse(Console.ReadLine());

			listAccounts[indexOriginAccount].Transfer(valueTransfer, listAccounts[indexDestinyAccount]);
		}

		private static void InsertAccounts()
		{
			Console.WriteLine("Inserir nova conta");

			Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
			int inputTypeAccount = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome do Cliente: ");
			string inputName = Console.ReadLine();

			Console.Write("Digite o saldo inicial: ");
			double inputBalance = double.Parse(Console.ReadLine());

			Console.Write("Digite o crédito: ");
			double inputCredit = double.Parse(Console.ReadLine());

			Account account = new Account(inputName, inputBalance, inputCredit, (AccountType)inputTypeAccount);
			listAccounts.Add(account);
		}

		private static void ListAccounts()
		{
			Console.WriteLine("Listar contas");

			if (listAccounts.Count == 0)
			{
				Console.WriteLine("Nenhuma conta cadastrada.");
				return;
			}

			for (int i = 0; i < listAccounts.Count; i++)
			{
				Account conta = listAccounts[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(conta);
			}
		}

		private static string GetUserOption()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Bank a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar contas");
			Console.WriteLine("2- Inserir nova conta");
			Console.WriteLine("3- Transferir");
			Console.WriteLine("4- Sacar");
			Console.WriteLine("5- Depositar");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string optionUser = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return optionUser;
		}
	}
}

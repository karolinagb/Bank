using Bank.Enums;
using System;

namespace Bank
{
    public class Account
    {
        private string Name { get; set; }
        private double Balance { get; set; }
        private double Credit { get; set; }
        private AccountType AccountType { get; set; }

        public Account(string name, double balance, double credit, AccountType accountType)
        {
            Name = name;
            Balance = balance;
            Credit = credit;
            AccountType = accountType;
        }

        public bool Withdraw (double value)
        {
            if(Balance - value < (Credit *-1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            Balance = Balance - value;

            Console.WriteLine("Saldo atual de {0} é {1}", Name, Balance);

            return true;
        }

        public void Deposit (double value)
        {
            Balance = Balance + value;

            Console.WriteLine("Saldo atual de {0} é {1}", Name, Balance);
        }

        public void Transfer (double value, Account destiny)
        {
            if (Withdraw(value))
            {
                destiny.Deposit(value);
            }
        }

        public override string ToString()
        {
            string accountDetails = "";
            accountDetails += "Tipo de Conta: " + AccountType + " | ";
            accountDetails += "Nome: " + Name + " | ";
            accountDetails += "Saldo: " + Balance + " | ";
            accountDetails += "Crédito: " + Credit;
            return accountDetails;
        }
    }
}

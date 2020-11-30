using System;
using System.Collections.Generic;
using System.Text;

namespace bankappman
{
    class Savings : Account
    {
        public Savings() : base()
        {
        }

        public override bool deposit(double amount)
        {
            this.ammount = amount;
            this.balance = balance + ammount;
            Console.WriteLine("Ny saldo: " + balance);
            return true;
        }

        public override bool withdraw(double amount)
        {
            this.ammount = amount;
            this.balance = balance - ammount;
            Console.WriteLine("Ny saldo: " + balance);
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace bankappman
{
    
    class Credit : Account
    {
        public double minBalance = -100000;
        private double dailyWithdrawLimit = 20000;


        public Credit() : base()
        {
        }
        public Credit(string name, DOB DOB, string numrid, double balance) : base(name, DOB, numrid, balance)
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
            if (amount < this.minBalance)
            {
                Console.WriteLine("Ikke nok penger på konto!");
                return false;
            }
            else if (amount > dailyWithdrawLimit)
            {
                Console.WriteLine("Maks utak er 20000.");
                return false;
            }
            else
            {

                this.balance = balance - ammount;
                Console.WriteLine("Ny saldo: " + balance);
                return true;
            }
        }
    }
}

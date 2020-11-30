using System;
using System.Collections.Generic;
using System.Text;

namespace bankappman
{
    class Program
    {
        static void Main(string[] args)
        {
            String input;
            DOB dob = new DOB();
            IDGenerator id = new IDGenerator();
            Credit cr = new Credit();
            Debit db = new Debit();
            Savings sv = new Savings();
            Bank bn = new Bank();
            Console.WriteLine("****HenningsBank***");
            while (true)
            {
                Console.WriteLine("\nHva kan vi hjelpe deg med:");
                Console.WriteLine("1. Opprette konto");
                Console.WriteLine("2. Finn konto info");
                Console.WriteLine("3. Overføre beløp");
                Console.WriteLine("4. Ta ut beløp");
                Console.WriteLine("5. Hvis alle kontor med id");
                Console.WriteLine("6. refresh");
                Console.WriteLine("7. Exit");
                object ob1 = Console.ReadLine();
                input = Convert.ToString(ob1);

                if (input == "1")
                {
                    Console.WriteLine("Enter account Type :");
                    bn.create_account();

                }
                else if (input == "2")
                {
                    Console.Write("Enter account Number :");
                    bn.showInfo();
                }
                else if (input == "3")
                {
                    Console.WriteLine("Enter Account Id: ");
                    bn.deposit();
                }
                else if (input == "4")
                {
                    Console.WriteLine("Enter Account Id: ");
                    bn.withdraw();
                }
                else if (input == "5")
                {
                    bn.showAll();
                }
                else if (input == "6")
                {
                    Console.Clear();
                }
                else if (input == "7")
                {
                    Environment.Exit(0);
                }
                Console.ReadKey();


            }

        }

    }
}
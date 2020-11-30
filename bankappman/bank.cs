using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bankappman
{
    class Bank
    {
        string id;
        public int idnum = 0;

        public string[] myId = new string[100];
        public string[] myName = new string[100];
        public string[] myAccType = new string[100];
        public string[] myDob = new string[100];
        public string[] mynumrid = new string[100];
        public double[] myBalance = new double[100];

        IDGenerator Id = new IDGenerator();
        DOB dob = new DOB();
        Credit cr = new Credit();
        Debit db = new Debit();
        Savings sv = new Savings();

        public bool val = true;
        public bool debval = true;

        private void GetAcc(string ID)
        {
            ID = this.id;
            myId[idnum] = ID;
            idnum++;

        }
        public void showAll()
        {
            Console.WriteLine("Alle kontor:\n");
            for (int i = 0; i < idnum; i++)
            {
                Console.WriteLine(myId[i]);

            }
        }

        public void showInfo()
        {
            int indexNum;
            string inId = Convert.ToString(Console.ReadLine());
            if (myId.Contains(inId))
            {
                indexNum = Array.IndexOf(myId, inId);
                Console.WriteLine("Your details: ");
                Console.WriteLine("Navn: " + myName[indexNum]);
                Console.WriteLine("Id: " + myId[indexNum]);
                Console.WriteLine("Acc Type: " + myAccType[indexNum]);
                Console.WriteLine("DOB: " + myDob[indexNum]);
                Console.WriteLine("Nominee: " + mynumrid[indexNum]);
                Console.WriteLine("Balance: " + myBalance[indexNum]);
            }
            else
            {
                Console.WriteLine("feil id!");
            }


        }

        public void create_account()
        {

            string accType;
            string name;
            int d, m, y;
            string numrid;
            double balance;
            string input;
            Console.WriteLine("1. låne konto");
            Console.WriteLine("2. kredit konto");
            Console.WriteLine("3. spare konto");
            object ob1 = Console.ReadLine();
            input = Convert.ToString(ob1);

            if (input == "1")
            {

                accType = "lån";
                myAccType[idnum] = accType;
                Console.Write("Navn:");

                name = Convert.ToString(Console.ReadLine());
                myName[idnum] = name;

                while (val == true)
                {
                    Console.WriteLine("Enter dato: ");

                    d = Convert.ToInt32(Console.ReadLine());
                    m = Convert.ToInt32(Console.ReadLine());
                    y = Convert.ToInt32(Console.ReadLine());
                    dob.set(d, m, y);
                    if (dob.printDate() == false)
                    {
                        myDob[idnum] = Convert.ToString(d + "/" + m + "/" + y);
                        val = false;
                    }
                    else val = true;
                }
                val = true;
                Console.WriteLine("Enter numrid navn: ");
                numrid = Convert.ToString(Console.ReadLine());
                mynumrid[idnum] = numrid;
                while (debval == true)
                {
                    Console.WriteLine("Enter konto balance: ");
                    balance = Convert.ToDouble(Console.ReadLine());
                    if (balance > db.maxBalance)
                    {
                        Console.WriteLine("lånet er maks 100000!");
                        debval = true;
                    }
                    else
                    {
                        myBalance[idnum] = balance;
                        debval = false;
                    }
                }
                debval = true;
                Console.WriteLine("låne konto er godkjent! ");
                id = Id.generate();
                id = id + "lån";
                Console.WriteLine("konto Id : " + id);
                GetAcc(id);

            }
            else if (input == "2")
            {
                accType = "brukskonto";
                myAccType[idnum] = accType;
                Console.Write("Navn:");
                name = Convert.ToString(Console.ReadLine());
                myName[idnum] = name;
                while (val == true)
                {
                    Console.WriteLine("Enter dato: ");

                    d = Convert.ToInt32(Console.ReadLine());
                    m = Convert.ToInt32(Console.ReadLine());
                    y = Convert.ToInt32(Console.ReadLine());
                    dob.set(d, m, y);
                    if (dob.printDate() == false)
                    {
                        myDob[idnum] = Convert.ToString(d + "-" + m + "-" + y);
                        val = false;
                    }
                    else val = true;
                }
                val = true;
                Console.WriteLine("Enter numrid navn: ");
                numrid = Convert.ToString(Console.ReadLine());
                mynumrid[idnum] = numrid;
                while (debval == true)
                {
                    Console.WriteLine("Enter konto balance: ");
                    balance = Convert.ToDouble(Console.ReadLine());
                    if (balance < cr.minBalance)
                    {
                        Console.WriteLine("bruks konto er -100000!");
                        debval = true;
                    }
                    else
                    {
                        myBalance[idnum] = balance;
                        debval = false;
                    }
                }
                debval = true;
                Console.WriteLine("ny brukskonto! ");
                id = Id.generate();
                id = id + "brukskonto";
                Console.WriteLine("kontoid : " + id);
                GetAcc(id);

            }
            else if (input == "3")
            {
                accType = "spare";
                myAccType[idnum] = accType;
                Console.Write("Navn:");

                name = Convert.ToString(Console.ReadLine());
                myName[idnum] = name;
                while (val == true)
                {
                    Console.WriteLine("Enter dato: ");

                    d = Convert.ToInt32(Console.ReadLine());
                    m = Convert.ToInt32(Console.ReadLine());
                    y = Convert.ToInt32(Console.ReadLine());
                    dob.set(d, m, y);
                    if (dob.printDate() == false)
                    {
                        myDob[idnum] = Convert.ToString(d + "-" + m + "-" + y);
                        val = false;
                    }
                    else val = true;
                }
                val = true;
                Console.WriteLine("Enter numrid navn: ");
                numrid = Convert.ToString(Console.ReadLine());
                mynumrid[idnum] = numrid;
                Console.WriteLine("Enter konto balance: ");
                balance = Convert.ToDouble(Console.ReadLine());
                myBalance[idnum] = balance;
                Console.WriteLine("sparekonto opprettet! ");
                id = Id.generate();
                id = id + "spare";
                Console.WriteLine("sparekonto id : " + id);
                GetAcc(id);

            }

        }

        public void deposit()
        {
            int indexNum;
            string inId = Convert.ToString(Console.ReadLine());
            if (myId.Contains(inId))
            {
                indexNum = Array.IndexOf(myId, inId);
                Console.WriteLine("Your Balance is: " + myBalance[indexNum]);
                Console.WriteLine("How much you want to deposit: ");
                double depval = Convert.ToDouble(Console.ReadLine());
                if (myAccType[indexNum] == "Debit")
                {
                    db.balance = myBalance[indexNum];
                    db.deposit(depval);
                    myBalance[indexNum] = db.balance;
                }
                else if (myAccType[indexNum] == "Credit")
                {
                    cr.balance = myBalance[indexNum];
                    cr.deposit(depval);
                    myBalance[indexNum] = db.balance;
                }
                else if (myAccType[indexNum] == "Savings")
                {
                    sv.balance = myBalance[indexNum];
                    sv.deposit(depval);
                    myBalance[indexNum] = sv.balance;
                }

            }

            else
            {
                Console.WriteLine("Your id is wrong!");
            }

        }
        public void withdraw()
        {
            int indexNum;
            string inId = Convert.ToString(Console.ReadLine());
            if (myId.Contains(inId))
            {
                indexNum = Array.IndexOf(myId, inId);
                Console.WriteLine("Your Balance is: " + myBalance[indexNum]);
                Console.WriteLine("How much you want to withdraw: ");
                double depval = Convert.ToDouble(Console.ReadLine());
                if (myAccType[indexNum] == "Debit")
                {
                    db.balance = myBalance[indexNum];
                    db.withdraw(depval);
                    myBalance[indexNum] = db.balance;
                }
                else if (myAccType[indexNum] == "Credit")
                {
                    cr.balance = myBalance[indexNum];
                    cr.withdraw(depval);
                    myBalance[indexNum] = cr.balance;
                }
                else if (myAccType[indexNum] == "Savings")
                {
                    sv.balance = myBalance[indexNum];
                    sv.withdraw(depval);
                    myBalance[indexNum] = sv.balance;
                }

            }
            else
            {
                Console.WriteLine("Your id is wrong!");
            }

        }
    }
}
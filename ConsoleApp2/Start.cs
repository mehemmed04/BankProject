using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public partial class Controller
    {
        public Client client1, client2,client3;
        public Bank BANK;
        public void Init()
        {
            Random random = new Random();
            client1 = new Client()
            {
                Name = "Mehemmed",
                Age = 18,
                Salary = 2200,
                Surname = "Bayramov",
                Bank_card = new BankCard()
                {
                    Username = "Mehemmed Bayramov",
                    PAN = "1234567890123456",
                    PIN = 1234,
                    Balance = random.Next(0, 20000),
                    CVC = random.Next(100, 999)
                }
            };

            client2 = new Client()
            {
                Name = "Resul",
                Age = 18,
                Salary = 200,
                Surname = "Resulzade",

                Bank_card = new BankCard()
                {
                    Username = "Resul Resulzade",
                    PAN = "1234432190172346",
                    PIN = 0000,
                    Balance = random.Next(0, 20000),
                    CVC = random.Next(100, 999)
                }
            };
            client3 = new Client()
            {
                Name = "Tunay",
                Age = 18,
                Salary = 200,
                Surname = "Huseynov",

                Bank_card = new BankCard()
                {
                    Username = "Tunay Huseynov",
                    PAN = "8754432194682343",
                    PIN = 5555,
                    Balance = random.Next(0, 20000),
                    CVC = random.Next(100, 999)
                }
            };

            BANK = new Bank()
            {
                Clients = new Client[3] { client1, client2,client3 }
            };
        }
        public void Start()
        {
            while (true)
            {
                Console.WriteLine("Enter PIN : ");
                bool IsInt = int.TryParse(Console.ReadLine(), out int PIN);
                BankCard CurrentBankCard = null;
                Client CurrentClient = null;
                foreach (var client in BANK.Clients)
                {
                    if (PIN == client.Bank_card.PIN)
                    {
                        CurrentClient = client;
                        CurrentBankCard = client.Bank_card;
                        break;
                    }
                }
                if (CurrentBankCard != null)
                {
                    Console.WriteLine($"Welcome {CurrentClient.Name} {CurrentClient.Surname}, Please choose operation :");
                    Console.WriteLine("BALANCE        [1] : ");
                    Console.WriteLine("Cash           [2] : ");
                    Console.WriteLine("Operations     [3] : ");
                    Console.WriteLine("Card to Card   [4] : ");
                    IsInt = int.TryParse(Console.ReadLine(), out int select);
                    if (IsInt)
                    {
                        if (select == 1)
                        {
                           Console.WriteLine($"BALANCE : {CurrentBankCard?.Balance} AZN");
                        }
                        else if (select == 2)
                        {
                            Console.WriteLine("10  AZN [1]");
                            Console.WriteLine("20  AZN [2]");
                            Console.WriteLine("50  AZN [3]");
                            Console.WriteLine("100 AZN [4]");
                            Console.WriteLine("Other   [5]");
                            IsInt = int.TryParse(Console.ReadLine(), out select);
                            if (select == 1) CurrentBankCard.Balance -= 10;
                            else if (select == 2) CurrentBankCard.Balance -= 20;
                            else if (select == 3) CurrentBankCard.Balance -= 50;
                            else if (select == 4) CurrentBankCard.Balance -= 100;
                            else if (select == 5)
                            {

                            }
                        }
                        else if (select == 3)
                        {

                        }
                        else if(select == 4)
                        {
                            Console.WriteLine("Enter card PAN :");
                            string new_PAN =Console.ReadLine();
                            BankCard bank_card2 = BANK.GetBankCardWithPAN(new_PAN);
                            if(bank_card2 != null)
                            {
                                Console.WriteLine("Enter Price : ");
                                bool isDecimal = decimal.TryParse(Console.ReadLine(), out decimal price);
                                if (isDecimal)
                                {
                                    CurrentBankCard.Balance -= price;
                                    bank_card2.Balance+=price;
                                }
                            }

                        }
                        else
                        {

                        }
                    }
                }

            }
        }
    }
}

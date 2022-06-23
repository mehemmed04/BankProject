using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public partial class Controller
    {
        public Client client1, client2, client3;
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
                Clients = new Client[3] { client1, client2, client3 }
            };
        }
        public void Start()
        {
            while (true)
            {
                BankCard CurrentBankCard = null;
                Client CurrentClient = null;
                string operation = null;
                try
                {
                    Console.WriteLine("Enter PIN : ");
                    bool IsInt = int.TryParse(Console.ReadLine(), out int PIN);
                    if (IsInt)
                    {
                        CurrentBankCard = BANK.GetBankCardWithPIN(PIN);
                        CurrentClient = BANK.GetClientWithBankCard(CurrentBankCard);

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
                                    operation = "Balance was shown at " + DateTime.Now.ToString();
                                }
                                else if (select == 2)
                                {
                                    Console.WriteLine("10  AZN [1]");
                                    Console.WriteLine("20  AZN [2]");
                                    Console.WriteLine("50  AZN [3]");
                                    Console.WriteLine("100 AZN [4]");
                                    Console.WriteLine("Other   [5]");
                                    IsInt = int.TryParse(Console.ReadLine(), out select);
                                    if (select == 1) { if (CurrentBankCard.Balance >= 10) { CurrentBankCard.Balance -= 10; operation = "10 AZN WITHDRAW at " + DateTime.Now.ToString(); } else { throw new Exception("There is not enought money in your Bank Card"); operation = " 10 AZN INVALID WITHDRAW OPERATION at " + DateTime.Now.ToString(); } }
                                    else if (select == 2) { if (CurrentBankCard.Balance >= 20) { CurrentBankCard.Balance -= 20; operation = "20 AZN WITHDRAW at " + DateTime.Now.ToString(); } else { throw new Exception("There is not enought money in your Bank Card"); operation = " 20 AZN INVALID WITHDRAW OPERATION at " + DateTime.Now.ToString(); } }
                                    else if (select == 3) { if (CurrentBankCard.Balance >= 50) { CurrentBankCard.Balance -= 50; operation = "50 AZN WITHDRAW at " + DateTime.Now.ToString(); } else { throw new Exception("There is not enought money in your Bank Card"); operation = " 50 AZN INVALID WITHDRAW OPERATION at " + DateTime.Now.ToString(); } }
                                    else if (select == 4) { if (CurrentBankCard.Balance >= 100) { CurrentBankCard.Balance -= 100; operation = "100 AZN WITHDRAW at " + DateTime.Now.ToString(); } else { throw new Exception("There is not enought money in your Bank Card"); operation = " 100 AZN INVALID WITHDRAW OPERATION at " + DateTime.Now.ToString(); } }
                                    else if (select == 5)
                                    {
                                        IsInt = int.TryParse(Console.ReadLine(), out int cash);
                                        if (IsInt)
                                        {
                                            if (CurrentBankCard.Balance >= cash) { CurrentBankCard.Balance -= cash; operation = cash.ToString() + " AZN WITHDRAW at " + DateTime.Now.ToString(); }
                                            else { operation = cash.ToString() + " AZN INVALID WITHDRAW at " + DateTime.Now.ToString(); throw new Exception("There is not enought money in your Bank Card"); }
                                        }
                                        else throw new FormatException("INPUT TYPE ERROR. MUST BE INTEGER");
                                    }

                                    else Console.WriteLine("You can select only in 1-5");
                                    Console.WriteLine($"Current Balance : {CurrentBankCard.Balance}");
                                }
                                else if (select == 3)
                                {
                                    CurrentClient.ShowAllOperations();
                                }
                                else if (select == 4)
                                {
                                    Console.WriteLine("Enter card PAN :");
                                    string new_PAN = Console.ReadLine();
                                    BankCard bank_card2 = BANK.GetBankCardWithPAN(new_PAN);
                                    decimal price = 0 ;
                                    if (bank_card2 != null)
                                    {
                                        Console.WriteLine("Enter Price : ");
                                        bool isDecimal = decimal.TryParse(Console.ReadLine(), out price);
                                        if (isDecimal)
                                        {
                                            if (CurrentBankCard.Balance >= price)
                                            {
                                                CurrentBankCard.Balance -= price;
                                                bank_card2.Balance += price;
                                                operation = price.ToString() + " AZN SUCCESSFULL MONEY TRANSFER TO "+bank_card2.Username + " at " + DateTime.Now.ToString();
                                            }
                                            else {
                                                operation = price.ToString() + " AZN UNSUCCESSFULL CARD-TO-CARD OPERATION at " + DateTime.Now.ToString();
                                                throw new Exception("There is not enought money in your Bank Card");
                                            }
                                        }
                                        else throw new FormatException("INPUT TYPE ERROR. MUST BE DECIMAL");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Wrong PAN. Try again");
                                    }
                                }
                                else Console.WriteLine("You can select only in 1-4");
                            }
                            else throw new Exception("INPUT TYPE ERROR. MUST BE INTEGER");
                        }
                        else Console.WriteLine("PIN code is wrong");
                    }
                    else throw new Exception("INPUT TYPE ERROR. MUST BE INTEGER");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR : {ex.Message}");
                }
                finally
                {
                    if (operation != null) CurrentClient.AddOperation(ref operation);
                }
            }
        }
    }
}

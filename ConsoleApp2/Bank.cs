using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Bank
    {
        public Client[] Clients { get; set; }
        public BankCard GetBankCardWithPAN(string PAN)
        {
            foreach(var client in Clients)
            {
                if (PAN == client.Bank_card.PAN) return client.Bank_card;
            }
            return null;
        }
    }
}

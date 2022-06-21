using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class BankCard
    {
        public string Username { get; set; }
        public string PAN { get; set; }
        public int PIN { get; set; }
        public int CVC { get; set; }
        public DateTime ExpireDate { get; set; } = DateTime.Now.AddYears(4);
        public decimal Balance { get; set; }

    }
}

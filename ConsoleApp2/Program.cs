using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {

        static void Main(string[] args)
        {
            Controller c = new Controller();
            c.Init();
            c.Start();
        }

    }
}

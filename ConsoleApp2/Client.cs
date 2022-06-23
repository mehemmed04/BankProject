using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Client
    {
        public static int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public BankCard Bank_card { get; set; }
        public string[] operations { get; set; } 
        public int operations_count { get; set; } = 0;
        public void AddOperation(ref string operation)
        {
            string[] new_operations = new string[operations_count+1];
            if(operations_count>0) Array.Copy(operations, new_operations, operations_count);
            new_operations[operations_count] = operation;
            operations_count++;
            operations = new_operations;
        }
        public void ShowAllOperations()
        {
            Console.WriteLine("OPERATIONS : ");
            for (int i = 0; i < operations.Length; i++)
            {
                Console.WriteLine($"{i+1}. {operations[i]}");
            }
        }

    }
}

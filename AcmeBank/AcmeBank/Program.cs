using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeBank
{
    class Program
    {
        static void Main(string[] args)
        {
            SystemDB systemDB = SystemDB.Instance;

           systemDB.DisplayMessage();
            //systemDB.GetAccount(5);
            Console.ReadLine();

            AccountService save = new SavingsAccount(1, "2", 1500);
            save.withdraw(1, 1500); //test 1 withdraw from valid savings account, outcome should be not enough funds. A savings account should have min of 1000 in it
            Console.WriteLine("Test 1 results");
            systemDB.DisplayMessage();
            Console.ReadLine();

            AccountService save1 = new SavingsAccount(1, "2", 300);
            save.withdraw(1, 300); //test 2 withdraw from valid savings account, should decrease the amount

            Console.WriteLine("Test 2 results");
            systemDB.DisplayMessage();
            Console.ReadLine();


            AccountService save2 = new SavingsAccount(9, "2", 300);
            save.withdraw(9, 300); //test 3 withdraw from invalid savings account

            Console.WriteLine("Test 3 results");
            systemDB.DisplayMessage();
            Console.ReadLine();

            AccountService current = new CurrentAccount(1, "2", 500, 1000);
            current.withdraw(3, 4000); //test 4 withdraw from more than avail for current account amount. should fail

            Console.WriteLine("Test 4 results");
            systemDB.DisplayMessage();
            Console.ReadLine();

            AccountService current1 = new CurrentAccount(1, "2", 500, 500);
            current.withdraw(3, 500); //test 5 withdraw from to make the value in account negative

            Console.WriteLine("Test 5 results");
            systemDB.DisplayMessage();
            Console.ReadLine();

            AccountService current2 = new CurrentAccount(1, "2", 500, 1000);
            current.withdraw(4, 2000); //test 6 withdraw from valid current account

            Console.WriteLine("Test 6 results");
            systemDB.DisplayMessage();
            Console.ReadLine();
             

        }
    }
}

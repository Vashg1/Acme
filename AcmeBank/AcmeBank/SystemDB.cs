using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace AcmeBank
{

    public class SystemDB
    {
        private static SystemDB instance;
        static int accountId = 1;
        static List<AccountService> accList = new List<AccountService>();

        private SystemDB()
        {
            setupData();
        }

        private void setupData()
        {
            //set up the data and add it to a list.
            accList.Add(new SavingsAccount(accountId++, "1", 2000));
            accList.Add(new SavingsAccount(accountId++, "2", 5000));
            accList.Add(new CurrentAccount(accountId++, "3", 2000, 1000));
             accList.Add(new CurrentAccount(accountId++, "4", -5000, 20000));
        }

        public static SystemDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SystemDB();
                }
                return instance;
            }
        }

        public void DisplayMessage() // To be removed when going to live, been added in for testing purposes
        {
            foreach (var accountinformation in accList)
            {
                Console.WriteLine("Account is {0} and Balance is {1}, and  overdraft is {2}", accountinformation.AccountId, accountinformation.Balance,accountinformation.Overdraft);
            }
        }

        public bool GetAccount(int accountid)
        {
           return accList.Exists(x => x.AccountId == accountid);
        }

        public int GetBalance(int accountid)
        {
            AccountService result =  accList.Find(x => x.AccountId == accountid); // give me the current balance of the account using account id
            return result.Balance + result.Overdraft; // In the savings the overdraft will always be zero. To make this as generic as possible I kept overdraft here to be used by savings as well

        }

        public void SetBalance(int accountid, int amt)
        {
            accList.Where(x => x.AccountId == accountid).ToList().ForEach(i => i.Balance = amt);
        }

    }
}






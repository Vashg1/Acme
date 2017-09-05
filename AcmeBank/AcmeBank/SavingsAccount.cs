using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AcmeBank
{
    class SavingsAccount : AccountService  
    {
        int balance = 0;
        int accountId = 0;
        string customerNum;
        int overdraft = 0; 

        public SavingsAccount(int accountId, string customerNum, int balance)
        {
            this.accountId = accountId;
            this.balance = balance;
            this.customerNum = customerNum;
        }


        public int Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public int AccountId
        {
            get { return accountId; }
            set { accountId = value; }
        }

        public string CustomerNum
        {
            get { return customerNum; }
            set { customerNum = value; }
        }

        public int Overdraft
        {
            get { return overdraft; }
            set { overdraft = value; }
        }



        public void withdraw(int accountId, int amountToWithdraw)
        {
            try
            {
                if (!(SystemDB.Instance.GetAccount(accountId)))
                {
                     throw new ArgumentNullException();
                }

                else
                {
                    int balanceOfthisAccount = SystemDB.Instance.GetBalance(accountId);
                    if ((balanceOfthisAccount - amountToWithdraw) < 1000)
                        throw new Exception();
                    else
                    {
                        SystemDB.Instance.SetBalance(accountId, balanceOfthisAccount - amountToWithdraw);
                    }
                }

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("This account does not exist");
                Console.ReadLine(); //can choose to exist here
            }
            catch (Exception e)
            {
                Console.WriteLine("Not enough funds in the account");
                Console.ReadLine(); //can choose to exist here
            }



               
        }

    }
}

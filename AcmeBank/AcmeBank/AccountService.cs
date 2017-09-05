using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeBank
{
    interface AccountService
    {
        int AccountId { get; set; }
        string CustomerNum { get; set; }
        int Balance { get; set; }
        int Overdraft { get; set; }

         void withdraw(int accountId, int amountToWithdraw);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountClassLibrary
{
    
    public class SavingsAccount: Account
    {
        private decimal _interestRate;

        public SavingsAccount(string name = "Anon", decimal balance = 0.0M, string accountNo = "000000000000", decimal interestRate = 0.0M) : base(name, balance, accountNo)
        {
            _interestRate = interestRate;
        }
    }
}

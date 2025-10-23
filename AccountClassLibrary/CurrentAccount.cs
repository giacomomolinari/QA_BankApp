using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountClassLibrary
{
    public class CurrentAccount: Account
    {
        private decimal _maxOverdraft = 1000M;


        public override decimal Balance
        {
            get { return _balance; }
            // can create negative amount up to -_maxOverdraft
            protected set { _balance = (value > -_maxOverdraft) ? value : 0.0M; }
        }


        public CurrentAccount(string name = "Anon", decimal balance = 0.0M, string accountNo = "000000000000") : base(name, balance, accountNo)
        {

        }


        // allow account to dip into negative 
        public override bool Debit(decimal amount)
        {
            if (this.Balance - amount < - _maxOverdraft || amount < 0)
            {
                return false;
            }
            else
            {
                this.Balance = this.Balance - amount;
                return true;
            }
        }

    }
}

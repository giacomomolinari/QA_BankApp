using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountClassLibrary
{
    public class Account
    {
        private char[] _allowedDigits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        private string _accountNo;

        protected decimal _balance;

        public string Name { get; private init; }

        // 12-character string of digits
        public string AccountNo
        {
            get { return _accountNo; }
            private init { _accountNo = (IsValidAccoutNo(value)) ? value : "000000000000"; }
        }

        public virtual decimal Balance
        {
            get { return _balance; }
            protected set { _balance = (value > 0) ? value : 0.0M; }
        }


        public Account(string name = "Anon", decimal balance = 0.0M, string accountNo = "000000000000")
        {
            Name = name;
            AccountNo = accountNo;
            Balance = balance;

        }

        // can only be used to credit POSITIVE amount.
        // Return true if successful, false if unsuccessful
        public bool Credit(decimal amount)
        {
            if (amount >= 0)
            {
                Balance = Balance + amount;
                return true;
            }
            else
            {
                return false;
            }         
        }

        // return false if failed (overdraft or negative debt) true if succeeded
        public virtual bool Debit(decimal amount)
        {
            if (Balance - amount < 0 || amount < 0)
            {
                return false;
            }
            else
            {
                Balance = Balance - amount;
                return true;
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}; AccountNo: {AccountNo}; Balance: {Balance}";
        }

        private bool IsValidAccoutNo(string accountNo)
        {
            if (accountNo.Length != 12)
            {
                return false;
            }

            char[] accountNoChars = accountNo.ToCharArray();
            foreach (char c in accountNoChars)
            {
                if (!_allowedDigits.Contains(c))
                {
                    return false;
                }
            }

            return true;
        }

    }
}

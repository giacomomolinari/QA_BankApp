using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountClassLibrary;

namespace BankAccountTest
{
    public class CurrentAccountTest
    {
        [Theory]
        [InlineData(-100)]
        public void testConstructorNegBalanceValid(decimal balance)
        {
            CurrentAccount currentAccount = new CurrentAccount(balance: balance);
            Assert.Equal(currentAccount.Balance, balance);
        }

        [Theory]
        [InlineData(100, 1000)]
        [InlineData(-100, 100)]
        public void testDebitToNegValid(decimal balance, decimal amount)
        {
            CurrentAccount crtAcc = new CurrentAccount(balance: balance);
            crtAcc.Debit(amount);

            Assert.Equal(balance - amount, crtAcc.Balance);
        }

    }
}

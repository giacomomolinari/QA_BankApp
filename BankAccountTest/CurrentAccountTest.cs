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

    }
}

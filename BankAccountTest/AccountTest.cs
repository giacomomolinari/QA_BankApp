using AccountClassLibrary;
using System.Xml.Linq;

namespace BankAccountTest
{
    public class AccountTest
    {
        [Theory]
        [InlineData("Anon", "000000000000", 0)]
        public void TestAccountConstructorNoArgs(string expName, string expAccountNo, decimal expBalance)
        {
            Account account = new Account();
            Assert.Equal(account.Name, expName);
            Assert.Equal(account.AccountNo, expAccountNo);
            Assert.Equal(account.Balance, expBalance);
        }

        [Theory]
        [InlineData("TestName", "012345678912", 100)]
        [InlineData("Carl", "123037389012", 0)]
        public void TestAccountConstructorAllArgsValid(string name, string accountNo, decimal balance)
        {
            Account account = new Account(name:name, accountNo: accountNo, balance: balance );
            Assert.Equal(account.Name, name);
            Assert.Equal(account.AccountNo, accountNo);
            Assert.Equal(account.Balance, balance);
        }

        [Theory]
        [InlineData("12923837418730283740174", "000000000000")] // too long
        [InlineData("12", "000000000000")] // too short
        [InlineData("12A000000000", "000000000000")] // non-numeric
        public void TestAccountConstructorInvalidAccountNo(string accountNo, string expAccountNo)
        {
            Account account = new Account(accountNo: accountNo);
            Assert.Equal(account.AccountNo, expAccountNo);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 0)]
        [InlineData(100, 100)]
        [InlineData(0, 100)]
        public void TestCreditMethodPositiveAmount(decimal startingBalance, decimal amount)
        {
            Account account = new Account(balance: startingBalance);
            account.Credit(amount);

            // when positive amount, should add
            Assert.Equal(account.Balance, startingBalance + amount);

        }

        [Theory]
        [InlineData(0, -1)]
        [InlineData(10, -100)]
        public void TestCreditMethodNegativeAmount(decimal startingBalance, decimal amount)
        {
            Account account = new Account(balance: startingBalance);
            account.Credit(amount);

            // when negative amount, should do nothing
            Assert.Equal(account.Balance, startingBalance);

        }


        [Theory]
        [InlineData(100, 10)]
        [InlineData(0, 0)]
        [InlineData(20, 10)]
        public void TestDebitMethodAmountLEQBalance(decimal startingBalance, decimal amount)
        {
            Account account = new Account(balance: startingBalance);
            account.Debit(amount);

            // when amount <= balance, subtract from balance
            Assert.Equal(account.Balance, startingBalance - amount);

        }

        [Theory]
        [InlineData(0, 10)]
        [InlineData(100, 110)]
        [InlineData(11.01, 11.02)]
        [InlineData(20, 20.01)]
        public void TestDebitMethodAmountGBalance(decimal startingBalance, decimal amount)
        {
            Account account = new Account(balance: startingBalance);
            account.Debit(amount);

            // when amount > balance, do nothing
            Assert.Equal(account.Balance, startingBalance);

        }


        [Theory]
        [InlineData(0, -10)]
        [InlineData(100, -10)]
        public void TestDebitMethodAmountNeg(decimal startingBalance, decimal amount)
        {
            Account account = new Account(balance: startingBalance);
            account.Debit(amount);

            // when amount < 0, do nothing
            Assert.Equal(account.Balance, startingBalance);

        }
    }
}
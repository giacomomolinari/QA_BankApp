using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionsDB;
using TransactionsDBLibrary;
using AccountClassLibrary;

namespace BankAccountTest
{
    public class TransactionDBTest
    {
        public void testDBAddGetAll()
        {
            ITransactionDB db = new TransactionDB();
            TransactionRecord testRecord = new TransactionRecord(amount: 10.0M, accountNo: "000000000000");
            List<TransactionRecord> recordList = db.GetAllRecords();

            Assert.Equal(testRecord, recordList[0]);
        }

       
    }
}

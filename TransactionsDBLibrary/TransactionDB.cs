using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionsDBLibrary;

namespace TransactionsDB
{
    public class TransactionDB : ITransactionDB
    {

        private List<TransactionRecord> transactionList;

        public TransactionDB()
        {
            transactionList = new List<TransactionRecord>();
        }

        public List<TransactionRecord> GetAllRecords()
        {
            return transactionList;
        }

        public TransactionRecord? GetRecord(Guid id)
        {
            return (transactionList.Find(x => x.Id == id));
        }

        public bool PostRecord(TransactionRecord record)
        {
            transactionList.Add(record);
            return true;
        }

        public TransactionRecord? Update(Guid id, TransactionRecord record)
        {
            TransactionRecord? targetRecord = transactionList.Find(x => x.Id == id);
            if (targetRecord != null)
            {
                targetRecord.AccountNumber = record.AccountNumber;
                targetRecord.TransactionAmount = record.TransactionAmount;
            }
            return targetRecord;
        }

        public bool DeleteRecord(Guid id)
        {
            TransactionRecord? targetRecord = transactionList.Find(x => x.Id == id);
            if (targetRecord == null)
            {
                return false;
            }
            else {
                transactionList.Remove(targetRecord);
                return true;
            }       
        }
    }
}

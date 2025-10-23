using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionsDBLibrary
{
    public record TransactionRecord
    {
        public Guid Id { get; init; }

        public DateTime CreationDate {get; init;}

        public decimal TransactionAmount {get; set;}

        public string? AccountNumber { get; set; }

        public TransactionRecord(decimal amount, string accountNo)
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
            TransactionAmount = amount; 
            AccountNumber = accountNo;
        }
    }
}

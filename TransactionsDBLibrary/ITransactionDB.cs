namespace TransactionsDBLibrary
{
    public interface ITransactionDB
    {
        List<TransactionRecord> GetAllRecords();

        TransactionRecord? GetRecord(Guid id);

        TransactionRecord? Update(Guid id, TransactionRecord record);

        bool PostRecord(TransactionRecord record);

        bool DeleteRecord(Guid id);
    }
}

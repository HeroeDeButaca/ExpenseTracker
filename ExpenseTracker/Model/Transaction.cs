namespace ExpenseTracker.Model
{
    public enum TransactionCategories
    {
        Food, Debt, Reparation, Entertainment, Other
    }

    public enum TransactionType { Expense, Income }

    public class Transaction
    {
        public string Description { get; set; }
        public TransactionCategories Category { get; set; }
        public TransactionType Type { get; set; }
        public decimal Money {  get; set; }
        public DateTime TransactionDate { get; set; }

        public Transaction() { }

        public Transaction(string description, TransactionCategories category, TransactionType type,
                           decimal money)
        {
            Description = description;
            Category = category;
            Type = type;
            Money = money;
            TransactionDate = DateTime.Now;
        }
    }
}

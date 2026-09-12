namespace ExpenseTracker.Model
{
    public enum TransactionType
    {
        Expense,
        Income
    }

    public enum ExpenseCategory
    {
        Food, Transport, Housing,
        Utilities, Shopping, Health,
        Education, Entertainment, Subscriptions,
        Travel, PersonalCare, Insurance,
        Taxes, Debt, Gifts, Other
    }

    public enum IncomeCategory
    {
        Salary, Freelance, Investment,
        Gift, Refund, Other
    }

    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public TransactionType Type { get; set; }

        public string Category { get; set; }
        public ExpenseCategory? ExpenseCategory { get; set; }
        public IncomeCategory? IncomeCategory { get; set; }

        public decimal Money {  get; set; }
        public DateTime TransactionDate { get; set; }

        public Transaction() { }

        public Transaction(string description, TransactionType type, ExpenseCategory? expenseCategory, IncomeCategory? incomeCategory, decimal money)
        {
            Description = description;
            Type = type;
            ExpenseCategory = expenseCategory;
            IncomeCategory = incomeCategory;
            Money = money;
            TransactionDate = DateTime.Now;
            Category = ExpenseCategory != null ? ExpenseCategory.Value.ToString() : IncomeCategory.Value.ToString();
        }
    }
}

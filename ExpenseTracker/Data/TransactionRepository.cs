using ExpenseTracker.Model;

namespace ExpenseTracker.Data
{
    public class TransactionRepository
    {
        private readonly Database _database;

        public TransactionRepository(Database database)
        {
            _database = database;
        }

        public void Add(Transaction transaction)
        {
            using var connection = _database.GetConnection();
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText =
                """
                INSERT INTO Transactions(
                    Description, Type, Category, ExpenseCategory, IncomeCategory, Money, TransactionDate)
                VALUES(
                    $description, $type, $category, $expenseCategory, $incomeCategory, $money, $transactionDate);
                """;

            command.Parameters.AddWithValue("$description", transaction.Description);
            command.Parameters.AddWithValue("$type", (int)transaction.Type);
            command.Parameters.AddWithValue("$category", transaction.Category);

            command.Parameters.AddWithValue("$expenseCategory",
                transaction.ExpenseCategory.HasValue ? (int)transaction.ExpenseCategory.Value : DBNull.Value);

            command.Parameters.AddWithValue("$incomeCategory",
                transaction.IncomeCategory.HasValue ? (int)transaction.IncomeCategory.Value : DBNull.Value);

            command.Parameters.AddWithValue("$money", transaction.Money);
            command.Parameters.AddWithValue("$transactionDate", transaction.TransactionDate.ToString("O"));

            command.ExecuteNonQuery();
        }

        public List<Transaction> GetAll(bool recentFirst)
        {
            List<Transaction> transactions = new List<Transaction>();

            using var connection = _database.GetConnection();
            connection.Open();

            using var command = connection.CreateCommand();

            if (recentFirst)
                command.CommandText =
                    """
                    SELECT Id, Description, Type, Category, 
                    ExpenseCategory, IncomeCategory, Money, 
                    TransactionDate FROM Transactions ORDER BY Id DESC;
                    """;
            else
                command.CommandText =
                    """
                    SELECT Id, Description, Type, Category, 
                    ExpenseCategory, IncomeCategory, Money, 
                    TransactionDate FROM Transactions ORDER BY Id ASC;
                    """;

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var transaction = new Transaction()
                {
                    Id = reader.GetInt32(0),
                    Description = reader.GetString(1),
                    Type = (TransactionType)reader.GetInt32(2),
                    Category = reader.GetString(3),
                    ExpenseCategory = reader.IsDBNull(4) ? null : (ExpenseCategory)reader.GetInt32(4),
                    IncomeCategory = reader.IsDBNull(5) ? null : (IncomeCategory)reader.GetInt32(5),
                    Money = reader.GetDecimal(6),
                    TransactionDate = DateTime.Parse(reader.GetString(7))
                };

                transactions.Add(transaction);
            }

            return transactions;
        }

        public void Delete(int id)
        {
            using var connection = _database.GetConnection();
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText =
                """
                DELETE FROM Transactions
                WHERE Id = $id;
                """;

            command.Parameters.AddWithValue("$id", id);

            command.ExecuteNonQuery();
        }
    }
}

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
                    Description, Category, Type, Money, TransactionDate)
                VALUES(
                    $description, $category, $type, $money, $transactionDate);
                """;

            command.Parameters.AddWithValue("$description", transaction.Description);
            command.Parameters.AddWithValue("$category", (int)transaction.Category);
            command.Parameters.AddWithValue("$type", (int)transaction.Type);
            command.Parameters.AddWithValue("$money", transaction.Money);
            command.Parameters.AddWithValue("$transactionDate", transaction.TransactionDate.ToString("O"));

            command.ExecuteNonQuery();
        }

        public List<Transaction> GetAll()
        {
            List<Transaction> transactions = new List<Transaction>();

            using var connection = _database.GetConnection();
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText =
                """
                SELECT Id, Description, Category, Type,
                Money, TransactionDate FROM Transactions;
                """;

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var transaction = new Transaction()
                {
                    Id = reader.GetInt32(0),
                    Description = reader.GetString(1),
                    Category = (TransactionCategories)reader.GetInt32(2),
                    Type = (TransactionType)reader.GetInt32(3),
                    Money = reader.GetDecimal(4),
                    TransactionDate = DateTime.Parse(reader.GetString(5))
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

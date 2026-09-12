using System.IO;
using Microsoft.Data.Sqlite;

namespace ExpenseTracker.Data
{
    public class Database
    {
        private readonly string _connectionString;
        private const string DATABASE_FILENAME = "expense_tracker_database.db";

        public Database()
        {
            string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DATABASE_FILENAME);
            _connectionString = $"Data Source={databasePath}";
        }

        public SqliteConnection GetConnection()
        {
            return new SqliteConnection(_connectionString);
        }

        public void Initialize()
        {
            using var connection = GetConnection();
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText =
                """
                CREATE TABLE IF NOT EXISTS Transactions(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Description TEXT NOT NULL,
                    Type INTEGER NOT NULL,
                    Category TEXT NOT NULL,
                    ExpenseCategory INTEGER,
                    IncomeCategory INTEGER,
                    Money REAL NOT NULL,
                    TransactionDate TEXT NOT NULL
                );
                """;

            command.ExecuteNonQuery();
        }
    }
}

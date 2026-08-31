using ExpenseTracker.Data;
using ExpenseTracker.Model;
using System.Windows;

namespace ExpenseTracker
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Database database = new Database();
            database.Initialize();
        }
    }

}

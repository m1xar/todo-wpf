using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;

namespace todo
{
    internal class TodoTask_Repository : ITaskRepository
    {
        public static void Delete(string name, string connectionString = "Data Source=MSI;Initial Catalog=todo;Integrated Security=True;Encrypt=False")
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute("Delete from task where name = @name", new { name });
            }
        }

        public static Todo_Task Get(string name, string connectionString = "Data Source=MSI;Initial Catalog=todo;Integrated Security=True;Encrypt=False")
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Todo_Task>("Select from task where name = @name", new { name }).FirstOrDefault();
            }
        }

        public static void Insert(Todo_Task task, string connectionString = "Data Source=MSI;Initial Catalog=todo;Integrated Security=True;Encrypt=False")
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute("Insert into task (Name, Description, Priority, Time) Values (@Name, @Description, @Priority, @Time)", task);
            }
        }

        public static List<Todo_Task> Select(string connectionString = "Data Source=MSI;Initial Catalog=todo;Integrated Security=True;Encrypt=False")
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Todo_Task>("Select * from task Order by Time, Priority").ToList();
            }
        }

        public static void Update(Todo_Task task, string previousName, string connectionString = "Data Source=MSI;Initial Catalog=todo;Integrated Security=True;Encrypt=False")
        {
            object[] parameters = { new { Name = task.Name, Description = task.Description, Time = task.Time, Priority = task.Priority, previousName = previousName } };
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute("Update task set Name = @Name, Description = @Description, Priority = @Priority, Time = @Time Where Name = @previousName", parameters);
            }
        }
    }
}

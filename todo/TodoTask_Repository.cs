using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace todo
{
    internal class TodoTask_Repository : ITaskRepository
    {
        string connectionString;
        public TodoTask_Repository(string connectionString) => this.connectionString = connectionString;

        public void Delete(string name)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute("Delete from task where name = @name", new { name });
            }
        }

        public Todo_Task Get(string name)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Todo_Task>("Select from task where name = @name", new { name }).FirstOrDefault();

            }
        }

        public void Insert(Todo_Task task)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute("Insert into task (Name, Description, Priority, Time) Values (@Name, @Description, @Priority, @Time)", task);
            }
        }

        public List<Todo_Task> Select()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Todo_Task>("Select * from task").ToList();
            }
        }

        public void Update(Todo_Task task)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute("Update task set Name = @Name, Description = @Description, Priority = @Priority, Time = @Time Where Name = @Name", task);
            }
        }
    }
}

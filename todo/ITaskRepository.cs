namespace todo
{
    internal interface ITaskRepository
    {
        static abstract void Insert(Todo_Task task, string connectionString = "Data Source=MSI;Initial Catalog=todo;Integrated Security=True;Encrypt=False");
        static abstract Todo_Task Get(string name, string connectionString = "Data Source=MSI;Initial Catalog=todo;Integrated Security=True;Encrypt=False");
        static abstract List<Todo_Task> Select(string connectionString = "Data Source=MSI;Initial Catalog=todo;Integrated Security=True;Encrypt=False");
        static abstract void Delete(string name, string connectionString = "Data Source=MSI;Initial Catalog=todo;Integrated Security=True;Encrypt=False");
        static abstract void Update(Todo_Task task, string previousName, string connectionString = "Data Source=MSI;Initial Catalog=todo;Integrated Security=True;Encrypt=False");

    }
}

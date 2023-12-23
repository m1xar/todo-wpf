using System.Windows;


namespace todo
{
    public partial class CreateTaskWindow : Window
    {
        private readonly string connectionString = "Data Source=MSI;Initial Catalog=todo;Integrated Security=True;Encrypt=False";

        public event EventHandler TaskCreated;
        public CreateTaskWindow()
        {
            InitializeComponent();
        }

        private void addTask_Click(object sender, RoutedEventArgs e)
        {
            Todo_Task task = new Todo_Task(inputName.Text, inputDescription.Text, inputDate.SelectedDate.Value.Date, inputPriority.SelectedIndex + 1);
            TodoTask_Repository.Insert(task);

            TaskCreated?.Invoke(this, EventArgs.Empty);

            Close();
        }
    }
}

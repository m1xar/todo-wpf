using System.Windows;


namespace todo
{
    public partial class MainWindow : Window
    {
        private readonly string connectionString = "Data Source=MSI;Initial Catalog=todo;Integrated Security=True;Encrypt=False";
        public MainWindow()
        {
           InitializeComponent();
           List<Todo_Task> tasks = new List<Todo_Task>();
           tasks = TodoTask_Repository.Select();
           TasksGrid.ItemsSource = tasks;
        }

        private void addTask(object sender, RoutedEventArgs e)
        {
            CreateTaskWindow taskWindow = new CreateTaskWindow();
            taskWindow.TaskCreated += TaskWindow_TaskCreated;
            taskWindow.Show();
        }

        private void TaskWindow_TaskCreated(object sender, EventArgs e)
        {
            refreshGrid();
        }

        private void refreshGrid()
        {
            List<Todo_Task> tasks = new List<Todo_Task>();
            tasks = TodoTask_Repository.Select();
            TasksGrid.ItemsSource = tasks;
            TasksGrid.Items.Refresh();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            Todo_Task selectedTask = (Todo_Task)TasksGrid.SelectedItem;
            EditTaskWindow taskWindow = new EditTaskWindow(selectedTask.Name, selectedTask.Description, selectedTask.Time, selectedTask.Priority);
            taskWindow.TaskEdited += TaskWindow_TaskEdited;
            taskWindow.Show();
                        
        }

        private void TaskWindow_TaskEdited(object sender, EventArgs e)
        {
            refreshGrid();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            Todo_Task selectedTask = (Todo_Task)TasksGrid.SelectedItem;
            TodoTask_Repository.Delete(selectedTask.Name);
            refreshGrid();
        }



    }
}
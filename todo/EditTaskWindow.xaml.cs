using System.Windows;


namespace todo
{
    public partial class EditTaskWindow : Window
    {

        public event EventHandler TaskEdited;
        private string previousName;
        public EditTaskWindow(string name, string description, DateTime time, int priority)
        {
            Todo_Task task;
            task = new Todo_Task(name, description, time, priority);
            InitializeComponent();
            previousName = task.Name;
            inputDate.SelectedDate = task.Time;
            inputDescription.Text = task.Description;
            inputName.Text = task.Name;
            inputPriority.SelectedIndex = task.Priority - 1;
        }

        private void saveTask_Click(object sender, RoutedEventArgs e)
        {
            Todo_Task task = new Todo_Task(inputName.Text, inputDescription.Text, inputDate.SelectedDate.Value.Date, inputPriority.SelectedIndex + 1);
            TodoTask_Repository.Update(task, previousName);
            TaskEdited?.Invoke(this, EventArgs.Empty);
            Close();
        }
    }
}

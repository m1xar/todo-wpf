using System.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using todo;

namespace todo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string connectionString = "Data Source=MSI;Initial Catalog=todo;Integrated Security=True;Encrypt=False";

        List<Todo_Task> tasks = new List<Todo_Task>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello WPF!");
        }

        private void addTask(object sender, RoutedEventArgs e)
        {
            var todotask = new TodoTask_Repository(connectionString);
            Todo_Task newTask = new Todo_Task();
            todotask.Delete("Default");
            tasks = todotask.Select();

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySqlConnector;
using System.Data.SqlClient;
using System.Data;

namespace Project_ToDo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MySqlConnection connection = new MySqlConnection("Data Source=localhost;Database=project_test;User ID=root;");

        public MainWindow()
        {
            InitializeComponent();
            //this.connection.Open();
            //this.setEntriesFromDB();
            //this.connection.Close();
            //this.connection.Open();
            //this.setPossibleDistricts();
            //this.connection.Close();
        }

        private void setEntriesFromDB()
        {
            string ToDoSelectQuery = "SELECT todo_test.date, todo_test.task, todo_test.category, todo_test.priority,";
             //"officers.crimes_solved FROM officers INNER JOIN district on district.external_id = officers.working_district";
            var command = new MySqlCommand(ToDoSelectQuery, this.connection);
            var ToDoReader = command.ExecuteReader();
            while (ToDoReader.Read())
            {
                ToDo.setDate(ToDoReader.GetString(1));
                ToDo.setTask(ToDoReader.GetString(2));
                ToDo.setCategory(ToDoReader.GetString(3));
                ToDo.setPriority(ToDoReader.GetString(4))
                this.todos.Items.Add(ToDo);
            }
        }

        private void AddToDo(object sender, RoutedEventArgs e)
        {
            this.AddToDoToDB();
            this.todos.Items.Clear();
            this.connection.Open();
            this.setEntriesFromDB();
        }

        private void AddToDoToDB()
        {
            this.connection.Open();
            string insertToDoSQLQuery = "INSERT INTO todo_test (date, category, priority, task)"
                + "VALUES (@date,@category,@priority,@task)";

            MySqlParameter dateParam = new MySqlParameter("@date", SqlDbType.Date);
            MySqlParameter categoryParam = new MySqlParameter("@category", SqlDbType.Text);
            MySqlParameter priorityParam = new MySqlParameter("@priority", SqlDbType.Text);
            MySqlParameter taskParam = new MySqlParameter("@task", SqlDbType.Text);

            var command = new MySqlCommand(insertToDoSQLQuery, connection);
            command.Parameters.Add(dateParam);
            command.Parameters.Add(categoryParam);
            command.Parameters.Add(priorityParam);
            command.Parameters.Add(taskParam);

            command.Parameters[0].Value = this.Date.Date;
            command.Parameters[1].Value = this.Task.Text;
            command.Parameters[2].Value = this.Category.Text;
            command.Parameters[3].Value = this.Priority.Text;
            command.Prepare();
            command.ExecuteNonQuery();
            this.connection.Close();
        }  
}

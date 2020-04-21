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
using DesktopContactsApp.Classes;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            readDatabase();
        }
        private void Button_Click (object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog(); // Show dialog makes the user use the new window before continuing

            readDatabase(); //will not be executed until the dialog window closes
        }

        void readDatabase()
        {
            List<Contact> contacts;
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>(); //can be called twice and will not create the table again
                contacts = connection.Table<Contact>().ToList(); //to list is nessesary to have a usable variable in c# in this instance
            }
            if (contacts != null)
            {
                contactsListView.ItemsSource = contacts; //This is basically a for each loop
            }
        }
    }
}

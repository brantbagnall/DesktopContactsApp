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
using System.Windows.Shapes;
using DesktopContactsApp.Classes;
using SQLite;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
        }
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact()
            //Setting values in the SQLlite DB
            {
                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneNumberTextBox.Text
            };
            

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath)) //using defines element that will only exist within this context, has to use the idisposable object
            {
                connection.CreateTable<Contact>(); //can be called twice and will not create the table again
                connection.Insert(contact); //inserting the contact we created above
            }
            

            Close(); // can be written as this.Close()
        }
    }
}

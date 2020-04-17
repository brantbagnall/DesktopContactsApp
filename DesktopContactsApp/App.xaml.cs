using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static String databaseName = "Contacts.db";
        static String folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static String databasePath = System.IO.Path.Combine(folderPath, databaseName); // best practice for creating a path
    }
}

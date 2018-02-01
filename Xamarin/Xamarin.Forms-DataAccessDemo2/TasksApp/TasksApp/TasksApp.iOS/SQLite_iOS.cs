using System;
using System.IO;
using Xamarin.Forms;

using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;

using TasksApp.iOS;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace TasksApp.iOS
{
    public class SQLite_iOS : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            string sqLiteFileName = "SQLite.db3";
            string documentsFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsFilePath, "..", "Library");

            string path = Path.Combine(libraryPath, sqLiteFileName);

            var connection = new SQLiteConnection(new SQLitePlatformIOS(), path);

            return connection;
        }
    }
}
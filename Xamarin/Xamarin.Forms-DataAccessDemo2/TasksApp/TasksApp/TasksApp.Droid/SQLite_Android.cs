using System;
using System.IO;
using Xamarin.Forms;

using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;

[assembly: Dependency(typeof(TasksApp.Droid.SQLite_Android))]
namespace TasksApp.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android()
        {
        }

        public SQLiteConnection GetConnection()
        {
            string sqLiteFileName = "SQLite.db3";
            string documentsFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            string path = Path.Combine(documentsFilePath, sqLiteFileName);

            var connection = new SQLiteConnection(new SQLitePlatformAndroid(), path);

            return connection;
        }
    }
}
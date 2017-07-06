using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BloodForLifeXamarin.Data;
using SQLite;
using System.IO;
using Xamarin.Forms;
using BloodForLifeXamarin.Droid.Data;

[assembly: Dependency(typeof(SQLite_Android))]

namespace BloodForLifeXamarin.Droid.Data
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFileName = "TestDB.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}
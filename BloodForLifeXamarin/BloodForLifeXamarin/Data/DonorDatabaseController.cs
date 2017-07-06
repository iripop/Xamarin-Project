using BloodForLifeXamarin.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BloodForLifeXamarin.Data
{
    public class DonorDatabaseController
    {
        static object locker = new object();
        SQLiteConnection database;

        public DonorDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Donor>();
        }

        public Donor GetDonor()
        {
            lock (locker)
            {
                if (database.Table<Donor>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<Donor>().First();
                }
            }
        }

        public int SaveDonor(Donor donor)
        {
            lock (locker)
            {
                if (donor.DonorID != 0)
                {
                    database.Update(donor);
                    return donor.DonorID;
                }
                else
                {
                    return database.Insert(donor);
                }
            }
        }

        public int DeleteUser(int id)
        {
            lock (locker)
            {
                return database.Delete<Donor>(id);
            }
        }
    }
}

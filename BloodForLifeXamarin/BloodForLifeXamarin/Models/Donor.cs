using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodForLifeXamarin.Models
{
    public class Donor
    {
        public int DonorID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Donor() { }
        public Donor(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }

        public bool CheckLoginInfo()
        {
            if (!this.Username.Equals("") && !this.Password.Equals(""))
                return true;
            else
                return false;
        }
    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodForLifeXamarin.Models
{
    public class Token
    {
        [PrimaryKey]
        public int DonorID { get; set; }
        public string access_token { get; set; }
        public string error_description { get; set; }
        public DateTime expire_date { get; set; }
        public int expire_in { get; set; }

        public Token() { }
    }
}

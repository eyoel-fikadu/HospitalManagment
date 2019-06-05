using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBedManagment.Model
{
    public class User
    {
        public int ID { get; set; }
        public int PersonId { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}

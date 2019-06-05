using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBedManagment.Model
{
    public class BedInformation 
    {
        public int Id { get; set; }
        public string BedNumber { get; set; }
        public string Room { get; set; }
        public string Remark { get; set; }
    }
}

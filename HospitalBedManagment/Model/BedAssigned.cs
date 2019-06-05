using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBedManagment.Model
{
    public class BedAssigned
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int BedId { get; set; }
        public int CaseTeam { get; set; }
        public bool isActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String Remark { get; set; }
    }
}

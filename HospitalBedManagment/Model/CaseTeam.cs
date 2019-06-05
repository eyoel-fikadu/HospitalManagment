using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBedManagment.Model
{
    public class CaseTeam
    {
        public int Id { get; set; }
        public string CaseTeamName { get; set; }
        public List<Person> CaseTeamMembers { get; set; }
    }
}

using HospitalBedManagment.Controller;
using HospitalBedManagment.Model;
using HospitalBedManagment.View.Assign;
using HospitalBedManagment.View.Manage;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalBedManagment
{
    public partial class MainForm : Form
    {
        public static Connection con;
        public MainForm()
        {
            InitializeComponent();
            con = new Connection();
        }

        private void btnManagePatient_Click(object sender, EventArgs e)
        {
            ManagePatient pat = new ManagePatient(con.GetAllPerson().Where(X => X.Type == "Patient").ToList());
            pat.ShowDialog();
        }

        private void btnAssignBed_Click(object sender, EventArgs e)
        {
            AssignedBed bed = new AssignedBed(con.GetActiveAssignedBed());
            bed.ShowDialog();
        }

        private void btnManageCaseTeam_Click(object sender, EventArgs e)
        {
            ManageCaseTeam caseTeam = new ManageCaseTeam(con.GetAllCastTeams());
            caseTeam.ShowDialog();
        }

        private void btnManageBed_Click(object sender, EventArgs e)
        {
            ManageBeds beds = new ManageBeds(con.GetAllBed());
            beds.ShowDialog();
        }
    }
}

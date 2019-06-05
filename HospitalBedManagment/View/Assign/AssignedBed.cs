using HospitalBedManagment.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalBedManagment.View.Assign
{
    public partial class AssignedBed : Form
    {
        public AssignedBed(List<BedAssigned> assignedBeds)
        {
            InitializeComponent();
            gridAssignedBeds.DataSource = assignedBeds;
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AssignBeds newBeds = new AssignBeds();
            newBeds.FormClosed += newBeds_FormClosed;
            newBeds.ShowDialog();
        }

        void newBeds_FormClosed(object sender, FormClosedEventArgs e)
        {
            gridAssignedBeds.DataSource = null;
            gridAssignedBeds.DataSource = MainForm.con.GetActiveAssignedBed();
        }

        private void btnRemoveBed_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}

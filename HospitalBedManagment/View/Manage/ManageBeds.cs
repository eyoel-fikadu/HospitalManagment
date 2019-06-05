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

namespace HospitalBedManagment.View.Manage
{
    public partial class ManageBeds : Form
    {
        public ManageBeds(List<BedInformation> allBed)
        {
            InitializeComponent();
            gridBeds.DataSource = allBed;
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddBed bed = new AddBed();
            bed.FormClosed += bed_FormClosed;
            bed.ShowDialog();
        }

        void bed_FormClosed(object sender, FormClosedEventArgs e)
        {
            gridBeds.DataSource = null;
            gridBeds.DataSource = MainForm.con.GetAllBed();
        }


    }
}

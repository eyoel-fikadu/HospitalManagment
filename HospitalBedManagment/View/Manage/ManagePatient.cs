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
    public partial class ManagePatient : Form
    {
        public ManagePatient(List<Person> allPerson)
        {
            InitializeComponent();
            gridAllPatients.DataSource = allPerson;
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddPerson add = new AddPerson();
            add.FormClosed += add_FormClosed;
            add.ShowDialog();
        }

        void add_FormClosed(object sender, FormClosedEventArgs e)
        {
            gridAllPatients.DataSource = null;
            gridAllPatients.DataSource = MainForm.con.GetAllPerson().Where(X => X.Type == "Patient").ToList();
        }
    }
}

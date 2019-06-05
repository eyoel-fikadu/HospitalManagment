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

namespace HospitalBedManagment.View
{
    public partial class AddBed : Form
    {
        public AddBed()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBedNumber.Text)) { MessageBox.Show("Bed Number Not Inserted!"); return; }
            if (string.IsNullOrEmpty(txtRoomNumber.Text)) { MessageBox.Show("Room Number Not Inserted!"); return; }

            BedInformation bed = new BedInformation();
            bed.BedNumber = txtBedNumber.Text;
            bed.Room = txtRoomNumber.Text;
            try
            {
                if (MainForm.con.InsertBed(bed) > 0)
                {
                    MessageBox.Show("Saved Succesfully");
                    this.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}

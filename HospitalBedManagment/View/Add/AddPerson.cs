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
    public partial class AddPerson : Form
    {
        public AddPerson()
        {
            InitializeComponent();
            comboGender.Properties.Items.AddRange(MainForm.con.GetAllLookups().Where(x => x.Type == "Gender").Select(x => x.Data).ToList());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (FormValid())
            {
                Person per = new Person();
                per.CardNumber = txtCardNumber.Text;
                per.FirstName = txtFirstName.Text;
                per.Lastname = txtLastName.Text;
                per.DateOfBirth = dob.DateTime.Date;
                per.Gender = comboGender.Text;
                per.Address = txtAddress.Text;
                per.PhoneNumber = txtPhoneNumber.Text;
                per.AltPhoneNumber = txtAltPhoneNumber.Text;
                per.Type = "Patient";
                try
                {
                    if (MainForm.con.InsertPerson(per) > 0)
                    {
                        MessageBox.Show("Succesfully Added");
                        this.Close();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private bool FormValid()
        {
            if (string.IsNullOrEmpty(txtCardNumber.Text)) { MessageBox.Show("Card Number Not Inserted"); return false; };
            if (string.IsNullOrEmpty(txtFirstName.Text)) { MessageBox.Show("First Name Not Inserted"); return false; };
            if (string.IsNullOrEmpty(txtLastName.Text)) { MessageBox.Show("Last Name Not Inserted"); return false; };
            if (string.IsNullOrEmpty(dob.Text)) { MessageBox.Show("Date Of Birth Not Selected"); return false; };
            if (string.IsNullOrEmpty(comboGender.Text)) { MessageBox.Show("Gender Not Selected"); return false; };
            return true;
        }
    }
}

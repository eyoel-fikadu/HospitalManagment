﻿using HospitalBedManagment.Model;
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
    public partial class ManageCaseTeam : Form
    {
        public ManageCaseTeam(List<CaseTeam> teams)
        {
            InitializeComponent();
            gridCaseTeam.DataSource = teams;
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddCaseTeam team = new AddCaseTeam();
            team.FormClosed += team_FormClosed;
            team.ShowDialog();
        }

        void team_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}

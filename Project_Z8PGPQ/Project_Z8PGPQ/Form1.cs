using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Z8PGPQ
{
    public partial class Form1 : Form
    {
        CostCentersDB costCentersDB;
        public Form1()
        {
            InitializeComponent();

            costCentersDB = new CostCentersDB();

            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.DataSource = costCentersDB.costCenters;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            if (sfd.ShowDialog() != DialogResult.OK) return;

            costCentersDB.ToCSV(sfd.FileName);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            costCentersDB.WrongElements();
            if (costCentersDB.wrongcostCenters.Count != 0)
                dataGridView2.DataSource = costCentersDB.wrongcostCenters;
            else
                dataGridView2.DataSource = null;
            LoadData();
            Refresh();
        }

        private void btnCorrect_Click(object sender, EventArgs e)
        {
            costCentersDB.RefreshCostCenters();
            LoadData();
            Refresh();
        }
    }
}

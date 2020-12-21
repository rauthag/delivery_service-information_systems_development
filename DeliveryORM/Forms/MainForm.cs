using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void adminB_Click(object sender, EventArgs e)
        {
            adminUI ui = new adminUI();

            using (ui)
            {
                ui.ShowDialog();
            }
        }

        private void courierB_Click(object sender, EventArgs e)
        {
            courierUI ui = new courierUI();

            using (ui)
            {
                ui.ShowDialog();
            }
        }

        private void customerB_Click(object sender, EventArgs e)
        {
            customerUI ui = new customerUI();

            using (ui)
            {
                ui.ShowDialog();
            }
        }

        private void exitB_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

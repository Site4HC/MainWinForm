using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;
using Main;

namespace Biblio
{
    public partial class myBD : Form
    {
        public myBD()
        {
            InitializeComponent();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About f1 = new About();
            f1.ShowDialog();
        }

        private void калькуляторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calculator f2 = new Calculator();
            f2.ShowDialog();
        }

        private void OpenTableOsoba_Click(object sender, EventArgs e)
        {
            frmOsoba f1 = new frmOsoba();
            f1.ShowDialog();
        }

        private void myBD_Load(object sender, EventArgs e)
        {

        }

        private void OpenTableKatalog_Click(object sender, EventArgs e)
        {
            frmKatalog f1 = new frmKatalog();
            f1.ShowDialog();
        }
    }
}

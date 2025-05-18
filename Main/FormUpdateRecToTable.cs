using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblio;
using MySql.Data.MySqlClient;

namespace Main
{
    public partial class FormUpdateRecToTable : Form
    {
        public FormUpdateRecToTable()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlStr = "UPDATE Katalog SET " + tbSetToUpdate.Text + " WHERE " + tbWhereToUpdate.Text;

            if (MessageBox.Show("Ви впевнені, що хочете замінити дані?", "Заміна",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (MySqlConnection con = new MySqlConnection(h.ConStr))
                {
                    MySqlCommand cmd = new MySqlCommand(sqlStr, con);

                    con.Open();             // Відкриваємо з'єднання
                    cmd.ExecuteNonQuery();  // Виконуємо команду cmd
                    con.Close();            // Закриваємо з'єднання
                }
            }
            this.Close();
        }

        private void FormUpdateRecToTable_Load(object sender, EventArgs e)
        {

        }
    }
}

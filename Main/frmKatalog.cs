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
    public partial class frmKatalog : Form
    {
        public frmKatalog()
        {
            InitializeComponent();
        }

        private void frmKatalog_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable table = new DataTable();
                using (MySqlConnection con = new MySqlConnection(h.ConStr))
                {
                    string sql = "SELECT IPk, NameK, AvtorK, KilkK, RikVydK, VydavnK FROM Katalog";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
                    adapter.Fill(table);
                }


                BindingSource bindingSource1 = new BindingSource();
                bindingSource1.DataSource = table;

                dataGridView1.DataSource = bindingSource1;
                bindingNavigator1.BindingSource = bindingSource1;
                dataGridView1.RowHeadersVisible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при завантаженні: " + ex.Message);
            }
        }



        private void Addnew_Click(object sender, EventArgs e)
        {
            Table1_Insert f1 = new Table1_Insert();
            f1.ShowDialog();

            if (h.bs1 == null)
                h.bs1 = new BindingSource();

            h.bs1.DataSource = h.myfunDt("SELECT IPk, NameK, AvtorK, KilkK, RikVydK, VydavnK FROM Katalog");

            dataGridView1.DataSource = h.bs1;
            bindingNavigator1.BindingSource = h.bs1;
            dataGridView1.RowHeadersVisible = false;
        }


        private void Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Будь ласка, виберіть рядок для видалення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Отримуємо ключове значення
            h.curVal0 = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            h.keyName = dataGridView1.Columns[0].Name;

            // Відкриваємо форму для видалення
            Table1_Delete f3 = new Table1_Delete();
            f3.ShowDialog();

            // Оновлюємо дані
            h.bs1.DataSource = h.myfunDt("SELECT IPk, NameK, AvtorK, KilkK, RikVydK, VydavnK FROM Katalog");
            dataGridView1.DataSource = h.bs1;
            bindingNavigator1.BindingSource = h.bs1;
        }

        private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            h.keyName = dataGridView1.Columns[0].Name;
            h.curVal0 = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();

            int curColInx = dataGridView1.CurrentCellAddress.X;
            string curColName = dataGridView1.Columns[curColInx].Name;
            string newCurCellVal = e.Value.ToString();

            if (curColName == "NameK" || curColName == "AvtorK" || curColName == "VydavnK")
            {
                newCurCellVal = "'" + newCurCellVal + "'";
            }
            else if (curColName == "RikVydK")
            {
                if (DateTime.TryParse(newCurCellVal, out DateTime parsedDate))
                {
                    newCurCellVal = "'" + parsedDate.ToString("yyyy-MM-dd") + "'";
                }
                else
                {
                    // Handle parsing error, maybe show a message to the user
                    e.ParsingApplied = false; // Indicate that parsing failed
                    return;
                }
            }


            string sqlStr = "UPDATE Katalog SET " + curColName + " = " + newCurCellVal + " WHERE " + h.keyName + " = '" + h.curVal0 + "'";

            using (MySqlConnection con = new MySqlConnection(h.ConStr))
            {
                MySqlCommand cmd = new MySqlCommand(sqlStr, con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                h.curVal0 = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                h.keyName = dataGridView1.Columns[0].Name;

                FormUpdateRecToTable f4 = new FormUpdateRecToTable();
                f4.ShowDialog(); // показуємо форму у режимі діалогу

                if (h.bs1 == null)
                {
                    h.bs1 = new BindingSource();
                }
                h.bs1.DataSource = h.myfunDt("SELECT IPk, NameK, AvtorK, KilkK, RikVydK, VydavnK FROM Katalog");

                dataGridView1.DataSource = h.bs1; // оновлюємо DataGridView
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть рядок для редагування.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
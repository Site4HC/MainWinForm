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

namespace Main
{
    public partial class frmOsoba : Form
    {
        public frmOsoba()
        {
            InitializeComponent();
        }

        private void frmOsoba_Load(object sender, EventArgs e)
        {
            this.Height = 320;
            h.bs1 = new BindingSource();
            h.bs1.DataSource = h.myfunDt("Select * from info");
            dataGridView1.DataSource = h.bs1;
            bindingNavigator1.BindingSource = h.bs1;
            dataGridView1.RowHeadersVisible = false;



            DWGFormat();

            DataTable dtBorder = new DataTable();
            DataTable dtDistinct = new DataTable();
            dtBorder = h.myfunDt("SELECT min(rating), max(rating), min(DNO), max(DNO) FROM info");
            dtDistinct = h.myfunDt("SELECT distinct Adresa from info");

            txtReitFrom.Text = dtBorder.Rows[0][0].ToString();
            txtReitTo.Text = dtBorder.Rows[0][1].ToString();
            dtpDNOFrom.Value = Convert.ToDateTime(dtBorder.Rows[0][2].ToString());
            dtpDNOTo.Value = Convert.ToDateTime(dtBorder.Rows[0][3].ToString());

            cmbAdres.Items.Add("");
            for (int i = 0; i < dtDistinct.Rows.Count; i++)
            {
                cmbAdres.Items.Add(dtDistinct.Rows[i][0].ToString());
            }
            cmbAdres.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbSex.Items.Add("");
            cmbSex.Items.Add("ч");
            cmbSex.Items.Add("ж");
            cmbSex.Text = "ч";
            cmbSex.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        void DWGFormat()
        {
            dataGridView1.Columns[0].Width = 25;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

            if (btnFind.Checked)
            {
                label1.Visible = true;
                txtFind.Visible = true;
                txtFind.Focus();
            }
            else
            {
                CancelFind();
            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(txtFind.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
                    }
                }
            }
        }

        private void txtFind_Leave(object sender, EventArgs e)
        {
            btnFind.Checked = false;
            CancelFind();
        }
        private void CancelFind()
        {
            label1.Visible = false;
            txtFind.Visible = false;
            txtFind.Text = "";
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
            }
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.DarkViolet, 1); // колір і товщина рамки
            gfx.DrawLine(p, 0, 5, 5, 5);          // верхня горизонтальна лінія до Text
            gfx.DrawLine(p, 35, 5, e.ClipRectangle.Width - 2, 5); // верхня горизонтальна лінія після Text
            gfx.DrawLine(p, 0, 5, 0, e.ClipRectangle.Height - 2); // ліва вертикаль
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, 5, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2); // права вертикаль
            gfx.DrawLine(p, 0, e.ClipRectangle.Height - 2, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2); // низ
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (btnFind.Enabled)
            {
                this.Height = 500;
                groupBox1.Visible = true;
            }
            else
            {
                this.Height = 320;
                groupBox1.Visible = false;
            }
        }

        private void btnFilterOk_Click(object sender, EventArgs e)
        {
            string strFilter = "ID > 0";

            if (!string.IsNullOrWhiteSpace(txtPIP.Text))
            {
                strFilter += $" AND PIPO LIKE '{txtPIP.Text}%'";
            }

            if (!string.IsNullOrWhiteSpace(txtReitFrom.Text) && !string.IsNullOrWhiteSpace(txtReitTo.Text))
            {
                strFilter += $" AND (Rating >= {txtReitFrom.Text.Replace(',', '.')} AND Rating <= {txtReitTo.Text.Replace(',', '.')})";
            }
            else if (string.IsNullOrWhiteSpace(txtReitFrom.Text) && !string.IsNullOrWhiteSpace(txtReitTo.Text))
            {
                strFilter += $" AND (Rating <= {txtReitTo.Text.Replace(',', '.')})";
            }
            else if (!string.IsNullOrWhiteSpace(txtReitFrom.Text) && string.IsNullOrWhiteSpace(txtReitTo.Text))
            {
                strFilter += $" AND (Rating >= {txtReitFrom.Text.Replace(',', '.')})";
            }

            strFilter += $" AND (DNO >= #{dtpDNOFrom.Value:yyyy-MM-dd}# AND DNO <= #{dtpDNOTo.Value:yyyy-MM-dd}#)";

            if (!string.IsNullOrWhiteSpace(cmbAdres.Text))
            {
                strFilter += $" AND (Adresa = '{cmbAdres.Text}')";
            }


            if (cmbSex.Text == "ч")
            {
                strFilter += " AND (Sex = 0)";
            }
            else if (cmbSex.Text == "ж")
            {
                strFilter += " AND (Sex = 1)";
            }

            h.bs1.Filter = strFilter;

        }

        private void btnFilterCancel_Click(object sender, EventArgs e)
        {
            h.bs1.RemoveFilter();
        }

    }
}

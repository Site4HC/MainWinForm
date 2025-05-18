using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Biblio
{
    public partial class LogIn : Form
    {
        public string[,] matrix;
        DataTable dt;

        public LogIn()
        {
            InitializeComponent();
            h.ConStr = "server=194.44.236.9; database=sqlkn24_1_gri;user=sqlkn24_1_gri; password=kn24_gri; charset=cp1251;";
            dt = h.myfunDt("SELECT * FROM userName");

            int kilkz = dt.Rows.Count;
            matrix = new string[kilkz, 4];

            for (int i = 0; i < kilkz; i++)
            {
                matrix[i, 0] = dt.Rows[i].Field<int>("ID").ToString();
                matrix[i, 1] = dt.Rows[i].Field<string>("UserName") ?? "";
                matrix[i, 2] = dt.Rows[i].Field<int>("Type").ToString();
                matrix[i, 3] = dt.Rows[i].Field<string>("Password") ?? "";
                cbxUser.Items.Add(matrix[i, 1]);
                txtPassword.UseSystemPasswordChar = true;
                cbxUser.Focus();
            }
        }

        public static string EncryptedPassword_MD5(string s)
        {
            if (string.Compare(s, "null", true) == 0)
                return "NULL";
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHach = CSP.ComputeHash(bytes);
            string hash = string.Empty;
            foreach (byte b in byteHach)
                hash += string.Format("{0:x2}", b);
            return hash;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Avtorization()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (String.Equals(cbxUser.Text.ToUpper(), matrix[i, 1].ToUpper()))
                {
                    if (String.Equals(EncryptedPassword_MD5(txtPassword.Text), matrix[i, 3]))
                    {
                        this.Hide();
                        myBD f1 = new myBD();
                        f1.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Введіть правильний пароль!", "Помилка авторизації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Avtorization();
            else if (e.KeyCode == Keys.Escape)
                Application.Exit();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Avtorization();
        }
    }

    public static class h
    {
        public static string ConStr { get; set; }
        public static string typeUser { get; set; }
        public static string nameUser { get; set; }
        public static BindingSource bs1 { get; set; }

        public static DataTable myfunDt(string commandString)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(h.ConStr))
            {
                MySqlCommand cmd = new MySqlCommand(commandString, con);
                try
                {
                    con.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dt.Load(dr);
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Неможливо з'єднатися з SQL-сервером! \nПеревірте наявність Інтернету...", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return dt;
            }
        }
    }
}

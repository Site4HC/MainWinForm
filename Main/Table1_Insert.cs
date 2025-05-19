using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblio;
using MySql.Data.MySqlClient;

namespace Main
{
    public partial class Table1_Insert : Form
    {
        public Table1_Insert()
        {
            InitializeComponent();
        }

        private void Tabl1InsAdd_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(h.ConStr))
            {
                string tb1 = textBox1.Text;
                string tb2 = textBox2.Text;
                string tb3 = textBox3.Text;
                string tb4 = textBox4.Text;
                string tb5 = textBox5.Text;
                string tb6 = textBox6.Text;

                string sql = "INSERT INTO Katalog " +
                             "(IpK, NameK, AvtorK, KilKk, RikVydK, VydavnK";

                // Додаємо стовпець для фото, якщо шлях до фотографії не порожній
                if (!string.IsNullOrEmpty(h.pathToPhoto))
                {
                    sql += ", Photo";
                }

                sql += ") VALUES (@TK1, @TK2, @TK3, @TK4, @TK5, @TK6";

                // Додаємо параметр для фото, якщо шлях до фотографії не порожній
                if (!string.IsNullOrEmpty(h.pathToPhoto))
                {
                    sql += ", @File";
                }

                sql += ")";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@TK1", tb1);
                cmd.Parameters.AddWithValue("@TK2", tb2);
                cmd.Parameters.AddWithValue("@TK3", tb3);
                cmd.Parameters.AddWithValue("@TK4", tb4);
                cmd.Parameters.AddWithValue("@TK5", tb5);
                cmd.Parameters.AddWithValue("@TK6", tb6);

                // Додаємо параметр для фото, якщо шлях до фотографії не порожній
                if (!string.IsNullOrEmpty(h.pathToPhoto))
                {
                    string strFileName = h.pathToPhoto;
                    FileStream fs = new FileStream(strFileName, FileMode.Open, FileAccess.Read);
                    int FileSize = (int)fs.Length;
                    byte[] rawData = new byte[FileSize];
                    fs.Read(rawData, 0, FileSize);
                    fs.Close();

                    cmd.Parameters.AddWithValue("@File", rawData);
                    // Видалили рядок з @FileName
                    // cmd.Parameters.AddWithValue("@FileName", strFileName);
                }

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Додавання запису пройшло вдало");
                this.Close();
            }
        }

        private void Tabl1InsCansel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Table1_Insert_Load(object sender, EventArgs e)
        {
            h.pathToPhoto = Application.StartupPath + @"\" + "img247.jpg";
            pictureBox1.Image = Image.FromFile(h.pathToPhoto);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Виберіть файл";
            openFileDialog1.Filter = "img files (*.jpg)|*.jpg|bmp file (*.bmp)|*.bmp|All files (*.*)|*.*";
            openFileDialog1.InitialDirectory = Application.StartupPath;
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            {
                h.pathToPhoto = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(h.pathToPhoto);
            }
        }
    }
}

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

        private void buttUpdateRec_Click(object sender, EventArgs e)
        {
            string sqlStr;

            if ((checkBox1.Checked == true) && (checkBox2.Checked == false))
            {
                //формуємо запит тільки на редагування даних за умовою
                sqlStr = "UPDATE Katalog SET " + tbSetToUpdate.Text +
                         " WHERE " + tbWhereToUpdate.Text;
                if (MessageBox.Show("Ви впевнені, що хочете замінити дані?", "Заміна",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (MySqlConnection con = new MySqlConnection(h.ConStr))
                    {
                        MySqlCommand cmd = new MySqlCommand(sqlStr, con);
                        con.Open(); //Відкриваємо з'єднання
                        cmd.ExecuteNonQuery(); //Виконуємо команду cmd
                        con.Close(); //Закриваємо з'єднання
                        MessageBox.Show("Редагування запису пройшло вдало");
                    }
                }
            }
            if ((checkBox1.Checked == false) && (checkBox2.Checked == true))
            {
                //формуємо запит тільки на заміну зображення
                int FileSize;
                byte[] masBytes;
                FileStream fs;
                string strFileName;

                strFileName = h.pathToPhoto; //отримано з OpenFileDialog
                fs = new FileStream(strFileName, FileMode.Open, FileAccess.Read);
                FileSize = (int)fs.Length;
                masBytes = new byte[FileSize];
                fs.Read(masBytes, 0, FileSize); //читаємо зображення як масив байтів
                fs.Close();

                sqlStr = "UPDATE Katalog SET Photo = @File WHERE " + tbWhereToUpdate.Text;
                if (MessageBox.Show("Ви впевнені, що хочете замінити дані?", "Заміна",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (MySqlConnection con = new MySqlConnection(h.ConStr))
                    {
                        MySqlCommand cmd = new MySqlCommand(sqlStr, con);
                        cmd.Parameters.AddWithValue("@File", masBytes);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Редагування запису пройшло вдало");
                    }
                }
            }
            if ((checkBox1.Checked == true) && (checkBox2.Checked == true))
            {
                //формуємо запит на редагування даних за умовою + фото
                int FileSize;
                byte[] rawData;
                FileStream fs;
                string strFileName;

                strFileName = h.pathToPhoto;
                fs = new FileStream(strFileName, FileMode.Open, FileAccess.Read);
                FileSize = (int)fs.Length;
                rawData = new byte[FileSize];
                fs.Read(rawData, 0, FileSize);
                fs.Close();

                sqlStr = "UPDATE Katalog SET " + tbSetToUpdate.Text +
                         ", Photo = @File " +
                         "WHERE " + tbWhereToUpdate.Text;
                if (MessageBox.Show("Ви впевнені, що хочете замінити дані?", "Заміна",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (MySqlConnection con = new MySqlConnection(h.ConStr))
                    {
                        MySqlCommand cmd = new MySqlCommand(sqlStr, con);
                        cmd.Parameters.AddWithValue("@File", rawData);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Редагування запису пройшло вдало");
                    }
                }
            }

            //Закриваємо вікно
            this.Close();
        }

        private void FormUpdateRecToTable_Load(object sender, EventArgs e)
        {
            h.pathToPhoto = Application.StartupPath + @"\" + "img247.jpg";
            pictureBox1.Image = Image.FromFile(h.pathToPhoto);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                label1.Visible = true;
                tbSetToUpdate.Visible = true; //none textBox1
                button1.Visible = true; //кнопка Button1
            }
            else if (checkBox1.Checked == false)
            {
                label1.Visible = false;
                tbSetToUpdate.Visible = false; //none textBox1
                if (checkBox2.Checked == false)
                {
                    button1.Visible = false; //кнопка Button1
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                panel2.Visible = true;
                label3.Visible = true;
                button3.Visible = true;
                pictureBox1.Visible = true;
                button1.Visible = true; //кнопка Button1
            }
            else if (checkBox2.Checked == false)
            {
                panel2.Visible = false;
                label3.Visible = false;
                button3.Visible = false;
                pictureBox1.Visible = false;
                if (checkBox1.Checked == false)
                {
                    button1.Visible = false; //кнопка Button1
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Title = "Виберіть файл";
            OFD.Filter = "img files (*.jpg)|*.jpg|bmp file (*.bmp)|*.bmp|All files (*.*)|*.*";
            OFD.InitialDirectory = Application.StartupPath;

            if (OFD.ShowDialog() != DialogResult.OK) return;
            {
                h.pathToPhoto = OFD.FileName;
                pictureBox1.Image = Image.FromFile(h.pathToPhoto);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
//挂失，照价赔偿
namespace WindowsFormsApplication1
{
    public partial class Home : Form
    {
        public Login loginForm = null;
        int FillListFlag = 0;//默认情况为书名，0表示书名，1表示作者，2表示出版社
        SqlConnection mSqlConnection = new SqlConnection();//用于连接数据库
        SqlCommand nSqlCommand = new SqlCommand();//用于模糊查询
        //SqlCommand pSqlCommand = new SqlCommand();//用于返回查询结果第一行第一列
        public Home()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "书名";
            comboBox1.SelectedIndex = 0;
            //toolStripStatusLabel5.Text = "系统时间："+Convert.ToString(System.DateTime.Now);
            mSqlConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\furui\Documents\libraryBooks.mdf;Integrated Security=True;Connect Timeout=30";
            mSqlConnection.Open();
           
        }

        public void FillList()
        {
            lstBooks.Items.Clear();//清空数据
            nSqlCommand.Connection = mSqlConnection;
            if (FillListFlag == 0)
            {
                nSqlCommand.CommandText = "select * from books where bookName like '%" + enquireTextBox.Text + "%'";//书名的模糊查询
            }
            else if (FillListFlag == 1)
            {
                nSqlCommand.CommandText = "select * from books where author like '%" + enquireTextBox.Text + "%'";//作者的模糊查询
            }
            else if (FillListFlag == 2)
            {
                nSqlCommand.CommandText = "select * from books where publisher like '%" + enquireTextBox.Text + "%'";//出版社的模糊查询
            }
            
            SqlDataReader sqldr = nSqlCommand.ExecuteReader();//返回的数据集
            while (sqldr.Read())//默认停留在第一条
            {
                ListViewItem lvi = new ListViewItem(sqldr[1].ToString());
                lvi.SubItems.Add(sqldr[2].ToString());
                lvi.SubItems.Add(sqldr[3].ToString());
                lvi.SubItems.Add(sqldr[4].ToString());
                lvi.SubItems.Add(sqldr[5].ToString());
                lvi.SubItems.Add(sqldr[0].ToString());
                this.lstBooks.Items.Add(lvi);
            }
            sqldr.Close();
            if (lstBooks.Items.Count==0)//判断查询是否有结果
            {
                MessageBox.Show("No Results！","Warning",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
           
        }
        private void Form3_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void borrowIntroductionLabel_Click(object sender, EventArgs e)
        {
            
        }

        private void qToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.Equals("Title"))
            {
                FillListFlag = 0;
                FillList();
            }else if (comboBox1.SelectedItem.Equals("Author"))
            {
                FillListFlag = 1;
                FillList();
            }else if (comboBox1.SelectedItem.Equals("Publisher"))
            {
                FillListFlag = 2;
                FillList();
            }

        }

        private void LoginLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            loginForm = new Login();
            loginForm.ShowDialog();//表示当前窗体不关，则其他窗体不可用
        }

        private void lstBooks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void enquireTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void borrowIntroduction_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {

        }
    }
}

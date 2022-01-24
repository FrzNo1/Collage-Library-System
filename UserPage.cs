using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class UserPage : Form
    {
        int alterPsdTimer = 2;//用于判断计时时执行哪一个操作，2为默认状态为掩码，1表示新密码恢复，0表示确认新密码恢复
        string userNameLab;
        SqlConnection mSqlConnection = new SqlConnection();
        SqlCommand nSqlCommand = new SqlCommand();
        public UserPage()
        {
            InitializeComponent();
        }
        public UserPage(string userName)//用来传递登陆成功的参数
        {
            userNameLab = userName;
            InitializeComponent();
        }

        private void UserPage_Load(object sender, EventArgs e)
        {
            //toolStripStatusLabel5.Text = "系统时间：" + Convert.ToString(System.DateTime.Now);
            userLab.Text = userNameLab;
            //连接数据库
            mSqlConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\furui\Documents\libraryBooks.mdf;Integrated Security=True;Connect Timeout=30";
            mSqlConnection.Open();
            //进行信息的更新
            //进行更新时间的更改
            DateTime dtNow = System.DateTime.Now;
            nSqlCommand.Connection = mSqlConnection;
            nSqlCommand.CommandText = "update borrowInformation set updateTime =  '" + dtNow + "' where user_name = '" + userNameLab + "' and returnTime is null";
            nSqlCommand.ExecuteNonQuery();
            //进行欠费信息处理
            nSqlCommand.Connection = mSqlConnection;
            nSqlCommand.CommandText = "select borrowedBooks from users where user_name = '" + userNameLab + "' ";
            int j = Convert.ToInt32(nSqlCommand.ExecuteScalar());
            if (j > 0)//指存在借书情况，也就是可能存在欠费情况
            {
                //进行每一条借阅信息欠费的处理
                nSqlCommand.CommandText = "update borrowInformation set BookMoney = (DATEDIFF(DAY,borrowTime ,updateTime)+1-30)*0.1 where user_name = '" + userNameLab + "' and returnTime is null and (DATEDIFF(DAY,borrowTime ,updateTime)+1-30)>0";
                nSqlCommand.ExecuteNonQuery();

                //计算总的欠费信息,先进行该用户是否正在借书数目的判断
                nSqlCommand.CommandText = "select sum(bookMoney) from borrowInformation where user_name = '" + userNameLab + "' and returnTime is null ";
                float allDebt = Convert.ToSingle(nSqlCommand.ExecuteScalar());
                //修改用户总的欠费信息
                nSqlCommand.CommandText = "update users set debt = " + allDebt + " where user_name = '" + userNameLab + "'  ";
                nSqlCommand.ExecuteNonQuery();
            }
            //填写个人信息
            nSqlCommand.Connection = mSqlConnection;
            //正在借阅图书
            nSqlCommand.CommandText = "select count(*) from borrowInformation where user_name = '"+ userNameLab + "' and returnTime is null";//返回正在借书个数，有几条不为空的还书数据
            int borrowingBooksNumber = Convert.ToInt32(nSqlCommand.ExecuteScalar());
            borrowingBooksNum.Text = ""+ borrowingBooksNumber.ToString()+""+" Books";
            //已借阅图书
            nSqlCommand.CommandText = "select count(*) from borrowInformation where user_name = '" + userNameLab + "' and returnTime is not null";//返回已经借书个数，还书时间不为空
            int borrowedBooksNumber = Convert.ToInt32(nSqlCommand.ExecuteScalar());
            borrowedBooksNum.Text = "" + borrowedBooksNumber.ToString() + "" + " Books";
            //填写欠费图书
            nSqlCommand.CommandText = "select count(*) from borrowInformation where user_name = '" + userNameLab + "'and bookMoney != 0 and returnTime is null";//返回欠费书籍的个数
            int debtBooksNumber = Convert.ToInt32(nSqlCommand.ExecuteScalar());
            debtBooksNum.Text = "" + debtBooksNumber.ToString() + "" + " Books";
            //填写欠费的钱
            nSqlCommand.CommandText = "select debt from users where user_name = '" + userNameLab + "'";//返回欠费书籍个数,从用户表里
            string debtMoneyNumber = Convert.ToString(nSqlCommand.ExecuteScalar());//ToSingle是转换为浮点类型
            debtMoney.Text = "" + debtMoneyNumber + "" + " Dollars";
            //填写ListView
            FillBorrowingList();
            FillBorrowedList();
        }

        private void user_return_Click(object sender, EventArgs e)//点击返回，修改密码的相关控件均不能使用
        {
            panel1.Enabled = false;
            panel2.Enabled = false;
            alterPsdTex.Clear();//密码为空
            reAlterPsdTex.Clear();//确认修改变为空
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (alterPsdTimer == 1)//密码变为掩码
            {
                alterPsdTex.PasswordChar = '*';
                alterPsdTimer = 2;
            }
            else if (alterPsdTimer == 0)//确认密码变为掩码
            {
                reAlterPsdTex.PasswordChar = '*';
                alterPsdTimer = 2;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            alterPsdTex.PasswordChar = default(char);
            alterPsdTimer = 1;
            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            reAlterPsdTex.PasswordChar = default(char);
            alterPsdTimer = 0;
            timer1.Start();
        }

        private void user_login_Click(object sender, EventArgs e)
        {
            //注意：下面那个要在方法里定义，不能定义成成员变量，否则在方法最后要进行处理恢复至原来的状态
            int alterPsdFlag = 1;//用于判断是否可以修改密码，1表示可以修改，0表示因为密码为空不可以修改
            //进行密码判空操作
            if (!alterPsdTex.Focused && alterPsdTex.Text == "")//判断第一次输入的密码是否为空
            {
                alterPsd_null.Text = "Password Cannot be Empty！";
                alterPsdFlag = 0;//不可修改密码
            }
            //进行确认密码判空操作
            if (!reAlterPsdTex.Focused && reAlterPsdTex.Text == "")//判断第一次输入的密码是否为空
            {
                reALterPsd_null.Text = "Password Cannot be Empty！";
                alterPsdFlag = 0;//不可修改密码
            }
            if (alterPsdTex.Text == reAlterPsdTex.Text && alterPsdFlag == 1)//若输入的密码与新密码相同，且允许修改
            {
                //如果用户选择继续修改
                if (MessageBox.Show("Sure to Change Password？", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)==DialogResult.OK)
                {
                    nSqlCommand.Connection = mSqlConnection;
                    nSqlCommand.CommandText = "update users set user_password = '"+ alterPsdTex.Text +"' where user_name = '"+ userNameLab +"'";
                    nSqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Password Change successfully！");
                }
            }
            else if(alterPsdFlag == 1)//表示密码不为空但是输入不一致
            {
                MessageBox.Show("Passwords do not match！");
                alterPsdFlag = 0;
            }
        }

        private void alterPsdTex_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void reAlterPsdTex_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }
        public void FillBorrowingList()//查询正在借阅的书籍
        {
            lstBorrowingBooks.Items.Clear();//清空数据
            nSqlCommand.Connection = mSqlConnection;
            nSqlCommand.CommandText = "select * from borrowInformation where user_name = '" + userNameLab + "' and returnTime is null";//查询该用户的正在借阅的借书信息
            SqlDataReader sqldr = nSqlCommand.ExecuteReader();//返回的数据集
            while (sqldr.Read())//默认停留在第一条
            {
                ListViewItem lvi = new ListViewItem(sqldr[1].ToString());
                lvi.SubItems.Add(sqldr[2].ToString());
                lvi.SubItems.Add(sqldr[3].ToString());
                //处理借书时间
                DateTime dt1 = Convert.ToDateTime(sqldr[3]);
                DateTime dt2 = System.DateTime.Now;
                TimeSpan ts1 = new TimeSpan(dt1.Ticks);//利用时间间隔
                TimeSpan ts2 = new TimeSpan(dt2.Ticks);
                TimeSpan ts = ts1.Subtract(ts2).Duration();//计算两个日期的差值并求绝对值
                lvi.SubItems.Add(ts.Days.ToString()+" Days "+ts.Hours.ToString()+" Hours "+ts.Minutes.ToString()+" Minutes "+ts.Seconds.ToString()+" Seconds");//差值精确到秒
                lvi.SubItems.Add(sqldr[6].ToString());
                this.lstBorrowingBooks.Items.Add(lvi);
            }
            sqldr.Close();
        }
        public void FillBorrowedList()//查询已借阅的书籍
        {
            lstBorrowedBooks.Items.Clear();//清空数据
            nSqlCommand.Connection = mSqlConnection;
            nSqlCommand.CommandText = "select * from borrowInformation where user_name = '" + userNameLab + "'and returnTime is not null";//查询该用户的所有已经借阅的信息
            SqlDataReader sqldr = nSqlCommand.ExecuteReader();//返回的数据集
            while (sqldr.Read())//默认停留在第一条
            {
                ListViewItem lvi = new ListViewItem(sqldr[1].ToString());
                lvi.SubItems.Add(sqldr[2].ToString());
                lvi.SubItems.Add(sqldr[3].ToString());
                lvi.SubItems.Add(sqldr[4].ToString());
                lvi.SubItems.Add(sqldr[6].ToString());
                this.lstBorrowedBooks.Items.Add(lvi);
            }
            sqldr.Close();
        }
        private void alterPsdTex_TextChanged(object sender, EventArgs e)
        {
            alterPsd_null.Text = "";//输入后，为空提示消失
        }

        private void reAlterPsdTex_TextChanged(object sender, EventArgs e)
        {
            reALterPsd_null.Text = "";//输入后，为空提示消失
        }
        
        private void lstBooks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//点击修改密码，设置修改密码的相关功能可以进行点击
        {
            panel1.Enabled = true;
            panel2.Enabled = true;
        }


        private void alterPsd_null_Click(object sender, EventArgs e)
        {

        }

        private void debtBooksNum_Click(object sender, EventArgs e)
        {

        }

        private void borrowingBooksNum_Click(object sender, EventArgs e)
        {

        }

        private void borrowedBooksLab_Click(object sender, EventArgs e)
        {

        }

        private void debtBooksNumLab_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}

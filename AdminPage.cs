using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    public partial class AdminPage : Form
    {
        string adminNameLab;
        int alterPsdTimer = 2;//用于判断计时时执行哪一个操作，2为默认状态为掩码，1表示新密码恢复，0表示确认新密码恢复
        int enquireUserFlag = 0;//判断是否查询到用户，查询到为1，未查询到为0
        int FillListFlag = 0;//默认情况为书名，0表示书名，1表示作者，2表示出版社，3表示书籍号
        SqlConnection mSqlConnection = new SqlConnection();
        SqlCommand nSqlCommand = new SqlCommand();
        SqlCommand pSqlCommand = new SqlCommand();
        public AdminPage()
        {
            InitializeComponent();
        }
        public AdminPage(string adminName)//用来传递登陆成功的参数
        {
            adminNameLab = adminName;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            panel2.Enabled = true;
        }

        private void user_return_Click(object sender, EventArgs e)
        {
            alterPsdTex.Clear();
            reAlterPsdTex.Clear();
            panel1.Enabled = false;
            panel2.Enabled = false;

        }
        void fillEnquireAllUser()
        {
            lstBorrowedBooks.Items.Clear();//清空数据
            nSqlCommand.Connection = mSqlConnection;
            nSqlCommand.CommandText = "select * from users";//查询所有用户信息
            SqlDataReader sqldr = nSqlCommand.ExecuteReader();//返回的数据集
            while (sqldr.Read())//默认停留在第一条
            {
                ListViewItem lvi = new ListViewItem(sqldr[0].ToString());//用户姓名
                lvi.SubItems.Add(sqldr[3].ToString());
                lvi.SubItems.Add(sqldr[4].ToString());
                lvi.SubItems.Add(sqldr[5].ToString());
                //this.listView1.Items.Add(lvi);
            }
            sqldr.Close();
        }
        private void AdminPage_Load(object sender, EventArgs e)
        {
            //toolStripStatusLabel5.Text = "系统时间：" + Convert.ToString(System.DateTime.Now);
            adminLab.Text = adminNameLab;//管理员用户名写上
            mSqlConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\furui\Documents\libraryBooks.mdf;Integrated Security=True;Connect Timeout=30";
            mSqlConnection.Open();
            //设置未查询到正确的用户前，按钮不可用
            textBox11.Enabled = false;//借书查询文本框不可用
            pictureBox4.Enabled = false;//借书查询按钮不可用
            button3.Enabled = false;//确认借书按钮不可用
            textBox6.Enabled = false;//还书查询按钮不可用
            pictureBox6.Enabled = false;//还书查询按钮不可用
            button5.Enabled = false;//确认还书按钮不可用
            //button7.Enabled = false;//确认删除用户不可用
            button8.Enabled = false;//修改书籍信息不可用
            button4.Enabled = false;//删除书籍不可用
            //填写查询所有用户
            fillEnquireAllUser();
            //查询书籍时默认显示书名
            comboBox1.Text = "ISBN";
            comboBox1.SelectedIndex = 0;
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
                if (MessageBox.Show("Sure to Change Password？", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    nSqlCommand.Connection = mSqlConnection;
                    nSqlCommand.CommandText = "update admin set admin_password = '" + alterPsdTex.Text + "' where admin_name = '" + adminNameLab + "'";
                    nSqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Password changes successfully！");
                }
            }
            else if (alterPsdFlag == 1)//表示密码不为空但是输入不一致
            {
                MessageBox.Show("Passwords do not match！");
                alterPsdFlag = 0;
            }
        }

        private void alterPsdTex_TextChanged(object sender, EventArgs e)
        {
            alterPsd_null.Text = "";//输入后，为空提示消失
        }

        private void reAlterPsdTex_TextChanged(object sender, EventArgs e)
        {
            reALterPsd_null.Text = "";//输入后，为空提示消失
        }


        private void tabControl2_DrawItem(object sender, DrawItemEventArgs e)
        {
            string text = ((TabControl)sender).TabPages[e.Index].Text;

            SolidBrush brush = new SolidBrush(Color.Black);

            StringFormat sf = new StringFormat(StringFormatFlags.DirectionRightToLeft);

            sf.LineAlignment = StringAlignment.Center;

            sf.Alignment = StringAlignment.Center;

            e.Graphics.DrawString(text, SystemInformation.MenuFont, brush, e.Bounds, sf);
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {
           
        }
        public void FillBorrowingList_Admin()//查询正在借阅的书籍
        {
            lstBorrowingBooks.Items.Clear();//清空数据
            nSqlCommand.CommandText = "select * from borrowInformation where user_name = '" + textBox12.Text +"' and returnTime is null";//查询该用户的正在借阅的借书信息
            SqlDataReader sqldr = nSqlCommand.ExecuteReader();//返回的数据集
            while (sqldr.Read())//默认停留在第一条
            {
                ListViewItem lvi = new ListViewItem(sqldr[1].ToString());//书号
                lvi.SubItems.Add(sqldr[2].ToString());//书籍名称
                lvi.SubItems.Add(sqldr[3].ToString());//借书时间
                //处理借书时间
                DateTime dt3 = Convert.ToDateTime(sqldr[3]);
                DateTime dt4 = System.DateTime.Now;
                TimeSpan ts3 = new TimeSpan(dt3.Ticks);//利用时间间隔
                TimeSpan ts4 = new TimeSpan(dt4.Ticks);
                TimeSpan tsm = ts3.Subtract(ts4).Duration();//计算两个日期的差值并求绝对值
                lvi.SubItems.Add(tsm.Days.ToString() + " Days " + tsm.Hours.ToString() + " Hours " + tsm.Minutes.ToString() + " Minutes " + tsm.Seconds.ToString() + " Seconds");//差值精确到秒
                lvi.SubItems.Add(sqldr[6].ToString());//需缴费
                this.lstBorrowingBooks.Items.Add(lvi);
                
            }
            sqldr.Close();
        }
        public void FillBorrowedList_Admin()//查询已借阅的书籍
        {
            lstBorrowedBooks.Items.Clear();//清空数据
            nSqlCommand.Connection = mSqlConnection;
            nSqlCommand.CommandText = "select * from borrowInformation where user_name = '" + textBox12.Text + "'and returnTime is not null";//查询该用户的所有已经借阅的信息
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

        private void button2_Click(object sender, EventArgs e)//进行所有的有效性验证
        {
            int addBooks_flag = 1;//用于判断增加的书籍是否符合，1表示符合，0表示不符合
            if (textBox1.Text == "")//书籍号为空的情况
            {
                label10.Text = "ISBN Cannot be Empty！";
                addBooks_flag = 0;
            }
            nSqlCommand.Connection = mSqlConnection;
            nSqlCommand.CommandText = "select count(*) from books where bookID = '"+ textBox1.Text +"'";
            int i = Convert.ToInt32(nSqlCommand.ExecuteScalar());
            if (i == 1)//书籍名已经存在的情况
            {
                label10.Text = "ISBN Already Existed";
                addBooks_flag = 0;
            }
            if (textBox2.Text == "")//书籍名为空的情况
            {
                label11.Text = "Title Cannot be Empty！";
                addBooks_flag = 0;
            }
            if (textBox3.Text == "")//作者为空的情况
            {
                label12.Text = "Author Cannot be Empty！";
                addBooks_flag = 0;
            }
            if (textBox4.Text == "")//出版社为空的情况
            {
                label13.Text = "Publisher Cannot be Empty！";
                addBooks_flag = 0;
            } 
            if (!radioButton1.Checked && !radioButton2.Checked)//未选是否在架的情况
            {
                label14.Text = "（Necessary）";
                addBooks_flag = 0;
            }
            if (!radioButton3.Checked && !radioButton4.Checked)//未选是否可借情况
            {
                label15.Text = "（Necessary）";
                addBooks_flag = 0;
            }
            if (addBooks_flag == 1)//完全符合增加条件
            {
                if (MessageBox.Show("Sure to Add Books？", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    //处理一下是否在架，是否可借
                    string isOnShelf = "";//在架情况
                    string canBeBorrowed = "";//可借情况
                    if (radioButton1.Checked)//指在架
                    {
                        isOnShelf = "On Shelf";
                    }else if (radioButton2.Checked)//指不在架
                    {
                        isOnShelf = "Not on Shelf";
                    }
                    if (radioButton4.Checked)//指可借
                    {
                        canBeBorrowed = "Can be Borrowed";
                    }else if (radioButton3.Checked)//指不可借
                    {
                        canBeBorrowed = "Cannot be Borrowed";
                    }
                    nSqlCommand.Connection = mSqlConnection;
                    nSqlCommand.CommandText = "insert into books  values ('"+ textBox1.Text +"','"+ textBox2.Text +"','"+ textBox3.Text +"','"+ textBox4.Text +"','"+ isOnShelf +"','"+ canBeBorrowed +"',"+ Convert.ToSingle(textBox7.Text) +",'"+ textBox5.Text +"')";
                    nSqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Books added successfully！");
                    label14.Text = "";
                    label15.Text = "";//两个请选择的提示设置为空
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label10.Text = ""; 
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label11.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label12.Text = "";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label13.Text = "";
        }

        private void radioButton1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            nSqlCommand.Connection = mSqlConnection;
            nSqlCommand.CommandText = "select count(*) from books where bookID = '" + enquireTextBox.Text + "'";
            int i = Convert.ToInt32(nSqlCommand.ExecuteScalar());
            if (i==1)//表示查询到该书
            {
                label18.Text = enquireTextBox.Text;
                nSqlCommand.CommandText = "select bookName from books where bookID = '" + enquireTextBox.Text + "'";//查询书名
                label19.Text = Convert.ToString(nSqlCommand.ExecuteScalar());
                nSqlCommand.CommandText = "select author from books where bookID = '" + enquireTextBox.Text + "'";//作者
                label20.Text = Convert.ToString(nSqlCommand.ExecuteScalar());
                nSqlCommand.CommandText = "select publisher from books where bookID = '" + enquireTextBox.Text + "'";//出版社
                label21.Text = Convert.ToString(nSqlCommand.ExecuteScalar());
                nSqlCommand.CommandText = "select bookMoney from books where bookID = '" + enquireTextBox.Text + "'";//出版社
                label102.Text = Convert.ToString(nSqlCommand.ExecuteScalar())+"元";
                nSqlCommand.CommandText = "select isOnShelf from books where bookID = '" + enquireTextBox.Text + "'";//是否在架
                label22.Text = Convert.ToString(nSqlCommand.ExecuteScalar());
                nSqlCommand.CommandText = "select canBeBorrowed from books where bookID = '" + enquireTextBox.Text + "'";//是否可借
                label23.Text = Convert.ToString(nSqlCommand.ExecuteScalar());
                nSqlCommand.CommandText = "select remarks from books where bookID = '" + enquireTextBox.Text + "'";//备注
                label31.Text = Convert.ToString(nSqlCommand.ExecuteScalar());
                button4.Enabled = true;//删除该书籍按钮可用

            }
            else//未查询到该书
            {
                MessageBox.Show("No Results！", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(label18.Text != ""){//保证已经查询到该书籍
                nSqlCommand.CommandText = "select isOnShelf from books where bookID = '"+ label18.Text + "'";
                if (Convert.ToString(nSqlCommand.ExecuteScalar())=="On Shelf")//保证该书已经归还在架
                {
                    if (MessageBox.Show("Sure to Delete Books？", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        nSqlCommand.Connection = mSqlConnection;//不可以进行删除，因为和借阅信息绑定了
                        nSqlCommand.CommandText = "update books set isOnShelf = 'Not on Shelf',canBeBorrowed = 'Cannot be Borrowed',remarks = 'Books Not in Library' where bookID = '" + label18.Text + "'";
                        nSqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Books Delete Successfully！");
                        enquireTextBox.Text = "";
                        button4.Enabled = false;//删除书籍按钮不可用
                    }
                }
                else
                {
                    MessageBox.Show("Books Cannot be deleted as It is In Use！", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }

            }
            else
            {
                MessageBox.Show("Please Search Books First！", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void tabControl3_DrawItem(object sender, DrawItemEventArgs e)
        {
            string text = ((TabControl)sender).TabPages[e.Index].Text;

            SolidBrush brush = new SolidBrush(Color.Black);

            StringFormat sf = new StringFormat(StringFormatFlags.DirectionRightToLeft);

            sf.LineAlignment = StringAlignment.Center;

            sf.Alignment = StringAlignment.Center;

            e.Graphics.DrawString(text, SystemInformation.MenuFont, brush, e.Bounds, sf);
        }
        void fillUserInformation()//填写用户信息
        {
            label67.Text = textBox12.Text;
            nSqlCommand.Connection = mSqlConnection;
            //正在借阅图书
            nSqlCommand.CommandText = "select count(*) from borrowInformation where user_name = '" + label67.Text + "' and returnTime is null";//返回正在借书个数，有几条不为空的还书数据
            int borrowingBooksNumber = Convert.ToInt32(nSqlCommand.ExecuteScalar());
            borrowingBooksNum.Text = "" + borrowingBooksNumber.ToString() + "" + " Books";
            //已借阅图书
            nSqlCommand.CommandText = "select count(*) from borrowInformation where user_name = '" + label67.Text + "' and returnTime is not null";//返回已经借书个数，还书时间不为空
            int borrowedBooksNumber = Convert.ToInt32(nSqlCommand.ExecuteScalar());
            borrowedBooksNum.Text = "" + borrowedBooksNumber.ToString() + "" + " Books";
            //填写欠费图书
            nSqlCommand.CommandText = "select count(*) from borrowInformation where user_name = '" + label67.Text + "'and bookMoney != 0 and returnTime is null";//返回欠费书籍的个数
            int debtBooksNumber = Convert.ToInt32(nSqlCommand.ExecuteScalar());
            debtBooksNum.Text = "" + debtBooksNumber.ToString() + "" + " Books";
            //填写欠费的钱
            nSqlCommand.CommandText = "select debt from users where user_name = '" + label67.Text + "'";//返回总共的欠款,从用户表里
            string debtMoneyNumber = Convert.ToString(nSqlCommand.ExecuteScalar());//ToSingle是转换为浮点类型
            debtMoney.Text = "" + debtMoneyNumber + "" + " Dollars";
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            nSqlCommand.Connection = mSqlConnection;
            nSqlCommand.CommandText = "select count(*) from users where user_name = '" + textBox12.Text + "'";
            int i = Convert.ToInt32(nSqlCommand.ExecuteScalar());
            if (i == 0)
            {
                MessageBox.Show("User Not Exsit！", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else//查询有结果的情况进行处理
            {
                enquireUserFlag = 1;//设置已经查询到
                pictureBox7.Visible = true;//标志已找到该用户
                //进行更新时间的更改
                DateTime dtNow = System.DateTime.Now;
                nSqlCommand.Connection = mSqlConnection;
                nSqlCommand.CommandText = "update borrowInformation set updateTime =  '"+ dtNow + "' where user_name = '" + textBox12.Text + "' and returnTime is null";
                nSqlCommand.ExecuteNonQuery();
                //进行欠费信息处理
                 nSqlCommand.Connection = mSqlConnection;
                 nSqlCommand.CommandText = "select borrowedBooks from users where user_name = '" + textBox12.Text + "' ";
                 int j = Convert.ToInt32(nSqlCommand.ExecuteScalar());
                 if (j > 0)//指存在借书情况，也就是可能存在欠费情况
                 {
                    //进行每一条借阅信息欠费的处理
                    nSqlCommand.CommandText = "update borrowInformation set BookMoney = (DATEDIFF(DAY,borrowTime ,updateTime)+1-30)*0.1 where user_name = '" + textBox12.Text + "' and returnTime is null and (DATEDIFF(DAY,borrowTime ,updateTime)+1-30)>0";
                    nSqlCommand.ExecuteNonQuery();
                   
                //计算总的欠费信息,先进行该用户是否正在借书数目的判断
                nSqlCommand.CommandText = "select sum(bookMoney) from borrowInformation where user_name = '" + textBox12.Text + "' and returnTime is null";
                float allDebt = Convert.ToSingle(nSqlCommand.ExecuteScalar());
                //修改用户总的欠费信息
                nSqlCommand.CommandText = "update users set debt = " + allDebt + " where user_name = '" + textBox12.Text + "'  ";
                nSqlCommand.ExecuteNonQuery();
                 }
                //刷新填写查询所有用户
                //listView1.Items.Clear();//先清空数据
                fillEnquireAllUser();
                FillBorrowingList_Admin();//正在借阅信息
                FillBorrowedList_Admin();//借书历史信息
                fillUserInformation();//填写用户信息标签页，放在修改欠费的后面
                textBox11.Enabled = true;//借书查询文本框可用
                pictureBox4.Enabled = true;//借书查询按钮可用
                textBox6.Enabled = true;//还书查询文本框可用
                pictureBox6.Enabled = true;//还书查询按钮可用
            }
           

        }

        private void pictureBox4_Click(object sender, EventArgs e)//用户管理中查询该书
        {
            nSqlCommand.Connection = mSqlConnection;
            nSqlCommand.CommandText = "select count(*) from books where bookID = '" + textBox11.Text + "'";
            int i = Convert.ToInt32(nSqlCommand.ExecuteScalar());
            if (i == 1)//表示查询到该书
            {
                label51.Text = textBox11.Text;
                nSqlCommand.CommandText = "select bookName from books where bookID = '" + textBox11.Text + "'";//查询书名
                label50.Text = Convert.ToString(nSqlCommand.ExecuteScalar());
                nSqlCommand.CommandText = "select author from books where bookID = '" + textBox11.Text + "'";//作者
                label49.Text = Convert.ToString(nSqlCommand.ExecuteScalar());
                nSqlCommand.CommandText = "select publisher from books where bookID = '" + textBox11.Text + "'";//出版社
                label48.Text = Convert.ToString(nSqlCommand.ExecuteScalar());
                nSqlCommand.CommandText = "select isOnShelf from books where bookID = '" + textBox11.Text + "'";//是否在架
                label47.Text = Convert.ToString(nSqlCommand.ExecuteScalar());
                nSqlCommand.CommandText = "select canBeBorrowed from books where bookID = '" + textBox11.Text + "'";//是否可借
                label46.Text = Convert.ToString(nSqlCommand.ExecuteScalar());
                nSqlCommand.CommandText = "select remarks from books where bookID = '" + textBox11.Text + "'";//备注
                label45.Text = Convert.ToString(nSqlCommand.ExecuteScalar());
                button3.Enabled = true;//确认借书按钮可用
            }
            else//未查询到该书
            {
                MessageBox.Show("No Results！", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void label57_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int canBeBorrowedFlag = 1;//判断是否该书可借的标志，1表示可借，0表示不可借        
              
                    if (label46.Text == "Cannot be Borrowed")//判断是否可借（不需要判断是否在架，因为书拿过来了）
                    {
                        MessageBox.Show("Books Cannot be Borrowed！", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        canBeBorrowedFlag = 0;
                    }
                    nSqlCommand.Connection = mSqlConnection;
                    nSqlCommand.CommandText = "select debt from users where user_name = '" + textBox12.Text + "'";//查询欠费情况
                    float debtMoney = Convert.ToSingle(nSqlCommand.ExecuteScalar());
                    if (debtMoney != 0.00)//判断是否存在欠费情况
                    {
                        MessageBox.Show("The user has arrears and cannot borrow any more！", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        canBeBorrowedFlag = 0;
                    }
                    nSqlCommand.CommandText = "select canborrowBooks from users where user_name = '" + textBox12.Text + "'";//查询借书情况
                    int canBorrowsBooksNum = Convert.ToInt32(nSqlCommand.ExecuteScalar());
                    if (canBorrowsBooksNum == 0)//判断是否已经借了15本书
                    {
                        MessageBox.Show("The user has borrowed 15 books and cannot borrow any more！", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        canBeBorrowedFlag = 0;
                    }
                    if (canBeBorrowedFlag == 1)//表示可以继续借书
                    {
                        if (MessageBox.Show("Sure to Borrow？", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                        {
                            nSqlCommand.Connection = mSqlConnection;
                            //借阅信息表中加入该用户的借书信息
                            DateTime dt = System.DateTime.Now;
                            nSqlCommand.CommandText = "insert into borrowInformation (user_name,bookID,bookName,borrowTime) values ('" + textBox12.Text + "','" + label51.Text + "','" + label50.Text + "','" + dt.ToString() + "')";
                            nSqlCommand.ExecuteNonQuery();
                            MessageBox.Show("Books Borrowed Successfully！");
                            //书籍信息表中该书籍变为不在架， 不可借
                            nSqlCommand.Connection = mSqlConnection;
                            nSqlCommand.CommandText = "update books set isOnShelf = 'Not on Shelf', canBeBorrowed = 'Cannot be Borrowed'  where bookID = '"+ label51.Text +"'";
                            nSqlCommand.ExecuteNonQuery();
                            textBox11.Text = "";
                    nSqlCommand.Connection = mSqlConnection;
                    nSqlCommand.CommandText = "select canborrowBooks from users where user_name = '" + textBox12.Text + "'";//找到该用户的可借书籍
                    int i = Convert.ToInt32(nSqlCommand.ExecuteScalar());
                    nSqlCommand.CommandText = "update users set canborrowBooks = " + (i-1) + " where user_name = '" + textBox12.Text + "'";//该用户可借书籍数减一
                    nSqlCommand.ExecuteNonQuery();
                    nSqlCommand.CommandText = "select borrowedBooks from users where user_name = '" + textBox12.Text + "'";//找到该用户的已借书籍数
                    int j = Convert.ToInt32(nSqlCommand.ExecuteScalar());
                    nSqlCommand.CommandText = "update users set borrowedBooks = " + (j+1) + " where user_name = '" + textBox12.Text + "'";//该用户已借书籍数加一
                    nSqlCommand.ExecuteNonQuery();
                    nSqlCommand.CommandText = "select allBorrowedBooks from users where user_name = '" + textBox12.Text + "'";//找到该用户的所有借阅书籍数
                    int k = Convert.ToInt32(nSqlCommand.ExecuteScalar());
                    nSqlCommand.CommandText = "update users set allBorrowedBooks = " + (k + 1) + " where user_name = '" + textBox12.Text + "'";//该用户所有已借书籍数加一
                    nSqlCommand.ExecuteNonQuery();
                    button3.Enabled = false;//确认借书按钮不可用
                        }
                    }
        }


        private void button5_Click_1(object sender, EventArgs e)//确认还书按钮
        {
            if (MessageBox.Show("Sure to Return Books？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                //保存缴费信息，不应该清零,总债务减去已经缴费的钱
                nSqlCommand.Connection = mSqlConnection;
                nSqlCommand.CommandText = "select debt from users where user_name = '" + label33.Text + "'";//得到总的欠款
                float allDebt = Convert.ToSingle(nSqlCommand.ExecuteScalar());
                nSqlCommand.CommandText = "select BookMoney from borrowInformation where bookID = '" + label38.Text + "' and returnTime is null";//得到已缴费书的欠款
                float aBookDebt = Convert.ToSingle(nSqlCommand.ExecuteScalar());
                nSqlCommand.CommandText = "update users set debt =  " + (allDebt - aBookDebt) + " where user_name = '" + label33.Text + "'";//更新总欠款
                nSqlCommand.ExecuteNonQuery();
                label63.Text = "0 Dollar";
                button5.Enabled = true;//缴费并确认还书按钮可用
                nSqlCommand.Connection = mSqlConnection;
                //借阅信息表中加入该用户的还书信息
                DateTime dt = System.DateTime.Now;
                nSqlCommand.CommandText = "update borrowInformation set returnTime = '" + dt.ToString() + "' where bookID = '" + label38.Text +"' and user_name = '"+ label33.Text +"' and returnTime is null";
                nSqlCommand.ExecuteNonQuery();
                MessageBox.Show("Books Returned Successfully！");
                //书籍信息表中该书籍变为不在架， 不可借
                nSqlCommand.Connection = mSqlConnection;
                nSqlCommand.CommandText = "update books set isOnShelf = 'On Shelf', canBeBorrowed = 'Can be Borrowed'  where bookID = '" + label38.Text + "'";
                nSqlCommand.ExecuteNonQuery();
                textBox6.Text = "";
                //用户可借书籍加一
                nSqlCommand.Connection = mSqlConnection;
                nSqlCommand.CommandText = "select canborrowBooks from users where user_name = '"+ label33.Text +"'";//找到该用户的可借书籍
                int i = Convert.ToInt32(nSqlCommand.ExecuteScalar());
                nSqlCommand.CommandText = "update users set canborrowBooks = "+ (i+1) + " where user_name = '" + label33.Text + "'";//该用户可借书籍数加一
                nSqlCommand.ExecuteNonQuery();
                nSqlCommand.CommandText = "select borrowedBooks from users where user_name = '" + label33.Text + "'";//找到该用户的已借书籍数
                int j = Convert.ToInt32(nSqlCommand.ExecuteScalar());
                nSqlCommand.CommandText = "update users set borrowedBooks = "+ (j-1) +" where user_name = '" + label33.Text + "'";//该用户已借书籍数减一
                nSqlCommand.ExecuteNonQuery();
                nSqlCommand.CommandText = "update users set debt = 0.00 where user_name = '" + label33.Text + "'";//该用户欠款清零
                nSqlCommand.ExecuteNonQuery();
                //除书籍污损极其严重或丢失外，其他情况只需缴费即可，未做其他任何处理
                /*nSqlCommand.CommandText = "select remarks from borrowInformation where bookID = '" + label38.Text + "' and returnTime is null";//备注信息
                if (radioButton5.Checked)//指书籍完好
                {
                    Select 
                }else if (radioButton6.Checked)//指一级污损
                {

                }
                else if (radioButton7.Checked)//指二级污损                
                {

                }else if (radioButton8.Checked)//指三级污损
                {

                }else */
                if (radioButton9.Checked)//指污损极其严重
                {
                    nSqlCommand.CommandText = "update books set canBeBorrowed = 'Cannot be Borrowed',remarks = 'Cannot be Borrowed' where bookID = '" + label38.Text + "' ";//更新不可借及备注信息
                    nSqlCommand.ExecuteNonQuery();
                }else if (radioButton10.Checked)//指书籍丢失
                {
                    nSqlCommand.CommandText = "update books set isOnShelf = 'Not on Shelf',canBeBorrowed = 'Cannot be Borrowed',remarks = 'Books are Lost' where bookID = '" + label38.Text + "' ";//更新不可借及备注信息
                    nSqlCommand.ExecuteNonQuery();
                }

                button5.Enabled = false;//确认还书按钮不可用
            }


        }

        private void pictureBox6_Click(object sender, EventArgs e)//还书查询
        {
            nSqlCommand.Connection = mSqlConnection;
            nSqlCommand.CommandText = "select count(*) from books where bookID = '" + textBox6.Text + "'";
            int i = Convert.ToInt32(nSqlCommand.ExecuteScalar());
            if (i == 1)//表示查询到该书
            {
                label38.Text = textBox6.Text;
                nSqlCommand.CommandText = "select bookName from books where bookID = '" + textBox6.Text + "'";//查询书名
                label37.Text = Convert.ToString(nSqlCommand.ExecuteScalar());
                nSqlCommand.CommandText = "select author from books where bookID = '" + textBox6.Text + "'";//作者
                label36.Text = Convert.ToString(nSqlCommand.ExecuteScalar());
                nSqlCommand.CommandText = "select publisher from books where bookID = '" + textBox6.Text + "'";//出版社
                label35.Text = Convert.ToString(nSqlCommand.ExecuteScalar());
                nSqlCommand.CommandText = "select user_name from borrowInformation where bookID = '" + textBox6.Text + "'and returnTime is null and user_name = '"+ textBox12.Text +"'";//判断借阅用户
                label33.Text = Convert.ToString(nSqlCommand.ExecuteScalar());
                if (label33.Text != "")//判断排除借阅用户为空或之前借阅过但现在并没有借阅的情况
                {
                        nSqlCommand.CommandText = "select borrowTime from borrowInformation where bookID = '" + textBox6.Text + "' and returnTime is null";//借阅时间
                        label39.Text = Convert.ToString(nSqlCommand.ExecuteScalar());
                        //判借已借天数
                        DateTime dt1 = Convert.ToDateTime(nSqlCommand.ExecuteScalar());
                        DateTime dt2 = System.DateTime.Now;
                        TimeSpan ts1 = new TimeSpan(dt1.Ticks);//利用时间间隔
                        TimeSpan ts2 = new TimeSpan(dt2.Ticks);
                        TimeSpan ts = ts1.Subtract(ts2).Duration();//计算两个日期的差值并求绝对值
                        label32.Text = (ts.Days + 1).ToString() + " Days";
                        nSqlCommand.CommandText = "select BookMoney from borrowInformation where bookID = '" + textBox6.Text + "' and returnTime is null";//判断是否需要缴费
                        label63.Text = Convert.ToString(nSqlCommand.ExecuteScalar()) + " Dollar";
                        button5.Enabled = true;//找到正确的书后还书按钮可用
                }
                else//只要借阅人为空，剩下的借阅时间，已借天数，需缴费都要为空
                {
                    label39.Text = "";
                    label32.Text = "";
                    label63.Text = "";
                }
               

            }
            else//未查询到该书
            {
                MessageBox.Show("Books not Found！", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void lstBorrowingBooks_Click(object sender, EventArgs e)
        {
            
        }

        private void lstBorrowedBooks_Click(object sender, EventArgs e)
        {
            
        }

        private void tabControl3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            pictureBox7.Visible = false;//用户名发生改变，对勾消失
            button5.Enabled = false;//确认还书按钮不可用
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void tabControl3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            nSqlCommand.Connection = mSqlConnection;
            nSqlCommand.CommandText = "select count(*) from users where user_name = '" + textBox12.Text + "'";
            int i = Convert.ToInt32(nSqlCommand.ExecuteScalar());
            if (i == 0)
            {
                MessageBox.Show("User Not Found！", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else//查询有结果的情况进行处理
            {
                enquireUserFlag = 1;//设置已经查询到
                pictureBox7.Visible = true;//标志已找到该用户
                //进行更新时间的更改
                DateTime dtNow = System.DateTime.Now;
                nSqlCommand.Connection = mSqlConnection;
                nSqlCommand.CommandText = "update borrowInformation set updateTime =  '" + dtNow + "' where user_name = '" + textBox12.Text + "' and returnTime is null";
                nSqlCommand.ExecuteNonQuery();
                //进行欠费信息处理
                nSqlCommand.Connection = mSqlConnection;
                nSqlCommand.CommandText = "select borrowedBooks from users where user_name = '" + textBox12.Text + "' ";
                int j = Convert.ToInt32(nSqlCommand.ExecuteScalar());
                if (j > 0)//指存在借书情况，也就是可能存在欠费情况
                {
                    //进行每一条借阅信息欠费的处理
                    nSqlCommand.CommandText = "update borrowInformation set BookMoney = (DATEDIFF(DAY,borrowTime ,updateTime)+1-30)*0.1 where user_name = '" + textBox12.Text + "' and returnTime is null and (DATEDIFF(DAY,borrowTime ,updateTime)+1-30)>0";
                    nSqlCommand.ExecuteNonQuery();

                    //计算总的欠费信息,先进行该用户是否正在借书数目的判断
                    nSqlCommand.CommandText = "select sum(bookMoney) from borrowInformation where user_name = '" + textBox12.Text + "' and returnTime is null ";
                    float allDebt = Convert.ToSingle(nSqlCommand.ExecuteScalar());
                    //修改用户总的欠费信息
                    nSqlCommand.CommandText = "update users set debt = " + allDebt + " where user_name = '" + textBox12.Text + "'  ";
                    nSqlCommand.ExecuteNonQuery();
                }
                //刷新填写查询所有用户
                //listView1.Items.Clear();//先清空数据
                fillEnquireAllUser();
                FillBorrowingList_Admin();//正在借阅信息
                FillBorrowedList_Admin();//借书历史信息
                fillUserInformation();//填写用户信息标签页，放在修改欠费的后面
                textBox11.Enabled = true;//借书查询文本框可用
                pictureBox4.Enabled = true;//借书查询按钮可用
                textBox6.Enabled = true;//还书查询文本框可用
                pictureBox6.Enabled = true;//还书查询按钮可用
            }
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

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            label69.Text = "";
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)//只能输入数字和小数点
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 46 && ((TextBox)sender).Text.IndexOf(".") >= 0) e.Handled = true;
        }

        private void tabControl4_DrawItem(object sender, DrawItemEventArgs e)
        {
            string text = ((TabControl)sender).TabPages[e.Index].Text;

            SolidBrush brush = new SolidBrush(Color.Black);

            StringFormat sf = new StringFormat(StringFormatFlags.DirectionRightToLeft);

            sf.LineAlignment = StringAlignment.Center;

            sf.Alignment = StringAlignment.Center;

            e.Graphics.DrawString(text, SystemInformation.MenuFont, brush, e.Bounds, sf);
        }

        /*
        private void button6_Click(object sender, EventArgs e)
        {
            int addUserFlag = 1;//判断是否可以增加用户，0表示不可以增加，1表示可以增加
            if (RegisterName.Text == "")//判断是否为空
            {
                register_name_null.Text = "用户名不能为空！";
                addUserFlag = 0;
            }
                nSqlCommand.Connection = mSqlConnection;//注意要先连接数据库
                nSqlCommand.CommandText = "select count(*) from users where user_name = '" + RegisterName.Text + "'";//用户的用户名查询语句
                int i = Convert.ToInt32(nSqlCommand.ExecuteScalar());//判断数据库中是否存在用户的名字
                if (i == 1)
                {
                    register_name_null.Text = "该用户名已存在！";
                addUserFlag = 0;
                    RegisterName.SelectAll();
                    RegisterName.Focus();//用户名变为选中状态
                }
            if (addUserFlag == 1)//表示可以增加用户
            {
                nSqlCommand.Connection = mSqlConnection;
                nSqlCommand.CommandText = "insert into users (user_name) values ('"+ RegisterName.Text + "')"; //新增用户
                nSqlCommand.ExecuteNonQuery();
                MessageBox.Show("用户增加成功！");
                //刷新填写查询所有用户
                listView1.Items.Clear();//先清空数据
                fillEnquireAllUser();
            }
        }
        */

        private void RegisterName_TextChanged(object sender, EventArgs e)
        {
            //register_name_null.Text = "";
        }

        private void label72_Click(object sender, EventArgs e)
        {

        }

        private void tabPage13_Click(object sender, EventArgs e)
        {

        }

        private void tabPage14_Click(object sender, EventArgs e)
        {

        }

        /*
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            nSqlCommand.Connection = mSqlConnection;
            nSqlCommand.CommandText = "select count(*) from users where user_name = '" + textBox8.Text + "'";
            int i = Convert.ToInt32(nSqlCommand.ExecuteScalar());
            if (i == 0)
            {
                MessageBox.Show("无该用户！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else//查询有结果的情况进行处理，显示信息
            {
                label76.Text = textBox8.Text;
                nSqlCommand.Connection = mSqlConnection;
                //正在借阅图书
                nSqlCommand.CommandText = "select count(*) from borrowInformation where user_name = '" + label76.Text + "' and returnTime is null";//返回正在借书个数，有几条不为空的还书数据
                int borrowingBooksNumber = Convert.ToInt32(nSqlCommand.ExecuteScalar());
                label84.Text = "" + borrowingBooksNumber.ToString() + "" + "本";
                //已借阅图书
                nSqlCommand.CommandText = "select count(*) from borrowInformation where user_name = '" + label76.Text + "' and returnTime is not null";//返回已经借书个数，还书时间不为空
                int borrowedBooksNumber = Convert.ToInt32(nSqlCommand.ExecuteScalar());
                label82.Text = "" + borrowedBooksNumber.ToString() + "" + "本";
                //填写欠费图书
                nSqlCommand.CommandText = "select count(*) from borrowInformation where user_name = '" + label76.Text + "'and bookMoney != 0 and returnTime is null";//返回欠费书籍的个数
                int debtBooksNumber = Convert.ToInt32(nSqlCommand.ExecuteScalar());
                label80.Text = "" + debtBooksNumber.ToString() + "" + "本";
                //填写欠费的钱
                nSqlCommand.CommandText = "select debt from users where user_name = '" + label76.Text + "'";//返回总共的欠款,从用户表里
                string debtMoneyNumber = Convert.ToString(nSqlCommand.ExecuteScalar());//ToSingle是转换为浮点类型
                label78.Text = "" + debtMoneyNumber + "" + "元";
                button7.Enabled = true;//确认删除用户可用
            }
        }



        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除该用户？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                nSqlCommand.Connection = mSqlConnection;
                nSqlCommand.CommandText = "delete from borrowInformation where user_name = '" + label76.Text + "'";//借阅信息删除该用户信息
                nSqlCommand.ExecuteNonQuery();
                nSqlCommand.CommandText = "delete from users where user_name = '" + label76.Text + "'";//用户表删除该用户信息
                nSqlCommand.ExecuteNonQuery();
                MessageBox.Show("用户删除成功！");
                textBox8.Text = "";
                //刷新填写查询所有用户
                listView1.Items.Clear();//先清空数据
                fillEnquireAllUser();
            }
        }
        */

        public void FillBookList()//填写书籍查询信息
        {
            lstBooks.Items.Clear();//清空数据
            nSqlCommand.Connection = mSqlConnection;
            if (FillListFlag == 0)
            {
                nSqlCommand.CommandText = "select * from books where bookName like '%" + textBox9.Text + "%'";//书名的模糊查询
            }
            else if (FillListFlag == 1)
            {
                nSqlCommand.CommandText = "select * from books where author like '%" + textBox9.Text + "%'";//作者的模糊查询
            }
            else if (FillListFlag == 2)
            {
                nSqlCommand.CommandText = "select * from books where publisher like '%" + textBox9.Text + "%'";//出版社的模糊查询
            }else if (FillListFlag == 3)
            {
                nSqlCommand.CommandText = "select * from books where bookID = '"+ textBox9.Text + "'";//书籍号的精确查询
            }

            SqlDataReader sqldr = nSqlCommand.ExecuteReader();//返回的数据集
            while (sqldr.Read())//默认停留在第一条
            {
                ListViewItem lvi = new ListViewItem(sqldr[0].ToString());
                lvi.SubItems.Add(sqldr[1].ToString());
                lvi.SubItems.Add(sqldr[2].ToString());
                lvi.SubItems.Add(sqldr[3].ToString());
                lvi.SubItems.Add(sqldr[4].ToString());
                lvi.SubItems.Add(sqldr[5].ToString());
                lvi.SubItems.Add(sqldr[6].ToString());
                this.lstBooks.Items.Add(lvi);
            }
            sqldr.Close();
            if (lstBooks.Items.Count == 0)//判断查询是否有结果
            {
                MessageBox.Show("No Results！", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }
        private void pictureBox9_Click(object sender, EventArgs e)//填写书籍信息
        {
            if (comboBox1.SelectedItem.Equals("Title"))
            {
                FillListFlag = 0;
                FillBookList();
            }
            else if (comboBox1.SelectedItem.Equals("Author"))
            {
                FillListFlag = 1;
                FillBookList();
            }
            else if (comboBox1.SelectedItem.Equals("Publisher"))
            {
                FillListFlag = 2;
                FillBookList();
            }
            else if (comboBox1.SelectedItem.Equals("ISBN"))
            {
                FillListFlag = 3;
                FillBookList();
            }
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            nSqlCommand.Connection = mSqlConnection;
            nSqlCommand.CommandText = "select count(*) from books where bookID = '" + textBox18.Text + "'";
            int i = Convert.ToInt32(nSqlCommand.ExecuteScalar());
            if (i == 1)//表示查询到该书
            {
                textBox17.Text = textBox18.Text;
                nSqlCommand.CommandText = "select bookName from books where bookID = '" + textBox18.Text + "'";//查询书名
                textBox16.Text = Convert.ToString(nSqlCommand.ExecuteScalar());
                nSqlCommand.CommandText = "select author from books where bookID = '" + textBox18.Text + "'";//作者
                textBox15.Text = Convert.ToString(nSqlCommand.ExecuteScalar());
                nSqlCommand.CommandText = "select publisher from books where bookID = '" + textBox18.Text + "'";//出版社
                textBox14.Text = Convert.ToString(nSqlCommand.ExecuteScalar());
                nSqlCommand.CommandText = "select bookMoney from books where bookID = '" + textBox18.Text + "'";//定价
                textBox10.Text = Convert.ToString(nSqlCommand.ExecuteScalar());
                nSqlCommand.CommandText = "select isOnShelf from books where bookID = '" + textBox18.Text + "'";//是否在架
                if (Convert.ToString(nSqlCommand.ExecuteScalar()) == "On Shelf")
                {
                    radioButton14.Checked = true;//在架被选中
                }
                else if (Convert.ToString(nSqlCommand.ExecuteScalar()) == "Not On Shelf")
                {
                    radioButton13.Checked = true;//在架被选中
                }
                nSqlCommand.CommandText = "select canBeBorrowed from books where bookID = '" + textBox18.Text + "'";//是否可借
                if (Convert.ToString(nSqlCommand.ExecuteScalar()) == "Can be Borrowed")
                {
                    radioButton12.Checked = true;//可借被选中
                }
                else if (Convert.ToString(nSqlCommand.ExecuteScalar()) == "Cannot be Borrowed")
                {
                    radioButton11.Checked = true;//不可借被选中
                }
                nSqlCommand.CommandText = "select remarks from books where bookID = '" + textBox18.Text + "'";//备注
                textBox13.Text = Convert.ToString(nSqlCommand.ExecuteScalar());
                button8.Enabled = true;//查询到书籍，可以进行修改

            }
            else//未查询到该书
            {
                MessageBox.Show("No Results！", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            int addBooks_flag = 1;//用于判断增加的书籍是否符合，1表示符合，0表示不符合
            if (textBox17.Text == "")//书籍号为空的情况
            {
                label93.Text = "ISBN Cannot be Empty！";
                addBooks_flag = 0;
            }
            nSqlCommand.Connection = mSqlConnection;
            nSqlCommand.CommandText = "select count(*) from books where bookID = '" + textBox17.Text + "'";
            int i = Convert.ToInt32(nSqlCommand.ExecuteScalar());
            if (i == 1 && textBox18.Text != textBox17.Text)//书籍名已经存在的情况（并排除未发生改变的情况）
            {
                label93.Text = "ISBN Already Exist";
                addBooks_flag = 0;
            }
            if (textBox16.Text == "")//书籍名为空的情况
            {
                label92.Text = "Title Cannot be Empt！";
                addBooks_flag = 0;
            }
            if (textBox15.Text == "")//作者为空的情况
            {
                label91.Text = "Author Cannot be Empt！";
                addBooks_flag = 0;
            }
            if (textBox14.Text == "")//出版社为空的情况
            {
                label90.Text = "Publisher Cannot be Empt！";
                addBooks_flag = 0;
            }
            if (!radioButton13.Checked && !radioButton14.Checked)//未选是否在架的情况
            {
                label89.Text = "（Necessary）";
                addBooks_flag = 0;
            }
            if (!radioButton12.Checked && !radioButton11.Checked)//未选是否可借情况
            {
                label88.Text = "（Necessary）";
                addBooks_flag = 0;
            }
            if (addBooks_flag == 1)//完全符合增加条件
            {
                if (MessageBox.Show("Sure to Change？", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    //处理一下是否在架，是否可借
                    string isOnShelf = "";//在架情况
                    string canBeBorrowed = "";//可借情况
                    if (radioButton14.Checked)//指在架
                    {
                        isOnShelf = "On Shelf";
                    }
                    else if (radioButton13.Checked)//指不在架
                    {
                        isOnShelf = "Not On Shelf";
                    }
                    if (radioButton12.Checked)//指可借
                    {
                        canBeBorrowed = "Can be Borrowed";
                    }
                    else if (radioButton11.Checked)//指不可借
                    {
                        canBeBorrowed = "Cannot be Borrowed";
                    }
                    nSqlCommand.Connection = mSqlConnection;
                    nSqlCommand.CommandText = "update books  set bookID = '" + textBox17.Text + "',bookName = '" + textBox16.Text + "'," +
                        "author = '" + textBox15.Text + "',publisher = '" + textBox14.Text + "',isOnShelf = '" + isOnShelf + "'," +
                        "canBeBorrowed = '" + canBeBorrowed + "',bookMoney = " + Convert.ToSingle(textBox10.Text) + ",remarks = '" + 
                        textBox13.Text + "' where bookID = '"+ textBox18.Text +"'";
                    nSqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Books Changed Successfully！");
                    button8.Enabled = false;//确认修改书籍信息按钮不可用
                    label89.Text = "";
                    label88.Text = "";//两个请选择的提示设置为空
                    textBox18.Text = "";//所有数据全部清空
                    textBox17.Text = "";
                    textBox16.Text = "";
                    textBox15.Text = "";
                    textBox14.Text = "";
                    textBox13.Text = "";
                    textBox10.Text = "";
                }
            }
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            label93.Text = "";//书籍号提示清空
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            label92.Text = "";//书籍号提示清空
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            label91.Text = "";//书籍号提示清空
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            label90.Text = "";//书籍号提示清空
        }

        private void label86_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            label86.Text = "";//书籍号提示清空
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)//只能输入数字和小数点
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 46 && ((TextBox)sender).Text.IndexOf(".") >= 0) e.Handled = true;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            button5.Enabled = false;//确认还书按钮不可用
        }

        private void alterPsdTex_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
   
}

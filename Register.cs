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
    public partial class Register : Form
    {
        int registerTimer = 2;//用于判断计时时执行哪一个操作，2为默认状态为掩码，1表示密码恢复，0表示确认密码恢复
        SqlConnection mSqlConnection = new SqlConnection();//用于连接数据库
        SqlCommand userSqlCommand = new SqlCommand();//用于用户命令语句
        SqlCommand adminSqlCommand = new SqlCommand();//用于管理员命令语句
        public Register()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void RegisterName_TextChanged(object sender, EventArgs e)
        {
            register_name_null.Text = "";//一旦输入，用户名为空提示消失
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel5.Text = "系统时间：" + Convert.ToString(System.DateTime.Now);
            mSqlConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\furui\Documents\libraryBooks.mdf;Integrated Security=True;Connect Timeout=30";
            mSqlConnection.Open();
        }

        private void Form2_MouseClick(object sender, MouseEventArgs e)//点击Form2别的地方进行用户名的有效性验证
        {
            if (!RegisterName.Focused && RegisterName.Text == "")//判断是否为空
            {
                register_name_null.Text = "Name Cannot be Empty！";
            }
            if (userRadioButton.Checked)//注册用户
            {
                userSqlCommand.Connection = mSqlConnection;//注意要先连接数据库
                userSqlCommand.CommandText = "select count(*) from users where user_name = '" + RegisterName.Text + "'";//用户的用户名查询语句
                int i = Convert.ToInt32(userSqlCommand.ExecuteScalar());//判断数据库中是否存在用户的名字
                if (i == 1)
                {
                    register_name_null.Text = "Name Already Exist！";
                    RegisterName.SelectAll();
                    RegisterName.Focus();//用户名变为选中状态
                }
            }
            if (adminRadioButton.Checked)//注册管理员
            {
                adminSqlCommand.Connection = mSqlConnection;//连接数据库
                adminSqlCommand.CommandText = "select count(*) from admin where admin_name = '" + RegisterName.Text + "'";//管理员的用户名查询语句
                int j = Convert.ToInt32(adminSqlCommand.ExecuteScalar());//判断数据库中是否已经存在管理员的名字
                if (j == 1)
                {
                    register_name_null.Text = "Name Already Exist！";
                    RegisterName.SelectAll();
                    RegisterName.Focus();//用户名变为选中状态
                }
            }
        }

        private void registerPassword_MouseClick(object sender, MouseEventArgs e)
        {
            int register_flag = 1;//用于判断注册的用户名是否符合，1表示符合，0表示不符合
            if (!RegisterName.Focused && RegisterName.Text == "")//点击密码框进行用户名的有效性验证
            {
                register_name_null.Text = "Name Cannot be Empty！";
            }
            if (userRadioButton.Checked)//注册用户
            {
                userSqlCommand.Connection = mSqlConnection;//注意要先连接数据库
                userSqlCommand.CommandText = "select count(*) from users where user_name = '" + RegisterName.Text + "'";//用户的用户名查询语句
                int i = Convert.ToInt32(userSqlCommand.ExecuteScalar());//判断数据库中是否存在
                if (i == 1)
                {
                    register_name_null.Text = "Name Already Exist！";
                    RegisterName.SelectAll();
                    RegisterName.Focus();//用户名变为选中状态
                }
            }
            if (adminRadioButton.Checked)//注册管理员
            {
                adminSqlCommand.Connection = mSqlConnection;//连接数据库
                adminSqlCommand.CommandText = "select count(*) from admin where admin_name = '" + RegisterName.Text + "'";//管理员的用户名查询语句
                int j = Convert.ToInt32(adminSqlCommand.ExecuteScalar());//判断数据库中是否已经存在管理员的名字
                if (j == 1)
                {
                    register_name_null.Text = "Name Already Exist！";
                    RegisterName.SelectAll();
                    RegisterName.Focus();//用户名变为选中状态
                }
            }
        }

        private void reRegisterPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (!RegisterName.Focused && RegisterName.Text == "")//点击确认密码进行用户名的有效性验证
            {
                register_name_null.Text = "Name Cannot be Empty！";
            }
            if (userRadioButton.Checked)//注册用户
            {
                userSqlCommand.Connection = mSqlConnection;//注意要先连接数据库
                userSqlCommand.CommandText = "select count(*) from users where user_name = '" + RegisterName.Text + "'";//用户的用户名查询语句
                int i = Convert.ToInt32(userSqlCommand.ExecuteScalar());//判断数据库中是否存在
                if (i == 1)
                {
                    register_name_null.Text = "Name Already Exist！";
                    RegisterName.SelectAll();
                    RegisterName.Focus();//用户名变为选中状态
                }
            }
            if (adminRadioButton.Checked)//注册管理员
            {
                adminSqlCommand.Connection = mSqlConnection;//连接数据库
                adminSqlCommand.CommandText = "select count(*) from admin where admin_name = '" + RegisterName.Text + "'";//管理员的用户名查询语句
                int j = Convert.ToInt32(adminSqlCommand.ExecuteScalar());//判断数据库中是否已经存在管理员的名字
                if (j == 1)
                {
                    register_name_null.Text = "Name Already Exist！";
                    RegisterName.SelectAll();
                    RegisterName.Focus();//用户名变为选中状态
                }
            }
            if (!registerPassword.Focused && registerPassword.Text == "")//判断第一次输入的密码是否为空
            {
                register_password_null.Text = "Password Cannot be Empty！";
            }
            
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!RegisterName.Focused && RegisterName.Text == "")//点击电话号码进行用户名的有效性验证
            {
                register_name_null.Text = "Name Cannot be Empty！";
            }
            if (userRadioButton.Checked)//注册用户
            {
                userSqlCommand.Connection = mSqlConnection;//注意要先连接数据库
                userSqlCommand.CommandText = "select count(*) from users where user_name = '" + RegisterName.Text + "'";//用户的用户名查询语句
                int i = Convert.ToInt32(userSqlCommand.ExecuteScalar());//判断数据库中是否存在
                if (i == 1)
                {
                    register_name_null.Text = "Name Already Exist！";
                    RegisterName.SelectAll();
                    RegisterName.Focus();//用户名变为选中状态
                }
            }
            if (adminRadioButton.Checked)//注册管理员
            {
                adminSqlCommand.Connection = mSqlConnection;//连接数据库
                adminSqlCommand.CommandText = "select count(*) from admin where admin_name = '" + RegisterName.Text + "'";//管理员的用户名查询语句
                int j = Convert.ToInt32(adminSqlCommand.ExecuteScalar());//判断数据库中是否已经存在管理员的名字
                if (j == 1)
                {
                    register_name_null.Text = "Name Already Exist！";
                    RegisterName.SelectAll();
                    RegisterName.Focus();//用户名变为选中状态
                }
            }
            if (!registerPassword.Focused && registerPassword.Text == "")//判断第一次输入的密码是否为空
            {
                register_password_null.Text = "Password Cannot be Empty！";
            }
            if (!reRegisterPassword.Focused && reRegisterPassword.Text == "")//判断第二次密码是否为空
            {
                re_register_password_null.Text = "Please Confirm Password！";
            }
        }

        private void registerPassword_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void registerPassword_TextChanged(object sender, EventArgs e)
        {
            register_password_null.Text = "";
        }

        private void reRegisterPassword_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void userRegisterButton_Click(object sender, EventArgs e)
        {
            int register_flag = 1;//用于判断注册的用户名是否符合，1表示符合，0表示不符合
            //判断两次输入的密码是否一致
            if (registerPassword.Text!=reRegisterPassword.Text)
            {
                register_flag = 0;//标志不可通过注册
                MessageBox.Show("Passwords do not match！","Warning",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
            if (!registerPassword.Focused && registerPassword.Text == "")//判断第一次输入的密码是否为空
            {
                register_password_null.Text = "Password Cannot be Empty！";
                register_flag = 0;//标志不可通过注册
            }
            if (!reRegisterPassword.Focused && reRegisterPassword.Text == "")//判断第二次密码是否为空
            {
                re_register_password_null.Text = "Please Confirm Password！";
                register_flag = 0;//标志不可通过注册
            }
            if (register_flag==1)//表示注册符合标准，可以向数据库传送
            {
                if (userRadioButton.Checked)//用户注册传送
                {
                    userSqlCommand.Connection = mSqlConnection;//注意要先连接数据库
                    //创建用户表中的数据
                    userSqlCommand.CommandText = "insert into users (user_name,user_password) values ('" + RegisterName.Text + "','"+registerPassword.Text+"')";//用户插入
                    userSqlCommand.ExecuteNonQuery();
                    MessageBox.Show("User Resgisters Successfully！");
                    this.Close();//注册窗口关闭
                }
                else if (adminRadioButton.Checked)//管理员注册数据传送
                {
                    adminSqlCommand.Connection = mSqlConnection;//注意要先连接数据库
                    adminSqlCommand.CommandText = "insert into admin (admin_name,admin_password) values ('" + RegisterName.Text + "','" + registerPassword.Text + "')";//管理员插入
                    adminSqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Librarian Resgisters Successfully！");
                    this.Close();//注册窗口关闭
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)//密码
        {
            
            registerPassword.PasswordChar = default(char);
            registerTimer = 1;
            timer1.Start();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            reRegisterPassword.PasswordChar = default(char);
            registerTimer = 0;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (registerTimer == 1)//密码变为掩码
            {
                registerPassword.PasswordChar = '*';
                registerTimer = 2;
            }else if (registerTimer == 0)//确认密码变为掩码
            {
                reRegisterPassword.PasswordChar = '*';
                registerTimer = 2;
            }

        }

        private void adminRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            userRadioButton.Enabled = false;
        }

        private void userRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            adminRadioButton.Enabled = false;
        }

        private void user_return_Click(object sender, EventArgs e)
        {
            this.Close();//该功能页面关闭
        }

        private void reRegisterPassword_TextChanged(object sender, EventArgs e)
        {
            re_register_password_null.Text = "";
        }
    }
}

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
    public partial class Login : Form
    {
        int userLoginNum;//用于记录用户还有多少次身份验证次数
        int adminLoginNum;//用于记录管理员还有多少次身份验证次数
        int loginTimer = 2;//用于判断计时时执行哪一个操作，2为默认状态为掩码，1表示用户密码恢复，0表示管理员密码恢复
        SqlConnection mSqlConnection = new SqlConnection();//用户连接对象
        SqlCommand userSqlCommand = new SqlCommand();//用户命令对象
        SqlCommand adminSqlCommand = new SqlCommand();//管理员命令对象
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//用户登录按钮，进行有效性验证
        {
            //判断用户名或密码是否为空
            if (textBox1.Text == "")
            {
                user_name_null.Text = "Name Cannot be Empty！";
            }
            if (maskedTextBox2.Text == "")
            {
                user_password_null.Text = "Password Cannot be Empty！";
            }
            userSqlCommand.Connection = mSqlConnection;//用于连接命令的对象，即已经连接的数据库
            userSqlCommand.CommandText = "select count(*) from users where user_name = '" + textBox1.Text + "' and user_password = '" + maskedTextBox2.Text + "'";
            int i = Convert.ToInt32(userSqlCommand.ExecuteScalar());
            if (i == 1)
            {
                UserPage userPage = new UserPage(textBox1.Text);
                userPage.ShowDialog();
                this.Hide();
            }
            else//判断是用户名错误还是密码错误
            {
                if (textBox1.Text != "" && maskedTextBox2.Text != "")//排除空的情况，只判断用户名密码不符合的情况
                {
                    userLoginNum--;//登录不符合允许身份验证的次数减一
                }
                userSqlCommand.CommandText = "select count(*) from users where user_name = '" + textBox1.Text + "'";
                int j = Convert.ToInt32(userSqlCommand.ExecuteScalar());
                if (j == 0)
                {
                    if (textBox1.Text != "")
                    {//排除用户名为空的情况
                        MessageBox.Show("Name not Exist！");
                        textBox1.SelectAll();
                        textBox1.Focus();//变为选中状态
                    }
                }
                else
                {
                    if (maskedTextBox2.Text != "")//排除密码为空的情况
                    {
                        MessageBox.Show("Wrong Password！");
                        maskedTextBox2.SelectAll();
                        maskedTextBox2.Focus();//变为选中状态
                    }
                }
                if (userLoginNum == 0)//三次机会用光
                {
                    MessageBox.Show("Fail Too Many Times, Please Try Later！");
                    textBox1.Clear();//用户名文本框清空数据并不允许继续编辑
                    textBox1.Enabled = false;
                    maskedTextBox2.Text = "";//密码文本框清空数据并不允许继续编辑
                    maskedTextBox2.Enabled = false;
                }
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)//用户用户名填写时的响应事件
        {
            user_name_null.Text = "";//下面为空的提示消失
        }

  

        private void button4_Click(object sender, EventArgs e)//管理员登录按钮，与用户登录按钮相同
        {
            //判断用户名或密码是否为空
            if (adminNameTextBox.Text == "")
            {
                admin_name_null.Text = "Name Cannot be Empty！";
            }
            if (adminPasswordMaskedTextBox.Text == "")
            {
                admin_password_null.Text = "Password Cannot be Empty！";
            }
            adminSqlCommand.Connection = mSqlConnection;//用于连接命令的对象，即已经连接的数据库
            adminSqlCommand.CommandText = "select count(*) from admin where admin_name = '" + adminNameTextBox.Text + "' and admin_password = '" + adminPasswordMaskedTextBox.Text + "'";
            int i = Convert.ToInt32(adminSqlCommand.ExecuteScalar());
            if (i == 1)
            {
                AdminPage adminPage = new AdminPage(adminNameTextBox.Text);
                adminPage.ShowDialog();
                this.Hide();
            }
            else//判断是用户名错误还是密码错误
            {
                if (adminNameTextBox.Text != "" && adminPasswordMaskedTextBox.Text != "")//排除空的情况，只判断用户名密码不符合的情况
                {
                    adminLoginNum--;//登录不符合允许身份验证的次数减一
                }
                adminSqlCommand.CommandText = "select count(*) from admin where admin_name = '" + adminNameTextBox.Text + "'";
                int j = Convert.ToInt32(adminSqlCommand.ExecuteScalar());
                if (j == 0)
                {
                    if (adminNameTextBox.Text != "")
                    {//排除用户名为空的情况
                        MessageBox.Show("Name not Exist！");
                        adminNameTextBox.SelectAll();
                        adminNameTextBox.Focus();//变为选中状态
                    }
                }
                else
                {
                    if (adminPasswordMaskedTextBox.Text != "")//排除密码为空的情况
                    {
                        MessageBox.Show("Wrong Password！");
                        adminPasswordMaskedTextBox.SelectAll();
                        adminPasswordMaskedTextBox.Focus();////变为选中状态
                    }
                }
                if (adminLoginNum == 0)//三次机会用光
                {
                    MessageBox.Show("Fail Too Many Times, Please Try Later！");
                    adminNameTextBox.Clear();//用户名文本框清空数据并不允许继续编辑
                    adminNameTextBox.Enabled = false;
                    adminPasswordMaskedTextBox.Text = "";//密码文本框清空数据并不允许继续编辑
                    adminPasswordMaskedTextBox.Enabled = false;
                }
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userLoginNum = 3;//每次加载窗体1时进行用户登录次数的初始化
            adminLoginNum = 3;//每次加载窗体1时进行管理员登录次数的初始化
            //toolStripStatusLabel5.Text = "系统时间：" + Convert.ToString(System.DateTime.Now);
            //窗体加载时便连接数据库
            //如果使用windows身份进行验证，用不可见控件Binding Source(拖进去，不可见控件)-->属性--〉DataSource(数据源，默认无)
            //--〉点开，添加项目数据源--〉停留在数据库，直接下一步--〉停留在数据集，直接下一步--〉新建链接--〉刷新
            //--〉如果刷不出来，去复制本地的windows身份数据库名称--〉复制在服务器名--〉看选择或输入数据库名称中是否有自己要用的表格
            //-->测试连接--〉成功--确定--〉展开将保存到应用程序中的连接字符串--〉复制粘贴--〉复制到代码中，注意斜杠的使用
            //mSqlConnection.ConnectionString = "Data Source=localhost;Initial Catalog=libraryBooks;Integrated Security=True";
            mSqlConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\furui\Documents\libraryBooks.mdf;Integrated Security=True;Connect Timeout=30";
            mSqlConnection.Open();//数据库打开

        }

        private void user_return_Click(object sender, EventArgs e)//用户返回按钮
        {
            this.Close();//该功能页面关闭
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void maskedTextBox2_TextChanged(object sender, EventArgs e)//填写密码时的响应事件
        {
            user_password_null.Text = "";//填写密码时为空的提示消失
        }

        private void adminPasswordMaskedTextBox_TextChanged(object sender, EventArgs e)//管理员密码
        {
            admin_password_null.Text = "";//填写密码时为空的提示消失
        }

        private void adminNameTextBox_TextChanged(object sender, EventArgs e)//管理员用户名
        {
            admin_name_null.Text = "";//下面用户名为空的提示消失
        }

        private void userRegisterButton_Click(object sender, EventArgs e)
        {
            Register form2 = new Register();
            form2.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (loginTimer == 1)//用户密码变为掩码
            {
                maskedTextBox2.PasswordChar = '*';
                loginTimer = 2;
            }
            else if (loginTimer == 0)//管理员密码变为掩码
            {
                adminPasswordMaskedTextBox.PasswordChar = '*';
                loginTimer = 2;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            maskedTextBox2.PasswordChar = default(char);
            loginTimer = 1;
            timer1.Start();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            adminPasswordMaskedTextBox.PasswordChar = default(char);
            loginTimer = 0;
            timer1.Start();
        }

        private void registerLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register registerForm = new Register();
            registerForm.ShowDialog();//表示当前窗体不关，则其他窗体不可用
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void user_name_null_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Register registerForm = new Register();
            registerForm.ShowDialog();//表示当前窗体不关，则其他窗体不可用
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

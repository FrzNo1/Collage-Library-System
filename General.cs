using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class General : Form
    {

        public Login loginForm = null;
        public Home homeForm = null;
        public General()
        {
            InitializeComponent();
        }

        private void General_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginForm = new Login();
            loginForm.ShowDialog();//表示当前窗体不关，则其他窗体不可用
        }

        private void button2_Click(object sender, EventArgs e)
        {
            homeForm = new Home(); 
            homeForm.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

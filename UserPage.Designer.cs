
namespace WindowsFormsApplication1
{
    partial class UserPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lstBorrowingBooks = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.user_login = new System.Windows.Forms.Button();
            this.user_return = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reAlterPsdTex = new System.Windows.Forms.MaskedTextBox();
            this.alterPsdTex = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.alterPsd_null = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.reALterPsd_null = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.debtMoney = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.debtBooksNum = new System.Windows.Forms.Label();
            this.debtBooksNumLab = new System.Windows.Forms.Label();
            this.borrowedBooksNum = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.borrowingBooksNum = new System.Windows.Forms.Label();
            this.borrowedBooksLab = new System.Windows.Forms.Label();
            this.userLab = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lstBorrowedBooks = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.lstBorrowingBooks);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(744, 239);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Books Borrwoed";
            // 
            // lstBorrowingBooks
            // 
            this.lstBorrowingBooks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lstBorrowingBooks.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstBorrowingBooks.FullRowSelect = true;
            this.lstBorrowingBooks.GridLines = true;
            this.lstBorrowingBooks.HideSelection = false;
            this.lstBorrowingBooks.Location = new System.Drawing.Point(-4, 2);
            this.lstBorrowingBooks.Margin = new System.Windows.Forms.Padding(2);
            this.lstBorrowingBooks.Name = "lstBorrowingBooks";
            this.lstBorrowingBooks.Size = new System.Drawing.Size(760, 229);
            this.lstBorrowingBooks.TabIndex = 18;
            this.lstBorrowingBooks.UseCompatibleStateImageBehavior = false;
            this.lstBorrowingBooks.View = System.Windows.Forms.View.Details;
            this.lstBorrowingBooks.SelectedIndexChanged += new System.EventHandler(this.lstBooks_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ISBN";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Title";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Time Being Borrowed";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Days Being Borrowed";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Payments";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 120;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.debtMoney);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.debtBooksNum);
            this.tabPage1.Controls.Add(this.debtBooksNumLab);
            this.tabPage1.Controls.Add(this.borrowedBooksNum);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.borrowingBooksNum);
            this.tabPage1.Controls.Add(this.borrowedBooksLab);
            this.tabPage1.Controls.Add(this.userLab);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(744, 239);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Personal Information";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.user_login);
            this.panel2.Controls.Add(this.user_return);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(104, 142);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(182, 52);
            this.panel2.TabIndex = 60;
            // 
            // user_login
            // 
            this.user_login.Location = new System.Drawing.Point(16, 10);
            this.user_login.Name = "user_login";
            this.user_login.Size = new System.Drawing.Size(76, 25);
            this.user_login.TabIndex = 8;
            this.user_login.Text = "Confirm";
            this.user_login.UseVisualStyleBackColor = true;
            this.user_login.Click += new System.EventHandler(this.user_login_Click);
            // 
            // user_return
            // 
            this.user_return.Location = new System.Drawing.Point(98, 11);
            this.user_return.Name = "user_return";
            this.user_return.Size = new System.Drawing.Size(76, 24);
            this.user_return.TabIndex = 37;
            this.user_return.Text = "Return";
            this.user_return.UseVisualStyleBackColor = true;
            this.user_return.Click += new System.EventHandler(this.user_return_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.reAlterPsdTex);
            this.panel1.Controls.Add(this.alterPsdTex);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.alterPsd_null);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.reALterPsd_null);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(8, 34);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(351, 104);
            this.panel1.TabIndex = 59;
            // 
            // reAlterPsdTex
            // 
            this.reAlterPsdTex.Location = new System.Drawing.Point(130, 63);
            this.reAlterPsdTex.Name = "reAlterPsdTex";
            this.reAlterPsdTex.PasswordChar = '*';
            this.reAlterPsdTex.Size = new System.Drawing.Size(165, 24);
            this.reAlterPsdTex.TabIndex = 46;
            this.reAlterPsdTex.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.reAlterPsdTex_MaskInputRejected);
            this.reAlterPsdTex.TextChanged += new System.EventHandler(this.reAlterPsdTex_TextChanged);
            // 
            // alterPsdTex
            // 
            this.alterPsdTex.Location = new System.Drawing.Point(130, 19);
            this.alterPsdTex.Name = "alterPsdTex";
            this.alterPsdTex.PasswordChar = '*';
            this.alterPsdTex.Size = new System.Drawing.Size(165, 24);
            this.alterPsdTex.TabIndex = 43;
            this.alterPsdTex.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.alterPsdTex_MaskInputRejected);
            this.alterPsdTex.TextChanged += new System.EventHandler(this.alterPsdTex_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 19);
            this.label2.TabIndex = 42;
            this.label2.Text = "New Password :";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::WindowsFormsApplication1.Properties.Resources.查看;
            this.pictureBox3.Location = new System.Drawing.Point(300, 20);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(19, 12);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 48;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // alterPsd_null
            // 
            this.alterPsd_null.AutoSize = true;
            this.alterPsd_null.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.alterPsd_null.ForeColor = System.Drawing.Color.Red;
            this.alterPsd_null.Location = new System.Drawing.Point(94, 42);
            this.alterPsd_null.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.alterPsd_null.Name = "alterPsd_null";
            this.alterPsd_null.Size = new System.Drawing.Size(35, 11);
            this.alterPsd_null.TabIndex = 44;
            this.alterPsd_null.Text = "     ";
            this.alterPsd_null.Click += new System.EventHandler(this.alterPsd_null_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(51, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 19);
            this.label6.TabIndex = 45;
            this.label6.Text = "Confirm :";
            // 
            // reALterPsd_null
            // 
            this.reALterPsd_null.AutoSize = true;
            this.reALterPsd_null.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.reALterPsd_null.ForeColor = System.Drawing.Color.Red;
            this.reALterPsd_null.Location = new System.Drawing.Point(96, 88);
            this.reALterPsd_null.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.reALterPsd_null.Name = "reALterPsd_null";
            this.reALterPsd_null.Size = new System.Drawing.Size(35, 11);
            this.reALterPsd_null.TabIndex = 47;
            this.reALterPsd_null.Text = "     ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApplication1.Properties.Resources.查看;
            this.pictureBox1.Location = new System.Drawing.Point(300, 64);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(19, 12);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 49;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 43);
            this.button1.TabIndex = 58;
            this.button1.Text = "Change Password";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // debtMoney
            // 
            this.debtMoney.AutoSize = true;
            this.debtMoney.Location = new System.Drawing.Point(548, 157);
            this.debtMoney.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.debtMoney.Name = "debtMoney";
            this.debtMoney.Size = new System.Drawing.Size(79, 15);
            this.debtMoney.TabIndex = 57;
            this.debtMoney.Text = "debtMoney";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(447, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 19);
            this.label5.TabIndex = 56;
            this.label5.Text = "Payments : ";
            // 
            // debtBooksNum
            // 
            this.debtBooksNum.AutoSize = true;
            this.debtBooksNum.Location = new System.Drawing.Point(548, 111);
            this.debtBooksNum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.debtBooksNum.Name = "debtBooksNum";
            this.debtBooksNum.Size = new System.Drawing.Size(103, 15);
            this.debtBooksNum.TabIndex = 55;
            this.debtBooksNum.Text = "debtBooksNum";
            this.debtBooksNum.Click += new System.EventHandler(this.debtBooksNum_Click);
            // 
            // debtBooksNumLab
            // 
            this.debtBooksNumLab.AutoSize = true;
            this.debtBooksNumLab.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debtBooksNumLab.Location = new System.Drawing.Point(409, 107);
            this.debtBooksNumLab.Name = "debtBooksNumLab";
            this.debtBooksNumLab.Size = new System.Drawing.Size(134, 19);
            this.debtBooksNumLab.TabIndex = 54;
            this.debtBooksNumLab.Text = "Arreared Books :";
            this.debtBooksNumLab.Click += new System.EventHandler(this.debtBooksNumLab_Click);
            // 
            // borrowedBooksNum
            // 
            this.borrowedBooksNum.AutoSize = true;
            this.borrowedBooksNum.Location = new System.Drawing.Point(548, 64);
            this.borrowedBooksNum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.borrowedBooksNum.Name = "borrowedBooksNum";
            this.borrowedBooksNum.Size = new System.Drawing.Size(135, 15);
            this.borrowedBooksNum.TabIndex = 53;
            this.borrowedBooksNum.Text = "borrowedBooksNum";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(387, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 19);
            this.label4.TabIndex = 52;
            this.label4.Text = "Already Borrowed :";
            // 
            // borrowingBooksNum
            // 
            this.borrowingBooksNum.AutoSize = true;
            this.borrowingBooksNum.Location = new System.Drawing.Point(548, 21);
            this.borrowingBooksNum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.borrowingBooksNum.Name = "borrowingBooksNum";
            this.borrowingBooksNum.Size = new System.Drawing.Size(143, 15);
            this.borrowingBooksNum.TabIndex = 51;
            this.borrowingBooksNum.Text = "borrowingBooksNum";
            this.borrowingBooksNum.Click += new System.EventHandler(this.borrowingBooksNum_Click);
            // 
            // borrowedBooksLab
            // 
            this.borrowedBooksLab.AutoSize = true;
            this.borrowedBooksLab.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.borrowedBooksLab.Location = new System.Drawing.Point(405, 17);
            this.borrowedBooksLab.Name = "borrowedBooksLab";
            this.borrowedBooksLab.Size = new System.Drawing.Size(138, 19);
            this.borrowedBooksLab.TabIndex = 50;
            this.borrowedBooksLab.Text = "Being Borrowed :";
            this.borrowedBooksLab.Click += new System.EventHandler(this.borrowedBooksLab_Click);
            // 
            // userLab
            // 
            this.userLab.AutoSize = true;
            this.userLab.Location = new System.Drawing.Point(144, 17);
            this.userLab.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.userLab.Name = "userLab";
            this.userLab.Size = new System.Drawing.Size(71, 15);
            this.userLab.TabIndex = 41;
            this.userLab.Text = "userName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name :";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(-2, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(752, 267);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lstBorrowedBooks);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage3.Size = new System.Drawing.Size(744, 239);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Borrowed History";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lstBorrowedBooks
            // 
            this.lstBorrowedBooks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.lstBorrowedBooks.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstBorrowedBooks.FullRowSelect = true;
            this.lstBorrowedBooks.GridLines = true;
            this.lstBorrowedBooks.HideSelection = false;
            this.lstBorrowedBooks.Location = new System.Drawing.Point(2, 4);
            this.lstBorrowedBooks.Margin = new System.Windows.Forms.Padding(2);
            this.lstBorrowedBooks.Name = "lstBorrowedBooks";
            this.lstBorrowedBooks.Size = new System.Drawing.Size(742, 231);
            this.lstBorrowedBooks.TabIndex = 19;
            this.lstBorrowedBooks.UseCompatibleStateImageBehavior = false;
            this.lstBorrowedBooks.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "ISBN";
            this.columnHeader6.Width = 80;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Title";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 150;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Time Being Borrowed";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 200;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Time Being Returned";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 200;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Payments";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader10.Width = 120;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 269);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(752, 22);
            this.statusStrip1.TabIndex = 37;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(63, 17);
            this.toolStripStatusLabel1.Text = "Ruizhe Fu";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(100, 17);
            this.toolStripStatusLabel2.Text = "Grinnell Collage";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(95, 17);
            this.toolStripStatusLabel3.Text = "(610) 420-8029";
            // 
            // UserPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(752, 291);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UserPage";
            this.Text = "Collage Library System";
            this.Load += new System.EventHandler(this.UserPage_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label userLab;
        private System.Windows.Forms.Button user_return;
        private System.Windows.Forms.Button user_login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label reALterPsd_null;
        private System.Windows.Forms.MaskedTextBox reAlterPsdTex;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label alterPsd_null;
        private System.Windows.Forms.MaskedTextBox alterPsdTex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListView lstBorrowingBooks;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label borrowingBooksNum;
        private System.Windows.Forms.Label borrowedBooksLab;
        private System.Windows.Forms.Label borrowedBooksNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label debtBooksNum;
        private System.Windows.Forms.Label debtBooksNumLab;
        private System.Windows.Forms.Label debtMoney;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView lstBorrowedBooks;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
    }
}
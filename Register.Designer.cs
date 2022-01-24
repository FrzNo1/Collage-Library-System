namespace WindowsFormsApplication1
{
    partial class Register
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
            this.adminRadioButton = new System.Windows.Forms.RadioButton();
            this.userRadioButton = new System.Windows.Forms.RadioButton();
            this.re_register_password_null = new System.Windows.Forms.Label();
            this.reRegisterPassword = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.userRegisterButton = new System.Windows.Forms.Button();
            this.register_password_null = new System.Windows.Forms.Label();
            this.register_name_null = new System.Windows.Forms.Label();
            this.registerPassword = new System.Windows.Forms.MaskedTextBox();
            this.user_return = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.RegisterName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // adminRadioButton
            // 
            this.adminRadioButton.AutoSize = true;
            this.adminRadioButton.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.adminRadioButton.Location = new System.Drawing.Point(182, 30);
            this.adminRadioButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.adminRadioButton.Name = "adminRadioButton";
            this.adminRadioButton.Size = new System.Drawing.Size(97, 20);
            this.adminRadioButton.TabIndex = 32;
            this.adminRadioButton.TabStop = true;
            this.adminRadioButton.Text = "Librarian";
            this.adminRadioButton.UseVisualStyleBackColor = true;
            this.adminRadioButton.CheckedChanged += new System.EventHandler(this.adminRadioButton_CheckedChanged);
            // 
            // userRadioButton
            // 
            this.userRadioButton.AutoSize = true;
            this.userRadioButton.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userRadioButton.Location = new System.Drawing.Point(116, 30);
            this.userRadioButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.userRadioButton.Name = "userRadioButton";
            this.userRadioButton.Size = new System.Drawing.Size(57, 20);
            this.userRadioButton.TabIndex = 31;
            this.userRadioButton.TabStop = true;
            this.userRadioButton.Text = "User";
            this.userRadioButton.UseVisualStyleBackColor = true;
            this.userRadioButton.CheckedChanged += new System.EventHandler(this.userRadioButton_CheckedChanged);
            // 
            // re_register_password_null
            // 
            this.re_register_password_null.AutoSize = true;
            this.re_register_password_null.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.re_register_password_null.ForeColor = System.Drawing.Color.Red;
            this.re_register_password_null.Location = new System.Drawing.Point(114, 166);
            this.re_register_password_null.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.re_register_password_null.Name = "re_register_password_null";
            this.re_register_password_null.Size = new System.Drawing.Size(35, 11);
            this.re_register_password_null.TabIndex = 30;
            this.re_register_password_null.Text = "     ";
            // 
            // reRegisterPassword
            // 
            this.reRegisterPassword.Location = new System.Drawing.Point(114, 143);
            this.reRegisterPassword.Name = "reRegisterPassword";
            this.reRegisterPassword.PasswordChar = '*';
            this.reRegisterPassword.Size = new System.Drawing.Size(165, 21);
            this.reRegisterPassword.TabIndex = 29;
            this.reRegisterPassword.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.reRegisterPassword_MaskInputRejected);
            this.reRegisterPassword.MouseClick += new System.Windows.Forms.MouseEventHandler(this.reRegisterPassword_MouseClick);
            this.reRegisterPassword.TextChanged += new System.EventHandler(this.reRegisterPassword_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(34, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 19);
            this.label6.TabIndex = 28;
            this.label6.Text = "Confirm : ";
            // 
            // userRegisterButton
            // 
            this.userRegisterButton.Location = new System.Drawing.Point(114, 188);
            this.userRegisterButton.Name = "userRegisterButton";
            this.userRegisterButton.Size = new System.Drawing.Size(74, 24);
            this.userRegisterButton.TabIndex = 27;
            this.userRegisterButton.Text = "Resgister";
            this.userRegisterButton.UseVisualStyleBackColor = true;
            this.userRegisterButton.Click += new System.EventHandler(this.userRegisterButton_Click);
            // 
            // register_password_null
            // 
            this.register_password_null.AutoSize = true;
            this.register_password_null.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.register_password_null.ForeColor = System.Drawing.Color.Red;
            this.register_password_null.Location = new System.Drawing.Point(112, 129);
            this.register_password_null.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.register_password_null.Name = "register_password_null";
            this.register_password_null.Size = new System.Drawing.Size(35, 11);
            this.register_password_null.TabIndex = 26;
            this.register_password_null.Text = "     ";
            // 
            // register_name_null
            // 
            this.register_name_null.AutoSize = true;
            this.register_name_null.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.register_name_null.ForeColor = System.Drawing.Color.Red;
            this.register_name_null.Location = new System.Drawing.Point(114, 91);
            this.register_name_null.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.register_name_null.Name = "register_name_null";
            this.register_name_null.Size = new System.Drawing.Size(29, 11);
            this.register_name_null.TabIndex = 25;
            this.register_name_null.Text = "    ";
            // 
            // registerPassword
            // 
            this.registerPassword.Location = new System.Drawing.Point(114, 106);
            this.registerPassword.Name = "registerPassword";
            this.registerPassword.PasswordChar = '*';
            this.registerPassword.Size = new System.Drawing.Size(165, 21);
            this.registerPassword.TabIndex = 24;
            this.registerPassword.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.registerPassword_MaskInputRejected);
            this.registerPassword.MouseClick += new System.Windows.Forms.MouseEventHandler(this.registerPassword_MouseClick);
            this.registerPassword.TextChanged += new System.EventHandler(this.registerPassword_TextChanged);
            // 
            // user_return
            // 
            this.user_return.Location = new System.Drawing.Point(214, 188);
            this.user_return.Name = "user_return";
            this.user_return.Size = new System.Drawing.Size(64, 24);
            this.user_return.TabIndex = 23;
            this.user_return.Text = "Return";
            this.user_return.UseVisualStyleBackColor = true;
            this.user_return.Click += new System.EventHandler(this.user_return_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 19);
            this.label2.TabIndex = 22;
            this.label2.Text = "Password :";
            // 
            // RegisterName
            // 
            this.RegisterName.Location = new System.Drawing.Point(114, 67);
            this.RegisterName.Name = "RegisterName";
            this.RegisterName.Size = new System.Drawing.Size(165, 21);
            this.RegisterName.TabIndex = 21;
            this.RegisterName.TextChanged += new System.EventHandler(this.RegisterName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 19);
            this.label1.TabIndex = 20;
            this.label1.Text = "Name :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(34, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 19);
            this.label7.TabIndex = 33;
            this.label7.Text = "Identity : ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApplication1.Properties.Resources.查看;
            this.pictureBox1.Location = new System.Drawing.Point(284, 110);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(19, 12);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WindowsFormsApplication1.Properties.Resources.查看;
            this.pictureBox2.Location = new System.Drawing.Point(284, 147);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(19, 12);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 35;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
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
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5});
            this.statusStrip1.Location = new System.Drawing.Point(0, 224);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(332, 22);
            this.statusStrip1.TabIndex = 36;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(63, 17);
            this.toolStripStatusLabel1.Text = "Ruizhe Fu";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.Color.White;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(100, 17);
            this.toolStripStatusLabel2.Text = "Grinnell Collage";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BackColor = System.Drawing.Color.White;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(95, 17);
            this.toolStripStatusLabel3.Text = "(610) 420-8029";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(117, 17);
            this.toolStripStatusLabel4.Text = "TEL：13793993558";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel5.Text = "toolStripStatusLabel5";
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(332, 246);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.adminRadioButton);
            this.Controls.Add(this.userRadioButton);
            this.Controls.Add(this.re_register_password_null);
            this.Controls.Add(this.reRegisterPassword);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.userRegisterButton);
            this.Controls.Add(this.register_password_null);
            this.Controls.Add(this.register_name_null);
            this.Controls.Add(this.registerPassword);
            this.Controls.Add(this.user_return);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RegisterName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Register";
            this.Text = "Collage Library System";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton adminRadioButton;
        private System.Windows.Forms.RadioButton userRadioButton;
        private System.Windows.Forms.Label re_register_password_null;
        private System.Windows.Forms.MaskedTextBox reRegisterPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button userRegisterButton;
        private System.Windows.Forms.Label register_password_null;
        private System.Windows.Forms.Label register_name_null;
        private System.Windows.Forms.MaskedTextBox registerPassword;
        private System.Windows.Forms.Button user_return;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RegisterName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
    }
}
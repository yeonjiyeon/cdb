namespace WindowsFormsApp5
{
    partial class frmclient
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textbox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbmodel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbwind = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbtemp = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbhum = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbinterval = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cbinterval = new System.Windows.Forms.CheckBox();
            this.tbserverip = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbsertport = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cbkeepalive = new System.Windows.Forms.CheckBox();
            this.tbprotocol = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnustart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuend = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuclose = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textbox1
            // 
            this.textbox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textbox1.Location = new System.Drawing.Point(12, 27);
            this.textbox1.Multiline = true;
            this.textbox1.Name = "textbox1";
            this.textbox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textbox1.Size = new System.Drawing.Size(513, 116);
            this.textbox1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbkeepalive);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.cbinterval);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.tbtemp);
            this.groupBox1.Controls.Add(this.tbsertport);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.tbserverip);
            this.groupBox1.Controls.Add(this.tbwind);
            this.groupBox1.Controls.Add(this.tbprotocol);
            this.groupBox1.Controls.Add(this.tbinterval);
            this.groupBox1.Controls.Add(this.tbhum);
            this.groupBox1.Controls.Add(this.tbmodel);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbcode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 161);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(513, 247);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "fCode";
            // 
            // tbcode
            // 
            this.tbcode.Location = new System.Drawing.Point(72, 66);
            this.tbcode.Name = "tbcode";
            this.tbcode.Size = new System.Drawing.Size(139, 25);
            this.tbcode.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(438, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "모델명";
            // 
            // tbmodel
            // 
            this.tbmodel.Location = new System.Drawing.Point(264, 66);
            this.tbmodel.Name = "tbmodel";
            this.tbmodel.Size = new System.Drawing.Size(150, 25);
            this.tbmodel.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "상태 W";
            // 
            // tbwind
            // 
            this.tbwind.Location = new System.Drawing.Point(73, 143);
            this.tbwind.Name = "tbwind";
            this.tbwind.Size = new System.Drawing.Size(138, 25);
            this.tbwind.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "상태 T";
            // 
            // tbtemp
            // 
            this.tbtemp.Location = new System.Drawing.Point(73, 105);
            this.tbtemp.Name = "tbtemp";
            this.tbtemp.Size = new System.Drawing.Size(138, 25);
            this.tbtemp.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(438, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "상태 H";
            // 
            // tbhum
            // 
            this.tbhum.Location = new System.Drawing.Point(264, 102);
            this.tbhum.Name = "tbhum";
            this.tbhum.Size = new System.Drawing.Size(150, 25);
            this.tbhum.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(438, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "간격";
            // 
            // tbinterval
            // 
            this.tbinterval.Location = new System.Drawing.Point(325, 140);
            this.tbinterval.Name = "tbinterval";
            this.tbinterval.Size = new System.Drawing.Size(89, 25);
            this.tbinterval.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(73, 32);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 25);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "시작시간";
            // 
            // cbinterval
            // 
            this.cbinterval.AutoSize = true;
            this.cbinterval.Location = new System.Drawing.Point(283, 146);
            this.cbinterval.Name = "cbinterval";
            this.cbinterval.Size = new System.Drawing.Size(18, 17);
            this.cbinterval.TabIndex = 4;
            this.cbinterval.UseVisualStyleBackColor = true;
            // 
            // tbserverip
            // 
            this.tbserverip.Location = new System.Drawing.Point(113, 179);
            this.tbserverip.Name = "tbserverip";
            this.tbserverip.Size = new System.Drawing.Size(108, 25);
            this.tbserverip.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(213, 179);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(108, 25);
            this.textBox3.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "상태 W";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(70, 182);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "서버";
            this.label9.Click += new System.EventHandler(this.label8_Click);
            // 
            // tbsertport
            // 
            this.tbsertport.Location = new System.Drawing.Point(213, 179);
            this.tbsertport.Name = "tbsertport";
            this.tbsertport.Size = new System.Drawing.Size(108, 25);
            this.tbsertport.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(283, 146);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // cbkeepalive
            // 
            this.cbkeepalive.AutoSize = true;
            this.cbkeepalive.Location = new System.Drawing.Point(338, 182);
            this.cbkeepalive.Name = "cbkeepalive";
            this.cbkeepalive.Size = new System.Drawing.Size(18, 17);
            this.cbkeepalive.TabIndex = 4;
            this.cbkeepalive.UseVisualStyleBackColor = true;
            // 
            // tbprotocol
            // 
            this.tbprotocol.Location = new System.Drawing.Point(73, 210);
            this.tbprotocol.Name = "tbprotocol";
            this.tbprotocol.Size = new System.Drawing.Size(299, 25);
            this.tbprotocol.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(570, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // controlToolStripMenuItem
            // 
            this.controlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnustart,
            this.mnuend,
            this.mnuclose});
            this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
            this.controlToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.controlToolStripMenuItem.Text = "ContextMenuStrip";
            this.controlToolStripMenuItem.Click += new System.EventHandler(this.controlToolStripMenuItem_Click);
            // 
            // mnustart
            // 
            this.mnustart.Name = "mnustart";
            this.mnustart.Size = new System.Drawing.Size(224, 26);
            this.mnustart.Text = "시작";
            this.mnustart.Click += new System.EventHandler(this.mnustart_Click);
            // 
            // mnuend
            // 
            this.mnuend.Name = "mnuend";
            this.mnuend.Size = new System.Drawing.Size(224, 26);
            this.mnuend.Text = "종료";
            this.mnuend.Click += new System.EventHandler(this.mnuend_Click);
            // 
            // mnuclose
            // 
            this.mnuclose.Name = "mnuclose";
            this.mnuclose.Size = new System.Drawing.Size(224, 26);
            this.mnuclose.Text = "프로그램끝내기";
            this.mnuclose.Click += new System.EventHandler(this.mnuclose_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmclient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 477);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textbox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmclient";
            this.Text = "Tcp/Ip Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textbox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbmodel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbwind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbinterval;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox tbtemp;
        private System.Windows.Forms.TextBox tbinterval;
        private System.Windows.Forms.TextBox tbhum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox tbserverip;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbkeepalive;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox tbsertport;
        private System.Windows.Forms.TextBox tbprotocol;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnustart;
        private System.Windows.Forms.ToolStripMenuItem mnuend;
        private System.Windows.Forms.ToolStripMenuItem mnuclose;
        private System.Windows.Forms.Timer timer1;
    }
}


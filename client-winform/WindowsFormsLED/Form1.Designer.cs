namespace WindowsFormsLED
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label_R = new System.Windows.Forms.Label();
            this.label_G = new System.Windows.Forms.Label();
            this.label_B = new System.Windows.Forms.Label();
            this.nudR = new System.Windows.Forms.NumericUpDown();
            this.nudG = new System.Windows.Forms.NumericUpDown();
            this.nudB = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.Track_R = new System.Windows.Forms.TrackBar();
            this.pB_Connect = new System.Windows.Forms.PictureBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.Track_G = new System.Windows.Forms.TrackBar();
            this.Track_B = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.nudR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Track_R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_Connect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Track_G)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Track_B)).BeginInit();
            this.SuspendLayout();
            // 
            // label_R
            // 
            this.label_R.BackColor = System.Drawing.Color.Black;
            this.label_R.Font = new System.Drawing.Font("굴림", 20F);
            this.label_R.ForeColor = System.Drawing.Color.White;
            this.label_R.Location = new System.Drawing.Point(44, 47);
            this.label_R.Margin = new System.Windows.Forms.Padding(0);
            this.label_R.Name = "label_R";
            this.label_R.Size = new System.Drawing.Size(100, 100);
            this.label_R.TabIndex = 5;
            this.label_R.Text = "R";
            this.label_R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_G
            // 
            this.label_G.BackColor = System.Drawing.Color.Black;
            this.label_G.Font = new System.Drawing.Font("굴림", 20F);
            this.label_G.ForeColor = System.Drawing.Color.White;
            this.label_G.Location = new System.Drawing.Point(44, 190);
            this.label_G.Margin = new System.Windows.Forms.Padding(0);
            this.label_G.Name = "label_G";
            this.label_G.Size = new System.Drawing.Size(100, 100);
            this.label_G.TabIndex = 6;
            this.label_G.Text = "G";
            this.label_G.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_B
            // 
            this.label_B.BackColor = System.Drawing.Color.Black;
            this.label_B.Font = new System.Drawing.Font("굴림", 20F);
            this.label_B.ForeColor = System.Drawing.Color.White;
            this.label_B.Location = new System.Drawing.Point(44, 343);
            this.label_B.Margin = new System.Windows.Forms.Padding(0);
            this.label_B.Name = "label_B";
            this.label_B.Size = new System.Drawing.Size(100, 100);
            this.label_B.TabIndex = 7;
            this.label_B.Text = "B";
            this.label_B.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudR
            // 
            this.nudR.Font = new System.Drawing.Font("굴림", 11F);
            this.nudR.Location = new System.Drawing.Point(599, 79);
            this.nudR.Margin = new System.Windows.Forms.Padding(0);
            this.nudR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudR.Name = "nudR";
            this.nudR.Size = new System.Drawing.Size(100, 29);
            this.nudR.TabIndex = 20;
            this.nudR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudR.ValueChanged += new System.EventHandler(this.nudR_TextChanged);
            // 
            // nudG
            // 
            this.nudG.Font = new System.Drawing.Font("굴림", 11F);
            this.nudG.Location = new System.Drawing.Point(599, 226);
            this.nudG.Margin = new System.Windows.Forms.Padding(0);
            this.nudG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudG.Name = "nudG";
            this.nudG.Size = new System.Drawing.Size(100, 29);
            this.nudG.TabIndex = 21;
            this.nudG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudG.ValueChanged += new System.EventHandler(this.nudG_TextChanged);
            // 
            // nudB
            // 
            this.nudB.Font = new System.Drawing.Font("굴림", 11F);
            this.nudB.Location = new System.Drawing.Point(599, 377);
            this.nudB.Margin = new System.Windows.Forms.Padding(0);
            this.nudB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudB.Name = "nudB";
            this.nudB.Size = new System.Drawing.Size(100, 29);
            this.nudB.TabIndex = 22;
            this.nudB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudB.ValueChanged += new System.EventHandler(this.nudB_TextChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("돋움체", 14F);
            this.label1.Location = new System.Drawing.Point(46, 505);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 30);
            this.label1.TabIndex = 30;
            this.label1.Text = "192.168.0.43:5000";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Track_R
            // 
            this.Track_R.LargeChange = 1;
            this.Track_R.Location = new System.Drawing.Point(192, 79);
            this.Track_R.Maximum = 255;
            this.Track_R.Name = "Track_R";
            this.Track_R.Size = new System.Drawing.Size(350, 56);
            this.Track_R.TabIndex = 32;
            this.Track_R.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Track_R.Scroll += new System.EventHandler(this.scrR_Scroll);
            // 
            // pB_Connect
            // 
            this.pB_Connect.Image = global::WindowsFormsLED.Properties.Resources.DISCONNECT;
            this.pB_Connect.Location = new System.Drawing.Point(30, 549);
            this.pB_Connect.Name = "pB_Connect";
            this.pB_Connect.Size = new System.Drawing.Size(250, 60);
            this.pB_Connect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pB_Connect.TabIndex = 31;
            this.pB_Connect.TabStop = false;
            // 
            // btn_clear
            // 
            this.btn_clear.Enabled = false;
            this.btn_clear.Font = new System.Drawing.Font("휴먼엑스포", 11F);
            this.btn_clear.Image = ((System.Drawing.Image)(resources.GetObject("btn_clear.Image")));
            this.btn_clear.Location = new System.Drawing.Point(610, 505);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(80, 80);
            this.btn_clear.TabIndex = 14;
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // Track_G
            // 
            this.Track_G.LargeChange = 1;
            this.Track_G.Location = new System.Drawing.Point(192, 226);
            this.Track_G.Maximum = 255;
            this.Track_G.Name = "Track_G";
            this.Track_G.Size = new System.Drawing.Size(350, 56);
            this.Track_G.TabIndex = 33;
            this.Track_G.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Track_G.Scroll += new System.EventHandler(this.Track_G_Scroll);
            // 
            // Track_B
            // 
            this.Track_B.LargeChange = 1;
            this.Track_B.Location = new System.Drawing.Point(192, 377);
            this.Track_B.Maximum = 255;
            this.Track_B.Name = "Track_B";
            this.Track_B.Size = new System.Drawing.Size(350, 56);
            this.Track_B.TabIndex = 34;
            this.Track_B.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Track_B.Scroll += new System.EventHandler(this.Track_B_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(756, 690);
            this.Controls.Add(this.Track_B);
            this.Controls.Add(this.Track_G);
            this.Controls.Add(this.Track_R);
            this.Controls.Add(this.pB_Connect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudB);
            this.Controls.Add(this.nudG);
            this.Controls.Add(this.nudR);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.label_B);
            this.Controls.Add(this.label_G);
            this.Controls.Add(this.label_R);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "LED 밝기 조절";
            ((System.ComponentModel.ISupportInitialize)(this.nudR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Track_R)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_Connect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Track_G)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Track_B)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_R;
        private System.Windows.Forms.Label label_G;
        private System.Windows.Forms.Label label_B;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.NumericUpDown nudR;
        private System.Windows.Forms.NumericUpDown nudG;
        private System.Windows.Forms.NumericUpDown nudB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pB_Connect;
        private System.Windows.Forms.TrackBar Track_R;
        private System.Windows.Forms.TrackBar Track_G;
        private System.Windows.Forms.TrackBar Track_B;
    }
}


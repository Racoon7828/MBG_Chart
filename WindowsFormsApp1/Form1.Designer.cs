namespace WindowsFormsApp1
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
            this.IntegraBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MelonBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.MyListAddBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BugsBtn = new System.Windows.Forms.Button();
            this.GnineBtn = new System.Windows.Forms.Button();
            this.MyListOpenBtn = new System.Windows.Forms.Button();
            this.showVidBtn = new System.Windows.Forms.Button();
            this.infoBtn = new System.Windows.Forms.Button();
            this.chatBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // IntegraBtn
            // 
            this.IntegraBtn.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IntegraBtn.Location = new System.Drawing.Point(25, 202);
            this.IntegraBtn.Name = "IntegraBtn";
            this.IntegraBtn.Size = new System.Drawing.Size(113, 57);
            this.IntegraBtn.TabIndex = 0;
            this.IntegraBtn.Text = "통합순위";
            this.IntegraBtn.UseVisualStyleBackColor = true;
            this.IntegraBtn.Click += new System.EventHandler(this.IntegraBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 266);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1016, 541);
            this.dataGridView1.TabIndex = 4;
            // 
            // MelonBtn
            // 
            this.MelonBtn.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MelonBtn.Location = new System.Drawing.Point(154, 203);
            this.MelonBtn.Name = "MelonBtn";
            this.MelonBtn.Size = new System.Drawing.Size(113, 57);
            this.MelonBtn.TabIndex = 5;
            this.MelonBtn.Text = "멜론";
            this.MelonBtn.UseVisualStyleBackColor = true;
            this.MelonBtn.Click += new System.EventHandler(this.MelonBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.resetBtn.Location = new System.Drawing.Point(991, 213);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(52, 46);
            this.resetBtn.TabIndex = 8;
            this.resetBtn.Text = "초기화";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Info;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox1.Location = new System.Drawing.Point(27, 166);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(144, 30);
            this.textBox1.TabIndex = 9;
            // 
            // MyListAddBtn
            // 
            this.MyListAddBtn.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MyListAddBtn.Location = new System.Drawing.Point(630, 146);
            this.MyListAddBtn.Name = "MyListAddBtn";
            this.MyListAddBtn.Size = new System.Drawing.Size(157, 69);
            this.MyListAddBtn.TabIndex = 10;
            this.MyListAddBtn.Text = "MyList 추가";
            this.MyListAddBtn.UseVisualStyleBackColor = true;
            this.MyListAddBtn.Click += new System.EventHandler(this.MyListAddBtn_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(26, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(486, 123);
            this.label1.TabIndex = 12;
            this.label1.Text = "MBG 차트";
            // 
            // BugsBtn
            // 
            this.BugsBtn.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BugsBtn.Location = new System.Drawing.Point(284, 202);
            this.BugsBtn.Name = "BugsBtn";
            this.BugsBtn.Size = new System.Drawing.Size(113, 57);
            this.BugsBtn.TabIndex = 13;
            this.BugsBtn.Text = "벅스";
            this.BugsBtn.UseVisualStyleBackColor = true;
            this.BugsBtn.Click += new System.EventHandler(this.BugsBtn_Click);
            // 
            // GnineBtn
            // 
            this.GnineBtn.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.GnineBtn.Location = new System.Drawing.Point(415, 203);
            this.GnineBtn.Name = "GnineBtn";
            this.GnineBtn.Size = new System.Drawing.Size(113, 57);
            this.GnineBtn.TabIndex = 14;
            this.GnineBtn.Text = "지니";
            this.GnineBtn.UseVisualStyleBackColor = true;
            this.GnineBtn.Click += new System.EventHandler(this.GenieBtn_Click);
            // 
            // MyListOpenBtn
            // 
            this.MyListOpenBtn.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MyListOpenBtn.Location = new System.Drawing.Point(804, 146);
            this.MyListOpenBtn.Name = "MyListOpenBtn";
            this.MyListOpenBtn.Size = new System.Drawing.Size(153, 69);
            this.MyListOpenBtn.TabIndex = 15;
            this.MyListOpenBtn.Text = "MyList 열기";
            this.MyListOpenBtn.UseVisualStyleBackColor = true;
            this.MyListOpenBtn.Click += new System.EventHandler(this.MyListOpenBtn_Click);
            // 
            // showVidBtn
            // 
            this.showVidBtn.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.showVidBtn.Location = new System.Drawing.Point(548, 52);
            this.showVidBtn.Name = "showVidBtn";
            this.showVidBtn.Size = new System.Drawing.Size(150, 80);
            this.showVidBtn.TabIndex = 16;
            this.showVidBtn.Text = "선택한 노래 재생하기";
            this.showVidBtn.UseVisualStyleBackColor = true;
            this.showVidBtn.Click += new System.EventHandler(this.showVidBtn_Click);
            // 
            // infoBtn
            // 
            this.infoBtn.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.infoBtn.Location = new System.Drawing.Point(720, 52);
            this.infoBtn.Name = "infoBtn";
            this.infoBtn.Size = new System.Drawing.Size(149, 78);
            this.infoBtn.TabIndex = 17;
            this.infoBtn.Text = "노래 정보";
            this.infoBtn.UseVisualStyleBackColor = true;
            this.infoBtn.Click += new System.EventHandler(this.infoBtn_Click);
            // 
            // chatBtn
            // 
            this.chatBtn.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chatBtn.Location = new System.Drawing.Point(890, 53);
            this.chatBtn.Name = "chatBtn";
            this.chatBtn.Size = new System.Drawing.Size(153, 78);
            this.chatBtn.TabIndex = 18;
            this.chatBtn.Text = "전체 차트 확인";
            this.chatBtn.UseVisualStyleBackColor = true;
            this.chatBtn.Click += new System.EventHandler(this.chartBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1081, 831);
            this.Controls.Add(this.chatBtn);
            this.Controls.Add(this.infoBtn);
            this.Controls.Add(this.showVidBtn);
            this.Controls.Add(this.MyListOpenBtn);
            this.Controls.Add(this.GnineBtn);
            this.Controls.Add(this.BugsBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MyListAddBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.MelonBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.IntegraBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button IntegraBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button MelonBtn;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button MyListAddBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BugsBtn;
        private System.Windows.Forms.Button GnineBtn;
        private System.Windows.Forms.Button MyListOpenBtn;
        private System.Windows.Forms.Button showVidBtn;
        private System.Windows.Forms.Button infoBtn;
        private System.Windows.Forms.Button chatBtn;
    }
}


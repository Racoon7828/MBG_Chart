namespace WindowsFormsApp1
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.delBtn = new System.Windows.Forms.Button();
            this.showBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "MyList 차트";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 101);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(439, 485);
            this.dataGridView1.TabIndex = 1;
            // 
            // delBtn
            // 
            this.delBtn.Font = new System.Drawing.Font("굴림", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.delBtn.Location = new System.Drawing.Point(23, 601);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(171, 44);
            this.delBtn.TabIndex = 2;
            this.delBtn.Text = "삭제";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // showBtn
            // 
            this.showBtn.Font = new System.Drawing.Font("굴림", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.showBtn.Location = new System.Drawing.Point(291, 601);
            this.showBtn.Name = "showBtn";
            this.showBtn.Size = new System.Drawing.Size(171, 44);
            this.showBtn.TabIndex = 3;
            this.showBtn.Text = "재생";
            this.showBtn.UseVisualStyleBackColor = true;
            this.showBtn.Click += new System.EventHandler(this.showBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.resetBtn.Location = new System.Drawing.Point(410, 42);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(52, 41);
            this.resetBtn.TabIndex = 9;
            this.resetBtn.Text = "최신화";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(489, 666);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.showBtn);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Button showBtn;
        private System.Windows.Forms.Button resetBtn;
    }
}
namespace MineSweep
{
    partial class UserDefine
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
            this.label2 = new System.Windows.Forms.Label();
            this.tBoundry = new System.Windows.Forms.TextBox();
            this.tMineCount = new System.Windows.Forms.TextBox();
            this.bOK = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "边长([0,20]):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "雷数([0,边长2]):";
            // 
            // tBoundry
            // 
            this.tBoundry.Location = new System.Drawing.Point(101, 19);
            this.tBoundry.Name = "tBoundry";
            this.tBoundry.Size = new System.Drawing.Size(99, 21);
            this.tBoundry.TabIndex = 2;
            this.tBoundry.TextChanged += new System.EventHandler(this.tBoundry_TextChanged);
            // 
            // tMineCount
            // 
            this.tMineCount.Location = new System.Drawing.Point(101, 50);
            this.tMineCount.Name = "tMineCount";
            this.tMineCount.Size = new System.Drawing.Size(99, 21);
            this.tMineCount.TabIndex = 3;
            this.tMineCount.TextChanged += new System.EventHandler(this.tMineCount_TextChanged);
            // 
            // bOK
            // 
            this.bOK.Location = new System.Drawing.Point(206, 16);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(75, 24);
            this.bOK.TabIndex = 4;
            this.bOK.Text = "确定";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(206, 50);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 24);
            this.bCancel.TabIndex = 5;
            this.bCancel.Text = "取消";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // UserDefine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 90);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.tMineCount);
            this.Controls.Add(this.tBoundry);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UserDefine";
            this.Text = "自定义";
            this.Load += new System.EventHandler(this.UserDefine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBoundry;
        private System.Windows.Forms.TextBox tMineCount;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Button bCancel;
    }
}
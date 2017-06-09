namespace MineSweep
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.游戏GToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolPriminary = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMiddle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolHigh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolUserDefine = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.PassedTime = new System.Windows.Forms.PictureBox();
            this.UnMarkedMines = new System.Windows.Forms.PictureBox();
            this.tPassedTime = new System.Windows.Forms.Timer(this.components);
            this.times = new System.Windows.Forms.Label();
            this.LeftCount = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PassedTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnMarkedMines)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImage = global::MineSweep.MineResources.MenuBar;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.游戏GToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(244, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 游戏GToolStripMenuItem
            // 
            this.游戏GToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新游戏ToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolPriminary,
            this.toolMiddle,
            this.toolHigh,
            this.toolUserDefine,
            this.toolStripSeparator2,
            this.退出ToolStripMenuItem});
            this.游戏GToolStripMenuItem.Name = "游戏GToolStripMenuItem";
            this.游戏GToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.游戏GToolStripMenuItem.Text = "游戏(&G)";
            // 
            // 新游戏ToolStripMenuItem
            // 
            this.新游戏ToolStripMenuItem.Name = "新游戏ToolStripMenuItem";
            this.新游戏ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.新游戏ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.新游戏ToolStripMenuItem.Text = "新游戏";
            this.新游戏ToolStripMenuItem.Click += new System.EventHandler(this.新游戏ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(130, 6);
            // 
            // toolPriminary
            // 
            this.toolPriminary.Name = "toolPriminary";
            this.toolPriminary.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.toolPriminary.Size = new System.Drawing.Size(133, 22);
            this.toolPriminary.Text = "初级";
            this.toolPriminary.Click += new System.EventHandler(this.toolPriminary_Click);
            // 
            // toolMiddle
            // 
            this.toolMiddle.Name = "toolMiddle";
            this.toolMiddle.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.toolMiddle.Size = new System.Drawing.Size(133, 22);
            this.toolMiddle.Text = "中级";
            this.toolMiddle.Click += new System.EventHandler(this.toolMiddle_Click);
            // 
            // toolHigh
            // 
            this.toolHigh.Name = "toolHigh";
            this.toolHigh.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.toolHigh.Size = new System.Drawing.Size(133, 22);
            this.toolHigh.Text = "高级";
            this.toolHigh.Click += new System.EventHandler(this.toolHigh_Click);
            // 
            // toolUserDefine
            // 
            this.toolUserDefine.Name = "toolUserDefine";
            this.toolUserDefine.Size = new System.Drawing.Size(133, 22);
            this.toolUserDefine.Text = "自定义";
            this.toolUserDefine.Click += new System.EventHandler(this.toolUserDefine_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(130, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAbout,
            this.toolHelp});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // toolAbout
            // 
            this.toolAbout.Name = "toolAbout";
            this.toolAbout.Size = new System.Drawing.Size(152, 22);
            this.toolAbout.Text = "关于扫雷";
            this.toolAbout.Click += new System.EventHandler(this.toolAbout_Click);
            // 
            // toolHelp
            // 
            this.toolHelp.Name = "toolHelp";
            this.toolHelp.Size = new System.Drawing.Size(152, 22);
            this.toolHelp.Text = "帮助";
            this.toolHelp.Click += new System.EventHandler(this.toolHelp_Click);
            // 
            // PassedTime
            // 
            this.PassedTime.Image = global::MineSweep.MineResources.PassedTime;
            this.PassedTime.Location = new System.Drawing.Point(12, 247);
            this.PassedTime.Name = "PassedTime";
            this.PassedTime.Size = new System.Drawing.Size(75, 30);
            this.PassedTime.TabIndex = 1;
            this.PassedTime.TabStop = false;
            // 
            // UnMarkedMines
            // 
            this.UnMarkedMines.Image = global::MineSweep.MineResources.UnmarkedMines;
            this.UnMarkedMines.Location = new System.Drawing.Point(157, 247);
            this.UnMarkedMines.Name = "UnMarkedMines";
            this.UnMarkedMines.Size = new System.Drawing.Size(75, 30);
            this.UnMarkedMines.TabIndex = 2;
            this.UnMarkedMines.TabStop = false;
            // 
            // tPassedTime
            // 
            this.tPassedTime.Interval = 1000;
            this.tPassedTime.Tick += new System.EventHandler(this.tPassedTime_Tick);
            // 
            // times
            // 
            this.times.AutoSize = true;
            this.times.BackColor = System.Drawing.Color.RoyalBlue;
            this.times.Font = new System.Drawing.Font("华文琥珀", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.times.Location = new System.Drawing.Point(59, 260);
            this.times.Name = "times";
            this.times.Size = new System.Drawing.Size(0, 17);
            this.times.TabIndex = 3;
            // 
            // LeftCount
            // 
            this.LeftCount.AutoSize = true;
            this.LeftCount.BackColor = System.Drawing.Color.RoyalBlue;
            this.LeftCount.Font = new System.Drawing.Font("华文琥珀", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LeftCount.Location = new System.Drawing.Point(167, 260);
            this.LeftCount.Name = "LeftCount";
            this.LeftCount.Size = new System.Drawing.Size(0, 17);
            this.LeftCount.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 281);
            this.Controls.Add(this.LeftCount);
            this.Controls.Add(this.times);
            this.Controls.Add(this.UnMarkedMines);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.PassedTime);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "扫雷";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PassedTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnMarkedMines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 游戏GToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolPriminary;
        private System.Windows.Forms.ToolStripMenuItem toolMiddle;
        private System.Windows.Forms.ToolStripMenuItem toolHigh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolAbout;
        private System.Windows.Forms.ToolStripMenuItem toolHelp;
        private System.Windows.Forms.PictureBox PassedTime;
        private System.Windows.Forms.PictureBox UnMarkedMines;
        private System.Windows.Forms.Timer tPassedTime;
        private System.Windows.Forms.Label times;
        private System.Windows.Forms.Label LeftCount;
        private System.Windows.Forms.ToolStripMenuItem toolUserDefine;
    }
}


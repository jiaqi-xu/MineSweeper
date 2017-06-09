using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MineSweep
{
    /// <summary>
    /// Author : Jiaqi Xu
    /// Date    : 2011/04/29
    /// Notes  : 
    ///            1、实现左右键一起按自动消除功能；
    ///            2、将部分代码封装到类；
    ///            3、增加自定义功能；
    ///            4、关于、帮助界面......
    /// ======================================================           
    /// Date    :2011/04/26
    /// Notes  : 1、解决自动清除是递归错误;
    /// ======================================================
    /// Date    :2011/04/22
    /// Notes  : 工程创建
    /// </summary>
    public partial class Form1 : Form
    {
        #region 定义
        public struct Mine
        {
            public int AreaType; //用于记录区域类型  0:空区域  1~8:块内含有的雷数目  9:雷区域；
            public bool isClicked;  //记录当前区域是否被点击过；
            public int State; //记录当前区域状态  0:未处理  1:插旗  2:问号；
        }
        //记录鼠标按下，用于自动清除所在块内未标记的区域
        bool LeftDown = false;
        bool RightDown = false;

        public bool IsFirstDefine = true ; //判断是否显示自定义窗口；
        public int Flags = 0; //记录已经标记的旗数
        public int PassedTimes = 0;  //记录已用时间
        public int Level = 1;  //记录难度  1、初级   2、中级   3、高级  4、自定义
        public int MineCount = 10;  //不同难度对应雷数量 1->10  2->30 3->60;
        public int Boundry = 10;  //不同难度雷区范围(不含虚拟边框) 1->10  2->16  3->20
        public Point ClickedPoint = new Point(); //记录鼠标松开时的坐标；
        public int i = 0;  //数组坐标
        public int j = 0;  //数组坐标
        public static  int StartX = 20;  //屏幕初始绘图位置
        public static  int StartY = 40;  //屏幕初始绘图位置
        public Mine [,] MineMap = new Mine[22, 22];  //雷区范围，含虚拟边框

        /// <summary>
        /// SetMap类:用于处理雷区
        ///             void RandomSetMine(ref MineSweep.Form1.Mine[,] MineMap, int MineCount, int Boundry) 随机布雷
        ///             void MarkCount(ref MineSweep.Form1.Mine[,] MineMap, int Boundry)  标记雷周围的方块
        /// GameProcess类:用于处理游戏过程中事件
        /// 
        ///             //判断游戏是否胜利
        ///             void JudgeIsWin(ref MineSweep .Form1 .Mine [,] MineMap,int Boundry,int MineCount)       
        ///             //自动清除空白区域
        ///             void AutoClearBlankArea(ref MineSweep .Form1 .Mine [,] MineMap,int Boundry,int i, int j,Graphics g)
        ///             //判断所属坐标位置内对应的类型；
        ///             void JudgePos(ref MineSweep.Form1.Mine[,] MineMap,int Boundry, int i, int j, Graphics g) 
        ///             //自动清除已标记完的块
        ///             void AutoClear(ref MineSweep .Form1 .Mine [,] MineMap,int Boundry,int a, int b,Graphics g)
        ///             //游戏结束
        ///             void GameOver(ref MineSweep.Form1.Mine[,] MineMap, int Boundry, int i, int j, Graphics g) 
        ///             //重新绘制
        ///             void Painting(int i, int j, Bitmap TemBit,Graphics g)        ///             
        /// </summary>
        SetMap setmap = new SetMap();
        GameProcess gaming = new GameProcess();

        
        #endregion

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }


        //重新布置雷区；
        public void SetMine(int TemBoundry,int TemMineCount)
        {
            setmap.RandomSetMine(ref MineMap, TemMineCount ,TemBoundry );
            setmap.MarkCount(ref MineMap, TemBoundry  );
        }

        //重新绘制游戏画面；
        public void Repaint(object sender)
        {
            //重置鼠标动作；
            LeftDown = false;
            RightDown = false;
            //重置坐标;
            i = 0;
            j = 0;
            //重置时间；
            tPassedTime.Start();
            PassedTimes = 0;
            times.Text = "0";
            Flags = 0;
            LeftCount.Text = Convert.ToString(MineCount);
            //重新绘制雷区；
            Graphics g = this.CreateGraphics();
            g.Clear(BackColor);
            Rectangle Rec = new Rectangle();
            Bitmap Area = new Bitmap(MineResources.Area);
            TextureBrush temBrush = new TextureBrush(Area);
            PaintEventArgs test = new PaintEventArgs(g, Rec);
            //控制窗体大小；
            this.Width = Boundry * 20 + 60;
            this.Height = Boundry * 20 + 120;
            //控制剩余时间位置；
            PassedTime.Top = this.Height  - 70;
            PassedTime.Left = this.Width / 2 - 100;
            //控制剩余雷数位置
            UnMarkedMines.Top = this.Height - 70;
            UnMarkedMines.Left = PassedTime.Right + 30;
            //控制已用时间位置
            times.Left = PassedTime.Left + 40;
            times.Top = PassedTime.Top + 5;
            //控制剩余雷数位置
            LeftCount.Left = times.Right + 55;
            LeftCount.Top = times.Top;

            Form1_Paint(sender, test);

        }

        private void 新游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Restart();
        }

        #region 难度选择

        //初级
        private void toolPriminary_Click(object sender, EventArgs e)
        {
            IsFirstDefine = true;
            Level = 1;
            MineCount = 10;
            Boundry = 10;
            //重置雷区
            SetMine(Boundry, MineCount);
            //重绘窗体
            Repaint(sender);
        }

        //中级
        private void toolMiddle_Click(object sender, EventArgs e)
        {
            IsFirstDefine = true;
            Level = 2;
            MineCount = 30;
            Boundry = 16;
            //重置雷区
            SetMine(Boundry, MineCount);
            //重绘窗体
            Repaint(sender);
        }

        //高级
        private void toolHigh_Click(object sender, EventArgs e)
        {
            IsFirstDefine = true;
            Level = 3;
            MineCount = 60;
            Boundry = 20;
            //重置雷区
            SetMine(Boundry, MineCount);
            //重绘窗体
            Repaint(sender); 
        }
        
        //自定义
        private void toolUserDefine_Click(object sender, EventArgs e)
        {
            if (IsFirstDefine)
            {
                UserDefine user = new UserDefine(this);
                user.Show();
                IsFirstDefine = false;
            }
            else
            {
                Level = 4;
                //重置雷区
                SetMine(Boundry, MineCount);
                //重绘窗体
                Repaint(sender);
            }
        }

        #endregion

        //关于扫雷
        private void toolAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        //游戏帮助
        private void toolHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("www.baidu.com \n 百度一下 你就知道");
        }

        public  void Form1_Load(object sender, EventArgs e)
        {
            Repaint(sender);
            SetMine(Boundry, MineCount);
            tPassedTime.Start();
        }

        //窗体绘制
        public void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics g = e.Graphics;
            for (int i = StartX; i <= Boundry * 20; i += 20)
            {
                for (int j = StartY; j <= Boundry * 20 + 20; j += 20)
                {
                    Rectangle rArea = new Rectangle(i, j, 20, 20);
                    Bitmap Area = new Bitmap(MineResources.Area);
                    TextureBrush tBrush = new TextureBrush(Area);
                    g.FillRectangle(tBrush, rArea);
                }
            }

            #region  花样绘图
            //for (int i = StartX; i <= Boundry * 20; i += 40)
            //{
            //    for (int j = StartY; j <= Boundry * 20 + 20; j += 40)
            //    {
            //        Rectangle rArea = new Rectangle(i, j, 20, 20);
            //        Bitmap Area = new Bitmap(MineResources.Area);
            //        TextureBrush tBrush = new TextureBrush(Area);
            //        g.FillRectangle(tBrush, rArea);
            //    }
            //}
            //for (int i = StartX; i <= Boundry * 20; i += 20)
            //{
            //    for (int j = StartY; j <= Boundry * 20 + 20; j += 20)
            //    {
            //        Rectangle rArea = new Rectangle(i, j, 20, 20);
            //        Bitmap Area = new Bitmap(MineResources.Area);
            //        TextureBrush tBrush = new TextureBrush(Area);
            //        g.FillRectangle(tBrush, rArea);
            //    }
            //}

            //for (int i = StartX; i <= Boundry * 20; i += 20)
            //{
            //    for (int j = StartY; j <= Boundry * 20 + 20; j += 20)
            //    {
            //        Rectangle rArea = new Rectangle(i, j, 20, 20);
            //        Bitmap Area = new Bitmap(MineResources.Area);
            //        TextureBrush tBrush = new TextureBrush(Area);
            //        g.FillRectangle(tBrush, rArea);
            //    }
            //}
            #endregion

        }       

        //重新开始新游戏；
        public void Restart()
        {
            object sender = new object();
            EventArgs e = new EventArgs();
            switch (Level)
            {
                case 1:
                    {
                        toolPriminary_Click(sender, e);
                        break;
                    }
                case 2:
                    {
                        toolMiddle_Click(sender, e);
                        break;
                    }
                case 3:
                    {
                        toolHigh_Click(sender, e);
                        break;
                    }
                case 4:
                    {
                        toolUserDefine_Click(sender,e );
                        break;
                    }
            }
        }

        //鼠标松开事件
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            //获取鼠标点击时坐标；
            ClickedPoint.X = e.X;
            ClickedPoint.Y = e.Y;
            //MessageBox.Show(Convert.ToString(ClickedPoint.X) + "  " + Convert.ToString(ClickedPoint.Y));

            //窗体坐标转换成对应二维数组坐标；
            i = (int)((ClickedPoint.Y - StartY) / 20);
            j = (int)((ClickedPoint.X - StartX) / 20);
            i++;
            j++;

            if (e.Button == MouseButtons.Left)
            //{
                LeftDown = false;
            //    MessageBox.Show("Left is UP");
            //}
            else if (e.Button == MouseButtons.Right)
            //{
                RightDown = false;
            //    MessageBox.Show("Right is UP");
            //}
            #region 左击处理
            if (e.Button == MouseButtons.Left && (MineMap[i, j].State != 1))
            {
                MineMap[i, j].isClicked = true;
                if (e.X >= StartX && e.Y >= StartY && (e.X < Boundry * 20 + StartX) && (e.Y < Boundry * 20 + StartY))
                {
                    //MessageBox.Show(Convert.ToString(i) + " " + Convert.ToString(j));
                    if (i >= 1 && j >= 1 && i <= Boundry && j <= Boundry)
                    {
                        //MessageBox.Show(Convert.ToString(MineMap[i - 1, j - 1].AreaType));
                        //JudgePos(i, j,g );//判断坐标对应的数值；
                        gaming.JudgePos(ref MineMap ,Boundry , i, j, g);
                        //GameProcess .DeleRestart d = new GameProcess.DeleRestart (Restart);
                    }
                }
            }
            #endregion

            #region 右击处理
            else if ((e.Button == MouseButtons .Right )&&( MineMap[i, j].isClicked == false))
            {
                //判断当前区域状态 0:未点击  1:插旗  2:问号
                switch (MineMap[i, j].State)
                {
                    case 0:
                        {
                            MineMap[i, j].State = 1;
                            Flags ++;
                            LeftCount.Text  = Convert .ToString ( MineCount - Flags);
                            //MessageBox.Show(Convert.ToString(Flags));
                            Bitmap Flag = new Bitmap(MineResources.flag);
                            gaming.Painting(i, j, Flag,g );
                            if (gaming .JudgeIsWin (ref MineMap ,Boundry ,MineCount ) && (Flags == MineCount ))
                            {
                                tPassedTime.Stop();
                                MessageBox.Show("Congratulations! You win~\n" + "用时：" + Convert .ToString (PassedTimes ) + "  秒");
                                Restart();
                            }
                            break;
                        }
                    case 1:
                        {
                            MineMap[i, j].State = 2;
                            Flags --;
                            LeftCount.Text = Convert.ToString(MineCount - Flags);
                            Bitmap Doubt = new Bitmap(MineResources.doubt);
                            gaming . Painting(i, j, Doubt,g );
                            break;
                        }
                    case 2:
                        {
                            MineMap[i, j].State = 0;
                            Bitmap Area = new Bitmap(MineResources.Area);
                           gaming . Painting(i, j, Area,g );
                            break;
                        }
                }
            }
            #endregion

        }
       

        //实现同时按下鼠标两个按键，自动清除所在块内的区域；
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            int a;
            int b;
            //获取鼠标点击时坐标；
            ClickedPoint.X = e.X;
            ClickedPoint.Y = e.Y;
            //MessageBox.Show(Convert.ToString(ClickedPoint.X) + "  " + Convert.ToString(ClickedPoint.Y));

            //窗体坐标转换成对应二维数组坐标；
            a = (int)((ClickedPoint.Y - StartY) / 20);
            b = (int)((ClickedPoint.X - StartX) / 20);
            a++;
            b++;

            if (e.Button == MouseButtons.Left)
                LeftDown = true;
            else if (e.Button == MouseButtons.Right)
                RightDown = true;


            if (LeftDown && RightDown)
            {
                LeftDown = false;
                RightDown = false;
                //AutoClear(a,b);
                gaming.AutoClear(ref  MineMap,Boundry , a, b,g );
            }
        }

        #region 雷区随鼠标移动的动态画面；
        /// <summary>
        /// 雷区随鼠标移动的动态画面；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            ClickedPoint.X = e.X;
            ClickedPoint.Y = e.Y;
            //MessageBox.Show(Convert.ToString(ClickedPoint.X) + "  " + Convert.ToString(ClickedPoint.Y));
            i = (int)((ClickedPoint.Y - StartY) / 20);
            j = (int)((ClickedPoint.X - StartX) / 20);
            //Rectangle Rec = new Rectangle((j) * 20 + StartX, (i) * 20 + StartY, 20, 20);
            //Bitmap tem = new Bitmap(MineResources.doubt);
            //TextureBrush ee = new TextureBrush(tem);
            //Graphics g = this.CreateGraphics();
            //g.FillRectangle(ee, Rec);
        }
        #endregion

        //记录已用时间；
        public void tPassedTime_Tick(object sender, EventArgs e)
        {
            times.Text = Convert.ToString(PassedTimes);
            PassedTimes += 1;
        }
    }
}

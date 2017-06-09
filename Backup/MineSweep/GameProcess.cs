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
    /// GameProcess类，主要用于处理游戏过程中的各种动作
    /// </summary>
    class GameProcess
    {
        //public delegate   void DeleRestart();

        //判断游戏是否胜利
        public bool JudgeIsWin(ref MineSweep .Form1 .Mine [,] MineMap,int Boundry,int MineCount)
        {
            int AllMines = 0;
            for (int a = 0; a <= Boundry + 1; a++)
            {
                for (int b = 0; b <= Boundry + 1; b++)
                {
                    if ((MineMap[a, b].AreaType == 9) && (MineMap[a, b].State == 1))
                    {
                        AllMines++;
                    }
                }
            }
            if (AllMines == MineCount)
                return true;
            else
                return false;
        }

        //自动清除空白区域
        public void AutoClearBlankArea(ref MineSweep .Form1 .Mine [,] MineMap,int Boundry,int i, int j,Graphics g)
        {
            //Graphics g = this.CreateGraphics();
            if (i >= 1 && j >= 1 && i <= Boundry && j <= Boundry)
            {
                Bitmap Blank = new Bitmap(MineResources.blank);
                TextureBrush NumBrush = new TextureBrush(Blank);
                Rectangle TemRec = new Rectangle((j - 1) * 20 +Form1 . StartX, (i - 1) * 20 + Form1 . StartY, 20, 20);
                g.FillRectangle(NumBrush, TemRec);
                MineMap[i, j].AreaType = -1; //标记已处理过的空白区域，防止递归陷入死循环；
                MineMap[i, j].isClicked = true;

                //从当前块左上角顺时针运用递归方法扫描所有空白区所在块内的所有空白区，并标记；
                //扫描方向示意图；
                // 1            2             3
                // 8    当前空白区域     4
                // 7            6             5
                //以当前区域为节点，递归扫描；  
                //MessageBox.Show(Convert.ToString(MineMap[i - 1, j - 1].AreaType));

                //方向1
                if (MineMap[i - 1, j - 1].AreaType == 0)
                    AutoClearBlankArea(ref MineMap ,Boundry , i - 1, j - 1,g );
                else JudgePos(ref MineMap,Boundry , i - 1, j - 1,g );
           

                //方向2
                if (MineMap[i - 1, j].AreaType == 0)
                    AutoClearBlankArea(ref MineMap, Boundry, i - 1, j, g);
                else JudgePos(ref MineMap, Boundry, i - 1, j, g);

                //方向3
                if (MineMap[i - 1, j + 1].AreaType == 0)
                    AutoClearBlankArea(ref MineMap, Boundry, i - 1, j + 1, g);
                else JudgePos(ref MineMap, Boundry, i - 1, j + 1, g);

                //方向4
                if (MineMap[i, j + 1].AreaType == 0)
                    AutoClearBlankArea(ref MineMap, Boundry, i, j + 1, g);
                else JudgePos(ref MineMap, Boundry, i, j + 1, g);

                //方向5
                if (MineMap[i + 1, j + 1].AreaType == 0)
                    AutoClearBlankArea(ref MineMap, Boundry, i + 1, j + 1, g);
                else JudgePos(ref MineMap, Boundry, i + 1, j + 1, g);

                //方向6
                if (MineMap[i + 1, j].AreaType == 0)
                    AutoClearBlankArea(ref MineMap, Boundry, i + 1, j, g);
                else JudgePos(ref MineMap, Boundry, i + 1, j, g);

                //方向7
                if (MineMap[i + 1, j - 1].AreaType == 0)
                    AutoClearBlankArea(ref MineMap, Boundry, i + 1, j - 1, g);
                else JudgePos(ref MineMap, Boundry, i + 1, j - 1, g);

                //方向8]
                if (MineMap[i, j - 1].AreaType == 0)
                    AutoClearBlankArea(ref MineMap, Boundry, i, j - 1, g);
                else JudgePos(ref MineMap, Boundry, i, j - 1, g);
                
            }
            return;
        }

        //判断所属坐标位置内对应的类型；
        public void JudgePos(ref MineSweep.Form1.Mine[,] MineMap,int Boundry, int i, int j, Graphics g)
        {
            MineMap[i, j].isClicked = true;
            switch (MineMap[i, j].AreaType)
            {
                case 0:  //如果为空区域
                    {
                        //自动清楚所属块内所有空区域
                        //AutoClearBlankArea(i, j);
                        AutoClearBlankArea(ref  MineMap, Boundry, i, j, g);
       
                        break;
                    }

                #region 画出对应的数字图片
                //画出对应的数字图片
                case 1:
                    {
                        Bitmap Num = new Bitmap(MineResources.Num_1);
                        Painting(i, j, Num,g );
                        break;
                    }
                case 2:
                    {
                        Bitmap Num = new Bitmap(MineResources.Num_2);
                        Painting(i, j, Num, g);
                        break;
                    }
                case 3:
                    {
                        Bitmap Num = new Bitmap(MineResources.Num_3);
                        Painting(i, j, Num, g);
                        break;
                    }
                case 4:
                    {
                        Bitmap Num = new Bitmap(MineResources.Num_4);
                        Painting(i, j, Num, g);
                        break;
                    }
                case 5:
                    {
                        Bitmap Num = new Bitmap(MineResources.Num_5);
                        Painting(i, j, Num, g);
                        break;
                    }
                case 6:
                    {
                        Bitmap Num = new Bitmap(MineResources.Num_6);
                        Painting(i, j, Num, g);
                        break;
                    }
                case 7:
                    {
                        Bitmap Num = new Bitmap(MineResources.Num_7);
                        Painting(i, j, Num, g);
                        break;
                    }
                case 8:
                    {
                        Bitmap Num = new Bitmap(MineResources.Num_8);
                        Painting(i, j, Num, g);
                        break;
                    }
                #endregion

                //点到雷，游戏结束
                case 9:
                    {

                        GameOver(ref MineMap ,Boundry , i, j,g );
                        break;
                    }
            }
        }

        //自动清除已标记完的块
        public void AutoClear(ref MineSweep .Form1 .Mine [,] MineMap,int Boundry,int a, int b,Graphics g)
        {
            bool IsGameOver = false;
            int Flags = 0;
            int temi = 0;
            int temj = 0;

            //判断是否满足同时按下条件(所在块内旗数=AreaType)
            if (MineMap[a - 1, b - 1].State == 1) Flags++;
            if (MineMap[a - 1, b].State == 1) Flags++;
            if (MineMap[a - 1, b + 1].State == 1) Flags++;
            if (MineMap[a, b + 1].State == 1) Flags++;
            if (MineMap[a + 1, b + 1].State == 1) Flags++;
            if (MineMap[a + 1, b].State == 1) Flags++;
            if (MineMap[a + 1, b - 1].State == 1) Flags++;
            if (MineMap[a, b - 1].State == 1) Flags++;

            if (a >= 1 && b >= 1 && a <= Boundry && b <= Boundry && MineMap[a, b].AreaType <= Flags)
            {
                //扫描方向示意图；
                // 1            2             3
                // 8    当前空白区域     4
                // 7            6             5

                //方向1
                if (MineMap[a - 1, b - 1].AreaType == 9)
                {
                    if (MineMap[a - 1, b - 1].State != 1)
                    {
                        IsGameOver = true;
                        temi = a - 1;
                        temj = b - 1;
                    }
                }
                else JudgePos(ref MineMap ,Boundry , a - 1, b - 1,g);

                //方向2
                if (MineMap[a - 1, b].AreaType == 9)
                {
                    if (MineMap[a - 1, b].State != 1)
                    {
                        IsGameOver = true;
                        temi = a - 1;
                        temj = b;
                    }
                }
                else JudgePos(ref MineMap, Boundry, a - 1, b, g);

                //方向3
                if (MineMap[a - 1, b + 1].AreaType == 9)
                {
                    if (MineMap[a - 1, b + 1].State != 1)
                    {
                        IsGameOver = true;
                        temi = a - 1;
                        temj = b + 1;
                    }
                }
                else JudgePos(ref MineMap, Boundry, a - 1, b + 1, g);

                //方向4
                if (MineMap[a, b + 1].AreaType == 9)
                {
                    if (MineMap[a, b + 1].State != 1)
                    {
                        IsGameOver = true;
                        temi = a;
                        temj = b + 1;
                    }
                }
                else JudgePos(ref MineMap, Boundry, a, b + 1, g);

                //方向5
                if (MineMap[a + 1, b + 1].AreaType == 9)
                {
                    if (MineMap[a + 1, b + 1].State != 1)
                    {
                        IsGameOver = true;
                        temi = a + 1;
                        temj = b + 1;
                    }
                }
                else JudgePos(ref MineMap, Boundry, a + 1, b + 1, g);

                //方向6
                if (MineMap[a + 1, b].AreaType == 9)
                {
                    if (MineMap[a + 1, b].State != 1)
                    {
                        IsGameOver = true;
                        temi = a + 1;
                        temj = b;
                    }
                }
                else JudgePos(ref MineMap, Boundry, a + 1, b, g);

                //方向7
                if (MineMap[a + 1, b - 1].AreaType == 9)
                {
                    if (MineMap[a + 1, b - 1].State != 1)
                    {
                        IsGameOver = true;
                        temi = a + 1;
                        temj = b - 1;
                    }
                }
                else JudgePos(ref MineMap, Boundry, a + 1, b - 1, g);

                //方向8]
                if (MineMap[a, b - 1].AreaType == 9)
                {
                    if (MineMap[a, b - 1].State != 1)
                    {
                        IsGameOver = true;
                        temi = a;
                        temj = b - 1;
                    }
                }
                else JudgePos(ref MineMap, Boundry, a, b - 1,g);
            }

            if (IsGameOver)
                GameOver(ref MineMap ,Boundry , temi, temj,g );
        }

        //游戏失败
        public void GameOver(ref MineSweep.Form1.Mine[,] MineMap, int Boundry, int i, int j, Graphics g)
        {
            System.Media.SoundPlayer Booming = new System.Media.SoundPlayer(MineResources .Booming );
            Booming.PlayLooping();
            Bitmap InExploded = new Bitmap(MineResources.mine_inexplored);  //被点到的雷
            TextureBrush InExplodedBrush = new TextureBrush(InExploded);

            Bitmap Mines = new Bitmap(MineResources.mine_original);  //未被点到的雷
            TextureBrush tMines = new TextureBrush(Mines);

            Rectangle Rec = new Rectangle((j - 1) * 20 + Form1 . StartX, (i - 1) * 20 +Form1 . StartY, 20, 20);
            g.FillRectangle(InExplodedBrush, Rec);
            //游戏结束，显示雷区内所有雷；
            for (int a = 0; a <= Boundry + 1; a++)
            {
                for (int b = 0; b <= Boundry + 1; b++)
                {
                    if (MineMap[a, b].AreaType == 9)
                    {
                        Rectangle tem = new Rectangle((b) * 20, (a + 1) * 20, 20, 20);
                        g.FillRectangle(tMines, tem);
                    }
                }
            }
            g.FillRectangle(InExplodedBrush, Rec);
            //tPassedTime.Stop();
            MessageBox.Show("Sorry......Game Over!!!", "提示");
            SendKeys.Send("{F5}");
            Booming.Stop();
        }

        //重新绘制
        public void Painting(int i, int j, Bitmap TemBit,Graphics g)
        {
            Rectangle TemRec = new Rectangle((j - 1) * 20 + Form1 . StartX, (i - 1) * 20 + Form1. StartY, 20, 20);
            TextureBrush TemBrush = new TextureBrush(TemBit);
            g.FillRectangle(TemBrush, TemRec);
        }
    }
}

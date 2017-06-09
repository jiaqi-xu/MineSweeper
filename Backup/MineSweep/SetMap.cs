using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweep
{
    class SetMap
    {
        /// <summary>
        /// RandomSetMine();
        /// MarkCount();
        /// </summary>
        /// <param name="MineMap">
        /// 用于随机产生MineCout颗雷，MineMap引用传递，表示雷区；
        /// </param>
        /// <param name="MineCount">
        /// 用于标记所属块内雷数；
        /// </param>
        public void RandomSetMine(ref MineSweep.Form1.Mine[,] MineMap, int MineCount, int Boundry)
        {
            Random RandomSet = new Random();
            int Count = 0;
            int i, j;

            //先重置数组；
            for (i = 0; i <= 21; i++)
            {
                for (j = 0; j <= 21; j++)
                {
                    MineMap[i, j].AreaType = 0;
                    MineMap[i, j].State = 0;
                    MineMap[i, j].isClicked = false;
                }
            }

            while (Count < MineCount)
            {
                //通过随机一个数组坐标来确定雷，减少循环次数；
                i = RandomSet.Next(1, Boundry);
                j = RandomSet.Next(1, Boundry);
                if (MineMap[i, j].AreaType != 9)
                {
                    MineMap[i, j].AreaType = 9;
                    Count++;
                }
            }
        }
        public void MarkCount(ref MineSweep.Form1.Mine[,] MineMap, int Boundry)
        {
            int tem = 0; //临时变量，记录所属块内雷数；

            #region 原始方案
            //扫描分三种模式 :
            //    1、四个顶角(3个区域) 
            //    2、四条边(5个区域)
            //    3、内部(8个区域)

            //#region 左上角
            //if (MineMap[0, 0] != 9)
            //{
            //    if (MineMap[0, 1] == 9) tem++;
            //    if (MineMap[1, 0] == 9) tem++;
            //    if (MineMap[1, 1] == 9) tem++;
            //    MineMap[0, 0] = tem;
            //    tem = 0;
            //}
            //#endregion

            //#region 右上角
            //if (MineMap[0, MineCount - 1] != 9)
            //{
            //    if (MineMap[0, MineCount - 2] == 9) tem++;
            //    if (MineMap[1, MineCount - 2] == 9) tem++;
            //    if (MineMap[1, MineCount - 1] == 9) tem++;
            //    MineMap[0, MineCount - 1] = tem;
            //    tem = 0;
            //}
            //#endregion

            //#region 左下角
            //if (MineMap[MineCount - 1, 0] != 9)
            //{
            //    if (MineMap[MineCount -2, 0] == 9) tem++;
            //    if (MineMap[MineCount -2, 1] == 9) tem++;
            //    if (MineMap[MineCount -1, 1] == 9) tem++;
            //    MineMap[MineCount - 1, 0] = tem;
            //    tem = 0;
            //}
            //#endregion

            //#region 右下角
            //if (MineMap[MineCount - 1, MineCount - 1] != 9)
            //{
            //    if (MineMap[MineCount - 1, MineCount - 2] == 9) tem++;
            //    if (MineMap[MineCount -2, MineCount - 2] == 9) tem++;
            //    if (MineMap[MineCount -1, MineCount - 1] == 9) tem++;
            //    MineMap[MineCount - 1, MineCount - 1] = tem;
            //    tem = 0;
            //}
            //#endregion

            //#region 上排
            //for (int j = 1; j <= MineCount - 2; j++)
            //{
            //    tem = 0;
            //    if (MineMap[0, j] != 9)
            //    {
            //        if (MineMap[0, j - 1] == 9) tem++;
            //        if (MineMap[0, j + 1] == 9) tem++;
            //        if (MineMap[1, j - 1] == 9) tem++;
            //        if (MineMap[1, j] == 9) tem++;
            //        if (MineMap[1, j + 1] == 9) tem++;
            //        MineMap[0, j] = tem;
            //    }
            //}
            //#endregion

            //#region 下排
            //for (int j = 1; j <= MineCount - 2; j++)
            //{
            //    tem = 0;
            //    if (MineMap[MineCount - 1, j] != 9)
            //    {
            //        if (MineMap[MineCount - 2, j - 1] == 9) tem++;
            //        if (MineMap[MineCount - 2, j] == 9) tem++;
            //        if (MineMap[MineCount - 2, j + 1] == 9) tem++;
            //        if (MineMap[MineCount - 1, j - 1] == 9) tem++;
            //        if (MineMap[MineCount - 1, j + 1] == 9) tem++;
            //        MineMap[MineCount - 1, j] = tem;
            //    }
            //}
            //#endregion

            //#region 左排
            //for (int i = 1; i <= MineCount - 2; i++)
            //{
            //    tem = 0;
            //    if (MineMap[i, 0] != 9)
            //    {
            //        if (MineMap[i - 1, 0] == 9) tem++;
            //        if (MineMap[i - 1, 1] == 9) tem++;
            //        if (MineMap[i , 1] == 9) tem++;
            //        if (MineMap[i + 1, 0] == 9) tem++;
            //        if (MineMap[i + 1, 1] == 9) tem++;
            //        MineMap[i,0] = tem;
            //    }
            //}
            //#endregion

            //#region 右排
            //for (int i = 1; i <= MineCount - 2; i++)
            //{
            //    tem = 0;
            //    if (MineMap[i,MineCount - 1] != 9)
            //    {
            //        if (MineMap[i - 1,MineCount - 2] == 9) tem++;
            //        if (MineMap[i - 1,MineCount - 1] == 9) tem++;
            //        if (MineMap[i,MineCount - 2] == 9) tem++;
            //        if (MineMap[i + 1,MineCount - 2] == 9) tem++;
            //        if (MineMap[i + 1,MineCount - 1] == 9) tem++;
            //        MineMap[i, MineCount - 1] = tem;
            //    }
            //}
            //#endregion

            //#region 扫描内部
            //for (int i = 1; i <= MineCount - 2; i++)
            //{
            //    for (int j = 1; j <= MineCount - 2; j++)
            //    {
            //        tem = 0;
            //        if (MineMap[i, j] != 9)  //当前区域为雷时，不进行扫描
            //        {
            //            //扫描所属块内8个区域；
            //            if (MineMap [i - 1,j - 1] == 9) tem ++;
            //            if (MineMap [i - 1,j ] == 9) tem ++;
            //            if (MineMap [i - 1,j + 1] == 9) tem ++;
            //            if (MineMap [i ,j - 1] == 9) tem ++;
            //            if (MineMap [i ,j + 1] == 9) tem ++;
            //            if (MineMap [i + 1,j - 1] == 9) tem ++;
            //            if (MineMap [i + 1,j ] == 9) tem ++;
            //            if (MineMap [i + 1,j + 1] == 9) tem ++;
            //            MineMap[i, j] = tem ;
            //        }
            //    }
            //}
            //#endregion

            #endregion

            #region 虚拟边框方案

            //扩大雷区范围，在雷区外加“边界保护罩”，便于处理数据，简化代码；
            //实际雷区处理范围：1<=i,j<=MineCout；
            //无需考虑特殊位置的处理；
            for (int i = 1; i <= Boundry ; i++)
            {
                for (int j = 1; j <= Boundry ; j++)
                {
                    tem = 0;
                    if (MineMap[i, j].AreaType  != 9)  //当前区域为雷时，不进行扫描
                    {
                        //扫描所属块内8个区域；
                        if (MineMap[i - 1, j - 1].AreaType  == 9) tem++;
                        if (MineMap[i - 1, j].AreaType  == 9) tem++;
                        if (MineMap[i - 1, j + 1].AreaType  == 9) tem++;
                        if (MineMap[i, j - 1].AreaType  == 9) tem++;
                        if (MineMap[i, j + 1].AreaType  == 9) tem++;
                        if (MineMap[i + 1, j - 1].AreaType  == 9) tem++;
                        if (MineMap[i + 1, j].AreaType  == 9) tem++;
                        if (MineMap[i + 1, j + 1].AreaType  == 9) tem++;
                        MineMap[i, j].AreaType  = tem;
                    }
                }
            }
            #endregion
        }
    }
}

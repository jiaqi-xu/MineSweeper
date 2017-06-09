using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweep
{
    class Mine
    {
        public int AreaType; //用于记录区域类型  0:空区域  1~8:块内含有的雷数目  9:雷区域；
        public bool isClicked;  //记录当前区域是否被点击过；
        public int State; //记录当前区域状态  0:未处理  1:插旗  2:问号；
    }
}

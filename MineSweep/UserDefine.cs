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
    public partial class UserDefine : Form
    {
        Form1 FromForm;

        public UserDefine(Form1 TemForm)
        {
            InitializeComponent();
            FromForm = TemForm;
        }

        private void UserDefine_Load(object sender, EventArgs e)
        {
            bOK.Enabled = false;
        }

        //确保输入内容不为空
        private void tBoundry_TextChanged(object sender, EventArgs e)
        {
            if ((tBoundry.Text == "") || (tMineCount.Text == ""))
            {
                bOK.Enabled = false;
            }
            else bOK.Enabled = true;
        }

        //确保输入内容不为空
        private void tMineCount_TextChanged(object sender, EventArgs e)
        {
            if ((tBoundry.Text == "") || (tMineCount.Text == ""))
            {
                bOK.Enabled = false;
            }
            else bOK.Enabled = true;
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            int Boundry = 0;
            int MineCount = 0;
            try
            {
                Boundry = Convert.ToUInt16(tBoundry.Text);
                MineCount = Convert.ToUInt16(tMineCount.Text);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                tBoundry.Text = "";
                tMineCount.Text = "";
            }
            if ((Boundry > 20) || (Boundry < 0) || (MineCount > Boundry * Boundry) || (MineCount < 0))
            {
                MessageBox.Show("超出范围，请重新输入！");
            }
            else
            {
                FromForm.Level = 4;
                FromForm.Boundry = Boundry;
                FromForm.MineCount = MineCount;
                FromForm.SetMine(Boundry, MineCount);
                FromForm.Repaint(sender);
                this.Dispose();
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


    }
}

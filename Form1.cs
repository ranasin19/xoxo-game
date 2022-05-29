using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        enum Gametype { X, o };
        Gametype current_gt = Gametype.X;
        int playd_games = 0;
        Button[,] btns = new Button[3, 3];
        public Form1()
        {
            InitializeComponent();
            btns[0, 0] = btn00; btns[0, 1] = btn01; btns[0, 2] = btn02;
            btns[1, 0] = btn10; btns[1, 1] = btn11; btns[1, 2] = btn12;
            btns[2, 0] = btn20; btns[2, 1] = btn21; btns[2, 2] = btn22;
            foreach (Button btn in btns) btn.Click += new EventHandler(btn_click);

        }

        void btn_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Text != "") return;
            playd_games++;
            btn.Text = current_gt.ToString();
            if (IsWin())
            {
                MessageBox.Show("مبروك" + current_gt.ToString() + "لقد فزت");
                NewGame();
                return;
            }
            if (playd_games == 9)
            {
                MessageBox.Show("النتيجه تعادل");
                NewGame();
            }
            switchGame();
        }
        void NewGame()
        {
            foreach (Button btn in btns) btn.Text = "";
            playd_games = 0;
        }
        void switchGame()
        {
            if (current_gt == Gametype.o) current_gt = Gametype.o;
            else current_gt = Gametype.X;
        }

        bool IsWin()
        {
            for (int i = 0; 1 <= 2; i++)
            {
                if (btns[0, i].Text == current_gt.ToString() &&
                    btns[0, i].Text == btns[1, i].Text &&
                    btns[i, 1].Text == btns[2, i].Text)
                    return true;

                if (btns[i, 0].Text == current_gt.ToString() &&
                   btns[i, i].Text == btns[i, 1].Text &&
                   btns[i, 1].Text == btns[i, 2].Text)
                    return true;
            }
            if (btns[0, 0].Text == current_gt.ToString() &&
               btns[0, 0].Text == btns[1, 1].Text &&
                    btns[1, 1].Text == btns[2, 2].Text)
                return true;

            if (btns[0, 2].Text == current_gt.ToString() &&
               btns[0, 2].Text == btns[1, 1].Text &&
               btns[1, 1].Text == btns[2, 0].Text)
                return true;
            return false;
        }
    }
 }

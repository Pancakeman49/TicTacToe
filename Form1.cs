using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool xPlayerTurn = false;
        Button button = new Button();
        Label labelend = new Label();
        string winner;
        public Form1()
        {
            InitializeComponent();
            InitializeGrid();
            InitilazeCells();
            CreateButtonNLabel();
        }

        private void InitializeGrid()
        {
            Grid.Show();
            Grid.BackColor = Color.LightCoral;
            Grid.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
        }
        private void InitilazeCells()
        {
            string labelName;
            for (int i = 1; i < 10; i++)
            {
                labelName = "label" + i;
                Grid.Controls[labelName].Text = string.Empty;
            }
        }
        private void CreateButtonNLabel()
        {
            Controls.Add(button);
            button.Location = new Point(ClientSize.Width / 2 - button.Width, ClientSize.Height / 2 - button.Height);
            button.Width = 100;
            button.Height = 50;
            button.Text = "Reset";
            button.Anchor = (AnchorStyles.None);
            button.Click += new EventHandler(Button_Click);
            button.Hide();

            Controls.Add(labelend);
            labelend.Width = 200;
            labelend.Height = 200;
            labelend.Location = new Point(ClientSize.Width / 2 - button.Width + 10, ClientSize.Height / 2 - button.Height - 50);
            labelend.Font = new Font("Courier New", 30);
            labelend.Anchor = (AnchorStyles.None);
            labelend.Hide();
        }

        private void Player_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            if (label.Text == string.Empty)
            {
                if (xPlayerTurn)
                {
                    label.Text = "X";
                }
                else
                {
                    label.Text = "O";
                }
                WinCheck();
                DrawCheck();
                xPlayerTurn = !xPlayerTurn;
            }

        }
        private void WinCheck()
        {
            string labelName2;
            string vLine = null;
            string hLine1 = null;
            string hLine2 = null;
            string hLine3 = null;
            string dLine1 = null;
            string dLine2 = null;
            for (int i = 1; i < 10; i++)
            {
                labelName2 = "label" + i;
                vLine += Grid.Controls[labelName2].Text;
                if (vLine == "XXX" || vLine == "OOO")
                {
                    GameOver();
                    return;
                }
                if (i == 3 || i == 6)
                {
                    vLine = string.Empty;
                }
                if (i == 1 || i == 4 || i == 7)
                {
                    hLine1 += Grid.Controls[labelName2].Text;
                }
                if (i == 2 || i == 5 || i == 8)
                {
                    hLine2 += Grid.Controls[labelName2].Text;
                }
                if (i == 3 || i == 6 || i == 9)
                {
                    hLine3 += Grid.Controls[labelName2].Text;        // this is worse than just writing all the options label2 == labe2 && label2 == label3 ...
                }
                if (i == 1 || i == 5 || i == 9)
                {
                    dLine1 += Grid.Controls[labelName2].Text;
                }
                if (i == 3 || i == 5 || i == 7)
                {
                    dLine2 += Grid.Controls[labelName2].Text;
                }
                if (hLine1 == "XXX" || hLine1 == "OOO" || 
                    hLine2 == "XXX" || hLine2 == "OOO" || 
                    hLine3 == "XXX" || hLine3 == "OOO" || 
                    dLine1 == "XXX" || dLine1 == "OOO" || 
                    dLine2 == "XXX" || dLine2 == "OOO")
                {
                    GameOver();
                    return;
                }
            }
        }
        private void DrawCheck()
        {
            if (label1.Text != string.Empty &&
                label2.Text != string.Empty &&
                label3.Text != string.Empty &&
                label4.Text != string.Empty &&
                label5.Text != string.Empty &&
                label6.Text != string.Empty &&
                label7.Text != string.Empty &&
                label8.Text != string.Empty && // i hate this
                label9.Text != string.Empty)
            {
                labelend.Text = "Draw :(";
                GameReset();
            }
        }
        private void GameOver()
        {
            if (xPlayerTurn)
            {
                winner = "X";
            }
            else
            {
                winner = "O";
            }
            labelend.Text = winner + " Wins";
            GameReset();
        }
        private void GameReset()
        {
            Grid.Hide();
            button.Show();
            labelend.Show();

        }
        private void Button_Click(object sender, EventArgs e)
        {
            InitializeGrid();
            InitilazeCells();
            button.Hide();
            labelend.Hide();
        }
    }
}

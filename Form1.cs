using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Diagnostics;
using System.Linq;
using System.Media;
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
            Grid.BackColor = Color.Transparent;
            Grid.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
        }
        private void InitilazeCells()
        {
            string pictureName;
            for (int i = 1; i < 10; i++)
            {
                pictureName = "pictureBox" + i;
                Grid.Controls[pictureName].Tag = string.Empty;
                Grid.Controls[pictureName].BackColor = Color.Transparent;

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
            labelend.Location = new Point(ClientSize.Width / 2 - button.Width - 9, ClientSize.Height / 2 - button.Height - 50);
            labelend.Font = new Font("Javanese Text", 30);
            labelend.Anchor = (AnchorStyles.None);
            labelend.Hide();

            labelbord.Anchor = (AnchorStyles.Top);
            labelbord.Location = new Point(ClientSize.Width / 2 - labelbord.Width - 20, 0);
            if (xPlayerTurn)
            {
                labelbord.Text = "O's Turn";
            }
            else
            {
                labelbord.Text = "X's Turn";
            }
        }

        private void Player_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            if (picture.Tag == string.Empty)
            {
                if (xPlayerTurn)
                {
                    labelbord.Text = "O's Turn";
                    picture.Tag = "X";
                }
                else
                {
                    labelbord.Text = "X's Turn";
                    picture.Tag = "O";
                }
                PlaySound("Click");
                WinCheck();
                DrawCheck();
                xPlayerTurn = !xPlayerTurn;
                
            }

        }
        private void WinCheck()
        {
            string pictureName2;
            string vLine = null;
            string hLine1 = null;
            string hLine2 = null;
            string hLine3 = null;
            string dLine1 = null;
            string dLine2 = null;
            for (int i = 1; i < 10; i++)
            {
                pictureName2 = "pictureBox" + i;
                vLine += Grid.Controls[pictureName2].Tag;
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
                    hLine1 += Grid.Controls[pictureName2].Tag;
                }
                if (i == 2 || i == 5 || i == 8)
                {
                    hLine2 += Grid.Controls[pictureName2].Tag;
                }
                if (i == 3 || i == 6 || i == 9)
                {
                    hLine3 += Grid.Controls[pictureName2].Tag;        // this is worse than just writing all the options label2 == labe2 && label2 == label3 ...
                }                                                    // stupid code
                if (i == 1 || i == 5 || i == 9)                      // i dont like it 
                {                                                    // ugh
                    dLine1 += Grid.Controls[pictureName2].Tag;        // TIC TAC TOE TIME
                }                                                    //         #         #
                if (i == 3 || i == 5 || i == 7)                      //         #         #
                {                                                    //         #         #
                    dLine2 += Grid.Controls[pictureName2].Tag;        //         #         #
                }                                                    //#############################
                if (hLine1 == "XXX" || hLine1 == "OOO" ||            //         #         #
                    hLine2 == "XXX" || hLine2 == "OOO" ||            //         #         #
                    hLine3 == "XXX" || hLine3 == "OOO" ||            //         #         #
                    dLine1 == "XXX" || dLine1 == "OOO" ||            //         #         #
                    dLine2 == "XXX" || dLine2 == "OOO")              //#############################
                {                                                    //         #         #
                    GameOver();                                      //         #         #
                    return;                                          //         #         #
                }                                                    //         #         #
            }
        }
        private void DrawCheck()
        {
            if (pictureBox1.Tag != string.Empty &&
                pictureBox2.Tag != string.Empty &&
                pictureBox3.Tag != string.Empty &&
                pictureBox4.Tag != string.Empty &&
                pictureBox5.Tag != string.Empty &&
                pictureBox6.Tag != string.Empty &&
                pictureBox7.Tag != string.Empty &&
                pictureBox8.Tag != string.Empty && // i hate this
                pictureBox9.Tag != string.Empty)
            {
                PlaySound("Draw");
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
            labelbord.Hide();
            button.Show();
            labelend.Show();

        }
        private void Button_Click(object sender, EventArgs e)
        {
            InitializeGrid();
            InitilazeCells();
            button.Hide();
            labelend.Hide();
            labelbord.Show();
            SoundPlayer player = new SoundPlayer();
            player.Stop();
        }
        private void PlaySound(string soundName)
        {
            System.IO.Stream str = (System.IO.Stream)Properties.Resources.ResourceManager.GetObject(soundName);
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();
        }












        //private void ChangeCellColors(Label labelOne, Label labelTwo, Label labelThree, Color color)                      /// ignore
        //{
        //    labelOne.BackColor = color;
        //    labelTwo.BackColor = color;
        //    labelThree.BackColor = color;
        //}
        //private void checksomething()
        //{
        //    if (label1.Text == label2.Text && label1.Text == label3.Text && label1.Text != "")
        //    {
        //        ChangeCellColors(label1, label2, label3, Color.Purple);
        //  }
        //}

        private void secret_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
        }
    }
    
}

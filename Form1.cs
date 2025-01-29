using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XO_Game.Properties;

namespace XO_Game
{
    public partial class Form1 : Form
    {
        stGame Game;
        public enum enWinner
        {
            enGameInProcces = 0,enPlayer1=1,enPlayer2=2,enDraw=3
        }
        public enum enTurn
        {
         Player1= 0 ,Player2=1   
        }

        public struct stGame
        {
            public byte RoundNum;
            public enTurn Turn;
            public enWinner Winner;
            
        }
        public Form1()
        {
            InitializeComponent();
            Game.Turn = enTurn.Player1;
            Game.Winner = enWinner.enGameInProcces;
            Game.RoundNum = 0;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color Black = Color.White;
            Pen pen = new Pen(Black,10);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
             //herizontal
            e.Graphics.DrawLine(pen,200,150,575,150);
            e.Graphics.DrawLine(pen,200,250,575,250);
            //vertical
            e.Graphics.DrawLine(pen, 325, 75, 325, 325);
            e.Graphics.DrawLine(pen, 450, 75, 450, 325);
        }

        public bool Cheak3ButtomValues(Button B1,Button B2,Button B3)
        {
            return (B1.Tag == B2.Tag && B1.Tag == B3.Tag)? (B1.Tag.ToString() != "?")? true:false : false;
        }
        public void MAkeWinButton(Button B1, Button B2, Button B3)
        {
            B1.BackColor = Color.Green;
            B2.BackColor = Color.Green;
            B3.BackColor = Color.Green;

            End_Game();

            Game.Winner = (Game.Turn == enTurn.Player1)?enWinner.enPlayer2 :enWinner.enPlayer1;
        }

        public void End_Game()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
        }
        public void Cheak_Win()
        {
            //first raw 
            if (Cheak3ButtomValues(button1, button2, button3))
            {
                MAkeWinButton(button1,button2,button3);
            }
            //Second raw 
            if (Cheak3ButtomValues(button4, button5, button6))
            {
                MAkeWinButton(button4, button5, button6);
            }
            //Third raw 
            if (Cheak3ButtomValues(button7, button8, button9))
            {
                MAkeWinButton(button7, button8, button9);
            }
            //first Coul 
            if (Cheak3ButtomValues(button3, button6, button9))
            {
                MAkeWinButton(button3, button6, button9);
            }
            //second Coul 
            if (Cheak3ButtomValues(button2, button5, button8))
            {
                MAkeWinButton(button2, button5, button8);
            }
            //Thied Coul 
            if (Cheak3ButtomValues(button1, button4, button7))
            {
                MAkeWinButton(button1, button4, button7);
            }
            //first Dial 
            if (Cheak3ButtomValues(button1, button5, button9))
            {
                MAkeWinButton(button1, button5, button9);
            }
            //first raw 
            if (Cheak3ButtomValues(button3, button5, button7))
            {
                MAkeWinButton(button3, button5, button7);
            }
        }

        public void ChangeButton(Button B)
        {
            if (B.Tag.ToString() == "?") {
                if (Game.Turn == enTurn.Player1)
                {
                    B.BackgroundImage = Resources.X;
                    B.Tag = "X";
                    Game.Turn = enTurn.Player2;
                    labTurn.Text = "Player 2";
                    ++Game.RoundNum;
                    Cheak_Win();
                }
                else
                {
                    B.BackgroundImage = Resources.O;
                    B.Tag = "O";
                    Game.Turn = enTurn.Player1;
                    labTurn.Text = "Player 1";
                    ++Game.RoundNum;
                    Cheak_Win();
                }
            }
            else
            {
                MessageBox.Show("You Can\'t Choosse this","ERROR choose",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (Game.Winner != enWinner.enGameInProcces)
            {
                labWinner.Text = (Game.Winner == enWinner.enPlayer1) ? "Player 1" : "Player 2";
                labWinner.Left = 60;
            }else if(Game.RoundNum == 9)
            {
                Game.Winner = enWinner.enDraw;
                labWinner.Text = "Draw";
                labWinner.Left = 75;
                End_Game();
            }
        }
        private void button_Click(object sender, EventArgs e)
        {
            ChangeButton((Button) sender);
        }

        public void RestBottom(Button B)
        {
            B.Enabled = true;
            B.Tag = "?";
            B.BackgroundImage = Resources.question_mark_96;
            B.BackColor = Color.Transparent;
        }
        public void RestGame()
        {
            Game.Turn = enTurn.Player1;
            Game.Winner = enWinner.enGameInProcces;
            Game.RoundNum = 0;
            labWinner.Text = "Game In Procces";
            labWinner.Left = 20;
            labTurn.Text = "Player 1";

            RestBottom(button1);
            RestBottom(button2);
            RestBottom(button3);
            RestBottom(button4);
            RestBottom(button5);
            RestBottom(button6);
            RestBottom(button7);
            RestBottom(button8);
            RestBottom(button9);

        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure ! you want restart", "RESTART", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                RestGame();
            }
        }
    }
}

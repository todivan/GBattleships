using GBattleships.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GBattleships
{
    public partial class Form1 : Form
    {
        private Battleships _battleships = new Battleships();

        public Form1()
        {
            InitializeComponent();
            _battleships = new Battleships();
            consoleLog.Text = $"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}: Application_start{Environment.NewLine}";
            Logger.TextArea = consoleLog;
            coordinatesBox.Enabled = false;
            buttonFire.Enabled = false;
            this.AcceptButton = buttonFire;
        }

        

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void playerBoard_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.LightBlue, e.CellBounds);

            var filed = _battleships.PlayerBoard.GetField(e.Row,e.Column);
            if(filed != null)
            {
                if (filed.IsShip)
                {
                    var rectangle = e.CellBounds;
                    rectangle.Inflate(-1, -1);
                    ControlPaint.DrawBorder3D(e.Graphics, rectangle, Border3DStyle.Raised, Border3DSide.All); // 3D border
                }
                else
                {
                    var rectangle = e.CellBounds;
                    ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Black, ButtonBorderStyle.Inset);}

                if (filed.IsHit && filed.IsShip)
                {
                    e.Graphics.FillRectangle(Brushes.Red, e.CellBounds);
                }
                else if (filed.IsHit)
                {
                    e.Graphics.FillRectangle(Brushes.Black, e.CellBounds);
                }
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;

            _battleships.Start();
            Logger.Info("GameStarted");

            coordinatesBox.Enabled = true;
            buttonFire.Enabled = true;

            playerBoard.Refresh();
            computerBoard.Refresh();

            this.ActiveControl = coordinatesBox;
        }

        private void buttonFire_Click(object sender, EventArgs e)
        {
            FireCommand fireCommand = new FireCommand(coordinatesBox.Text);

            if (fireCommand.IsValid)
            {

                _battleships.PlayerTurn(fireCommand);
                Logger.Info($"Payer turn {coordinatesBox.Text}");
                computerBoard.Refresh();

                if (_battleships.IsGameOver())
                {
                    FinishGame(isPlayerWinner: true);
                }
                else
                {
                    var commnad = _battleships.ComputerTurn();
                    Logger.Info($"Computer turn {commnad.GetInput()}");
                    playerBoard.Refresh();
                    if (_battleships.IsGameOver())
                    {
                        FinishGame(isPlayerWinner: false);
                    }
                }
            }
            else
            {
                MessageBox.Show("Coordinates are invalid");
                return;
            }

            coordinatesBox.Text = "";
            this.ActiveControl = coordinatesBox;
        }

        private void FinishGame(bool isPlayerWinner)
        {
            string winner = isPlayerWinner ? "Player" : "Computer";
            Logger.Info($"Winer is {winner} !!!!");
            startButton.Enabled = true;
            coordinatesBox.Enabled = false;
            buttonFire.Enabled = false;

            if (isPlayerWinner)
            {
                MessageBox.Show("Congratulation you are WINNER !!!");
            }
            else
            {
                MessageBox.Show("Unfortunately the computer was better this time.");
            }
        }

        private void computerBoard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void computerBoard_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.LightBlue, e.CellBounds);

            //This can enable visibility for ships on computer board
            bool computerBoardVisibility = false;

            var filed = _battleships.ComputerBoard.GetField(e.Row, e.Column);
            if (filed != null)
            {
                var rectangle = e.CellBounds;
                //rectangle.Inflate(-1, -1);
                ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Black, ButtonBorderStyle.Inset);

                if (filed.IsShip && computerBoardVisibility)
                {
                    rectangle = e.CellBounds;
                    rectangle.Inflate(-1, -1);
                    ControlPaint.DrawBorder3D(e.Graphics, rectangle, Border3DStyle.Raised, Border3DSide.All); // 3D border
                }

                if (filed.IsHit && filed.IsShip)
                {
                    e.Graphics.FillRectangle(Brushes.Red, e.CellBounds);
                }
                else if(filed.IsHit)
                {
                    e.Graphics.FillRectangle(Brushes.Black, e.CellBounds);
                }
            }
        }
    }
}

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
                    //rectangle.Inflate(-1, -1);
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
                    FinishGame("Player");
                }
                else
                {
                    _battleships.ComputerTurn();
                    Logger.Info("Computer turn");
                    playerBoard.Refresh();
                    if (_battleships.IsGameOver())
                    {
                        FinishGame("Computer");
                    }
                }
            }
            else
            {
                MessageBox.Show("Coordinates are invalid");
                return;
            }

            coordinatesBox.Text = "";
        }

        private void FinishGame(string winner)
        {
            Logger.Info($"Winer is {winner} !!!!");
            startButton.Enabled = true;
            coordinatesBox.Enabled = false;
            buttonFire.Enabled = false;
        }

        private void computerBoard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void computerBoard_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.LightBlue, e.CellBounds);

            var filed = _battleships.ComputerBoard.GetField(e.Row, e.Column);
            if (filed != null)
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
                    //rectangle.Inflate(-1, -1);
                    ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Black, ButtonBorderStyle.Inset);
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

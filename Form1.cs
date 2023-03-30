using GBattleships.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            Logger.TextArea = consoleLog;
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

                if (filed.IsHit)
                {
                    e.Graphics.FillRectangle(Brushes.Red, e.CellBounds);
                }
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;

            

            _battleships.Start();
            Logger.Info("GameStarted");

            playerBoard.Refresh();

            while (!_battleships.IsGmaeOver())
            {
                while(!_battleships.PlayerTurn())
                {
                    
                }

                if(!_battleships.IsGmaeOver())
                {
                    _battleships.ComputerTurn();
                }
            }

            //board.Add(new BoardFiled() { Row = 6, Column = 6, IsHit = true, IsShip = true });

            playerBoard.Refresh();

            startButton.Enabled = true;
        }
    }
}

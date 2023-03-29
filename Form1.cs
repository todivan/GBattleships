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
        public Form1()
        {
            InitializeComponent();
            board.Add(new BoardFiled() { Row = 1, Column = 1, IsHit = true, IsShip = true});
            board.Add(new BoardFiled() { Row = 2, Column = 2, IsHit = false, IsShip = true});
            board.Add(new BoardFiled() { Row = 3, Column = 3, IsHit = true, IsShip = false });
            board.Add(new BoardFiled() { Row = 4, Column = 4, IsHit = false, IsShip = false });
            board.Add(new BoardFiled() { Row = 5, Column = 5, IsHit = true, IsShip = true});
        }

        List<BoardFiled> board = new List<BoardFiled>();
        

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.LightBlue, e.CellBounds);

            var filed = board.FirstOrDefault(x => x.Row == e.Row && x.Column == e.Column);
            if(filed != null)
            {
                if (filed.IsShip)
                {
                    var rectangle = e.CellBounds;
                    rectangle.Inflate(-1, -1);
                    ControlPaint.DrawBorder3D(e.Graphics, rectangle, Border3DStyle.Raised, Border3DSide.All); // 3D border
                }
                if (filed.IsHit)
                {
                    e.Graphics.FillRectangle(Brushes.Red, e.CellBounds);

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            board.Add(new BoardFiled() { Row = 6, Column = 6, IsHit = true, IsShip = true });

            tableLayoutPanel1.Refresh();

        }
    }

    internal class BoardFiled
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public bool IsShip { get; set; }
        public bool IsHit { get; set; }
    }
}

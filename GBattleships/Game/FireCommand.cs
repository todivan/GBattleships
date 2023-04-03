using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GBattleships.Game
{
    /// <summary>
    /// Class to carry command and transform from input string to coordinates and vise versa
    /// </summary>
    public class FireCommand
    {
        public int X { get; set; }
        public int Y { get; set; }

        private Dictionary<char, int> _yValues = new Dictionary<char, int>()
        {
            { 'A', 0 },
            { 'B', 1 },
            { 'C', 2 },
            { 'D', 3 },
            { 'E', 4 },
            { 'F', 5 },
            { 'G', 6 },
            { 'H', 7 },
            { 'I', 8 },
            { 'J', 9 },
            { 'a', 0 },
            { 'b', 1 },
            { 'c', 2 },
            { 'd', 3 },
            { 'e', 4 },
            { 'f', 5 },
            { 'g', 6 },
            { 'h', 7 },
            { 'i', 8 },
            { 'j', 9 }
        };

        private Dictionary<char, int> _xValues = new Dictionary<char, int>()
        {
            { '1', 9 },
            { '2', 8 },
            { '3', 7 },
            { '4', 6 },
            { '5', 5 },
            { '6', 4 },
            { '7', 3 },
            { '8', 2 },
            { '9', 1 }
        };

        //private const List<Char> XValues = new List<char>() { '1', '2', '3' };
        public bool IsValid { get; private set; }

        public FireCommand(string input) 
        {
            IsValid = true;

            if (input.Length ==0)
            { 
                IsValid = false; 
            }

            //Process y
            if (input.Length > 1)
            {
                char y = input[0];

                if (_yValues.ContainsKey(y))
                {
                    Y = _yValues[y];
                }
                else
                {
                    IsValid = false;
                }
            }

            //Process x one digit
            if(input.Length == 2)
            {
                char x = input[1];

                if (_xValues.ContainsKey(x))
                {
                    X = _xValues[x];
                }
                else
                {
                    IsValid = false;
                }
            }

            //Process x two digit (10)
            if (input.Length > 3)
            {
                if (input[1] == '1' && input[2] == 0)
                {
                    X = 0;
                }
                else
                {
                    IsValid = false;
                }
            }
        }

        public FireCommand(int x, int y)
        {
            X = x;
            Y = y;
        }


        public string GetInput()
        {
            var inputX = _xValues.FirstOrDefault(x => x.Value == X).Key;
            var inputY = _yValues.FirstOrDefault(x => x.Value == Y).Key;
            
            return inputY.ToString() + (inputX == '\0' ? "10" : inputX.ToString());
        }
    }
}

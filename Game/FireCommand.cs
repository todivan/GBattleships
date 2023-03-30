using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBattleships.Game
{
    internal class FireCommand
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
        };

        private Dictionary<char, int> _xValues = new Dictionary<char, int>()
        {
            { '1', 0 },
            { '2', 1 },
            { '3', 2 },
            { '4', 3 },
            { '5', 4 },
            { '6', 5 },
            { '7', 6 },
            { '8', 7 },
            { '9', 8 }
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
                    X = 9;
                }
                else
                {
                    IsValid = false;
                }
            }
        }

    }
}

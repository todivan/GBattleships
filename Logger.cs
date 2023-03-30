﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GBattleships
{
    internal class Logger
    {
        public static TextBox TextArea { get; set;}

        public static void Info(string logLine)
        {
            TextArea.Text = TextArea.Text + $"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}: {logLine}{Environment.NewLine}";
            TextArea.Refresh();
        }
    }
}

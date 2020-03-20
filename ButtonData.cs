using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class ButtonData
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public ButtonData(string name, string text)
        {
            this.Name = name;
            this.Text = text;
        }
    }
}

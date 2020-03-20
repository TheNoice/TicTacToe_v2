using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public class ComputerButtonSearch
    {
        public string Name4Search { get; set; }
        public string Text4Search { get; set; }

        public bool NameContainsString(ButtonData button)
        {
            return button.Name.Contains(Name4Search);
        }

        public bool NameContainsString(Button button) //если доделать Rules, то там не нужна будет эта перегрузка
        {
            return button.Name.Contains(Name4Search);
        }

        public bool TextContainsString(ButtonData button)
        {
            if (Text4Search == "")
            {
                return button.Text == string.Empty;
            }
            else
            {
                return button.Text.Contains(Text4Search);
            }
        }

        public bool TextContainsString(Button button) //если доделать Rules, то там не нужна будет эта перегрузка
        {
            if (Text4Search == "")
            {
                return button.Text == string.Empty;
            }
            else
            {
                return button.Text.Contains(Text4Search);
            }
        }

    }
}

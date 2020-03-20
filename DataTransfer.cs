using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public class DataTransfer
    {
        public List<ButtonData> OccupiedButtonsData { get; set; }
        public List<ButtonData> FreeButtonsData { get; set; }
        public List<ButtonData> DiagonalButtonsData { get; set; }


        public List<Button> OccupiedButtons { get; set; }
        public List<Button> FreeButtons { get; set; }

        public DataTransfer(List<Button> occupiedButtons, List<Button> freeButtons, List<Button> diagonalButtons)
        {
            OccupiedButtonsData = new List<ButtonData>(TransferButtonsData(occupiedButtons));
            FreeButtonsData = new List<ButtonData>(TransferButtonsData(freeButtons));
            DiagonalButtonsData = new List<ButtonData>(GetDiagonalsData(diagonalButtons));

            OccupiedButtons = occupiedButtons;
            FreeButtons = freeButtons;

            Computer computer = new Computer(OccupiedButtonsData, FreeButtonsData, DiagonalButtonsData);
            computer.ComputerTurn();
            UpdateButtonsData(computer.OccupiedButtonsData);


        }

        private List<ButtonData> TransferButtonsData(List<Button> occupiedOrFreeButtons)
        {
            if (occupiedOrFreeButtons.Any())
            {
                List<ButtonData> buttonsData = new List<ButtonData>();

                for (int i = 0; i < occupiedOrFreeButtons.Count; i++)
                {
                    buttonsData.Add(new ButtonData(occupiedOrFreeButtons[i].Name, occupiedOrFreeButtons[i].Text));
                }
                return buttonsData;
            }
            else
            {
                return new List<ButtonData>();
            }
        }

        private List<ButtonData> GetDiagonalsData(List<Button> diagonalButtons)
        {
            List<ButtonData> diagonalButtonsData = new List<ButtonData>();

            for (int i = 0; i < diagonalButtons.Count; i++)
            {
                diagonalButtonsData.Add(new ButtonData(diagonalButtons[i].Name, diagonalButtons[i].Text));
            }
            return diagonalButtonsData;
        }


        public void UpdateButtonsData(List<ButtonData> occupiedButtonsData)
        {
            for (int i = 0; i < occupiedButtonsData.Count; i++)
            {
                ComputerButtonSearch cbs = new ComputerButtonSearch();
                cbs.Name4Search = occupiedButtonsData[i].Name;
                int positionInButtons = OccupiedButtons.FindIndex(cbs.NameContainsString);
                if (positionInButtons < 0)
                {
                    positionInButtons = FreeButtons.FindIndex(cbs.NameContainsString);
                    OccupiedButtons.Add(FreeButtons[positionInButtons]);
                    OccupiedButtons[OccupiedButtons.Count - 1].Text = "O";
                    FreeButtons.Remove(FreeButtons[positionInButtons]);
                }
            }
        }

    }
}

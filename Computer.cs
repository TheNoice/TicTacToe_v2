using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Computer
    {
        public List<ButtonData> OccupiedButtonsData { get; set; }
        public List<ButtonData> FreeButtonsData { get; set; }

        public List<ButtonData> DiagonalButtonsData { get; set; }

        public Computer(List<ButtonData> occupiedButtonsData, List<ButtonData> freeButtonsData, List<ButtonData> diagonalButtonsData)
        {
            OccupiedButtonsData = new List<ButtonData>(occupiedButtonsData);
            FreeButtonsData = new List<ButtonData>(freeButtonsData);
            DiagonalButtonsData = new List<ButtonData>(diagonalButtonsData);
        }

        public void ComputerTurn()
        {
            ComputerButtonSearch cbs = new ComputerButtonSearch();
            bool turnComplete = false;
            ComputerFirstTurn(cbs, out turnComplete);
            if (turnComplete == true)
            {
                return;
            }
            else
            {
                ComputerFindsBestLine(cbs);
            }

        }

        private void ComputerFindsBestLine(ComputerButtonSearch cbs)
        {
            bool turnComplete = false;
            bool canWin = true;
            List<ButtonData> tmpOccupiedButtons = new List<ButtonData>(OccupiedButtonsData);
            int buttonWithO;
            while (!turnComplete)
            {
                cbs.Text4Search = "O";
                buttonWithO = tmpOccupiedButtons.FindIndex(cbs.TextContainsString);
                if (buttonWithO >= 0 && canWin == true)
                {
                    ComputerFirstOptionTurn(tmpOccupiedButtons, cbs, out turnComplete);
                    if (turnComplete)
                    {
                        return;
                    }
                    else
                    {
                        canWin = false;
                    }
                }
                if (buttonWithO >= 0 && canWin == false)
                {
                    ComputerSecondOptionTurn(tmpOccupiedButtons, buttonWithO, cbs, out turnComplete);
                    if (turnComplete)
                    {
                        return;
                    }
                    tmpOccupiedButtons.Remove(tmpOccupiedButtons[buttonWithO]);
                }
                else
                {
                    Random computerChoice = new Random();
                    int computerTurn = computerChoice.Next(0, FreeButtonsData.Count);
                    FreeButtonsData[computerTurn].Text = "O";
                    OccupiedButtonsData.Add(FreeButtonsData[computerTurn]);
                    FreeButtonsData.Remove(FreeButtonsData[computerTurn]);
                    turnComplete = true;
                }
            }
        }

        private void ComputerFirstOptionTurn(List<ButtonData> tmpOccupiedButtons, ComputerButtonSearch cbs, out bool turnComplete)
        {
            if (ComputerTryWinOrCounter(tmpOccupiedButtons, cbs, "X", "O"))
            {
                turnComplete = true;
            }
            else if (ComputerTryWinOrCounter(tmpOccupiedButtons, cbs, "O", "X"))
            {
                turnComplete = true;
            }
            else
            {
                turnComplete = false;
            }
        }

        private bool ComputerTryWinOrCounter(List<ButtonData> tmpOccupiedButtons, ComputerButtonSearch cbs, string buttonTextexclude, string textForSearch)
        {
            //buttonTextexclude X - win, O - counter
            //textForSearch O - win, X - counter 
            bool turnComplete = false;
            int buttonWithText = 0;
            List<ButtonData> tmpOccupiedButtons2 = new List<ButtonData>(tmpOccupiedButtons);
            cbs.Text4Search = buttonTextexclude;
            tmpOccupiedButtons2.RemoveAll(cbs.TextContainsString);

            while (tmpOccupiedButtons2.Any())
            {
                if (tmpOccupiedButtons2[buttonWithText].Name.Contains("Bot"))
                {
                    cbs.Name4Search = "Bot";
                    turnComplete = BestHorizontalAndVerticalTurn(cbs, textForSearch);
                    if (turnComplete)
                    {
                        return true;
                    }
                }
                if (tmpOccupiedButtons2[buttonWithText].Name.Contains("Mid"))
                {
                    cbs.Name4Search = "Mid";
                    turnComplete = BestHorizontalAndVerticalTurn(cbs, textForSearch);
                    if (turnComplete)
                    {
                        return true;
                    }
                }
                if (tmpOccupiedButtons2[buttonWithText].Name.Contains("Top"))
                {
                    cbs.Name4Search = "Top";
                    turnComplete = BestHorizontalAndVerticalTurn(cbs, textForSearch);
                    if (turnComplete)
                    {
                        return true;
                    }
                }
                if (tmpOccupiedButtons2[buttonWithText].Name.Contains("Left"))
                {
                    cbs.Name4Search = "Left";
                    turnComplete = BestHorizontalAndVerticalTurn(cbs, textForSearch);
                    if (turnComplete)
                    {
                        return true;
                    }
                }
                if (tmpOccupiedButtons2[buttonWithText].Name.Contains("Center"))
                {
                    cbs.Name4Search = "Center";
                    turnComplete = BestHorizontalAndVerticalTurn(cbs, textForSearch);
                    if (turnComplete)
                    {
                        return true;
                    }
                }
                if (tmpOccupiedButtons2[buttonWithText].Name.Contains("Right"))
                {
                    cbs.Name4Search = "Right";
                    turnComplete = BestHorizontalAndVerticalTurn(cbs, textForSearch);
                    if (turnComplete)
                    {
                        return true;
                    }
                }
                if (ButtonIsDiagonal(tmpOccupiedButtons2[buttonWithText]))
                {
                    turnComplete = BestDiagonalTurn(cbs, textForSearch);
                    if (turnComplete)
                    {
                        return true;
                    }
                }
                if (tmpOccupiedButtons2.Any())
                {
                    tmpOccupiedButtons2.Remove(tmpOccupiedButtons2[buttonWithText]);
                }
            }
            return false;
        }

        private void ComputerSecondOptionTurn(List<ButtonData> tmpOccupiedButtons, int buttonWithO, ComputerButtonSearch cbs, out bool turnComplete)
        {
            if (tmpOccupiedButtons[buttonWithO].Name.Contains("Bot"))
            {
                cbs.Name4Search = "Bot";
                turnComplete = HorizontalAndVerticalTurn(cbs);
                if (turnComplete)
                {
                    return;
                }
            }
            if (tmpOccupiedButtons[buttonWithO].Name.Contains("Mid"))
            {
                cbs.Name4Search = "Mid";
                turnComplete = HorizontalAndVerticalTurn(cbs);
                if (turnComplete)
                {
                    return;
                }
            }
            if (tmpOccupiedButtons[buttonWithO].Name.Contains("Top"))
            {
                cbs.Name4Search = "Top";
                turnComplete = HorizontalAndVerticalTurn(cbs);
                if (turnComplete)
                {
                    return;
                }
            }
            if (tmpOccupiedButtons[buttonWithO].Name.Contains("Left"))
            {
                cbs.Name4Search = "Left";
                turnComplete = HorizontalAndVerticalTurn(cbs);
                if (turnComplete)
                {
                    return;
                }
            }
            if (tmpOccupiedButtons[buttonWithO].Name.Contains("Center"))
            {
                cbs.Name4Search = "Center";
                turnComplete = HorizontalAndVerticalTurn(cbs);
                if (turnComplete)
                {
                    return;
                }
            }
            if (tmpOccupiedButtons[buttonWithO].Name.Contains("Right"))
            {
                cbs.Name4Search = "Right";
                turnComplete = HorizontalAndVerticalTurn(cbs);
                if (turnComplete)
                {
                    return;
                }
            }
            if (ButtonIsDiagonal(tmpOccupiedButtons[buttonWithO]))
            {
                turnComplete = DiagonalTurn();
                if (turnComplete)
                {
                    return;
                }
            }
            else
            {
                turnComplete = false;
            }
        }

        private bool HorizontalAndVerticalTurn(ComputerButtonSearch cbs)
        {
            List<ButtonData> rowOrColumnFreeButtons = FreeButtonsData.FindAll(cbs.NameContainsString);
            if (rowOrColumnFreeButtons.Count == 2)
            {
                rowOrColumnFreeButtons[0].Text = "O";
                OccupiedButtonsData.Add(rowOrColumnFreeButtons[0]);
                FreeButtonsData.Remove(rowOrColumnFreeButtons[0]);
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool BestHorizontalAndVerticalTurn(ComputerButtonSearch cbs, string textForSearch)
        {
            cbs.Text4Search = textForSearch;
            List<ButtonData> rowOrColumnFreeButtons = FreeButtonsData.FindAll(cbs.NameContainsString); //на условном боте 1 фри кнопка
            List<ButtonData> allOccupiedBySomeoneButtons = OccupiedButtonsData.FindAll(cbs.TextContainsString); //все кнопки с O
            List<ButtonData> rowOrColumnOccupiedBySomeoneButtons = allOccupiedBySomeoneButtons.FindAll(cbs.NameContainsString); //на условном боте 2 кнопки с O
            if (rowOrColumnFreeButtons.Count == 1 && rowOrColumnOccupiedBySomeoneButtons.Count == 2)
            {
                rowOrColumnFreeButtons[0].Text = "O";
                OccupiedButtonsData.Add(rowOrColumnFreeButtons[0]);
                FreeButtonsData.Remove(rowOrColumnFreeButtons[0]);
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ButtonIsDiagonal(ButtonData b)
        {
            if (b.Name == "buttonBotLeft" || b.Name == "buttonBotRight" || b.Name == "buttonTopRight" || b.Name == "buttonTopLeft" || b.Name == "buttonMidCenter")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool DiagonalTurn()
        {
            int firstDiagonalCount = 0;
            int secondDiagonalCount = 0;
            for (int i = 0; i < DiagonalButtonsData.Count; i++)
            {
                if (DiagonalButtonsData[i].Name == "buttonBotLeft" || DiagonalButtonsData[i].Name == "buttonMidCenter" || DiagonalButtonsData[i].Name == "buttonTopRight")
                {
                    if (DiagonalButtonsData[i].Text == string.Empty)
                    {
                        firstDiagonalCount++;
                    }
                }
            }
            for (int i = 0; i < DiagonalButtonsData.Count; i++)
            {
                if (DiagonalButtonsData[i].Name == "buttonBotRight" || DiagonalButtonsData[i].Name == "buttonMidCenter" || DiagonalButtonsData[i].Name == "buttonTopLeft")
                {
                    if (DiagonalButtonsData[i].Text == string.Empty)
                    {
                        firstDiagonalCount++;
                    }
                }
            }
            if (firstDiagonalCount == 3 || secondDiagonalCount == 3)
            {
                ComputerButtonSearch cbs = new ComputerButtonSearch();
                cbs.Name4Search = "buttonMidCenter";
                int midButtonNumber = FreeButtonsData.FindIndex(cbs.NameContainsString);
                OccupiedButtonsData.Add(FreeButtonsData[midButtonNumber]);
                FreeButtonsData.Remove(FreeButtonsData[midButtonNumber]);
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool BestDiagonalTurn(ComputerButtonSearch cbs, string textForSearch)
        {
            //List<ButtonData> firstDiagonal = new List<ButtonData>() { buttonBotLeft, buttonMidCenter, buttonTopRight };
            //List<ButtonData> secondDiagonal = new List<ButtonData>() { buttonBotRight, buttonMidCenter, buttonTopLeft };
            List<ButtonData> firstDiagonal = new List<ButtonData>(DiagonalButtonsData);
            int tmpPosition1 = 0;
            int tmpPosition2 = 0;
            for (int i = 0; i < DiagonalButtonsData.Count; i++)
            {
                if (firstDiagonal[i].Name == "buttonBotRight")
                {
                    tmpPosition1 = i;
                }
                if (firstDiagonal[i].Name == "buttonTopLeft")
                {
                    tmpPosition2 = i;
                }
            }
            firstDiagonal.Remove(firstDiagonal[tmpPosition1]);
            firstDiagonal.Remove(firstDiagonal[tmpPosition2]);

            List<ButtonData> secondDiagonal = new List<ButtonData>(DiagonalButtonsData);
            for (int i = 0; i < DiagonalButtonsData.Count; i++)
            {
                if (secondDiagonal[i].Name == "buttonBotLeft")
                {
                    tmpPosition1 = i;
                }
                if (secondDiagonal[i].Name == "buttonTopRight")
                {
                    tmpPosition2 = i;
                }
            }
            secondDiagonal.Remove(secondDiagonal[tmpPosition1]);
            secondDiagonal.Remove(secondDiagonal[tmpPosition2]);


            cbs.Text4Search = "";
            List<ButtonData> firstDiagonalFreeButtons = firstDiagonal.FindAll(cbs.TextContainsString);
            List<ButtonData> secondDiagonalFreeButtons = secondDiagonal.FindAll(cbs.TextContainsString);

            cbs.Text4Search = textForSearch;
            List<ButtonData> firstDOccupiedBySomeoneButtons = firstDiagonal.FindAll(cbs.TextContainsString);
            List<ButtonData> secondDOccupiedBySomeoneButtons = secondDiagonal.FindAll(cbs.TextContainsString);

            if (firstDiagonalFreeButtons.Count == 1 && firstDOccupiedBySomeoneButtons.Count == 2)
            {
                firstDiagonalFreeButtons[0].Text = "O";
                OccupiedButtonsData.Add(firstDiagonalFreeButtons[0]);
                FreeButtonsData.Remove(firstDiagonalFreeButtons[0]);
                return true;
            }
            else if (secondDiagonalFreeButtons.Count == 1 && secondDOccupiedBySomeoneButtons.Count == 2)
            {
                secondDiagonalFreeButtons[0].Text = "O";
                OccupiedButtonsData.Add(secondDiagonalFreeButtons[0]);
                FreeButtonsData.Remove(secondDiagonalFreeButtons[0]);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ComputerFirstTurn(ComputerButtonSearch cbs, out bool turnComplete)
        {
            cbs.Text4Search = "O";
            int buttonWithO = OccupiedButtonsData.FindIndex(cbs.TextContainsString);
            if (buttonWithO < 0)
            {
                Random computerChoice = new Random();
                int computerTurn = computerChoice.Next(0, FreeButtonsData.Count);
                FreeButtonsData[computerTurn].Text = "O";
                OccupiedButtonsData.Add(FreeButtonsData[computerTurn]);
                FreeButtonsData.Remove(FreeButtonsData[computerTurn]);
                turnComplete = true;
            }
            else
            {
                turnComplete = false;
            }
        }
    }
}

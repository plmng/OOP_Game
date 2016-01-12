namespace Application2.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private const string BoardTop = "\n    0123456789\n   ----------";
        private const string BoardBottom = "\n   ----------";
        private const string WelcomeMessage = "\nLet's play Minesweeper.\n\n Try your luck to find fields without mines.\n\n";
        private const string FinishedMessage = "\nThis game is finished.\nNew Game is starting!\n";
        private const string CommandsMessage = " The command \"Top\" shows the ratings.\n The command \"Restart\" launches a new game,\n The command \"Exit\" closes the game.";
        private const string PlayMessage = "\nSelect a row and a column: ";
        private const string ExitMessage = "\nBye Bye";
        private const string WrongCommandMessage = "\nWrong command!\n";
        private const string GiveNameMessage = "\nGive your name for the winning list: ";
        private const string WinMessage = "Welldone! You have opened {0} cells without shed a drop of blood.";
        private const string LoseMessage = "You lose, but you died like a hero with {0} points.";

        private const int BoardRows = 5;
        private const int BoardColumns = 10;
        private const int BombCount = 15;
        private const int FreeFieldCount = 35;
        private const int RatingsListToDisplayLength= 6;

        private readonly Random _random = new Random();

        private int _openedCells;
        private GameStage _gameStage;
        private char[,] _gameFieldMask;
        private char[,] _gameField;
        private List<Player> _champions;
        private UserInput _userInput;
        
        public Engine()
        {
            this._gameStage = GameStage.NewGame;
            this._champions = new List<Player>();
        }

        public void Run()
        {
            do
            {
                switch (this._gameStage)
                {
                    case GameStage.NewGame:
                        this.GameInit();
                        break;
                    case GameStage.Playing:
                        this.GameLoop();
                        break;
                    case GameStage.Win:
                    case GameStage.Lose:
                        this.GameResults();
                        break;
                    case GameStage.Quit:
                        Console.WriteLine(ExitMessage);
                        break;
                }

            } 

            while (this._gameStage != GameStage.Quit);
        }


        /// <summary>
        /// initial game setup;
        /// </summary>
        private void GameInit()
        {
            this._userInput = new UserInput();
            this._gameFieldMask = this.PopulateGameField('?');
            this._gameField = MineGameField();
            this._openedCells = 0;
            this._gameStage = GameStage.Playing;

            Console.WriteLine(WelcomeMessage);
            Console.WriteLine(CommandsMessage);
            this.DrawGameBoard(this._gameFieldMask);
        }

        /// <summary>
        /// Base Game Loop - reads commands from the console and executes them
        /// </summary>
        private void GameLoop()
        {
            Console.Write(PlayMessage);
            var command = Console.ReadLine().Trim();
            this._userInput.Command = TryParceCommand(command);
            this.ExecuteCommand(this._userInput.Command);
        }

       
        private void GameResults()
        {
            Console.WriteLine(this._gameStage == GameStage.Win
                ? string.Format(WinMessage, this._openedCells)
                : string.Format(LoseMessage, this._openedCells));

            this.DrawGameBoard(this._gameField);
            
            this.GetRatings();
            
            this._gameStage = GameStage.NewGame;
        }

        private char[,] MineGameField()

        {
            var field = this.PopulateGameField('-');
               
            var numbersList = new List<int>();
            
            while (numbersList.Count < BombCount)
            {
                var number = _random.Next(50);
                if (!numbersList.Contains(number))
                {
                    numbersList.Add(number);
                }
            }

            foreach (var number in numbersList)
            {
                var row = number / BoardColumns;
                var column = number % BoardColumns;

                if (column == 0 && number != 0)
                {
                    row--;
                    column = BoardColumns;
                }
                else
                {
                    column++;
                }

                field[row, column - 1] = '*';
            }

            return field;
        }

        private void ExecuteCommand(string command)
        {
            switch (command)
            {
                case "top":
                    this.GetRatings();
                    break;
                case "restart":
                    this._gameStage = GameStage.NewGame;
                    break;
                case "exit":
                    this._gameStage = GameStage.Quit;
                    break;
                case "turn":
                    this.CheckForBomb();
                    break;
                default:
                    Console.WriteLine(WrongCommandMessage);
                    break;
            }
        }
        
        private char[,] PopulateGameField(char symbol)
        {
            var board = new char[BoardRows, BoardColumns];

            for (var row = 0; row < BoardRows; row++)
            {
                for (var column = 0; column < BoardColumns; column++)
                {
                    board[row, column] = symbol;
                }
            }

            return board;
        }
        
        private void GetNearBombsCount()
        {
            var bombsNearCount = 0;
            var row = this._userInput.Row;
            var column = this._userInput.Column;
    
            if (row - 1 >= 0)
            {
                if (this._gameField[row - 1, column] == '*')
                {
                    bombsNearCount++;
                }
            }

            if (row + 1 < BoardRows)
            {
                if (this._gameField[row + 1, column] == '*')
                {
                    bombsNearCount++;
                }
            }

            if (column - 1 >= 0)
            {
                if (this._gameField[row, column - 1] == '*')
                {
                    bombsNearCount++;
                }
            }

            if (column + 1 < BoardColumns)
            {
                if (this._gameField[row, column + 1] == '*')
                {
                    bombsNearCount++;
                }
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (this._gameField[row - 1, column - 1] == '*')
                {
                    bombsNearCount++;
                }
            }

            if ((row - 1 >= 0) && (column + 1 < BoardColumns))
            {
                if (this._gameField[row - 1, column + 1] == '*')
                {
                    bombsNearCount++;
                }
            }

            if ((row + 1 < BoardRows) && (column - 1 >= 0))
            {
                if (this._gameField[row + 1, column - 1] == '*')
                {
                    bombsNearCount++;
                }
            }

            if ((row + 1 < BoardRows) && (column + 1 < BoardColumns))
            {
                if (this._gameField[row + 1, column + 1] == '*')
                {
                    bombsNearCount++;
                }
            }

            var bombsCount = char.Parse(bombsNearCount.ToString());
            this._gameField[row, column] = bombsCount;
            this._gameFieldMask[row, column] = bombsCount;
        } //ok
        
        private void CheckForBomb()
        {
            switch (this._gameField[this._userInput.Row, this._userInput.Column])
            {
                case '*':
                    this._gameStage = GameStage.Lose;
                    break;
                case '-':
                    this.GetNearBombsCount();
                    this._openedCells++;
                    if (FreeFieldCount == this._openedCells)
                    {
                        this._gameStage = GameStage.Win;
                    }
                    else
                    {
                        this.DrawGameBoard(this._gameFieldMask);
                    }
                    break;
            }
        }

        private string TryParceCommand(string command)
        {
            if (command.Length >= 3)
            {
                var userInputRow=0;
                var userInputColumn = 0;

                var validRowIsEntered = int.TryParse(command[0].ToString(), out userInputRow) && userInputRow <= BoardRows;
                var validColumnIsEntered = int.TryParse(command[2].ToString(), out userInputColumn) && userInputColumn <= BoardColumns;
                
                if (validRowIsEntered && validColumnIsEntered)
                {
                    command = "turn";
                    this._userInput.Row = userInputRow;
                    this._userInput.Column = userInputColumn;
                }

            }

            return command;
        }
        
        private void DrawGameBoard(char[,] board)
        {
            Console.WriteLine(BoardTop);

            for (var row = 0; row < BoardRows; row++)
            {
                Console.Write("{0} | ", row);
                for (var column = 0; column < BoardColumns; column++)
                {
                    Console.Write(board[row, column]);
                }
                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine(BoardBottom);
        }

        private void GetRatings()
        {
            Console.WriteLine(GiveNameMessage);
            var userInputName = Console.ReadLine();

            this._champions.Add(new Player()
            {
                Name = userInputName,
                Points = this._openedCells
            });

            Console.WriteLine("\nRatings:");

            if (this._champions.Count > 0)
            {
                var index = 1;
                var championsRatings = this._champions
                                            .OrderByDescending(champion => champion.Points)
                                            .ThenBy(champion => champion.Name)
                                            .Take(RatingsListToDisplayLength);
            
                foreach (var champion in championsRatings)
                {
                    Console.WriteLine("{0}. {1} --> {2} cells", index++, champion.Name, champion.Points);
                }

                Console.WriteLine();
            }

            else
            {
                Console.WriteLine("No champions\n");
            }

            Console.WriteLine(FinishedMessage);
        } 
        
    }

}

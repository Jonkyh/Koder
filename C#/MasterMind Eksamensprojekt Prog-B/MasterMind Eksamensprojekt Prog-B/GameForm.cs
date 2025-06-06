using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections;

namespace MasterMind_Eksamensprojekt_Prog_B
{
    public partial class GameForm : Form
    {
        public GameForm(string nameoftheplayer, bool continueGame)
        {
            InitializeComponent();
            playerName = nameoftheplayer;
            continueMyGame = continueGame;
        }
        //Create a bool variable for the player's desire to resume a game
        bool continueMyGame;
        //Create a variable for the playername
        string playerName;

        //Creates variables to timer
        double mmTime;
        double extraTime;

        //Computer' color combination 
        //the numbers that the player has to guess
        int[] gMasterMind = new int[4];

        //Creates a 2d array that stores all values ​​from the player's bid
        //for color combination
        int[,] mmArray2D = new int[14, 4];

        //Checklist
        //2d array for all our checklists (black and white, 2.1)
        int[,] checkmmArray2D = new int[14, 4];
        bool[] bMMCheck = new bool[4] { true, true, true, true};

        //Create a variabel for BrushColor;
        Brush brushColor;

        //create object for stopwatch
        Stopwatch mmStopWatch = new Stopwatch();

        //number of the row
        int numRowArr = 0;

        //created to check if the player wants to restart
        bool restartBool;

        //square to the colored squares
        int xposi, yposi, widthDraw, heightDraw;

        //square to Check
        int xCposi = 10, yCposi = 10, CwidthDraw = 20, CheightDraw = 20;

        private void GameForm_Load(object sender, EventArgs e)
        {
            //Checks if the player wants to take a normal game or a continegame
            if (continueMyGame == true)
            {
                ContinueGame();
            }
            if (continueMyGame == false)
            {
                gMasterMindGuess();
            }

            //Print your name
            lblName1.Text = "Welcome " + playerName;

            //Read Highscore:
            ReadHighScore();
        }

        //Makes an array that contains various
        //numbers that the player has to guess
        private void gMasterMindGuess()
        {
            //Minimum number
            int Min = 1;
            //Max number, and random.next(max) cant be 7
            //(max 6)(0<= x < 7)
            int Max = 7;

            //Instantiate random number generator
            Random randNum = new Random();

            //Creates a random color combination for the player
            for (int i = 0; i < gMasterMind.Length; i++)
            {
                gMasterMind[i] = randNum.Next(Min, Max);
            }
        }

        private void Coloredsquares()
        {
            //Square starter for colored squares
            xposi = 10;
            yposi = 10;
            widthDraw = 30;
            heightDraw = 30;
        }

        private void CheckSquares()
        {
            //Square-starter for check squares
            xCposi = 10 + 40 * mmArray2D.GetLength(1);
            yCposi = 10;
            CwidthDraw = 20;
            CheightDraw = 20;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Drawing the mastermind and checklist
            DrawMasterMind();
            DrawCheck();

            //Goes through checks when, for example, continuing the game
            //only works when resuming the game, because then numRowArr is greater than 0
            for (int i = 0; i < numRowArr; i++)
            {
                CheckArr(i);
            }

            //invisible start-button
            btnStart.Visible = false;
            //visible colors-gropbox
            groupBox1.Visible = true;

            //Declared that the player does not want to restart the game
            restartBool = false;

            //Start the stopwatch
            mmStopWatch.Start();
        } 

        private void GamePlay(int num101)
        {
            //Creates a new instance of this class
            NumberInArrayClass UpdataArr = new NumberInArrayClass();
            mmArray2D = UpdataArr.UpdateArr(mmArray2D, num101, numRowArr);

            //Draw MasterMind
            DrawMasterMind();
        }

        private void DrawMasterMind()
        {
            //Restarts squares positions
            Coloredsquares();

            //creates an object to draw on canvas
            Graphics gObject = canvas1.CreateGraphics();

            //creates an object to draw with a pen
            Pen GrayPen = new Pen(Color.LightGray, 1);

            //two forerunners for each rows and columns
            for (int i = 0; i < mmArray2D.GetLength(0); i++)
            {               
                //yposition is controlled by rows and 10 is air between the boxes
                yposi = 10 + 40 * i;

                //restarts x-position 
                xposi = 10;

                for (int j = 0; j < mmArray2D.GetLength(1); j++)
                {
                    //Adding x-position to the next 
                    xposi = 10 + 40 * j;

                    //Uses switch statement to color the player's bid
                    //for the correct color combination
                    switch (mmArray2D[i, j])
                    {
                        case 1: //Red
                            brushColor = new SolidBrush(Color.Red);
                            gObject.FillRectangle(brushColor, xposi, yposi, widthDraw, heightDraw);
                            break;
                        case 2: //Blue
                            brushColor = new SolidBrush(Color.Blue);
                            gObject.FillRectangle(brushColor, xposi, yposi, widthDraw, heightDraw);
                            break;
                        case 3: //Green
                            brushColor = new SolidBrush(Color.Green);
                            gObject.FillRectangle(brushColor, xposi, yposi, widthDraw, heightDraw);
                            break;
                        case 4: //Pink
                            brushColor = new SolidBrush(Color.Pink);
                            gObject.FillRectangle(brushColor, xposi, yposi, widthDraw, heightDraw);
                            break;
                        case 5: //Yellow
                            brushColor = new SolidBrush(Color.Yellow);
                            gObject.FillRectangle(brushColor, xposi, yposi, widthDraw, heightDraw);
                            break;
                        case 6: //Orange
                            brushColor = new SolidBrush(Color.Orange);
                            gObject.FillRectangle(brushColor, xposi, yposi, widthDraw, heightDraw);
                            break;
                        default: //Pen
                            gObject.DrawRectangle(GrayPen, xposi, yposi, widthDraw, heightDraw);
                            break;
                    }
                }               
            }
        }
    
        private void DrawCheck()
        {
            //creates an object to draw on canvas
            Graphics gObject = canvas1.CreateGraphics();

            //creates an object to draw with a pen
            Pen GrayPen = new Pen(Color.LightGray, 1);

            for (int i = 0; i < checkmmArray2D.GetLength(0); i++)
            {
                //Creates a new instance of CountCheck-class
                //The class counts after black and white after each lines
                CountCheck checks = new CountCheck(checkmmArray2D, i);

                //Restart checks squares
                CheckSquares();

                //yposition for Check squares is controlled by rows (i)
                //and 10 is air between the boxes
                yCposi = 10 + 40 * i;
                
                for (int g = 0; g < checks.Black(); g++)
                {
                    brushColor = new SolidBrush(Color.Black);
                    gObject.FillRectangle(brushColor, xCposi, yCposi + 5, CwidthDraw, CheightDraw);
                    //Shifts x-position after each drawing of square
                    xCposi = xCposi + CwidthDraw;
                }

                for (int h = 0; h < checks.White(); h++)
                {
                    brushColor = new SolidBrush(Color.White);
                    gObject.FillRectangle(brushColor, xCposi, yCposi + 5, CwidthDraw, CheightDraw);
                    //Shifts x-position after each drawing of square
                    xCposi = xCposi + CwidthDraw;
                }

                for (int j = 0; j < checks.Nothing(); j++)
                {
                    gObject.DrawRectangle(GrayPen, xCposi, yCposi + 5, CwidthDraw, CheightDraw);
                    //Shifts x-position after each drawing of square
                    xCposi = xCposi + CwidthDraw;
                }
                //Check if you have 4 blacks = then you have won
                if (checks.Black() == gMasterMind.Length)
                {
                    //Stop the stopwatch
                    mmStopWatch.Stop();

                    //updates high score
                    PrintToHighscore(); 

                    //Make a messagebox
                    string message = "Congratulations you have won" + "\r\n" +
                                     "Do you want to play again?";
                    string title = "Close Window";

                    //Creates a message box with a yes and no button
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons);

                    if (result == DialogResult.Yes)
                    {
                        //"true" is declared that the player wants to restart the game
                        restartBool = true;
                        break;
                    }
                    else if (result == DialogResult.No)
                    {
                        //Closing the form
                        this.Close();
                    }                    
                }
            }
        }
        
        private void CheckArr(int rownums)
        {
            //Restart bMMCheck
            bMMCheck = new bool[4] { true, true, true, true };

            //Checking for the right colors with the right placement(black)
            for (int i = 0; i < mmArray2D.GetLength(1); i++)
            {
                if (mmArray2D[rownums, i] == gMasterMind[i])
                {
                    //Makes sure the number is used
                    bMMCheck[i] = false;

                    //Sets 2 = black
                    checkmmArray2D[rownums, i] = 2;
                }
            }

            //Checking for the right colors but wrong placement (white)
            for (int i = 0; i < mmArray2D.GetLength(1); i++)
            {
                //Checking if the number from 'checklist' is available
                if (checkmmArray2D[rownums, i] == 0)
                {
                    for (int j = 0; j < mmArray2D.GetLength(1); j++)
                    {
                        //checks if the number is recorded
                        if (bMMCheck[j])
                        {
                            //check if they is identical
                            if (mmArray2D[rownums, i] == gMasterMind[j])
                            {
                                //Makes sure the number is used
                                bMMCheck[j] = false;
                                checkmmArray2D[rownums, i] = 1;
                                break;
                            }
                        }
                    }
                }
            }   
            
            //Drawing check    
            DrawCheck();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            //Check that we have all 4 guesses
            //Writes '-1' at the end, because Getlength is 4 in total and the last index is 3
            if (mmArray2D[numRowArr,mmArray2D.GetLength(1)-1] != 0)
            {
                //Review the method of checking the player's bids
                CheckArr(numRowArr);
                //adding a number to row
                numRowArr++;

                //checks if the player want to restart
                if (restartBool)
                {
                    //restart the game
                    RestartGame();
                }

                //Checks if you have no more guesses
                if (mmArray2D.GetLength(0) == numRowArr)
                {
                    //A message box pops up giving the player two choices to answer,
                    //yes and no if they want to play again
                    string message = "Unfortunately you have no more guesses" + "\r\n" +
                                     "Do you want to play again?";
                    string title = "Close Window";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.Yes)
                    {
                        RestartGame();
                    }
                    else if (result == DialogResult.No)
                    {
                        this.Close();
                    }
                }
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            //Clear my panel (canvas1)
            canvas1.Refresh();
            //Creates a new instance of this class and convert
            //the latest number to 0
            UndoArrayClass undoarr = new UndoArrayClass();
            mmArray2D = undoarr.UndoArr(mmArray2D, numRowArr);

            //Draw MasterMind
            DrawMasterMind();
            //Draw Check
            DrawCheck();
        }

        private void PrintToHighscore()
        {
            //Creates a sortedlist that always sorts by double, so the fastest player is Nr. 1
            SortedList<double, string> highscore = new SortedList<double, string>();

            //Setting the locations of the file
            string filepath = @"C:\Users\kyhnj\OneDrive\Skrivebord\Eksamensprojekt Programmering B\MasterMind Eksamensprojekt Prog-B\MasterMind Eksamensprojekt Prog-B\Properties\HighScore\HighScore.txt";

            //Read all lines from the file
            string[] lines = File.ReadAllLines(filepath);

            //i starts at 1 as I do not count the first line with(due to text "Second: Name:")
            for (int i = 1; i < lines.Length; i++)
            {
                //split number in between ' '
                string[] hall = lines[i].Split(' ');

                //Adds all names in each variable
                highscore.Add(Convert.ToDouble(hall[0]), hall[1]);
            }
            //Adder the latest name
            highscore.Add(mmTime, playerName);

            //Clear the file
            File.WriteAllText(filepath, String.Empty);

            //Adding extra text
            StreamWriter sw = File.AppendText(filepath);

            //printer "title" on highsvore
            sw.WriteLine("Seconds:  Name: ");

            //Goes through a loop that prints all names from the highscore list
            foreach (var item in highscore)
            {
                sw.WriteLine(item.Key + " " + item.Value);
            }
            sw.Flush();
            sw.Close();

            //Printer highscore using the method
            ReadHighScore();
        }
       
        private void ReadHighScore()
        {
            //Clear textbox for restart
            txtHighScore.Clear();
            //Setting the locations of the file
            string filepath = @"C:\Users\kyhnj\OneDrive\Skrivebord\Eksamensprojekt Programmering B\MasterMind Eksamensprojekt Prog-B\MasterMind Eksamensprojekt Prog-B\Properties\Highscore\HighScore.txt";

            //use the function "File.ReadAllText" for read all the text from the file.
            txtHighScore.Text = File.ReadAllText(filepath);
        }

        private void btnSaveGame_Click(object sender, EventArgs e)
        {
            //Stop the timer
            mmStopWatch.Stop();

            //SaveFiledialog allows you to save the file wherever you want
            //the file is saved in a txt file
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = playerName + "SaveGame"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            //If u have press "Ok"
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //creates a variable that prints to a file
                StreamWriter fs = new StreamWriter(dlg.FileName);

                //Print name
                fs.WriteLine(playerName);

                //Saves time
                mmTime = mmStopWatch.Elapsed.Seconds;

                //Print time
                fs.WriteLine(mmTime);

                //Runner MastermindCode
                foreach (int num in gMasterMind)
                {
                    fs.Write(num);
                }
                fs.WriteLine("");

                for (int i = 0; i < mmArray2D.GetLength(0); i++)
                {
                    for (int j = 0; j < mmArray2D.GetLength(1); j++)
                    {
                        fs.Write(mmArray2D[i, j].ToString());
                    }
                    fs.WriteLine("");
                }
                fs.Close();
                //Closes this form
                this.Close();
            }
            //Starter tiden igen
            mmStopWatch.Start();
        }

        private void ContinueGame()
        {
            //Create variabel fd for OpenFileDialog
            OpenFileDialog fd = new OpenFileDialog();

            //Show file dialog
            DialogResult dr = fd.ShowDialog();

            //Continue if user wants to open file
            if (DialogResult.Cancel != dr)
            {
                //Creates a variable for the filename
                string filepath = fd.FileName;

                //lines contains all lines that are read from the file
                string[] lines = File.ReadAllLines(filepath);

                //Setting the playername from the first line
                playerName = lines[0];

                //Setting the extraTime from the second line
                extraTime = Convert.ToDouble(lines[1]);

                //columns contains all values ​​from a row (columns)
                //Subtracting one as I want to look at the last line.
                string columns1 = lines[lines.Length-1];

                //Loads number of length to newly created array.
                //I subtract 3, due to the first 3 lines (Name, time and "gMasterMind""
                mmArray2D = new int[lines.Length - 3, columns1.Length];

                //I start from 2, as I disregard the first two lines
                for (int i = 2; i < lines.Length; i++)
                {
                    //print all numbers in line to hall
                    string hall = lines[i];

                    //Loads numbers to gMasterMind that the player must guess
                    //i must be 2, as it is on the 3rd line from the file
                    if (i == 2)
                    {
                        for (int j = 0; j < hall.Length; j++)
                        {
                            //Convert char to string and then to int
                            gMasterMind[j] = Convert.ToInt32(hall[j].ToString());
                        }
                    }
                    else
                    {
                        for (int j = 0; j < hall.Length; j++)
                        {
                            //i subtract 3 from i since i have to start at 0
                            mmArray2D[i - 3, j] = Convert.ToInt32(hall[j].ToString());
                        }
                    }
                }
                //Creates a new 2d array to check that measures by the size of mmarray2d
                checkmmArray2D = new int[mmArray2D.GetLength(0), mmArray2D.GetLength(1)];

                // Examines which row we are now working on
                // starts at the 4th line, and therefore i = 3
                for (int i = 3; i < lines.Length; i++)
                {
                    string hall = lines[i];
                    int hallint = Convert.ToInt32(hall[3].ToString());
                    if (hallint == 0)
                    {
                        //I subtract 3 due to the first line being deduced.
                        numRowArr = i - 3;
                        break;
                    }
                }
            }
            //Check if you cancel
            if (DialogResult.Cancel == dr)
            {
                //Closing the form
                this.Close();
            }
        }

        private void RestartGame()
        {
            //Startbutton makes visible
            btnStart.Visible = true;
            //color groupbox makes invisible
            groupBox1.Visible = false;

            //Reset the time
            extraTime = 0;
            mmStopWatch.Reset();

            //Clear my panel (canvas1)
            canvas1.Refresh();

            //Restart time, and color combination and
            //the two 2d arrays that store values ​​from the player's bid
            numRowArr = 0;
            gMasterMindGuess();
            checkmmArray2D = new int[14, 4];
            mmArray2D = new int[14, 4];

            //drawing the mastermind and checklist
            DrawMasterMind();
            DrawCheck();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            //restarts the game using the method
            RestartGame();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //rounds to 2 decimal places
            mmTime = Math.Round(extraTime + mmStopWatch.Elapsed.TotalSeconds, 2);

            //The timer print
            lblTime.Text = mmTime.ToString() + " sekunder.";
        }

        private void BtnHowToPlay_Click(object sender, EventArgs e)
        {
            //Switch GameForm to HowToPlay-form
            HowToPlayForm HTPF = new HowToPlayForm();
            HTPF.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //closing the form
            this.Close();
        }

        private void BtnRed_Click(object sender, EventArgs e)
        {
            //Uses the method to update the array after a bid for a color
            GamePlay(1);
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            GamePlay(2);
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            GamePlay(3);
        }

        private void btnPink_Click(object sender, EventArgs e)
        {
            GamePlay(4);
        }
        private void btnYellow_Click(object sender, EventArgs e)
        {
            GamePlay(5);
        }

        private void btnOrange_Click(object sender, EventArgs e)
        {
            GamePlay(6);
        }
    }
}

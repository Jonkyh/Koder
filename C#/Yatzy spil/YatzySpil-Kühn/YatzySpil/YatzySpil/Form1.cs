using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;


namespace YatzySpil
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //number of times you can roll dice:
        int antalRool = 3;

        int Diceroll;

        Image[] diceImage = new Image[6];
        Image[] diceChoose = new Image[6];

        Random random = new Random();

        //Creating a array for dice
        int[] dice = new int[5] { 0, 0, 0, 0, 0 };

        //Creating a bool array, which checks whether you are holding the dice or not
        bool[] boarr = new bool[5];

        //Creating a resultarray
        int[] diceResult = new int[5] { 0, 0, 0, 0, 0 };

        //Score:
        int yatzyScore;
        string player;

        //HighScores
        string[,] highscore = { { "", "-1000" }, { "", "-1000" }, { "", "-1000" } };

        List<HighScoreClass> Highscore1001 = new List<HighScoreClass>();

        int dims;

        bool twoPair = false;
        bool onePair = false;

        bool harduvalgt = true;

        private void Form1_Load(object sender, EventArgs e)
        {
            RoolTrue();

            //Put the images ind the array
            diceImage[0] = Properties.Resources.dieWhite_border1;
            diceImage[1] = Properties.Resources.dieWhite_border2;
            diceImage[2] = Properties.Resources.dieWhite_border3;
            diceImage[3] = Properties.Resources.dieWhite_border4;
            diceImage[4] = Properties.Resources.dieWhite_border5;
            diceImage[5] = Properties.Resources.dieWhite_border6;

            //Red dice array
            diceChoose[0] = Properties.Resources.dieRed_border1;
            diceChoose[1] = Properties.Resources.dieRed_border2;
            diceChoose[2] = Properties.Resources.dieRed_border3;
            diceChoose[3] = Properties.Resources.dieRed_border4;
            diceChoose[4] = Properties.Resources.dieRed_border5;
            diceChoose[5] = Properties.Resources.dieRed_border6;
        }

        //Creating a method, that make all dice true
        private void RoolTrue()
        {
            boarr[0] = true;
            boarr[1] = true;
            boarr[2] = true;
            boarr[3] = true;
            boarr[4] = true;
        }

        private void btnRollDice_Click(object sender, EventArgs e)
        {
            if (antalRool > 0)
            {
                antalRool--;

                //Printing printer number of strokes
                label6.Text = $"Du har {antalRool} slag tilbage";

                if (boarr[0] == true)
                {
                    RollDice(pb1, 1);
                }
                if (boarr[1] == true)
                {
                    RollDice(pb2, 2);
                }
                if (boarr[2] == true)
                {
                    RollDice(pb3, 3);
                }
                if (boarr[3] == true)
                {
                    RollDice(pb4, 4);
                }
                if (boarr[4] == true)
                {
                    RollDice(pb5, 5);
                }
                //Testing
                DiceResults();
            }
            else
            {
                //If you have used all your 3 strokes, you will be notified
                MessageBox.Show("Du har ikke flere slag");
            }
        }

        //Create a privat method to roll dice
        private void RollDice(PictureBox pb, int tal)
        {
            //Random tal ind i terning x
            dice[tal-1] = random.Next(0, 6);

            //Printer billedet af tallet
            pb.Image = diceImage[dice[tal - 1]];

            //Sætter tallet ind i array
            diceResult[tal - 1] = dice[tal - 1] + 1;
        }

        private void DiceResults()
        {
            for (int i = 0; i < diceResult.Length; i++)
            {
                if (diceResult[i] == 2)
                {
                    onePair = true;
                }
                for (int j = i+1; j < diceResult.Length; j++)
                {
                    if (diceResult[j] == 2)
                    {
                        twoPair = true;
                    }
                }
            }
        }

        //Makes a private method that changes the color of the selected cube
        private void ChooseDice(PictureBox pb, int DiceNumber)
        {
            pb.Image = diceChoose[diceResult[DiceNumber - 1] - 1];
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //Refills number strokes with 3
            antalRool = 3;

            //Enables all boaar true
            RoolTrue();

            //Printing printer number of strokes
            label6.Text = $"Du har {antalRool} slag tilbage";

            harduvalgt = true;
        }
        private void btnHoldDice1_Click(object sender, EventArgs e)
        {
            //Converts the boarr[0] to false
            boarr[0] = false;

            //Uses the method of holding the dice by changing the color of the dice
            ChooseDice(pb1, 1);
        }

        private void btnHoldDice2_Click(object sender, EventArgs e)
        {
            boarr[1] = false;
            ChooseDice(pb2, 2);
        }

        private void btnHoldDice3_Click(object sender, EventArgs e)
        {
            boarr[2] = false;
            ChooseDice(pb3, 3);
        }

        private void btnHoldDice4_Click(object sender, EventArgs e)
        {
            boarr[3] = false;
            ChooseDice(pb4, 4);
        }

        private void btnHoldDice5_Click(object sender, EventArgs e)
        {
            boarr[4] = false;
            ChooseDice(pb5, 5);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            foreach (int item in diceResult)
            {
                textBox1.AppendText(item.ToString());
            }
        }

        private void btnGemScore_Click(object sender, EventArgs e)
        {
            player = txtNameInput.Text;

            yatzyScore = Convert.ToInt32(textBox2.Text);

            //SaveFiledialog allows you to save the file wherever you want
            //the file is saved in a txt file
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter fs = new StreamWriter(dlg.FileName);
                //Printing out
                fs.WriteLine("Hej " + player + "\r\n" + "Dit YatzyScore: " + yatzyScore + "\r\n" + "Gemmes " + DateTime.Now.ToString("dddd , dd MMMM yyyy klokken HH:mm:ss") + "\r\n");

                fs.Flush();
                fs.Close();
            }
            Highscore1001.Add(new HighScoreClass(player, yatzyScore));
        }

        /*public class myComparer : IComparer
        {
            int IComparer.Compare(object xx, object yy)
            {
                HighScoreClass x = (HighScoreClass)xx;
                HighScoreClass y = (HighScoreClass)yy;
                return x.PartScore.CompareTo(y.PartScore);
            }
        }*/

        private void btnSaveHighScore_Click(object sender, EventArgs e)
        {
            /*
            //SaveFiledialog allows you to save the file wherever you want
            //the file is saved in a txt file
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter fs = new StreamWriter(dlg.FileName);

                Highscore1001.Sort();

                //Running the HighScore1001 list through and printing it
                for (int i = 1; i < Highscore1001.Count; i++)
                {
                    fs.WriteLine("Nummer: " + i + "\r\n" + "Navnet er {0} og score er {1}", Highscore1001[i].PartName, Highscore1001[i].PartScore + "\r\n");
                }

                fs.Flush();
                fs.Close();
            }*/

            
            //checks if the score is higher than the previous highscore
            if (Convert.ToInt32(highscore[0, 1]) <= yatzyScore)
            {
                // now making the previos highscore fall down to second place
                highscore[2, 0] = highscore[1, 0];
                highscore[2, 1] = highscore[1, 1];

                // now making the second place on the highscore list fall down to third place
                highscore[1, 0] = highscore[0, 0];
                highscore[1, 1] = highscore[0, 1];
                // sets in our players name and the score he got into the highscores first place.
                highscore[0, 0] = player;
                highscore[0, 1] = Convert.ToString(yatzyScore);
            }
            //checks if the score is higher than the second place on the highscorelist
            else if (Convert.ToInt32(highscore[1, 1]) <= yatzyScore)
            {
                // now making the second place on the highscore list fall down to third place
                highscore[2, 0] = highscore[1, 0];
                highscore[2, 1] = highscore[1, 1];
                // set in our players name and the score he got in the second place on the highscore list.
                highscore[1, 0] = player;
                highscore[1, 1] = Convert.ToString(yatzyScore);
            }
            //checks if the score is higher than the third place on the highscorelist
            else if (Convert.ToInt32(highscore[2, 1]) <= yatzyScore)
            {
                // set in our players name and the score he got in the third place on the highscore list.
                highscore[2, 0] = player;
                highscore[2, 1] = Convert.ToString(yatzyScore);
            }

            // Printing the highscore
            lblHS1.Text = highscore[0, 0] + ": " + highscore[0, 1];
            lblHS2.Text = highscore[1, 0] + ": " + highscore[1, 1];
            lblHS1.Text = highscore[2, 0] + ": " + highscore[2, 1];                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player = txtNameInput.Text;

            yatzyScore = Convert.ToInt32(textBox2.Text);

            Highscore1001.Add(new HighScoreClass(player, yatzyScore));
        }

        private void btnOnePair_Click(object sender, EventArgs e)
        {
            if (harduvalgt == false)
            {
                MessageBox.Show("Du har valgt");
            }
            else if (onePair == true || harduvalgt == true)
            {
                txtOnePair.Text = "4 point";
                harduvalgt = false;
            }
        }

        private void TwoPair_Click(object sender, EventArgs e)
        {
            if (harduvalgt == false)
            {
                MessageBox.Show("Du har valgt");
            }
            else if (twoPair == true || harduvalgt == true)
            {
                txtTwoPair.Text = "6 point";
                harduvalgt = false;
            }
        }

        private void btnOnes_Click(object sender, EventArgs e)
        {
            if (harduvalgt == false)
            {
                MessageBox.Show("Du har valgt");
            }
            else if (harduvalgt == true)
            {
                dims = 0;
                for (int i = 0; i < diceResult.Length; i++)
                {
                    if (diceResult[i] == 1)
                    {
                        dims++;
                    }
                }
                txtEner.Text = dims.ToString();
                harduvalgt = false;
            }
            
        }

        private void btnTwos_Click(object sender, EventArgs e)
        {
            if (harduvalgt == false)
            {
                MessageBox.Show("Du har valgt");
            }
            else if (harduvalgt == true)
            {
                dims = 0;
                for (int i = 0; i < diceResult.Length; i++)
                {
                    if (diceResult[i] == 2)
                    {
                        dims++;
                    }
                }
                txtToer.Text = dims.ToString();
                harduvalgt = false;
            }
        }
    }
}

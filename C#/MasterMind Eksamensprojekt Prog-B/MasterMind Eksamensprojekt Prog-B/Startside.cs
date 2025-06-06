using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterMind_Eksamensprojekt_Prog_B
{
    public partial class Startside : Form
    {
        public Startside()
        {
            InitializeComponent();
            txtName.Text = "Please enter your name";
        }
        //Create variable for playersname
        string player;
        private void btnStart_Click(object sender, EventArgs e)
        {
            //checks that the player has written his name
            if (txtName.Text != "" && txtName.Text != "Please enter your name")
            {
                //Create name to the player
                player = txtName.Text;

                //Switch forms
                GameForm GF = new GameForm(player, false);
                GF.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please enter your name");
            } 
        }

        private void btnHowToPlay_Click(object sender, EventArgs e)
        {
            //Switch form1 to HowToPlay-form
            HowToPlayForm HTPF = new HowToPlayForm();
            HTPF.ShowDialog();
        }

        private void btnContinueGame_Click(object sender, EventArgs e)
        {
            //Switch forms
            GameForm GF = new GameForm("", true);
            GF.ShowDialog();
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            //checks if he has written a name, and if not, then the text is "blank"
            if (txtName.Text == "Please enter your name")
            {
                txtName.Text = "";
                txtName.ForeColor = Color.Black;
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            //if the player has not written the name, then gray text will appear stating that the player is asked to write his name
            if (txtName.Text == "")
            {
                txtName.Text = "Please enter your name";
                txtName.ForeColor = Color.Silver;
            }
        }
    }
}

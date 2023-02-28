using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Flepi_Bird
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 15;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
            meniu_joc.Hide();
        }




        private void endGame()
        {

            gameTimer.Stop();
            p1.Image = Properties.Resources.E_editat;
            p1.BackColor = Color.Transparent;
            meniu_joc.Show();

        }




        private void gameTimer_Tick(object sender, EventArgs e)
        {
            p1.Top += gravity;
            p3.Left -= pipeSpeed;
            p2.Left -= pipeSpeed;
            label1.Text = "Scor: " + score;



            if (p3.Left < -50)
            {

                p3.Left = 400;
                score++;
            }
            if (p2.Left < -136)
            {

                p2.Left = 450;
                //score++;
            }



            if (p1.Bounds.IntersectsWith(p3.Bounds) ||
                p1.Bounds.IntersectsWith(p2.Bounds) ||
                p1.Bounds.IntersectsWith(p4.Bounds) || p1.Top < -25
                )
            {

                endGame();

            }



            if (score > 5)
            {
                pipeSpeed = 15;
            }

        }

        private void gamekeydown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space)
            {

                gravity = -30;
            }
        }

        private void gamekeyup(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space)
            {

                gravity = 15;
            }

        }

        private void labelrestart_Click(object sender, EventArgs e)
        {
            gameTimer.Start();
            meniu_joc.Hide();
            p1.Location = new Point(189, 160);
            p2.Location = new Point(563, 0);
            p3.Location = new Point(498, 330);
            label1.Text = "Scor: 0";
            score = 0;
            p1.Image = Properties.Resources.A;

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}



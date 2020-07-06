using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saper_project_GitHub
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// public strings for Form1
        /// </summary>

        public static string SetValueForWidth = "";
        public static string SetValueForHeight = "";
        public static string SetValueForBombs = "";


        /// <summary>
        /// Checking every Values first if they are numbers
        /// Second if they match the game rules
        /// Creating new Form and setting up the stoper 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void start_click(object sender, EventArgs e)
        {
            int cols;
            int rows;
            int bombs;


            if (int.TryParse(textBox1.Text, out cols))
            {
            }
            else
            {
                MessageBox.Show("Dane muszą być liczbą");
                return;
            }

            if (int.TryParse(textBox2.Text, out rows))
            {
            }
            else
            {
                MessageBox.Show("Dane muszą być liczbą");
                return;
            }

            if (int.TryParse(textBox3.Text, out bombs))
            {
            }
            else
            {
                MessageBox.Show("Dane muszą być liczbą");
                return;
            }


            if (cols < 5)
            {
                MessageBox.Show("Liczba column nie może być mniejsza niż 5!");
                return;
            }
            else if (cols > 20)
            {
                MessageBox.Show("Liczba column nie może być większa niż 20!");
                return;
            }

            if (rows < 5)
            {
                MessageBox.Show("Liczba wierszy nie może być mniejsza niż 5!");
                return;
            }
            else if (rows > 20)
            {
                MessageBox.Show("Liczba wierszy nie może być większa niż 20!");
                return;
            }

            if (bombs < 3)
            {
                MessageBox.Show("Liczba bomb nie może być mniejsza niż 3!");
                return;
            }


            if (bombs > rows * cols - 1)
            {
                MessageBox.Show("Liczba bomb nie może być większa niż liczba pól!");
                textBox3.Text = Convert.ToString(Convert.ToInt32(SetValueForHeight) * Convert.ToInt32(SetValueForWidth) - 1);
                return;
            }

            // Setting Values for form 1 if they passed all conditions
            SetValueForWidth = textBox1.Text;
            SetValueForHeight = textBox2.Text;
            SetValueForBombs = textBox3.Text;

            this.Hide();
            Form1 a1 = new Form1();


            a1.timer1.Enabled = true;

            a1.ShowTime();
            a1.ShowDialog();

        }

        /// <summary>
        /// close aplication when u click Exit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exit_click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Getting values for easy game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_button_click1(object sender, EventArgs e)
        {
            textBox1.Text = "5";
            textBox2.Text = "6";
            textBox3.Text = "4";
        }


        /// <summary>
        /// Getting values for medium game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_button_click2(object sender, EventArgs e)
        {
            textBox1.Text = "6";
            textBox2.Text = "8";
            textBox3.Text = "8";
        }

        /// <summary>
        /// Getting values for hard game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_button_click3(object sender, EventArgs e)
        {
            textBox1.Text = "8";
            textBox2.Text = "10";
            textBox3.Text = "15";
        }

       
    }
}

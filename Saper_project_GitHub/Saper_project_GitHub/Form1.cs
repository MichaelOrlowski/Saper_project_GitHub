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
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializing Form1 
        /// creating TableLayout with rows and columns from Form2
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            int boomset = Convert.ToInt32(Form2.SetValueForBombs);
            int rows = Convert.ToInt32(Form2.SetValueForHeight);
            int cols = Convert.ToInt32(Form2.SetValueForWidth);

            ModifyTableLayout(rows, cols);
            AssignIconsToSquares(boomset, rows, cols);
        }

        /// <summary>
        /// Global variable for checking player actual score
        /// </summary>
        static class Globals
        {
            public static int score = 0;

        }

        /// <summary>
        /// Running the stoper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            IncreaseSeconds();
            ShowTime();
        }

        private short _seconds;

        private void IncreaseSeconds()
        {
            _seconds++;
        }

        /// <summary>
        /// Resseting Timer and showing it on label
        /// </summary>
        public void ShowTime()
        {
            stopwatchlabel.Text = _seconds.ToString("00");
        }

        public static int fontSize = 48;

        /// <summary>
        /// Setting up the Font Size so it always apear
        /// even when squares are very small
        /// </summary>
        /// <param name="rows">Number of Rows</param>
        /// <param name="cols">Number of Columns</param>
        /// <returns> Returns Int Font Size</returns>
        public static int FontSize(int rows, int cols)
        {
            int i = 0;


            if (cols > 15 || rows > 15)
            {
                i = 15;
            }
            else if (cols > 10 || rows > 10)
            {
                i = 22;
            }
            else if (cols > 7 || rows > 7)
            {
                i = 30;
            }
            else
            {
                i = 48;
            }


            return fontSize = i;
        }

        /// <summary>
        /// Adding rows and columns for Table Layout Panel
        /// also setting labels for every square
        /// </summary>
        /// <param name="rows">Number of Rows</param>
        /// <param name="cols">Number of Columns</param>
        private void ModifyTableLayout(int rows, int cols)
        {
            TableLayoutPanel panel = tableLayoutPanel1;

            panel.ColumnCount = cols;
            panel.RowCount = rows;


            for (int i = 0; i <= rows - 5; i++)
            {
                panel.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
            }
            for (int i = 0; i <= cols - 5; i++)
            {
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            }

            for (int j = 0; j < cols * rows; j++)
            {

                panel.Controls.Add(new Label() { Text = null }, j + 1, panel.RowCount - rows - 1);

            }

        }





        /// <summary>
        /// Firstly creating an array containing number of bombs
        /// Secondly for each label setting parameters 
        /// crating a list with random number and then put bombs into random labels from list
        /// assign number of bombs around for each label
        /// </summary>
        /// <param name="boomset">Getting Number of Bombs</param>
        /// <param name="rows">Getting number of rows</param>
        /// <param name="cols">Getting Number of columns</param>
        private void AssignIconsToSquares(int boomset, int rows, int cols)
        {

            counterbombslabel.Text = Convert.ToString(boomset);

            // array with "M" value which represtns bomb icon in Wingdings Font

            string[] bombNumbers = new string[boomset];
            for (int i = 0; i < boomset; i++)
            {
                bombNumbers[i] = "M";
            }

            int labelNumber = 0;

            // Setting parameters for every label (Click, Dock,AutoSize,TextAlig, Name - very important)

            foreach (Control control in tableLayoutPanel1.Controls)
            {

                Label iconLabel = control as Label;
                iconLabel.Name = "label" + (labelNumber + 1);
                iconLabel.Click += new EventHandler(label_Click);
                iconLabel.Dock = DockStyle.Fill;
                iconLabel.AutoSize = false;
                iconLabel.TextAlign = ContentAlignment.MiddleCenter;
                FontSize(rows, cols);
                iconLabel.Font = new Font("Wingdings", fontSize, FontStyle.Bold);
                labelNumber++;


                if (iconLabel != null)
                {
                    iconLabel.ForeColor = iconLabel.BackColor;
                }

            }

            // Select random number for each bomb

            List<int> listNumbers = new List<int>();
            int number;
            Random bombRandom = new Random();

            // Assign bombs to random labels

            for (int i = 0; i < boomset; i++)
            {
                do
                {
                    number = bombRandom.Next(1, (rows * cols + 1));

                } while (listNumbers.Contains(number));
                listNumbers.Add(number);

                var labels = Controls.Find("label" + number, true);
                Label iconLabel = (Label)labels[0] as Label;
                iconLabel.Text = bombNumbers[i];

            }
        }

        private void label_Click(object sender, EventArgs e)
        { }

        }
}

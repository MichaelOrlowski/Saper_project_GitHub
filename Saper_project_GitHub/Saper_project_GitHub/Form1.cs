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
        /// Checking if score is equal to sorce u have to get to win
        /// If it is function shows every bomb,
        /// stoping timer, gives message about win 
        /// and then returns for Form2
        /// </summary>
        /// <param name="toWin">Number u need to score to Win</param>

        private void CheckTheWinner(int toWin)
        {
            if (Globals.score == toWin)
            {
                foreach (Control control in tableLayoutPanel1.Controls)
                {
                    Label iconLabel = control as Label;
                    if (iconLabel.Text == "M")
                    {
                        iconLabel.ForeColor = Color.Black;

                    }
                }
                timer1.Stop();
                MessageBox.Show("Gratulacje! Wygrałeś!");
                Globals.score = 0;
                this.Hide();
                Form2 a1 = new Form2();
                a1.ShowDialog();

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

            //For each label checking the number of bombs around 

            foreach (Control control in tableLayoutPanel1.Controls)
            {

                bool middlecolumn = false;
                bool middlerow = false;
                bool leftfree = false;
                bool rightfree = false;
                bool topfree = false;
                bool botfree = false;

                Label iconLabel = control as Label;
                if (iconLabel.Text == "")
                {
                    string clean = iconLabel.Name.Trim('l', 'a', 'b', 'e');
                    int cleanLabelNumber = Convert.ToInt32(clean);

                    int bombs = 0;

                    //Checking next and previous label for bombs

                    for (int i = 0; i < rows; i++)
                    {
                        if (cleanLabelNumber > (cols * i) + 1 && cleanLabelNumber < (cols * i) + cols)
                        {
                            middlecolumn = true;

                            var labelnext = Controls.Find("label" + (cleanLabelNumber + 1), true);
                            var labelprev = Controls.Find("label" + (cleanLabelNumber - 1), true);
                            Label iconLabelnext = (Label)labelnext[0] as Label;
                            Label iconLabelprev = (Label)labelprev[0] as Label;
                            if (iconLabelnext.Text == "M")
                            {
                                bombs += 1;
                            }
                            if (iconLabelprev.Text == "M")
                            {
                                bombs += 1;
                            }


                        }
                        else if (cleanLabelNumber == (cols * i) + cols)
                        {
                            leftfree = true;

                            var labelprev = Controls.Find("label" + (cleanLabelNumber - 1), true);
                            Label iconLabelprev = (Label)labelprev[0] as Label;
                            if (iconLabelprev.Text == "M")
                            {
                                bombs += 1;
                            }
                        }
                        else if (cleanLabelNumber == (cols * i) + 1)
                        {
                            rightfree = true;

                            var labelnext = Controls.Find("label" + (cleanLabelNumber + 1), true);
                            Label iconLabelnext = (Label)labelnext[0] as Label;
                            if (iconLabelnext.Text == "M")
                            {
                                bombs += 1;
                            }
                        }
                    }


                    // checking the upper and bottom bomb apearans

                    if (cleanLabelNumber > cols && cleanLabelNumber < cols * (rows - 1) + 1)
                    {
                        middlerow = true;

                        var labelbottom = Controls.Find("label" + (cleanLabelNumber + cols), true);
                        var labelupper = Controls.Find("label" + (cleanLabelNumber - cols), true);
                        Label iconLabelbottom = (Label)labelbottom[0] as Label;
                        Label iconLabelupper = (Label)labelupper[0] as Label;
                        if (iconLabelbottom.Text == "M")
                        {
                            bombs += 1;
                        }
                        if (iconLabelupper.Text == "M")
                        {
                            bombs += 1;
                        }
                    }
                    else if (cleanLabelNumber >= cols * (rows - 1))
                    {
                        topfree = true;

                        var labelupper = Controls.Find("label" + (cleanLabelNumber - cols), true);
                        Label iconLabelupper = (Label)labelupper[0] as Label;
                        if (iconLabelupper.Text == "M")
                        {
                            bombs += 1;
                        }
                    }
                    else if (cleanLabelNumber <= cols)
                    {
                        botfree = true;

                        var labelbottom = Controls.Find("label" + (cleanLabelNumber + cols), true);
                        Label iconLabelbottom = (Label)labelbottom[0] as Label;
                        if (iconLabelbottom.Text == "M")
                        {
                            bombs += 1;
                        }
                    }

                    // checking for corner bombs


                    if (middlecolumn == true && middlerow == true)
                    {
                        var labellefttop = Controls.Find("label" + (cleanLabelNumber - cols - 1), true);
                        var labelrighttop = Controls.Find("label" + (cleanLabelNumber - cols + 1), true);
                        var labelleftbot = Controls.Find("label" + (cleanLabelNumber + cols - 1), true);
                        var labelrightbot = Controls.Find("label" + (cleanLabelNumber + cols + 1), true);
                        Label iconLabellefttop = (Label)labellefttop[0] as Label;
                        Label iconLabelrighttop = (Label)labelrighttop[0] as Label;
                        Label iconLabelleftbot = (Label)labelleftbot[0] as Label;
                        Label iconLabelrightbot = (Label)labelrightbot[0] as Label;
                        if (iconLabellefttop.Text == "M")
                        {
                            bombs += 1;
                        }
                        if (iconLabelrighttop.Text == "M")
                        {
                            bombs += 1;
                        }
                        if (iconLabelleftbot.Text == "M")
                        {
                            bombs += 1;
                        }
                        if (iconLabelrightbot.Text == "M")
                        {
                            bombs += 1;
                        }
                    }
                    else if (middlecolumn == true && topfree == true)
                    {
                        var labellefttop = Controls.Find("label" + (cleanLabelNumber - cols - 1), true);
                        var labelrighttop = Controls.Find("label" + (cleanLabelNumber - cols + 1), true);
                        Label iconLabellefttop = (Label)labellefttop[0] as Label;
                        Label iconLabelrighttop = (Label)labelrighttop[0] as Label;
                        if (iconLabellefttop.Text == "M")
                        {
                            bombs += 1;
                        }
                        if (iconLabelrighttop.Text == "M")
                        {
                            bombs += 1;
                        }
                    }
                    else if (middlecolumn == true && botfree == true)
                    {
                        var labelleftbot = Controls.Find("label" + (cleanLabelNumber + cols - 1), true);
                        var labelrightbot = Controls.Find("label" + (cleanLabelNumber + cols + 1), true);
                        Label iconLabelleftbot = (Label)labelleftbot[0] as Label;
                        Label iconLabelrightbot = (Label)labelrightbot[0] as Label;
                        if (iconLabelleftbot.Text == "M")
                        {
                            bombs += 1;
                        }
                        if (iconLabelrightbot.Text == "M")
                        {
                            bombs += 1;
                        }
                    }
                    else if (middlerow == true && leftfree == true)
                    {
                        var labellefttop = Controls.Find("label" + (cleanLabelNumber - cols - 1), true);
                        var labelleftbot = Controls.Find("label" + (cleanLabelNumber + cols - 1), true);
                        Label iconLabellefttop = (Label)labellefttop[0] as Label;
                        Label iconLabelleftbot = (Label)labelleftbot[0] as Label;
                        if (iconLabellefttop.Text == "M")
                        {
                            bombs += 1;
                        }
                        if (iconLabelleftbot.Text == "M")
                        {
                            bombs += 1;
                        }
                    }
                    else if (middlerow == true && rightfree == true)
                    {
                        var labelrighttop = Controls.Find("label" + (cleanLabelNumber - cols + 1), true);
                        var labelrightbot = Controls.Find("label" + (cleanLabelNumber + cols + 1), true);
                        Label iconLabelrighttop = (Label)labelrighttop[0] as Label;
                        Label iconLabelrightbot = (Label)labelrightbot[0] as Label;
                        if (iconLabelrighttop.Text == "M")
                        {
                            bombs += 1;
                        }
                        if (iconLabelrightbot.Text == "M")
                        {
                            bombs += 1;
                        }
                    }

                    // checking THE CORNERS!

                    if (cleanLabelNumber == 1)
                    {
                        var labelrightbot = Controls.Find("label" + (cleanLabelNumber + cols + 1), true);
                        Label iconLabelrightbot = (Label)labelrightbot[0] as Label;
                        if (iconLabelrightbot.Text == "M")
                        {
                            bombs += 1;
                        }
                    }
                    else if (cleanLabelNumber == cols)
                    {
                        var labelleftbot = Controls.Find("label" + (cleanLabelNumber + cols - 1), true);
                        Label iconLabelleftbot = (Label)labelleftbot[0] as Label;
                        if (iconLabelleftbot.Text == "M")
                        {
                            bombs += 1;
                        }
                    }
                    else if (cleanLabelNumber == cols * (rows - 1) + 1)
                    {
                        var labelrighttop = Controls.Find("label" + (cleanLabelNumber - 4), true);
                        Label iconLabelrighttop = (Label)labelrighttop[0] as Label;
                        if (iconLabelrighttop.Text == "M")
                        {
                            bombs += 1;
                        }
                    }
                    else if (cleanLabelNumber == cols * rows)
                    {
                        var labellefttop = Controls.Find("label" + (cleanLabelNumber - 6), true);
                        Label iconLabellefttop = (Label)labellefttop[0] as Label;
                        if (iconLabellefttop.Text == "M")
                        {
                            bombs += 1;
                        }
                    }

                    if (bombs == 0)
                    {
                        iconLabel.Text = "";
                    }
                    else
                    {
                        iconLabel.Font = new Font("Arial", fontSize, FontStyle.Bold);
                        iconLabel.Text = Convert.ToString(bombs);
                    }

                }

            }



        }

        /// <summary>
        /// Clicking label, changing parameters and checking if its a bomb
        /// </summary>
        /// <param name="sender">Clicked Label</param>
        /// <param name="e"></param>

        private void label_Click(object sender, EventArgs e)
        {

            int rows = Convert.ToInt32(Form2.SetValueForHeight);
            int cols = Convert.ToInt32(Form2.SetValueForWidth);

            MouseEventArgs me = (MouseEventArgs)e;

            Label clickedLabel = sender as Label;

            if (me.Button == MouseButtons.Left)
            {
                if (clickedLabel != null)
                {


                    // If the clicked label is black, the player clicked
                    // an icon that's already been revealed --
                    // ignore the click
                    if (clickedLabel.BackColor == Color.Gray || clickedLabel.BackColor == Color.Green)
                        return;

                    // Checking if label is without text value

                    if (clickedLabel.Text == "")
                    {

                        clickedLabel.ForeColor = Color.Black;
                        clickedLabel.BackColor = Color.Gray;


                        string clean = clickedLabel.Name.Trim('l', 'a', 'b', 'e');
                        int cleanLabelNumber = Convert.ToInt32(clean);

                        //Checking if the labels around exist and if they do click them

                        if (cleanLabelNumber - cols <= 0 || (cleanLabelNumber - 1) % cols == 0)
                        {
                        }
                        else
                        {
                            var labellefttop = Controls.Find("label" + (cleanLabelNumber - cols - 1), true);
                            Label iconLabellefttop = (Label)labellefttop[0] as Label;
                            label_Click(iconLabellefttop, e);
                        }
                        if (cleanLabelNumber - cols > 0)
                        {
                            var labeltop = Controls.Find("label" + (cleanLabelNumber - cols), true);
                            Label iconLabeltop = (Label)labeltop[0] as Label;
                            label_Click(iconLabeltop, e);
                        }

                        if (cleanLabelNumber - cols <= 0 || (cleanLabelNumber % cols == 0))
                        {
                        }
                        else
                        {
                            var labelrighttop = Controls.Find("label" + (cleanLabelNumber - cols + 1), true);
                            Label iconLabelrighttop = (Label)labelrighttop[0] as Label;
                            label_Click(iconLabelrighttop, e);
                        }

                        if (cleanLabelNumber % cols == 1)
                        {
                        }
                        else
                        {
                            var labelleft = Controls.Find("label" + (cleanLabelNumber - 1), true);
                            Label iconLabelleft = (Label)labelleft[0] as Label;
                            label_Click(iconLabelleft, e);
                        }

                        if (cleanLabelNumber % cols == 0)
                        {
                        }
                        else
                        {
                            var labelright = Controls.Find("label" + (cleanLabelNumber + 1), true);
                            Label iconLabelright = (Label)labelright[0] as Label;
                            label_Click(iconLabelright, e);
                        }

                        if (cleanLabelNumber > cols * (rows - 1) || (cleanLabelNumber % cols) == 1)
                        {
                        }
                        else
                        {
                            var labelleftbot = Controls.Find("label" + (cleanLabelNumber + cols - 1), true);
                            Label iconLabelleftbot = (Label)labelleftbot[0] as Label;
                            label_Click(iconLabelleftbot, e);

                        }

                        if (cleanLabelNumber > cols * (rows - 1))
                        {
                        }
                        else
                        {
                            var labelbot = Controls.Find("label" + (cleanLabelNumber + cols), true);
                            Label iconLabelbot = (Label)labelbot[0] as Label;
                            label_Click(iconLabelbot, e);
                        }

                        if (cleanLabelNumber > cols * (rows - 1) || cleanLabelNumber % cols == 0)
                        {
                        }
                        else
                        {
                            var labelrightbot = Controls.Find("label" + (cleanLabelNumber + cols + 1), true);
                            Label iconLabelrightbot = (Label)labelrightbot[0] as Label;
                            label_Click(iconLabelrightbot, e);
                        }


                        Globals.score += 1;

                        int toWin = (cols * rows) - Convert.ToInt32(Form2.SetValueForBombs);

                        CheckTheWinner(toWin);



                    }
                    else if (clickedLabel.Text == "M")
                    {
                        // If its bomb End the game, set up Global score
                        // For next Game and Go to Form2

                        clickedLabel.ForeColor = Color.Black;
                        foreach (Control control in tableLayoutPanel1.Controls)
                        {
                            Label iconLabel = control as Label;
                            if (iconLabel.Text == "M")
                            {
                                iconLabel.ForeColor = Color.Black;

                            }
                        }

                        timer1.Stop();
                        MessageBox.Show("Bomba! Przegrałeś!");
                        Globals.score = 0;
                        // Application.Exit();
                        this.Hide();
                        Form2 a1 = new Form2();
                        a1.ShowDialog();
                    }
                    else
                    {
                        // Check function for the Winner

                        clickedLabel.BackColor = Color.Gray;
                        clickedLabel.ForeColor = Color.Black;


                        Globals.score += 1;

                        int toWin = (cols * rows) - Convert.ToInt32(Form2.SetValueForBombs);

                        CheckTheWinner(toWin);
                    }



                }
            }
            else if (me.Button == MouseButtons.Right)
            {
                //if its right button Mark label

                if (clickedLabel.BackColor == Color.Gray)
                {

                }
                else
                {
                    if (clickedLabel.BackColor == Color.Green)
                    {

                        clickedLabel.BackColor = Color.DarkRed;
                        clickedLabel.ForeColor = Color.DarkRed;
                        int bombs = Convert.ToInt32(counterbombslabel.Text);
                        counterbombslabel.Text = Convert.ToString(bombs + 1);
                    }
                    else
                    {

                        clickedLabel.BackColor = Color.Green;
                        clickedLabel.ForeColor = Color.Green;
                        int bombs = Convert.ToInt32(counterbombslabel.Text);
                        counterbombslabel.Text = Convert.ToString(bombs - 1);
                    }
                }

            }





        }
    }
}

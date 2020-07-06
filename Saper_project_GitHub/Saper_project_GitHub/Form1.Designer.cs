namespace Saper_project_GitHub
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bombsicon = new System.Windows.Forms.Label();
            this.counterbombslabel = new System.Windows.Forms.Label();
            this.boombslabel = new System.Windows.Forms.Label();
            this.timespend = new System.Windows.Forms.Label();
            this.stopwatchlabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // bombsicon
            // 
            this.bombsicon.Font = new System.Drawing.Font("Wingdings", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.bombsicon.Location = new System.Drawing.Point(249, 9);
            this.bombsicon.Name = "bombsicon";
            this.bombsicon.Size = new System.Drawing.Size(65, 38);
            this.bombsicon.TabIndex = 11;
            this.bombsicon.Text = "M";
            this.bombsicon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // counterbombslabel
            // 
            this.counterbombslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.counterbombslabel.Location = new System.Drawing.Point(173, 9);
            this.counterbombslabel.Name = "counterbombslabel";
            this.counterbombslabel.Size = new System.Drawing.Size(82, 38);
            this.counterbombslabel.TabIndex = 10;
            this.counterbombslabel.Text = "000";
            this.counterbombslabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // boombslabel
            // 
            this.boombslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.boombslabel.Location = new System.Drawing.Point(18, 9);
            this.boombslabel.Name = "boombslabel";
            this.boombslabel.Size = new System.Drawing.Size(162, 38);
            this.boombslabel.TabIndex = 9;
            this.boombslabel.Text = "BOMBY:";
            this.boombslabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timespend
            // 
            this.timespend.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timespend.Location = new System.Drawing.Point(422, 9);
            this.timespend.Name = "timespend";
            this.timespend.Size = new System.Drawing.Size(130, 38);
            this.timespend.TabIndex = 8;
            this.timespend.Text = "CZAS:";
            this.timespend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stopwatchlabel
            // 
            this.stopwatchlabel.AutoSize = true;
            this.stopwatchlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.stopwatchlabel.Location = new System.Drawing.Point(546, 9);
            this.stopwatchlabel.Name = "stopwatchlabel";
            this.stopwatchlabel.Size = new System.Drawing.Size(57, 39);
            this.stopwatchlabel.TabIndex = 7;
            this.stopwatchlabel.Text = "00";
            this.stopwatchlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.DarkRed;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(634, 561);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 611);
            this.Controls.Add(this.bombsicon);
            this.Controls.Add(this.counterbombslabel);
            this.Controls.Add(this.boombslabel);
            this.Controls.Add(this.timespend);
            this.Controls.Add(this.stopwatchlabel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label bombsicon;
        private System.Windows.Forms.Label counterbombslabel;
        private System.Windows.Forms.Label boombslabel;
        private System.Windows.Forms.Label timespend;
        private System.Windows.Forms.Label stopwatchlabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Timer timer1;
    }
}


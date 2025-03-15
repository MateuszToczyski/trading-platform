namespace TradingPlatform
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.lstInstruments = new System.Windows.Forms.ListBox();
            this.crtPrices = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.crtPrices)).BeginInit();
            this.SuspendLayout();
            // 
            // lstInstruments
            // 
            this.lstInstruments.FormattingEnabled = true;
            this.lstInstruments.Location = new System.Drawing.Point(594, 12);
            this.lstInstruments.Name = "lstInstruments";
            this.lstInstruments.Size = new System.Drawing.Size(120, 95);
            this.lstInstruments.TabIndex = 0;
            // 
            // crtPrices
            // 
            chartArea1.Name = "ChartArea1";
            this.crtPrices.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.crtPrices.Legends.Add(legend1);
            this.crtPrices.Location = new System.Drawing.Point(13, 13);
            this.crtPrices.Name = "crtPrices";
            this.crtPrices.Size = new System.Drawing.Size(575, 300);
            this.crtPrices.TabIndex = 1;
            this.crtPrices.Text = "chart1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 411);
            this.Controls.Add(this.crtPrices);
            this.Controls.Add(this.lstInstruments);
            this.Name = "MainForm";
            this.Text = "Trading Platform";
            ((System.ComponentModel.ISupportInitialize)(this.crtPrices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstInstruments;
        private System.Windows.Forms.DataVisualization.Charting.Chart crtPrices;
    }
}


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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.lstInstruments = new System.Windows.Forms.ListBox();
            this.crtPrices = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblOpenPositions = new System.Windows.Forms.Label();
            this.dgvOpenPositions = new System.Windows.Forms.DataGridView();
            this.lblNominal = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnBuy = new System.Windows.Forms.Button();
            this.btnSell = new System.Windows.Forms.Button();
            this.lblAvailableFunds = new System.Windows.Forms.Label();
            this.txtAvailableFunds = new System.Windows.Forms.TextBox();
            this.btnDeposit = new System.Windows.Forms.Button();
            this.btnWithdrawal = new System.Windows.Forms.Button();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtCurrentPrice = new System.Windows.Forms.TextBox();
            this.lblOrderValue = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtDepositWithdrawal = new System.Windows.Forms.TextBox();
            this.lblDepositWithdrawal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.crtPrices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpenPositions)).BeginInit();
            this.SuspendLayout();
            // 
            // lstInstruments
            // 
            this.lstInstruments.FormattingEnabled = true;
            this.lstInstruments.Location = new System.Drawing.Point(594, 12);
            this.lstInstruments.Name = "lstInstruments";
            this.lstInstruments.Size = new System.Drawing.Size(250, 108);
            this.lstInstruments.TabIndex = 0;
            // 
            // crtPrices
            // 
            chartArea2.Name = "ChartArea1";
            this.crtPrices.ChartAreas.Add(chartArea2);
            this.crtPrices.Location = new System.Drawing.Point(13, 13);
            this.crtPrices.Name = "crtPrices";
            this.crtPrices.Size = new System.Drawing.Size(575, 300);
            this.crtPrices.TabIndex = 1;
            this.crtPrices.Text = "chart1";
            // 
            // lblOpenPositions
            // 
            this.lblOpenPositions.AutoSize = true;
            this.lblOpenPositions.Location = new System.Drawing.Point(13, 331);
            this.lblOpenPositions.Name = "lblOpenPositions";
            this.lblOpenPositions.Size = new System.Drawing.Size(83, 13);
            this.lblOpenPositions.TabIndex = 2;
            this.lblOpenPositions.Text = "Otwarte pozycje";
            // 
            // dgvOpenPositions
            // 
            this.dgvOpenPositions.AllowUserToAddRows = false;
            this.dgvOpenPositions.AllowUserToDeleteRows = false;
            this.dgvOpenPositions.AllowUserToResizeColumns = false;
            this.dgvOpenPositions.AllowUserToResizeRows = false;
            this.dgvOpenPositions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOpenPositions.Location = new System.Drawing.Point(16, 358);
            this.dgvOpenPositions.Name = "dgvOpenPositions";
            this.dgvOpenPositions.ReadOnly = true;
            this.dgvOpenPositions.Size = new System.Drawing.Size(572, 150);
            this.dgvOpenPositions.TabIndex = 3;
            // 
            // lblNominal
            // 
            this.lblNominal.AutoSize = true;
            this.lblNominal.Location = new System.Drawing.Point(594, 140);
            this.lblNominal.Name = "lblNominal";
            this.lblNominal.Size = new System.Drawing.Size(66, 13);
            this.lblNominal.TabIndex = 4;
            this.lblNominal.Text = "Liczba sztuk";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(597, 156);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(597, 232);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(75, 23);
            this.btnBuy.TabIndex = 6;
            this.btnBuy.Text = "KUP";
            this.btnBuy.UseVisualStyleBackColor = true;
            // 
            // btnSell
            // 
            this.btnSell.Location = new System.Drawing.Point(678, 232);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(75, 23);
            this.btnSell.TabIndex = 7;
            this.btnSell.Text = "SPRZEDAJ";
            this.btnSell.UseVisualStyleBackColor = true;
            // 
            // lblAvailableFunds
            // 
            this.lblAvailableFunds.AutoSize = true;
            this.lblAvailableFunds.Location = new System.Drawing.Point(594, 290);
            this.lblAvailableFunds.Name = "lblAvailableFunds";
            this.lblAvailableFunds.Size = new System.Drawing.Size(69, 13);
            this.lblAvailableFunds.TabIndex = 8;
            this.lblAvailableFunds.Text = "Wolne środki";
            // 
            // txtAvailableFunds
            // 
            this.txtAvailableFunds.Location = new System.Drawing.Point(597, 306);
            this.txtAvailableFunds.Name = "txtAvailableFunds";
            this.txtAvailableFunds.ReadOnly = true;
            this.txtAvailableFunds.Size = new System.Drawing.Size(100, 20);
            this.txtAvailableFunds.TabIndex = 9;
            // 
            // btnDeposit
            // 
            this.btnDeposit.Location = new System.Drawing.Point(594, 401);
            this.btnDeposit.Name = "btnDeposit";
            this.btnDeposit.Size = new System.Drawing.Size(75, 23);
            this.btnDeposit.TabIndex = 10;
            this.btnDeposit.Text = "WPŁATA";
            this.btnDeposit.UseVisualStyleBackColor = true;
            this.btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);
            // 
            // btnWithdrawal
            // 
            this.btnWithdrawal.Location = new System.Drawing.Point(675, 401);
            this.btnWithdrawal.Name = "btnWithdrawal";
            this.btnWithdrawal.Size = new System.Drawing.Size(75, 23);
            this.btnWithdrawal.TabIndex = 11;
            this.btnWithdrawal.Text = "WYPŁATA";
            this.btnWithdrawal.UseVisualStyleBackColor = true;
            this.btnWithdrawal.Click += new System.EventHandler(this.btnWithdrawal_Click);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(710, 140);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(32, 13);
            this.lblPrice.TabIndex = 12;
            this.lblPrice.Text = "Cena";
            // 
            // txtCurrentPrice
            // 
            this.txtCurrentPrice.Location = new System.Drawing.Point(713, 156);
            this.txtCurrentPrice.Name = "txtCurrentPrice";
            this.txtCurrentPrice.ReadOnly = true;
            this.txtCurrentPrice.Size = new System.Drawing.Size(100, 20);
            this.txtCurrentPrice.TabIndex = 13;
            // 
            // lblOrderValue
            // 
            this.lblOrderValue.AutoSize = true;
            this.lblOrderValue.Location = new System.Drawing.Point(594, 190);
            this.lblOrderValue.Name = "lblOrderValue";
            this.lblOrderValue.Size = new System.Drawing.Size(89, 13);
            this.lblOrderValue.TabIndex = 14;
            this.lblOrderValue.Text = "Wartość zlecenia";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(597, 206);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 15;
            // 
            // txtDepositWithdrawal
            // 
            this.txtDepositWithdrawal.Location = new System.Drawing.Point(594, 375);
            this.txtDepositWithdrawal.Name = "txtDepositWithdrawal";
            this.txtDepositWithdrawal.Size = new System.Drawing.Size(100, 20);
            this.txtDepositWithdrawal.TabIndex = 16;
            // 
            // lblDepositWithdrawal
            // 
            this.lblDepositWithdrawal.AutoSize = true;
            this.lblDepositWithdrawal.Location = new System.Drawing.Point(594, 358);
            this.lblDepositWithdrawal.Name = "lblDepositWithdrawal";
            this.lblDepositWithdrawal.Size = new System.Drawing.Size(95, 13);
            this.lblDepositWithdrawal.TabIndex = 17;
            this.lblDepositWithdrawal.Text = "Wpłata / Wypłata";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 517);
            this.Controls.Add(this.lblDepositWithdrawal);
            this.Controls.Add(this.txtDepositWithdrawal);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lblOrderValue);
            this.Controls.Add(this.txtCurrentPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.btnWithdrawal);
            this.Controls.Add(this.btnDeposit);
            this.Controls.Add(this.txtAvailableFunds);
            this.Controls.Add(this.lblAvailableFunds);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblNominal);
            this.Controls.Add(this.dgvOpenPositions);
            this.Controls.Add(this.lblOpenPositions);
            this.Controls.Add(this.crtPrices);
            this.Controls.Add(this.lstInstruments);
            this.Name = "MainForm";
            this.Text = "Trading Platform";
            ((System.ComponentModel.ISupportInitialize)(this.crtPrices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpenPositions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstInstruments;
        private System.Windows.Forms.DataVisualization.Charting.Chart crtPrices;
        private System.Windows.Forms.Label lblOpenPositions;
        private System.Windows.Forms.DataGridView dgvOpenPositions;
        private System.Windows.Forms.Label lblNominal;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Label lblAvailableFunds;
        private System.Windows.Forms.TextBox txtAvailableFunds;
        private System.Windows.Forms.Button btnDeposit;
        private System.Windows.Forms.Button btnWithdrawal;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtCurrentPrice;
        private System.Windows.Forms.Label lblOrderValue;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtDepositWithdrawal;
        private System.Windows.Forms.Label lblDepositWithdrawal;
    }
}


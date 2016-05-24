namespace Reports.Test
{
    partial class frmMain
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
            if(disposing && (components != null))
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
            this.sfRelatorio = new OpenPOS.Desktop.ComponentModel.SearchField();
            this.lblSelecionar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sfRelatorio
            // 
            this.sfRelatorio.BackColor = System.Drawing.Color.White;
            this.sfRelatorio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sfRelatorio.DontClearMe = false;
            this.sfRelatorio.Location = new System.Drawing.Point(5, 29);
            this.sfRelatorio.MaxDropDownHeight = 0;
            this.sfRelatorio.Name = "sfRelatorio";
            this.sfRelatorio.Size = new System.Drawing.Size(475, 27);
            this.sfRelatorio.TabIndex = 0;
            this.sfRelatorio.Value = "";
            this.sfRelatorio.OnSelectedValueChanged += new OpenPOS.Desktop.ComponentModel.SearchField.SelectedItemHandler(this.sfRelatorio_OnSelectedValueChanged);
            // 
            // lblSelecionar
            // 
            this.lblSelecionar.AutoSize = true;
            this.lblSelecionar.Location = new System.Drawing.Point(12, 9);
            this.lblSelecionar.Name = "lblSelecionar";
            this.lblSelecionar.Size = new System.Drawing.Size(106, 13);
            this.lblSelecionar.TabIndex = 1;
            this.lblSelecionar.Text = "Selecionar o relatório";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 145);
            this.Controls.Add(this.lblSelecionar);
            this.Controls.Add(this.sfRelatorio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Testar Relatório";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private OpenPOS.Desktop.ComponentModel.SearchField sfRelatorio;

        #endregion

        private System.Windows.Forms.Label lblSelecionar;
    }
}
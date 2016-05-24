namespace Reports.Test.RdlDesign.Forms
{
    partial class frmDialogFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDialogFilter));
            this.grpBxFiltro = new System.Windows.Forms.GroupBox();
            this.buttonOK1 = new OpenPOS.Desktop.ComponentModel.ButtonOK();
            this.buttonCancelar1 = new OpenPOS.Desktop.ComponentModel.ButtonCancelar();
            this.SuspendLayout();
            // 
            // grpBxFiltro
            // 
            this.grpBxFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBxFiltro.Location = new System.Drawing.Point(3, 12);
            this.grpBxFiltro.Name = "grpBxFiltro";
            this.grpBxFiltro.Size = new System.Drawing.Size(553, 202);
            this.grpBxFiltro.TabIndex = 0;
            this.grpBxFiltro.TabStop = false;
            this.grpBxFiltro.Text = "Filtros:";
            // 
            // buttonOK1
            // 
            this.buttonOK1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK1.BackColor = System.Drawing.Color.Transparent;
            this.buttonOK1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.buttonOK1.Image = ((System.Drawing.Image)(resources.GetObject("buttonOK1.Image")));
            this.buttonOK1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOK1.Location = new System.Drawing.Point(386, 220);
            this.buttonOK1.Name = "buttonOK1";
            this.buttonOK1.Size = new System.Drawing.Size(82, 26);
            this.buttonOK1.TabIndex = 1;
            this.buttonOK1.Text = "OK";
            this.buttonOK1.UseVisualStyleBackColor = false;
            this.buttonOK1.Click += new System.EventHandler(this.buttonOK1_Click);
            // 
            // buttonCancelar1
            // 
            this.buttonCancelar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancelar1.BackColor = System.Drawing.Color.Transparent;
            this.buttonCancelar1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.buttonCancelar1.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancelar1.Image")));
            this.buttonCancelar1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancelar1.Location = new System.Drawing.Point(474, 220);
            this.buttonCancelar1.Name = "buttonCancelar1";
            this.buttonCancelar1.Size = new System.Drawing.Size(82, 26);
            this.buttonCancelar1.TabIndex = 2;
            this.buttonCancelar1.Text = "Cancelar";
            this.buttonCancelar1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancelar1.UseVisualStyleBackColor = false;
            this.buttonCancelar1.Click += new System.EventHandler(this.buttonCancelar1_Click);
            // 
            // frmDialogFilter
            // 
            this.AcceptButton = this.buttonOK1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelar1;
            this.ClientSize = new System.Drawing.Size(558, 249);
            this.Controls.Add(this.buttonCancelar1);
            this.Controls.Add(this.buttonOK1);
            this.Controls.Add(this.grpBxFiltro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDialogFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DialogFiltro";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBxFiltro;
        private OpenPOS.Desktop.ComponentModel.ButtonOK buttonOK1;
        private OpenPOS.Desktop.ComponentModel.ButtonCancelar buttonCancelar1;
    }
}
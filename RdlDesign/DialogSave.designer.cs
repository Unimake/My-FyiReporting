using System.Windows.Forms;

namespace fyiReporting.RdlDesign
{
    partial class frmDialogSave
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
            this.bCancel = new System.Windows.Forms.Button();
            this.bOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.sfGroup = new OpenPOS.Desktop.ComponentModel.SearchField();
            this.label2 = new System.Windows.Forms.Label();
            this.grbFiltros = new System.Windows.Forms.GroupBox();
            this.grdFiltros = new OpenPOS.Desktop.ComponentModel.GridPanel();
            this.dgvGUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvApelido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvNomeReal = new OpenPOS.Desktop.ComponentModel.DataGridViewComboBoxColumn();
            this.dgvTipo = new OpenPOS.Desktop.ComponentModel.DataGridViewComboBoxColumn();
            this.dgvObrigatorio = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvPadrao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvComparacao = new OpenPOS.Desktop.ComponentModel.DataGridViewComboBoxColumn();
            this.dgvClassificacao = new OpenPOS.Desktop.ComponentModel.DataGridViewComboBoxColumn();
            this.dgvVlr1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvVlr2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkTemplate = new System.Windows.Forms.CheckBox();
            this.grbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFiltros)).BeginInit();
            this.SuspendLayout();
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bCancel.Location = new System.Drawing.Point(584, 256);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 16;
            this.bCancel.Text = "Cancel";
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bOK
            // 
            this.bOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bOK.Location = new System.Drawing.Point(488, 256);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(75, 23);
            this.bOK.TabIndex = 15;
            this.bOK.Text = "OK";
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Title:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(57, 12);
            this.txtTitle.MaxLength = 50;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(594, 20);
            this.txtTitle.TabIndex = 18;
            // 
            // sfGroup
            // 
            this.sfGroup.BackColor = System.Drawing.Color.White;
            this.sfGroup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sfGroup.DataSource = null;
            this.sfGroup.DontClearMe = false;
            this.sfGroup.Location = new System.Drawing.Point(57, 38);
            this.sfGroup.MaxDropDownHeight = 0;
            this.sfGroup.Name = "sfGroup";
            this.sfGroup.Size = new System.Drawing.Size(594, 19);
            this.sfGroup.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Group:";
            // 
            // grbFiltros
            // 
            this.grbFiltros.Controls.Add(this.grdFiltros);
            this.grbFiltros.Location = new System.Drawing.Point(15, 87);
            this.grbFiltros.Name = "grbFiltros";
            this.grbFiltros.Size = new System.Drawing.Size(646, 160);
            this.grbFiltros.TabIndex = 22;
            this.grbFiltros.TabStop = false;
            this.grbFiltros.Text = "Filtros:";
            // 
            // grdFiltros
            // 
            this.grdFiltros.AllowUserToAddRows = true;
            this.grdFiltros.AllowUserToDeleteRows = true;
            this.grdFiltros.AllowUserToResizeRows = false;
            this.grdFiltros.AutoScroll = true;
            this.grdFiltros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdFiltros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grdFiltros.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            this.grdFiltros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.grdFiltros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvGUID,
            this.dgvApelido,
            this.dgvNomeReal,
            this.dgvTipo,
            this.dgvObrigatorio,
            this.dgvPadrao,
            this.dgvComparacao,
            this.dgvClassificacao,
            this.dgvVlr1,
            this.dgvVlr2});
            this.grdFiltros.DontClearMe = false;
            this.grdFiltros.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2;
            this.grdFiltros.Location = new System.Drawing.Point(15, 19);
            this.grdFiltros.MultiSelect = true;
            this.grdFiltros.Name = "grdFiltros";
            this.grdFiltros.ReadOnly = false;
            this.grdFiltros.RowHeadersVisible = true;
            this.grdFiltros.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.grdFiltros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFiltros.ShowCellErrors = false;
            this.grdFiltros.ShowEditingIcon = true;
            this.grdFiltros.ShowRowErrors = false;
            this.grdFiltros.ShowToolbarGridPanel = false;
            this.grdFiltros.Size = new System.Drawing.Size(625, 135);
            this.grdFiltros.TabIndex = 0;
            this.grdFiltros.FilterType = OpenPOS.Desktop.ComponentModel.GridPanelFilterType.None;
            // 
            // dgvGUID
            // 
            this.dgvGUID.HeaderText = "GUID";
            this.dgvGUID.Name = "dgvGUID";
            this.dgvGUID.ReadOnly = true;
            this.dgvGUID.Visible = false;
            // 
            // dgvApelido
            // 
            this.dgvApelido.HeaderText = "Apelido";
            this.dgvApelido.Name = "dgvApelido";
            // 
            // dgvNomeReal
            // 
            this.dgvNomeReal.HeaderText = "Nome Real";
            this.dgvNomeReal.Name = "dgvNomeReal";
            // 
            // dgvTipo
            // 
            this.dgvTipo.HeaderText = "Tipo";
            this.dgvTipo.Name = "dgvTipo";
            // 
            // dgvObrigatorio
            // 
            this.dgvObrigatorio.HeaderText = "Obrigatório";
            this.dgvObrigatorio.Name = "dgvObrigatorio";
            // 
            // dgvPadrao
            // 
            this.dgvPadrao.HeaderText = "Valor Padrão";
            this.dgvPadrao.Name = "dgvPadrao";
            // 
            // dgvComparacao
            // 
            this.dgvComparacao.HeaderText = "Comparação";
            this.dgvComparacao.Name = "dgvComparacao";
            // 
            // dgvClassificacao
            // 
            this.dgvClassificacao.HeaderText = "Classificação";
            this.dgvClassificacao.Name = "dgvClassificacao";
            // 
            // dgvVlr1
            // 
            this.dgvVlr1.HeaderText = "Valor 1";
            this.dgvVlr1.Name = "dgvVlr1";
            // 
            // dgvVlr2
            // 
            this.dgvVlr2.HeaderText = "Valor 2";
            this.dgvVlr2.Name = "dgvVlr2";
            // 
            // dgvLista
            // 
            this.dgvLista.HeaderText = "Lista";
            this.dgvLista.Name = "dgvLista";
            // 
            // chkTemplate
            // 
            this.chkTemplate.AutoSize = true;
            this.chkTemplate.Location = new System.Drawing.Point(57, 64);
            this.chkTemplate.Name = "chkTemplate";
            this.chkTemplate.Size = new System.Drawing.Size(135, 17);
            this.chkTemplate.TabIndex = 23;
            this.chkTemplate.Text = "Marcar como Template";
            this.chkTemplate.UseVisualStyleBackColor = true;
            // 
            // frmDialogSave
            // 
            this.AcceptButton = this.bOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(670, 290);
            this.Controls.Add(this.chkTemplate);
            this.Controls.Add(this.grbFiltros);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sfGroup);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDialogSave";
            this.Text = "Save Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDialogSave_FormClosing);
            this.grbFiltros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFiltros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtTitle;
        internal OpenPOS.Desktop.ComponentModel.SearchField sfGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grbFiltros;
        private OpenPOS.Desktop.ComponentModel.GridPanel grdFiltros;
        private OpenPOS.Desktop.ComponentModel.DataGridViewComboBoxColumn dgvComparacao;
        private OpenPOS.Desktop.ComponentModel.DataGridViewComboBoxColumn dgvClassificacao;
        private OpenPOS.Desktop.ComponentModel.DataGridViewComboBoxColumn dgvTipo;
        private OpenPOS.Desktop.ComponentModel.DataGridViewComboBoxColumn dgvNomeReal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvObrigatorio;
        private DataGridViewTextBoxColumn dgvGUID;
        private DataGridViewTextBoxColumn dgvVlr1;
        private DataGridViewTextBoxColumn dgvVlr2;
        private DataGridViewTextBoxColumn dgvApelido;
        private DataGridViewTextBoxColumn dgvPadrao;
        private DataGridViewTextBoxColumn dgvLista;
        private CheckBox chkTemplate;
    }
}
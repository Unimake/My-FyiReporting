namespace fyiReporting.RdlDesign
{
    internal partial class DialogDatabase : System.Windows.Forms.Form
	{
				

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogDatabase));
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.ReportPreview = new System.Windows.Forms.TabPage();
            this.rdlViewer1 = new fyiReporting.RdlViewer.RdlViewer();
            this.ReportSyntax = new System.Windows.Forms.TabPage();
            this.tbReportSyntax = new System.Windows.Forms.TextBox();
            this.TabularGroup = new System.Windows.Forms.TabPage();
            this.cbColumnList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ckbGrandTotal = new System.Windows.Forms.CheckBox();
            this.clbSubtotal = new System.Windows.Forms.CheckedListBox();
            this.DBSql = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.bMove = new System.Windows.Forms.Button();
            this.tbSQL = new System.Windows.Forms.TextBox();
            this.tvTablesColumns = new System.Windows.Forms.TreeView();
            this.ReportParameters = new System.Windows.Forms.TabPage();
            this.reportParameterCtl1 = new fyiReporting.RdlDesign.ReportParameterCtl();
            this.ReportType = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbReportName = new System.Windows.Forms.TextBox();
            this.tbReportDescription = new System.Windows.Forms.TextBox();
            this.tbReportAuthor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbOrientation = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbSchemaNo = new System.Windows.Forms.RadioButton();
            this.rbSchema2003 = new System.Windows.Forms.RadioButton();
            this.rbSchema2005 = new System.Windows.Forms.RadioButton();
            this.tcDialog = new System.Windows.Forms.TabControl();
            this.panel1.SuspendLayout();
            this.ReportPreview.SuspendLayout();
            this.ReportSyntax.SuspendLayout();
            this.TabularGroup.SuspendLayout();
            this.DBSql.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ReportParameters.SuspendLayout();
            this.ReportType.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tcDialog.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.btnCancel);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ReportPreview
            // 
            this.ReportPreview.Controls.Add(this.rdlViewer1);
            resources.ApplyResources(this.ReportPreview, "ReportPreview");
            this.ReportPreview.Name = "ReportPreview";
            this.ReportPreview.Tag = "preview";
            // 
            // rdlViewer1
            // 
            this.rdlViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.rdlViewer1, "rdlViewer1");
            this.rdlViewer1.dSubReportGetContent = null;
            this.rdlViewer1.Folder = null;
            this.rdlViewer1.HighlightAll = false;
            this.rdlViewer1.HighlightAllColor = System.Drawing.Color.Fuchsia;
            this.rdlViewer1.HighlightCaseSensitive = false;
            this.rdlViewer1.HighlightItemColor = System.Drawing.Color.Aqua;
            this.rdlViewer1.HighlightPageItem = null;
            this.rdlViewer1.HighlightText = null;
            this.rdlViewer1.Name = "rdlViewer1";
            this.rdlViewer1.PageCurrent = 1;
            this.rdlViewer1.Parameters = "";
            this.rdlViewer1.ReportName = null;
            this.rdlViewer1.ScrollMode = fyiReporting.RdlViewer.ScrollModeEnum.Continuous;
            this.rdlViewer1.SelectTool = false;
            this.rdlViewer1.ShowFindPanel = false;
            this.rdlViewer1.ShowParameterPanel = true;
            this.rdlViewer1.ShowWaitDialog = true;
            this.rdlViewer1.SourceFile = null;
            this.rdlViewer1.SourceRdl = null;
            this.rdlViewer1.UseTrueMargins = true;
            this.rdlViewer1.Zoom = 0.7312694F;
            this.rdlViewer1.ZoomMode = fyiReporting.RdlViewer.ZoomEnum.FitWidth;
            // 
            // ReportSyntax
            // 
            this.ReportSyntax.Controls.Add(this.tbReportSyntax);
            resources.ApplyResources(this.ReportSyntax, "ReportSyntax");
            this.ReportSyntax.Name = "ReportSyntax";
            this.ReportSyntax.Tag = "syntax";
            // 
            // tbReportSyntax
            // 
            resources.ApplyResources(this.tbReportSyntax, "tbReportSyntax");
            this.tbReportSyntax.Name = "tbReportSyntax";
            this.tbReportSyntax.ReadOnly = true;
            // 
            // TabularGroup
            // 
            this.TabularGroup.Controls.Add(this.clbSubtotal);
            this.TabularGroup.Controls.Add(this.ckbGrandTotal);
            this.TabularGroup.Controls.Add(this.label5);
            this.TabularGroup.Controls.Add(this.label4);
            this.TabularGroup.Controls.Add(this.cbColumnList);
            resources.ApplyResources(this.TabularGroup, "TabularGroup");
            this.TabularGroup.Name = "TabularGroup";
            this.TabularGroup.Tag = "group";
            // 
            // cbColumnList
            // 
            this.cbColumnList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbColumnList, "cbColumnList");
            this.cbColumnList.Name = "cbColumnList";
            this.cbColumnList.SelectedIndexChanged += new System.EventHandler(this.emptyReportSyntax);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // ckbGrandTotal
            // 
            resources.ApplyResources(this.ckbGrandTotal, "ckbGrandTotal");
            this.ckbGrandTotal.Name = "ckbGrandTotal";
            this.ckbGrandTotal.CheckedChanged += new System.EventHandler(this.emptyReportSyntax);
            // 
            // clbSubtotal
            // 
            this.clbSubtotal.CheckOnClick = true;
            resources.ApplyResources(this.clbSubtotal, "clbSubtotal");
            this.clbSubtotal.Name = "clbSubtotal";
            this.clbSubtotal.SelectedIndexChanged += new System.EventHandler(this.emptyReportSyntax);
            // 
            // DBSql
            // 
            this.DBSql.Controls.Add(this.panel2);
            resources.ApplyResources(this.DBSql, "DBSql");
            this.DBSql.Name = "DBSql";
            this.DBSql.Tag = "sql";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvTablesColumns);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbSQL);
            this.splitContainer1.Panel2.Controls.Add(this.bMove);
            // 
            // bMove
            // 
            resources.ApplyResources(this.bMove, "bMove");
            this.bMove.Name = "bMove";
            this.bMove.Click += new System.EventHandler(this.bMove_Click);
            // 
            // tbSQL
            // 
            this.tbSQL.AllowDrop = true;
            resources.ApplyResources(this.tbSQL, "tbSQL");
            this.tbSQL.Name = "tbSQL";
            this.tbSQL.TextChanged += new System.EventHandler(this.tbSQL_TextChanged);
            this.tbSQL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSQL_KeyDown);
            // 
            // tvTablesColumns
            // 
            resources.ApplyResources(this.tvTablesColumns, "tvTablesColumns");
            this.tvTablesColumns.FullRowSelect = true;
            this.tvTablesColumns.Name = "tvTablesColumns";
            this.tvTablesColumns.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvTablesColumns_BeforeExpand);
            // 
            // ReportParameters
            // 
            this.ReportParameters.Controls.Add(this.reportParameterCtl1);
            resources.ApplyResources(this.ReportParameters, "ReportParameters");
            this.ReportParameters.Name = "ReportParameters";
            this.ReportParameters.Tag = "parameters";
            // 
            // reportParameterCtl1
            // 
            resources.ApplyResources(this.reportParameterCtl1, "reportParameterCtl1");
            this.reportParameterCtl1.Name = "reportParameterCtl1";
            // 
            // ReportType
            // 
            this.ReportType.Controls.Add(this.groupBox2);
            this.ReportType.Controls.Add(this.cbOrientation);
            this.ReportType.Controls.Add(this.label6);
            this.ReportType.Controls.Add(this.tbReportAuthor);
            this.ReportType.Controls.Add(this.tbReportDescription);
            this.ReportType.Controls.Add(this.tbReportName);
            this.ReportType.Controls.Add(this.label3);
            this.ReportType.Controls.Add(this.label2);
            this.ReportType.Controls.Add(this.label1);
            resources.ApplyResources(this.ReportType, "ReportType");
            this.ReportType.Name = "ReportType";
            this.ReportType.Tag = "type";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // tbReportName
            // 
            resources.ApplyResources(this.tbReportName, "tbReportName");
            this.tbReportName.Name = "tbReportName";
            this.tbReportName.TextChanged += new System.EventHandler(this.tbReportName_TextChanged);
            // 
            // tbReportDescription
            // 
            resources.ApplyResources(this.tbReportDescription, "tbReportDescription");
            this.tbReportDescription.Name = "tbReportDescription";
            this.tbReportDescription.TextChanged += new System.EventHandler(this.tbReportDescription_TextChanged);
            // 
            // tbReportAuthor
            // 
            resources.ApplyResources(this.tbReportAuthor, "tbReportAuthor");
            this.tbReportAuthor.Name = "tbReportAuthor";
            this.tbReportAuthor.TextChanged += new System.EventHandler(this.tbReportAuthor_TextChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // cbOrientation
            // 
            this.cbOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrientation.Items.AddRange(new object[] {
            resources.GetString("cbOrientation.Items"),
            resources.GetString("cbOrientation.Items1")});
            resources.ApplyResources(this.cbOrientation, "cbOrientation");
            this.cbOrientation.Name = "cbOrientation";
            this.cbOrientation.SelectedIndexChanged += new System.EventHandler(this.emptyReportSyntax);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbSchema2005);
            this.groupBox2.Controls.Add(this.rbSchema2003);
            this.groupBox2.Controls.Add(this.rbSchemaNo);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // rbSchemaNo
            // 
            resources.ApplyResources(this.rbSchemaNo, "rbSchemaNo");
            this.rbSchemaNo.Name = "rbSchemaNo";
            // 
            // rbSchema2003
            // 
            resources.ApplyResources(this.rbSchema2003, "rbSchema2003");
            this.rbSchema2003.Name = "rbSchema2003";
            // 
            // rbSchema2005
            // 
            this.rbSchema2005.Checked = true;
            resources.ApplyResources(this.rbSchema2005, "rbSchema2005");
            this.rbSchema2005.Name = "rbSchema2005";
            this.rbSchema2005.TabStop = true;
            // 
            // tcDialog
            // 
            this.tcDialog.Controls.Add(this.ReportType);
            this.tcDialog.Controls.Add(this.ReportParameters);
            this.tcDialog.Controls.Add(this.DBSql);
            this.tcDialog.Controls.Add(this.TabularGroup);
            this.tcDialog.Controls.Add(this.ReportSyntax);
            this.tcDialog.Controls.Add(this.ReportPreview);
            resources.ApplyResources(this.tcDialog, "tcDialog");
            this.tcDialog.Name = "tcDialog";
            this.tcDialog.SelectedIndex = 0;
            this.tcDialog.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // DialogDatabase
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.tcDialog);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogDatabase";
            this.ShowInTaskbar = false;
            this.Closed += new System.EventHandler(this.DialogDatabase_Closed);
            this.panel1.ResumeLayout(false);
            this.ReportPreview.ResumeLayout(false);
            this.ReportSyntax.ResumeLayout(false);
            this.ReportSyntax.PerformLayout();
            this.TabularGroup.ResumeLayout(false);
            this.DBSql.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ReportParameters.ResumeLayout(false);
            this.ReportType.ResumeLayout(false);
            this.ReportType.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tcDialog.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion		


        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOK;
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.TabPage ReportPreview;
        private RdlViewer.RdlViewer rdlViewer1;
        private System.Windows.Forms.TabPage ReportSyntax;
        private System.Windows.Forms.TextBox tbReportSyntax;
        private System.Windows.Forms.TabPage TabularGroup;
        private System.Windows.Forms.CheckedListBox clbSubtotal;
        private System.Windows.Forms.CheckBox ckbGrandTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbColumnList;
        private System.Windows.Forms.TabPage DBSql;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvTablesColumns;
        private System.Windows.Forms.TextBox tbSQL;
        private System.Windows.Forms.Button bMove;
        private System.Windows.Forms.TabPage ReportParameters;
        private ReportParameterCtl reportParameterCtl1;
        private System.Windows.Forms.TabPage ReportType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbSchema2005;
        private System.Windows.Forms.RadioButton rbSchema2003;
        private System.Windows.Forms.RadioButton rbSchemaNo;
        private System.Windows.Forms.ComboBox cbOrientation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbReportAuthor;
        private System.Windows.Forms.TextBox tbReportDescription;
        private System.Windows.Forms.TextBox tbReportName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tcDialog;
	}
}

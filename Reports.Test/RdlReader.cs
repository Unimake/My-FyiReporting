/* ====================================================================
   Copyright (C) 2004-2008  fyiReporting Software, LLC
   Copyright (C) 2011  Peter Gill <peter@majorsilence.com>

   This file is part of the fyiReporting RDL project.
	
   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.


   For additional information, email info@fyireporting.com or visit
   the website www.fyiReporting.com.
*/
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Xml;
using System.IO;
using fyiReporting.RDL;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Reports.Test.RdlDesign;
using OpenPOS.Model.Reports;
using Reports.Test.RdlDesign.Forms;
using fyiReporting.RdlViewer;
using Reports.Test.Resources;
using Unimake;
using System.Xml.Linq;
using System.Linq;
using Unimake.Data.Generic;
using System.Globalization;
using RdlEngine.Definition;
using OpenPOS;

namespace Reports.Test.Reader
{
    /// <summary>
    /// RdlReader is a application for displaying reports based on RDL.
    /// </summary>
    partial class RdlReader: IMessageFilter
    {
        /*Variáveis temporárias para os arquivos atuais*/
        private fyiReporting.RDL.NeedPassword _GetPassword;
        private string _DataSourceReferencePassword = null;

        public RdlReader() // Construtor da Classe
        {
            //--------------------------------
            // # Código inserido para trazer maximizado na tela.
            // # By Otávio.
            //--------------------------------
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.Width = Screen.PrimaryScreen.Bounds.Width;

            InitializeComponent();

            BuildMenus();

            Application.AddMessageFilter(this);
            _GetPassword = new fyiReporting.RDL.NeedPassword(this.GetPassword);
        }
        //----------------------------------------------------------------------------------

        //Método para exibir uma mensagem.
        //Acredito que não seja necessário alterar nada
        public bool PreFilterMessage(ref Message m)
        {
#if MONO
            return false;
#else
            if(m.Msg == 0x20a)
            {
                // WM_MOUSEWHEEL, find the control at screen position m.LParam
                Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                IntPtr hWnd = WindowFromPoint(pos);
                if(hWnd != IntPtr.Zero && hWnd != m.HWnd && Control.FromHandle(hWnd) != null)
                {
                    SendMessage(hWnd, m.Msg, m.WParam, m.LParam);
                    return true;
                }
            }
            return false;
#endif
        }
#if MONO
#else
        /*Caso eu não esteja compilando no MONO, será importado essas DLL's do windows.*/
        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(Point pt);
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
#endif


        string GetPassword()
        {
            /*Se a variável utilizada para a senha do banco de dados for nula, retornará a mesma variável*/
            if(_DataSourceReferencePassword != null)
                return _DataSourceReferencePassword;

            /*Instância de um novo tipo de objeto (Senha de banco de dados)*/
            DataSourcePassword dlg = new DataSourcePassword();

            /*Caso o Dialog do objeto receba OK, irá passar*/
            if(dlg.ShowDialog() == DialogResult.OK)
                _DataSourceReferencePassword = dlg.PassPhrase;

            return _DataSourceReferencePassword; //retorno do método.
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

        #endregion

        private void BuildMenus() // Constrói menus com base em chamadas de métodos. 
        {
            // FILE MENU

            ToolStripMenuItem menuRecentItem = new ToolStripMenuItem(""); // Objeto de Interface, Substituto do MenuItem();
            fileToolStripMenuItem.DropDownOpening += new EventHandler(menuFile_Popup);

            // Edit menu
            editToolStripMenuItem.DropDownOpening += new EventHandler(this.menuEdit_Popup);

            // VIEW MENU
            pageLayoutToolStripMenuItem.DropDownOpening += new EventHandler(this.menuPL_Popup);
            viewToolStripMenuItem.DropDownOpening += new EventHandler(this.menuView_Popup);

            // MAIN
            IsMdiContainer = true; /*MDI = Multiple Document Interface - Essa linha indica que o forme é do tipo MDI e terá MDIChilds dentro dele. */

        }

        private void menuFile_Popup(object sender, EventArgs e)
        {
            // Esses métodos necessitam de um MDIChild para trabalharem
            bool bEnable = this.MdiChildren.Length > 0 ? true : false;
            saveAsToolStripMenuItem.Enabled = bEnable;
            printToolStripMenuItem.Enabled = bEnable;
        }

        /* Esse método não será utilizado pelo OpenPOS pois ele abrirá um arquivo já existente
         * e como os relatórios do Open POS são baseados na base de dados e não em arquivos, não utilizaremos esse método.*/
        public void OpenReport(DialogFilterResult dfr)
        {
            OpenReport(dfr, true);
        }

        /* Esse método não será utilizado pelo OpenPOS pois ele abrirá um arquivo já existente
         * e como os relatórios do Open POS são baseados na base de dados e não em arquivos, não utilizaremos esse método.*/
        MDIChild OpenReport(DialogFilterResult dfr, bool show)
        {
            MDIChild result = null;

            // Connection String
            Connection conn = OpenPOS.DbContext.CreateConnection(false, true);
            string fileName = String.Format("{0}.rdl", Path.GetTempFileName());
            IRelatorio relatorio = dfr.Report;

            using(FileStream writer = File.Create(fileName))
            {
                byte[] bytes = Unimake.Convert.ToByteArray(relatorio.Script);
                writer.Write(bytes, 0, bytes.Length);
                writer.Flush();
                writer.Close();
            }

            Uri file = new Uri(fileName);

            MDIChild mcOpen = null;
            //Caso não tenha arquivo aberto
            if(file != null)
            {
                foreach(MDIChild mc in this.MdiChildren)
                {
                    if(file == mc.SourceFile)
                    {							// Encontrou o arquivo.
                        mcOpen = mc;
                        break;
                    }
                }
            }

            //Caso não tenha um arquivo aberto
            if(mcOpen == null)
            {
                QueryHelper.Connection = OpenPOS.DbContext.CreateConnection();
                QueryHelper.Command = PrepareCommand(relatorio.Script, dfr.FilterItems);

                result = new MDIChild(this.ClientRectangle.Width * 3 / 4, this.ClientRectangle.Height * 3 / 4, dfr.FilterItems);
                result.MdiParent = this;
                result.Viewer.GetDataSourceReferencePassword = _GetPassword;
                result.SourceFile = file;
                result.Text = relatorio.Nome;
                result.Viewer.Report.Name = relatorio.Nome;
                result.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                result.ControlBox = false;
                result.MaximizeBox = false;
                result.MinimizeBox = false;
                result.WindowState = FormWindowState.Maximized;
                result.Viewer.Rebuild();
                if(show) result.Show();
            }
            else
            {
                result = mcOpen;
                mcOpen.Activate();
            }

            return result;
        }

        private Command PrepareCommand(string xmlScript, IList<FilterItem> list)
        {
            Command result = QueryHelper.Connection.CreateCommand() as Command;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlScript);

            var el = doc.GetElementsByTagName("CommandText")[0];
            TSplitSQL splitSql = TSplitSQL.SplitSQL(el.InnerText);
            if(!OpenPOS.IEnumerableExtensions.IsNullOrEmpty(list))
            {
                Where where = list.ToWhere();

                if(String.IsNullOrEmpty(splitSql.Where))
                    splitSql.Where = " where " + where;
                else
                    splitSql.Where = " where " + where + " AND " + splitSql.Where.Substring(6);
                result.Parameters.AddRange(where.Parameters);
            }

            result.CommandText = splitSql.ToString();


            return result;
        }

        private void menuFilePrint_Click(object sender, EventArgs e)
        {
            MDIChild mc = this.ActiveMdiChild as MDIChild;
            if(mc == null)
                return;
            if(printChild != null)			// already printing
            {
                Unimake.MessageBox.Show(Strings.RdlReader_ShowC_PrintOneFile);
                return;
            }

            printChild = mc;

            PrintDocument pd = new PrintDocument();
            pd.DocumentName = mc.SourceFile.LocalPath;
            pd.PrinterSettings.FromPage = 1;
            pd.PrinterSettings.ToPage = mc.Viewer.PageCount;
            pd.PrinterSettings.MaximumPage = mc.Viewer.PageCount;
            pd.PrinterSettings.MinimumPage = 1;
            if(mc.Viewer.PageWidth > mc.Viewer.PageHeight)
                pd.DefaultPageSettings.Landscape = true;
            else
                pd.DefaultPageSettings.Landscape = false;

            PrintDialog dlg = new PrintDialog();
            dlg.Document = pd;
            dlg.AllowSelection = true;
            dlg.AllowSomePages = true;
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if(pd.PrinterSettings.PrintRange == PrintRange.Selection)
                    {
                        pd.PrinterSettings.FromPage = mc.Viewer.PageCurrent;
                    }
                    mc.Viewer.Print(pd);
                }
                catch(Exception ex)
                {
                    Unimake.MessageBox.Show(Strings.RdlReader_ShowC_PrintError + ex.Message);
                }
            }
            printChild = null;
        }

        private void menuFileSaveAs_Click(object sender, EventArgs e)
        {
            MDIChild mc = this.ActiveMdiChild as MDIChild;
            if(mc == null)
                return;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = Strings.RdlReader_menuFileSaveAs_Click_FilesFilter;
            sfd.FilterIndex = 1;

            Uri file = mc.SourceFile;

            if(file != null)
            {
                int index = file.LocalPath.LastIndexOf('.');
                if(index > 1)
                    sfd.FileName = file.LocalPath.Substring(0, index) + ".pdf";
                else
                    sfd.FileName = "*.pdf";

            }
            else
                sfd.FileName = "*.pdf";

            if(sfd.ShowDialog(this) != DialogResult.OK)
                return;

            // save the report in a rendered format 
            string ext = null;
            int i = sfd.FileName.LastIndexOf('.');
            if(i < 1)
                ext = "";
            else
                ext = sfd.FileName.Substring(i + 1).ToLower();

            OutputPresentationType type = OutputPresentationType.Internal;
            switch(ext)
            {
                case "pdf":
                    type = OutputPresentationType.PDF;
                    break;
                case "xml":
                    type = OutputPresentationType.XML;
                    break;
                case "html":
                    type = OutputPresentationType.HTML;
                    break;
                case "htm":
                    type = OutputPresentationType.HTML;
                    break;
                case "csv":
                    type = OutputPresentationType.CSV;
                    break;
                case "rtf":
                    type = OutputPresentationType.RTF;
                    break;
                case "mht":
                    type = OutputPresentationType.MHTML;
                    break;
                case "mhtml":
                    type = OutputPresentationType.MHTML;
                    break;
                case "xlsx":
                    type = OutputPresentationType.Excel;
                    break;
                case "tif":
                    type = OutputPresentationType.TIF;
                    break;
                case "tiff":
                    type = OutputPresentationType.TIF;
                    break;
                default:
                    Unimake.MessageBox.ShowError(
                        String.Format(Strings.RdlReader_SaveG_NotValidFileType, sfd.FileName), Strings.RdlReader_SaveG_SaveAsError);
                    break;
            }

            if(type == OutputPresentationType.TIF)
            {
                DialogResult dr = Unimake.MessageBox.Show(Strings.RdlReader_ShowF_WantSaveColorsInTIF, Strings.RdlReader_ShowF_Export, MessageBoxButtons.YesNoCancel);
                if(dr == DialogResult.No)
                    type = OutputPresentationType.TIFBW;
                else if(dr == DialogResult.Cancel)
                    return;
            }

            if(type != OutputPresentationType.Internal)
            {
                try { mc.Viewer.SaveAs(sfd.FileName, type); }
                catch(Exception ex)
                {
                    Unimake.MessageBox.ShowError(ex.Message, Strings.RdlReader_SaveG_SaveAsError);
                }
            }

            return;
        }

        private void menuCopy_Click(object sender, System.EventArgs ea)
        {
            MDIChild mc = this.ActiveMdiChild as MDIChild;
            if(mc == null || !mc.Viewer.CanCopy)
                return;

            mc.Viewer.Copy();
        }

        private void menuFind_Click(object sender, System.EventArgs ea)
        {
            MDIChild mc = this.ActiveMdiChild as MDIChild;
            if(mc == null)
                return;

            if(!mc.Viewer.ShowFindPanel)
                mc.Viewer.ShowFindPanel = true;
            mc.Viewer.FindNext();
        }

        private void menuSelection_Click(object sender, System.EventArgs ea)
        {
            MDIChild mc = this.ActiveMdiChild as MDIChild;
            if(mc == null)
                return;

            mc.Viewer.SelectTool = !mc.Viewer.SelectTool;
        }
        private void menuEdit_Popup(object sender, EventArgs e)
        {
            // These menus require an MDIChild in order to work
            bool bEnable = this.MdiChildren.Length > 0 ? true : false;
            copyToolStripMenuItem.Enabled = bEnable;
            findToolStripMenuItem.Enabled = bEnable;
            selectionToolToolStripMenuItem.Enabled = bEnable;
            if(!bEnable)
                return;

            MDIChild mc = this.ActiveMdiChild as MDIChild;
            copyToolStripMenuItem.Enabled = mc.Viewer.CanCopy;
            selectionToolToolStripMenuItem.Checked = mc.Viewer.SelectTool;
        }
        private void menuView_Popup(object sender, EventArgs e)
        {
            // These menus require an MDIChild in order to work
            bool bEnable = this.MdiChildren.Length > 0 ? true : false;
            zoomToToolStripMenuItem.Enabled = bEnable;
            actualSizeToolStripMenuItem.Enabled = bEnable;
            fitPageToolStripMenuItem.Enabled = bEnable;
            fitWidthToolStripMenuItem.Enabled = bEnable;
            pageLayoutToolStripMenuItem.Enabled = bEnable;
            if(!bEnable)
                return;

            // Now handle checking the correct sizing menu
            MDIChild mc = this.ActiveMdiChild as MDIChild;
            actualSizeToolStripMenuItem.Checked = fitPageToolStripMenuItem.Checked = fitWidthToolStripMenuItem.Checked = false;

            if(mc.Viewer.ZoomMode == ZoomEnum.FitWidth)
                fitWidthToolStripMenuItem.Checked = true;
            else if(mc.Viewer.ZoomMode == ZoomEnum.FitPage)
                fitPageToolStripMenuItem.Checked = true;
            else if(mc.Viewer.Zoom == 1)
                actualSizeToolStripMenuItem.Checked = true;

        }

        private void menuPL_Popup(object sender, EventArgs e)
        {
            MDIChild mc = this.ActiveMdiChild as MDIChild;
            if(mc == null)
                return;

            singlePageToolStripMenuItem.Checked = continuousToolStripMenuItem.Checked = false; ;

            switch(mc.Viewer.ScrollMode)
            {
                case ScrollModeEnum.Continuous:
                    continuousToolStripMenuItem.Checked = true;
                    break;
                case ScrollModeEnum.SinglePage:
                    singlePageToolStripMenuItem.Checked = true;
                    break;
            }
        }

        private void menuPLZoomTo_Click(object sender, EventArgs e)
        {
            MDIChild mc = this.ActiveMdiChild as MDIChild;
            if(mc == null)
                return;

            ZoomTo dlg = new ZoomTo(mc.Viewer);
            dlg.StartPosition = FormStartPosition.CenterParent;
            dlg.ShowDialog();
        }

        private void menuPLActualSize_Click(object sender, EventArgs e)
        {
            MDIChild mc = this.ActiveMdiChild as MDIChild;
            if(mc != null)
                mc.Viewer.Zoom = 1;
        }

        private void menuPLFitPage_Click(object sender, EventArgs e)
        {
            MDIChild mc = this.ActiveMdiChild as MDIChild;
            if(mc != null)
                mc.Viewer.ZoomMode = ZoomEnum.FitPage;
        }

        private void menuPLFitWidth_Click(object sender, EventArgs e)
        {
            MDIChild mc = this.ActiveMdiChild as MDIChild;
            if(mc != null)
                mc.Viewer.ZoomMode = ZoomEnum.FitWidth;
        }

        private void menuPLSinglePage_Click(object sender, EventArgs e)
        {
            MDIChild mc = this.ActiveMdiChild as MDIChild;
            if(mc != null)
                mc.Viewer.ScrollMode = ScrollModeEnum.SinglePage;
        }

        private void menuPLContinuous_Click(object sender, EventArgs e)
        {
            MDIChild mc = this.ActiveMdiChild as MDIChild;
            if(mc != null)
                mc.Viewer.ScrollMode = ScrollModeEnum.Continuous;
        }

        private void menuWndCloseAll_Click(object sender, EventArgs e)
        {
            foreach(Form f in this.MdiChildren)
            {
                f.Close();
            }
        }

        private void menuWndTileH_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void menuWndTileV_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDIChild mc = this.ActiveMdiChild as MDIChild;
            if(mc != null)
                mc.Close();

            this.Close();
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: Quando a documentação do relatório estiver pronta, deverá ser modificado este link
            System.Diagnostics.Process.Start("http://sourceforge.net/p/openposbr/wiki/browse_pages/");
        }

        internal void Print(DialogFilterResult dfr)
        {
            MDIChild mc = OpenReport(dfr, false);
            printChild = mc;

            PrintDocument pd = new PrintDocument();
            pd.DocumentName = mc.SourceFile.LocalPath;
            pd.PrinterSettings.FromPage = 1;
            pd.PrinterSettings.ToPage = mc.Viewer.PageCount;
            pd.PrinterSettings.MaximumPage = mc.Viewer.PageCount;
            pd.PrinterSettings.MinimumPage = 1;
            if(mc.Viewer.PageWidth > mc.Viewer.PageHeight)
                pd.DefaultPageSettings.Landscape = true;
            else
                pd.DefaultPageSettings.Landscape = false;

            try
            {
                if(pd.PrinterSettings.PrintRange == PrintRange.Selection)
                {
                    pd.PrinterSettings.FromPage = mc.Viewer.PageCurrent;
                }
                mc.Viewer.Print(pd);
            }
            catch(Exception ex)
            {
                Unimake.MessageBox.Show(Strings.RdlReader_ShowC_PrintError + ex.Message);
            }

            printChild = null;
        }
    }
}

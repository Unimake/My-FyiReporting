using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reports.Test.RdlDesign;
using OpenPOS.Model.Reports;
using OpenPOS.Data.Reports;
using Reports.Test.Exceptions;
using Reports.Test.RdlDesign.Forms;
using System.Diagnostics;
using System.IO;
using OpenPOS;
using RdlEngine.Definition;

namespace Reports.Test
{
    /// <summary>
    /// Trata os objetos do relatório ao editar ou exibir um relatório.
    /// </summary>
    public static class RdlManager
    {
        #region Construtores
        static RdlManager()
        {
            #region Config
            FileInfo fi = new FileInfo("OpenPOS.Desktop.exe.config");
            if(!fi.Exists)
                throw new FileNotFoundException("O Arquivo de configuração do relatório não foi encontrado e não pode ser criado.\r\n" + fi.FullName);

            File.Copy("OpenPOS.Desktop.exe.config", "RdlDesigner.exe.config", true);
            #endregion
        }
        #endregion

        #region Design
        /// <summary>
        /// Exibe o designer do relatório
        /// </summary>
        public static void OpenDesign()
        {
            Process.Start("RdlDesigner.exe");
        }

        /// <summary>
        /// Exibe o designer do relatório
        /// <param name="guid">Código do relatório que será exibido</param>
        /// </summary>
        public static void OpenDesign(GUID guid)
        {
            Process.Start("RdlDesigner.exe", "GUID:" + guid);
        }
        #endregion

        #region Viewer
        /// <summary>
        /// Abre um relatório e exibe no design
        /// </summary>
        /// <param name="relatorio">relatório que deverá ser carregado e exibido para visualização</param>
        /// <exception cref="ReportObjectInvalid">Lançada quando o objeto do relatório que deverá ser exibido é inválido</exception>
        public static void OpenViewer(IRelatorio relatorio)
        {
            OpenViewer(relatorio, null);
        }
        /// <summary>
        /// Abre um relatório e exibe no design
        /// </summary>
        /// <param name="relatorio">relatório que deverá ser carregado e exibido para visualização</param>
        /// <param name="filters">Filtros que deverão ser usados no relatório</param>
        /// <exception cref="ReportObjectInvalid">Lançada quando o objeto do relatório que deverá ser exibido é inválido</exception>
        public static void OpenViewer(IRelatorio relatorio, IEnumerable<FilterItem> filters)
        {
            if(relatorio.IsNullOrEmpty())
                throw new ReportObjectInvalid();

            DialogFilterResult dfr = DialogFilter.Show(relatorio, filters);

            if(dfr.DialogResult == System.Windows.Forms.DialogResult.Cancel)
                return;

            if(filters != null)
            {
                foreach(FilterItem item in filters)
                {
                    dfr.FilterItems.Add(item);
                }
            }

            Reader.RdlReader reader = new Reader.RdlReader();
            reader.OpenReport(dfr);
            reader.Show();
        }

        /// <summary>
        /// Abre um relatório e exibe no design
        /// </summary>
        /// <param name="relatorio"></param>
        /// <exception cref="ReportObjectInvalid">Lançada quando o objeto do relatório que deverá ser exibido é inválido</exception>
        public static void OpenViewer(GUID guid)
        {
            OpenViewer(guid, null);
        }

        /// <summary>
        /// Abre um relatório e exibe no design
        /// </summary>
        /// <param name="relatorio"></param>
        /// <param name="filters">Filtros que deverão ser usados no relatório</param> 
        /// <exception cref="ReportObjectInvalid">Lançada quando o objeto do relatório que deverá ser exibido é inválido</exception>
        public static void OpenViewer(GUID guid, IEnumerable<FilterItem> filters)
        {
            IRelatorio relatorio = new Relatorio(guid);
            OpenViewer(relatorio, filters);
        }
        #endregion
    }
}

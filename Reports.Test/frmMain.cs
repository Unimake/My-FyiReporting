using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reports.Test
{
    public partial class frmMain: Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            sfRelatorio.DataSource = new OpenPOS.Data.Reports.Relatorio().GetDisplayValues();
        }

        private void sfRelatorio_OnSelectedValueChanged(object sender, OpenPOS.Desktop.ComponentModel.SearchField.SelectedItemArgs args)
        {
            try
            {
                RdlManager.OpenViewer(args.GUID);
            }
            catch(Exception ex)
            {
                Unimake.MessageBox.ShowError(ex, true);
            }
        }
    }
}

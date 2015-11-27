using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenPOS.Model.Reports;
using OpenPOS.Data.Reports;
using Unimake.Data.Generic;

namespace fyiReporting.RdlDesign
{
    partial class frmDialogSave : Form
    {
        public SaveDialogResult Result { get; private set; }
        public List<SqlColumn> _Columns { get; internal set; }

        public frmDialogSave(List<SqlColumn> colunas)
        {
            InitializeComponent();

            if(OpenPOS.Settings.RuntimeMode)
            {
                sfGroup.DataSource = new Grupo().GetDisplayValues();
                this.dgvTipo.Populate(from x in Enum.GetValues(typeof(GenericDbType)).Cast<GenericDbType>()
                                      select new
                                      {
                                          value = Convert.ToString(x),
                                          text = Convert.ToString(x)
                                      });

                this.dgvComparacao.Populate(from x in Enum.GetValues(typeof(ComparisonType)).Cast<ComparisonType>()
                                            select new
                                            {
                                                value = Convert.ToString(x),
                                                text = Convert.ToString(x)
                                            });

                this.dgvClassificacao.Populate(from x in Enum.GetValues(typeof(OrderByClassification)).Cast<OrderByClassification>()
                                               select new
                                               {
                                                   value = Convert.ToString(x),
                                                   text = Convert.ToString(x)
                                               });

                this.dgvNomeReal.Populate(from x in colunas
                                          select new
                                          {
                                              value = Convert.ToString(x),
                                              text = Convert.ToString(x)
                                          });

                grdFiltros.Populate();
            }
        }

        public frmDialogSave(List<SqlColumn> colunas, IRelatorio relatorio)
            : this(colunas)
        {
            if (relatorio != null)
            {
                foreach (IFiltro item in relatorio.Filtros)
                {
                    grdFiltros.Rows.Add(new object[] 
                        {
                            item,
                            item.Apelido,
                            Convert.ToString(item.NomeReal),
                            Convert.ToString(item.Tipo),
                            Convert.ToBoolean(item.Obrigatorio),
                            item.Valor,
                            Convert.ToString(item.Comparacao),
                            Convert.ToString(item.Classificacao),
                            item.Valor,
                            item.Valor2
                        });
                }
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Result = new SaveDialogResult
            {
                DialogResult = DialogResult.Cancel,
                Success = false
            };

            DialogResult = DialogResult.Cancel;
            Hide();
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;
            IList<IFiltro> filtros = new List<IFiltro>();

            if (String.IsNullOrEmpty(txtTitle.Text))
            {
                MessageBox.Show("The \"Title\" field is required");
                return;
            }

            if(!OpenPOS.GUID.IsValid(sfGroup.SelectedItem.GUID))
            {
                MessageBox.Show("The \"Group\" field is required");
                return;
            }

            foreach (DataGridViewRow row in grdFiltros.Rows
             .Cast<DataGridViewRow>()
             .Where(w => !w.IsNewRow))
            {
                if (row.Cells[this.dgvApelido.Index].Value == null)
                {
                    Unimake.MessageBox.Show("Obrigatório informar o \"Apelido\" na linha selecionada.", MessageBoxIcon.Exclamation);
                    row.Selected = true;
                    return;
                }
                if (row.Cells[this.dgvNomeReal.Index].Value == null)
                {
                    Unimake.MessageBox.Show("Obrigatório informar o \"NomeReal\" na linha selecionada.", MessageBoxIcon.Exclamation);
                    row.Selected = true;
                    return;
                }
                if (row.Cells[this.dgvTipo.Index].Value == null)
                {
                    Unimake.MessageBox.Show("Obrigatório informar o \"Tipo\" na linha selecionada.", MessageBoxIcon.Exclamation);
                    row.Selected = true;
                    return;
                }

                Filtro filtro = new Filtro();
                if (row.Cells[this.dgvApelido.Index].Value != null)
                    filtro.Apelido = row.Cells[this.dgvApelido.Index].Value.ToString();
                if (row.Cells[this.dgvNomeReal.Index].Value != null)
                    filtro.NomeReal = row.Cells[this.dgvNomeReal.Index].Value.ToString();
                if (row.Cells[this.dgvClassificacao.Index].Value != null)
                    filtro.Classificacao = Unimake.Convert.ToEnum<OrderByClassification>(row.Cells[this.dgvClassificacao.Index].Value.ToString());
                if (row.Cells[this.dgvTipo.Index].Value != null)
                    filtro.Tipo = Unimake.Convert.ToEnum<GenericDbType>(row.Cells[this.dgvTipo.Index].Value.ToString());
                if (row.Cells[this.dgvObrigatorio.Index].Value != null)
                    filtro.Obrigatorio = Convert.ToBoolean(row.Cells[this.dgvObrigatorio.Index].Value);
                if (row.Cells[this.dgvPadrao.Index].Value != null)
                    filtro.Padrao = Convert.ToBoolean(row.Cells[this.dgvPadrao.Index].Value.ToString());
                if (row.Cells[this.dgvComparacao.Index].Value != null)
                    filtro.Comparacao = Unimake.Convert.ToEnum<ComparisonType>(row.Cells[this.dgvComparacao.Index].Value.ToString());
                if (row.Cells[this.dgvVlr1.Index].Value != null)
                    filtro.Valor = row.Cells[this.dgvVlr1.Index].Value.ToString();
                if (row.Cells[this.dgvVlr2.Index].Value != null)
                    filtro.Valor2 = row.Cells[this.dgvVlr2.Index].Value.ToString();
                filtros.Add(filtro);
            }

            Result = new SaveDialogResult
            {
                Success = true,
                DialogResult = DialogResult.OK,
                Group = new Grupo
                {
                    GUID = sfGroup.SelectedItem.GUID,
                    Nome = sfGroup.SelectedItem.Descricao
                },
                Filtros = filtros,
                Template = chkTemplate.Checked,
                Title = txtTitle.Text

            };

            DialogResult = DialogResult.OK;

            Hide();
        }

        private void frmDialogSave_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Result = new SaveDialogResult
                {
                    DialogResult = DialogResult.Cancel,
                    Success = false
                };

                DialogResult = DialogResult.Cancel;
            }
        }
    }

    internal class SaveDialogResult : OpenPOS.ResultBase
    {
        public IGrupo Group { get; set; }
        public string Title { get; set; }
        public IList<IFiltro> Filtros { get; set; }
        public bool Template { get; set; }
    }

    internal static class SaveDialog
    {
        public static SaveDialogResult Show(string title, OpenPOS.GUID group, List<SqlColumn> colunas, IRelatorio relatorio)
        {

            frmDialogSave save = new frmDialogSave(colunas, relatorio);
            RdlDesigner _rdlDesigner = save.Parent as RdlDesigner;

            save.txtTitle.Text = title;
            save.sfGroup.SetValue(group.ToString());
            save.ShowDialog();
            SaveDialogResult result = save.Result;
            save.Close();
            save.Dispose();
            return result;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenPOS.Model.Reports;
using OpenPOS;
using Unimake.Data.Generic;
using Unimake;
using System.Globalization;

namespace Reports.Test.RdlDesign.Forms
{
    partial class frmDialogFilter: Form
    {
        #region Locais

        private IList<IFiltro> Filtros { get; set; }

        #endregion Locais

        #region construtores

        public frmDialogFilter()
        {
            InitializeComponent();
            Result = new DialogFilterResult
            {
                DialogResult = System.Windows.Forms.DialogResult.Ignore
            };
        }

        public frmDialogFilter(IList<IFiltro> filtros)
            : this()
        {
            Filtros = filtros;
            Inicializar();
        }

        private void Inicializar()
        {
            int top = grpBxFiltro.Top + 21;

            foreach(IFiltro f in Filtros)
            {
                Label lblApelido = new Label();
                Control control = null;
                Control control2 = null;
                lblApelido.Name = "lbl" + f.Apelido;
                lblApelido.Text = f.Apelido;
                lblApelido.Left = 25;
                Label lblAte = new Label();
                lblAte.Name = "lblAte";
                lblAte.Text = "Até";
                grpBxFiltro.Controls.Add(lblApelido);

                switch(f.Tipo)
                {
                    case Unimake.Data.Generic.GenericDbType.Bit:
                    case Unimake.Data.Generic.GenericDbType.Boolean:
                        control = new CheckBox();
                        control.Width = 150;
                        control.Name = "chk" + f.Apelido;

                        control.Location = new Point(lblApelido.Location.X + lblApelido.Width, lblApelido.Location.Y);
                        break;

                    case Unimake.Data.Generic.GenericDbType.Byte:
                        break;

                    case Unimake.Data.Generic.GenericDbType.DateTime:
                        control = new DateTimePicker
                        {
                            ShowCheckBox = true
                        };

                        control.Width = 150;
                        control.Name = "dtp" + f.Apelido + "1";
                        control.Text = f.Valor;
                        control.Location = new Point(lblApelido.Location.X + lblApelido.Width, lblApelido.Location.Y);
                        ((DateTimePicker)control).Format = DateTimePickerFormat.Short;

                        if(f.Comparacao == Unimake.Data.Generic.ComparisonType.Between)
                        {
                            control2 = new DateTimePicker
                            {
                                ShowCheckBox = true
                            };
                            control2.Width = 150;
                            control2.Name = "dtp" + f.Apelido + "2";
                            control2.Text = f.Valor2;
                            control2.Location = new Point(control.Location.X + control.Width, lblApelido.Location.Y);
                            ((DateTimePicker)control2).Format = DateTimePickerFormat.Short;
                        }
                        break;

                    case Unimake.Data.Generic.GenericDbType.TimeStamp:
                    case Unimake.Data.Generic.GenericDbType.Float:
                    case Unimake.Data.Generic.GenericDbType.Object:
                    case Unimake.Data.Generic.GenericDbType.Integer:
                    case Unimake.Data.Generic.GenericDbType.String:
                    case Unimake.Data.Generic.GenericDbType.Unknown:
                        control = new TextBox();
                        control.Width = 150;
                        control.Name = "txt" + f.Apelido + "1";
                        control.Location = new Point(lblApelido.Location.X + lblApelido.Width, lblApelido.Location.Y);
                        control.Text = f.Valor;

                        if(f.Comparacao == Unimake.Data.Generic.ComparisonType.Between)
                        {
                            control2 = new TextBox();
                            control2.Width = 150;
                            control2.Name = "txt" + f.Apelido + "2";
                            control2.Text = f.Valor2;
                            control2.Location = new Point(control.Location.X + control.Width, lblApelido.Location.Y);
                        }
                        break;
                }

                control.Top = top;
                control.Left = lblApelido.Left + lblApelido.Width + 10;
                lblApelido.Top = control.Top;
                lblAte.Top = control.Top;

                if(f.Comparacao == Unimake.Data.Generic.ComparisonType.Between)
                {
                    if(f.Tipo == GenericDbType.DateTime)
                    {
                        grpBxFiltro.Controls.Add(lblAte);
                        lblAte.Width = 30;
                        lblAte.Left = control.Left + control.Width + 10;
                        control2.Left = lblAte.Left + lblAte.Width;
                    }
                    else
                        control2.Left = control.Left + control.Width + 10;

                    control2.Top = top;
                    control2.Tag = new FilterItem
                    {
                        Alias = f.Apelido,
                        Name = f.NomeReal,
                        Obrigatorio = f.Obrigatorio,
                        ComparisonType = f.Comparacao,
                        GenericDbType = f.Tipo,
                        Mascara = f.Mascara
                    };
                }
                control.Tag = new FilterItem
                {
                    Alias = f.Apelido,
                    Name = f.NomeReal,
                    Obrigatorio = f.Obrigatorio,
                    ComparisonType = f.Comparacao,
                    GenericDbType = f.Tipo,
                    Mascara = f.Mascara
                };

                grpBxFiltro.Controls.Add(control);
                if(control2 != null)
                    grpBxFiltro.Controls.Add(control2);

                top += control.Height + 5;
            }
        }

        #endregion construtores

        private void buttonOK1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.None;
            object vlr1 = null;
            object vlr2 = null;
            //-------------------------------------------------------------------------
            // Tem alguma validação?
            //-------------- -----------------------------------------------------------
            Result = new DialogFilterResult();
            Result.Success = Validate();
            if(Result.Success)
                Result.DialogResult = System.Windows.Forms.DialogResult.OK;
            else
            {
                System.Windows.Forms.MessageBox.Show("Os valores informados não são válidos para o filtro de registros.");
                return;
            }

            foreach(Control item in grpBxFiltro.Controls)
            {
                if((item is Label) || String.IsNullOrEmpty(item.Text)) continue;

                if(item is DateTimePicker &&
                    !((DateTimePicker)item).Checked) continue;

                //-------------------------------------------------------------------------
                // Aqui foi implementado apenas o primeiro campo
                //-------------------------------------------------------------------------
                FilterItem filterItem = (FilterItem)item.Tag;

                //-------------------------------------------------------------------------
                // Definir o modo de comparação selecionado pelo usuário
                //-------------------------------------------------------------------------
                if(vlr1 == null)
                    vlr1 = item.Text;
                else
                    vlr2 = item.Text;


                if(vlr1 != null &&
                   vlr2 != null)
                {
                    filterItem.ComparisonType = ComparisonType.Between;
                    filterItem.Values = new OpenPOS.List<object> {
                        vlr1,
                        vlr2
                    };

                    Result.FilterItems.RemoveAt(Result.FilterItems.Count - 1);
                    Result.FilterItems.Add(filterItem);
                    vlr1 = vlr2 = null;
                }
                else
                {
                    filterItem.ComparisonType = item is DateTimePicker ? ComparisonType.Equal : ComparisonType.Having;
                    filterItem.Values = new OpenPOS.List<object> {
                        vlr1
                    };

                    Result.FilterItems.Add(filterItem);
                }
            }
            Hide();
        }

        private void buttonCancelar1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Result = new DialogFilterResult
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel
            };
            Hide();
        }

        public new DialogResult ShowDialog()
        {
            DialogResult result = base.ShowDialog();

            if(result == DialogResult.Cancel)
                result = base.ShowDialog();

            return result;
        }

        private new bool Validate()
        {
            bool valido = true;
            FilterItem filterItem = new FilterItem();

            foreach(Control item in grpBxFiltro.Controls)
            {
                if((item is Label) || String.IsNullOrEmpty(item.Text)) continue;

                //-------------------------------------------------------------------------
                // Aqui foi implementado apenas o primeiro campo
                //-------------------------------------------------------------------------
                filterItem = (FilterItem)item.Tag;

                if(filterItem.Obrigatorio &&
                   String.IsNullOrWhiteSpace(item.Text))
                {
                    item.SetErrorState("Este filtro é obrigatório.");
                    return false;
                }
                if(!String.IsNullOrWhiteSpace(item.Text))
                    switch(filterItem.GenericDbType)
                    {
                        case GenericDbType.Integer:
                        case GenericDbType.Integer64:
                        case GenericDbType.Float:
                        case GenericDbType.Decimal:
                        case GenericDbType.Double:
                            double d = 0;
                            if(!Double.TryParse(item.Text, out d))
                            {
                                item.SetErrorState("O valor informado para este campo não é válido. Informe apenas números");
                                return false;
                            }
                            break;

                        case GenericDbType.DateTime:
                        case GenericDbType.TimeStamp:
                            DateTimePicker dateTimePicker = item as DateTimePicker;

                            if(dateTimePicker.Checked)
                            {

                                DateTime dt = DateTime.Today;
                                if(!DateTime.TryParseExact(item.Text, "dd/MM/yyyy",
                                    CultureInfo.CurrentCulture.DateTimeFormat, DateTimeStyles.None, out dt))
                                {
                                    item.SetErrorState("O valor informado para este campo não é válido. Informe apenas datas");
                                    return false;
                                }
                            }
                            break;

                        case GenericDbType.Boolean:
                        case GenericDbType.String:
                        case GenericDbType.Bit:
                        case GenericDbType.Byte:
                        case GenericDbType.Object:
                        case GenericDbType.Unknown:
                        default:
                            break;
                    }
            }

            return valido;
        }

        public DialogFilterResult Result { get; private set; }
    }

    public struct FilterItem
    {
        #region propriedades

        public string Name { get; set; }
        public string Alias { get; set; }
        public IList<object> Values { get; set; }
        public ComparisonType ComparisonType { get; set; }
        public bool Obrigatorio { get; set; }
        public GenericDbType GenericDbType { get; set; }
        public string Mascara { get; set; }

        public string ParemeterName
        {
            get { return "@p______" + Math.Abs(Alias.GetHashCode()); }
        }

        #endregion propriedades
    }

    public class DialogFilterResult: ResultBase
    {
        public IList<FilterItem> FilterItems { get; set; }
        public IRelatorio Report { get; set; }

        public DialogFilterResult()
            : base()
        {
            FilterItems = new OpenPOS.List<FilterItem>();
        }
    }

    public static class DialogFilter
    {
        public static DialogFilterResult Show(IRelatorio relatorio, IEnumerable<FilterItem> filters = null)
        {
            frmDialogFilter f = new frmDialogFilter(relatorio.Filtros);

            if(!OpenPOS.IEnumerableExtensions.IsNullOrEmpty(relatorio.Filtros))
                f.Result.DialogResult = f.ShowDialog();
            else
            {
                if(filters != null)
                {
                    foreach(FilterItem filtro in filters)
                    {
                        f.Result.FilterItems.Add(new FilterItem
                        {
                            Alias = filtro.Alias,
                            Name = filtro.Name,
                            ComparisonType = filtro.ComparisonType,
                            Values = filtro.Values,
                            GenericDbType = filtro.GenericDbType,
                            Mascara = filtro.Mascara
                        });
                    }
                }

                f.Result.DialogResult = DialogResult.OK;
            }

            DialogFilterResult result = f.Result;
            result.Report = relatorio;
            f.Close();
            return result;
        }
    }
}
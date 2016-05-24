using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenPOS.Exceptions;

namespace Reports.Test.Exceptions
{
    /// <summary>
    /// Lançada quando o objeto do relatório que deverá ser exibido é inválido
    /// </summary>
    public class ReportObjectInvalid: ExceptionBase
    {
        public override string Message
        {
            get
            {
                return "O objeto de relatório que foi passado é inválido ou não existe na base de dados.";
            }
        }
    }
}

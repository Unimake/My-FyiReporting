using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdlEngine.Definition
{
    public static class QueryHelper
    {
        public static IDbConnection Connection { get; set; }
        public static IDbCommand Command { get; set; }
        public static IDataReader DataReader { get; set; }
    }
}

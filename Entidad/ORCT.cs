using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class ORCT
    {
        public DateTime DocDate { get; set; }

        public double DocTotal { get; set; }

        public string Comments { get; set; }

        public string DocCurr { get; set; }

        public List<RCT4> Lineas { get; set; }
    }

    public class RCT4
    {

        public int IdLine { get; set; }

        public string U_GMI_PAGORELACION { get; set; }

        public string LineMemo { get; set; }

        public double LineTotal { get; set; }

        public RCT4(int idLine, string u_GMI_PAGORELACION, string lineMemo, double lineTotal)
        {
            IdLine = idLine;
            U_GMI_PAGORELACION = u_GMI_PAGORELACION;
            LineMemo = lineMemo;
            LineTotal = lineTotal;
        }
    }
}

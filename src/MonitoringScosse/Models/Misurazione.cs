using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonitoringScosse.Models
{
    public class Misurazione
    {
        public int ID { get; set; }

        public DateTime DataOra { get; set; }

        public double SpostamentoX { get; set; }

        public double SpostamentoY { get; set; }

        public double SpostamentoZ { get; set; }

        public int IdStazione { get; set; }

    }
}

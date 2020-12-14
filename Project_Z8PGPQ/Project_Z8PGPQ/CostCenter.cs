using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Z8PGPQ
{
    public abstract class CostCenter
    {
        public int ID { get; set; }
        public String CTR { get; set; }
        public DateTime VFROM { get; set; }
        public DateTime VTO { get; set; }
        public String TYPE { get; set; }
        public String PROFCTR { get; set; }
        public OrgCodes ORGCODE;
        public virtual String ORGCODE_O { get; set; }
        public virtual String GEOCODE { get; set; }
        public abstract void WriteCSVLine(StreamWriter sw);
    }
}

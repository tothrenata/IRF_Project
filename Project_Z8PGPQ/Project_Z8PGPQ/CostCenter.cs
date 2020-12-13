using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Z8PGPQ
{
    public abstract class CostCenter
    {
        public String CTR { get; set; }
        public DateTime VFROM { get; set; }
        public DateTime VTO { get; set; }
        public String TYPE { get; set; }
        public String PROFCTR { get; set; }
        public OrgCodes ORGCODE;
        public virtual string ORGCODE_STR { get; set; }
        public String GEOCODE { get; set; }

        public abstract void WriteCSVLine(String FileName);

        //ellenőrizni azt attribútumokat

    }
}

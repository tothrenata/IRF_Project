using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Z8PGPQ
{
    class CostCenter
    {
        public String CTR { get; set; }
        public DateTime VFROM { get; set; }
        public DateTime VTO { get; set; }
        public String TYPE { get; set; }
        public String PROFCTR { get; set; }
        public OrgCodes ORGCODE;
        public string ORGCODE_STR
        {
            get
            {
                if (ORGCODE == OrgCodes.FI) return "FI";
                if (ORGCODE == OrgCodes.BI) return "BI";
                if (ORGCODE == OrgCodes.MA) return "MA";
                return "invalid";
            }
            set
            {
                ORGCODE = (OrgCodes)int.Parse(value);
            }
        }
        public String GEOCODE { get; set; }
    }
}

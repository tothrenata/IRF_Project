using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Z8PGPQ
{
    public class CostCenterHC: CostCenter
    {
        public override String ORGCODE_STR
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

        public override String GEOCODE
        {
            get 
            { 
                return GEOCODE; 
            }
            set 
            { 
                GEOCODE = ""; 
            }

        }

        public override void WriteCSVLine(String FileName)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Z8PGPQ
{
    public class CostCenterHC : CostCenter
    {
        public String ORGCODE_STR
        {
            get
            {
                if (ORGCODE == OrgCodes.FI) return "FI";
                if (ORGCODE == OrgCodes.BI) return "BI";
                if (ORGCODE == OrgCodes.MA) return "MA";
                return "invalid";
            }
        }

        public override String ORGCODE_O
        {
            get
            {
                return ORGCODE_STR;
            }
            set
            {
                ORGCODE = (OrgCodes)int.Parse(value);
            }
        }

        public override void WriteCSVLine(StreamWriter sw)
        {
            sw.Write(CTR);
            sw.Write(";");
            sw.Write(VFROM.Year.ToString() + "/" + VFROM.Month.ToString() + "/" + VFROM.Day.ToString());
            sw.Write(";");
            sw.Write(VTO.Year.ToString() + "/" + VTO.Month.ToString() + "/" + VTO.Day.ToString());
            sw.Write(";");
            sw.Write(TYPE.ToString());
            sw.Write(";");
            sw.Write(PROFCTR);
            sw.Write(";");
            sw.Write(ORGCODE_STR);
            sw.Write(";");
            sw.WriteLine("");
        }
    }
}

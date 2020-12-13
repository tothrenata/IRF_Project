using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Z8PGPQ
{
    public class CostCenterNH : CostCenter
    {
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
            sw.Write("");
            sw.Write(";");
            sw.WriteLine(GEOCODE);
        }
    }
}

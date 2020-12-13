using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Project_Z8PGPQ
{
    class CostCentersDB
    {
        public List<CostCenter> costCenters = new List<CostCenter>();

        public CostCentersDB()
        {
            ReadXML();
        }

        public void ReadXML()
        {
            var xml = new XmlDocument();
            xml.Load("XML files/CostCenters.xml");

            foreach (XmlElement element in xml.DocumentElement)
            {
                String type = element.GetAttribute("TYPE");
                
                CostCenter cc;

                if (type == "Headcount") cc = new CostCenterHC();
                else if (type == "Nonheadcount") cc = new CostCenterNH();
                else continue; //kihagy egy iterációt

                cc.CTR = element.GetAttribute("CTR");
                cc.VFROM = DateTime.Parse(element.GetAttribute("VFROM"));
                cc.VTO = DateTime.Parse(element.GetAttribute("VTO"));
                cc.TYPE = type;
                cc.PROFCTR = element.GetAttribute("PROFCTR");
                cc.ORGCODE_STR = element.GetAttribute("ORGCODE");
                cc.GEOCODE = element.GetAttribute("GEOCODE");
                costCenters.Add(cc);
            }
        }
        //WriteCSVLine(FileName);
        public void ToCSV(String FileName)
        {
            using (StreamWriter sw = new StreamWriter(FileName, false, Encoding.UTF8))
            {
                sw.Write("CTR");
                sw.Write(";");
                sw.Write("VFROM");
                sw.Write(";");
                sw.Write("VTO");
                sw.Write(";");
                sw.Write("TYPE");
                sw.Write(";");
                sw.Write("PROFCTR");
                sw.Write(";");
                sw.WriteLine("ORGCODE");

                foreach (CostCenter cc in costCenters)
                {
                    sw.Write(cc.CTR);
                    sw.Write(";");
                    sw.Write(cc.VFROM.Year.ToString() + "/" + cc.VFROM.Month.ToString() + "/" + cc.VFROM.Day.ToString());
                    sw.Write(";");
                    sw.Write(cc.VTO.Year.ToString() + "/" + cc.VTO.Month.ToString() + "/" + cc.VTO.Day.ToString());
                    sw.Write(";");
                    sw.Write(cc.TYPE.ToString());
                    sw.Write(";");
                    sw.Write(cc.PROFCTR);
                    sw.Write(";");
                    sw.WriteLine(cc.ORGCODE.ToString());
                }
            }
        }
    }
}

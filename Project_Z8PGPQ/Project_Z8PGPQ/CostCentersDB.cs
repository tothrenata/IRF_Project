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

        public List<CostCenter> wrongcostCenters = new List<CostCenter>();

        public CostCentersDB()
        {
            ReadXML();
        }

        public void ReadXML()
        {
            var xml = new XmlDocument();
            xml.Load("XML files/CostCenters.xml");

            int ID = 1;

            foreach (XmlElement element in xml.DocumentElement)
            {
                String type = element.GetAttribute("TYPE");

                CostCenter cc;

                if (type == "Headcount")
                {
                    cc = new CostCenterHC();
                    cc.ORGCODE = (OrgCodes)int.Parse(element.GetAttribute("ORGCODE"));
                }
                else if (type == "Nonheadcount")
                {
                    string test = element.GetAttribute("GEOCODE");
                    cc = new CostCenterNH();

                    cc.GEOCODE = element.GetAttribute("GEOCODE");
                }
                else continue;
                cc.ID = ID;
                cc.CTR = element.GetAttribute("CTR");
                cc.VFROM = DateTime.Parse(element.GetAttribute("VFROM"));
                cc.VTO = DateTime.Parse(element.GetAttribute("VTO"));
                cc.TYPE = type;
                cc.PROFCTR = element.GetAttribute("PROFCTR");
                costCenters.Add(cc);

                ID++;
            }
        }
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
                sw.Write("ORGCODE");
                sw.Write(";");
                sw.WriteLine("GEOCODE");

                foreach (CostCenter cc in costCenters)
                {
                    cc.WriteCSVLine(sw);
                }
            }
        }

        public void WrongElements()
        {
            wrongcostCenters.Clear();
            foreach (var item in costCenters)
            {
                if (item.CTR.Length != 8) wrongcostCenters.Add(item);
                if (item.VTO != DateTime.Parse("9999/12/31")) wrongcostCenters.Add(item);
                if (item.TYPE != "Nonheadcount" && item.TYPE != "Headcount") wrongcostCenters.Add(item);
                if (item.PROFCTR.Length !=5) wrongcostCenters.Add(item);
            }   
        }

        public void RefreshCostCenters()
        {
            foreach (var wrongcostCenter in wrongcostCenters)
            {
                for (int i = 0; i < costCenters.Count; i++)
                {
                    if (costCenters[i].ID == wrongcostCenter.ID)
                    {
                        costCenters[i] = wrongcostCenter;
                    }
                }
            }
        }
    }
}

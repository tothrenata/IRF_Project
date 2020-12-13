using System;
using System.Collections.Generic;
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
                CostCenter cc = new CostCenter();

                cc.CTR = element.GetAttribute("CTR");
                cc.VFROM = DateTime.Parse(element.GetAttribute("VFROM"));
                cc.VTO = DateTime.Parse(element.GetAttribute("VTO"));
                cc.TYPE = element.GetAttribute("TYPE");
                cc.PROFCTR = element.GetAttribute("PROFCTR");
                cc.ORGCODE_STR = element.GetAttribute("ORGCODE");
                cc.GEOCODE = element.GetAttribute("GEOCODE");
                costCenters.Add(cc);
            }
        }
    }
}

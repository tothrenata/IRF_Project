using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Z8PGPQ
{
    public class CostCenterNH: CostCenter
    {
        public override String ORGCODE_STR
        {
            get 
            { 
                return "";
            }
            set 
            { 
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
                GEOCODE=value; 
            } 
        
        }

        public override void WriteCSVLine(String FileName)
        {
            throw new NotImplementedException();
        }
    }
}

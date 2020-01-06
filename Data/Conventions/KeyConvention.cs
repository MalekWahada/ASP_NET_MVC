using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Conventions
{
   public class KeyConvention:Convention
    {
        public KeyConvention()
        {
            //this.Properties().Where(p => p.Name == "CIN").Configure(p => p.IsKey());
            this.Properties().Where(e => e.Name.EndsWith("Code")).Configure(e => e.IsKey());
        }
    }
}

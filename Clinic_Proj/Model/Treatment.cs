using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Proj.Model
{
    public class Treatment
    {
        public virtual int ID { get; set; }
        public virtual string Type { get; set; }
        public virtual string Description { get; set; }
    }
}

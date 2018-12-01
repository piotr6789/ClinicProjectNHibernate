using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Proj.Model
{
    public class Visit
    {
        public virtual int ID { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual VisitType VisitType { get; set; }
        public virtual DateTime VisitDate { get; set; }
        public virtual string Description { get; set; }
    }
}

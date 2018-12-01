using Clinic_Proj.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Proj.Mapping
{
    public class VisitMap : ClassMap<Visit>
    {
        public VisitMap()
        {
            Table("Visits");
            //LazyLoad();
            Id(x => x.ID).Column("ID");
            References(x => x.Patient).Column("PatientID");
            References(x => x.VisitType).Column("TypeID");
            Map(x => x.VisitDate).Column("VisitDate");
            Map(x => x.Description).Column("Description").Not.Nullable();
        }
    }
}

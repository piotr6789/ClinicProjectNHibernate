using Clinic_Proj.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Proj.Mapping
{
    public class TreatmentMap : ClassMap<Treatment>
    {
        public TreatmentMap()
        {
            Table("Treatments");
            //LazyLoad();
            Id(x => x.ID).Column("ID");
            Map(x => x.Type).Column("Type").Not.Nullable();
            Map(x => x.Description).Column("Description").Nullable();
        }
    }
}

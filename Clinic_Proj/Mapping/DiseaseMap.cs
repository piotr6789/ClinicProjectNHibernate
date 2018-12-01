using Clinic_Proj.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Proj.Mapping
{
    public class DiseaseMap : ClassMap<Disease>
    {
        public DiseaseMap()
        {
            Table("Diseases");
            //LazyLoad();
            Id(x => x.ID).Column("ID");
            References(x => x.Patient).Column("PatientID");
            References(x => x.Treatment).Column("TreatmentID");
            Map(x => x.Description).Column("Description").Nullable();
        }
    }
}

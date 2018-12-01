using Clinic_Proj.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Proj.Mapping
{
    public class PatientMap : ClassMap<Patient>
    {
        public PatientMap()
        {
            Table("Patients");
            //LazyLoad();
            Id(x => x.ID).Column("ID");
            References(x => x.Doctor).Column("DoctorID").Not.Nullable();
            Map(x => x.FirstName).Column("FirstName").Not.Nullable();
            Map(x => x.SecondName).Column("SecondName").Nullable();
            Map(x => x.Surname).Column("Surname").Not.Nullable();
            Map(x => x.PESEL).Column("PESEL").Not.Nullable();
            Map(x => x.Address).Column("Address").Not.Nullable();
        }
    }
}

using Clinic_Proj.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Proj.Mapping
{
    public class DoctorMap : ClassMap<Doctor>
    {
        public DoctorMap()
        {
            Table("Doctors");
            //LazyLoad();
            Id(x => x.ID).Column("ID");
            Map(x => x.FirstName).Column("FirstName").Not.Nullable();
            Map(x => x.Surname).Column("Surname").Not.Nullable();
            Map(x => x.PWZNumber).Column("PWZNumber").Not.Nullable();
            //HasMany(x => x.Patients).KeyColumn("DoctorID");
        }
    }
}

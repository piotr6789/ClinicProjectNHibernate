using Clinic_Proj.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Proj.Mapping
{
    public class VisitTypeMap : ClassMap<VisitType>
    {
        public VisitTypeMap()
        {
            Table("VisitTypes");
            //LazyLoad();
            Id(x => x.ID).Column("ID");
            Map(x => x.Name).Column("Name");
        }   
    }
}

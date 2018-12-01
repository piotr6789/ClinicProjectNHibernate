using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Clinic_Proj.Model
{
    [XmlRoot("Patient")]
    public class Patient
    {
        [XmlElement("ID")]
        public virtual int ID { get; set; }

        [XmlElement("Doctor")]
        public virtual Doctor Doctor { get; set; }

        [XmlElement("FirstName")]
        public virtual string FirstName { get; set; }

        [XmlElement("SecondName")]
        public virtual string SecondName { get; set; }

        [XmlElement("Surname")]
        public virtual string Surname { get; set; }

        [XmlElement("PESEL")]
        public virtual string PESEL { get; set; }

        [XmlElement("Address")]
        public virtual string Address { get; set; }
        //public virtual IList<Visit> Visits { get; set; }
        //public virtual IList<Disease> Diseases { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Proj.Model
{
    [Serializable()]
    public class Doctor
    {
        [System.Xml.Serialization.XmlElement("ID")]
        public virtual int ID { get; set; }

        [System.Xml.Serialization.XmlElement("FirstName")]
        public virtual string FirstName { get; set; }

        [System.Xml.Serialization.XmlElement("Surname")]
        public virtual string Surname { get; set; }

        [System.Xml.Serialization.XmlElement("PWZNumber")]
        public virtual string PWZNumber { get; set; }
        //public virtual IList<Patient> Patients { get; set; }
    }
}

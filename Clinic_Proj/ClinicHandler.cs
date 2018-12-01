using Clinic_Proj.Model;
using FluentNHibernate;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Clinic_Proj
{
    public class ClinicHandler
    {
        private ISessionFactory _sessionFactory;

        public ClinicHandler()
        {
            Configuration configuration = new Configuration();
            configuration.AddMappingsFromAssembly(Assembly.GetExecutingAssembly());
            _sessionFactory = configuration.BuildSessionFactory();
        }

        public List<T> SelectTableData<T>() where T : class
        {
            List<T> tableDataList = null;
            Type type = typeof(T);

            using (ISession session = _sessionFactory.OpenSession())
            {
                tableDataList = session.QueryOver<T>().List().ToList();
            }

            return tableDataList;
        }

        public List<Patient> GetPatientsByDoctorName(string surnname)
        {
            IList<Patient> patientList = null;


            using (ISession session = _sessionFactory.OpenSession())
            {
                patientList = session.QueryOver<Patient>().Where(x => x.Doctor != null)
                    .JoinQueryOver(x => x.Doctor)
                    .Where(y => y.Surname == surnname).List();
            }

            return patientList.ToList();
        }

        public List<Patient> GetPatientsByIDForIndex(int index, int count)
        {
            List<Patient> patients = null;

            using (ISession session = _sessionFactory.OpenSession())
            {
                patients = session.QueryOver<Patient>().JoinQueryOver(x => x.Doctor).Skip(index - 1).Take(count - 1).List().ToList();
            }

            return patients;
        }

        public List<Treatment> GetAllPatientTreatments(string PESEL)
        {
            List<Treatment> treatments = new List<Treatment>();

            using (ISession session = _sessionFactory.OpenSession())
            {
                List<Disease> diseases = session.QueryOver<Disease>()
                                                 .Where(x => x.Patient != null)
                                                 .JoinQueryOver(x => x.Patient)
                                                 .Where(y => y.PESEL == PESEL).List().ToList();

                if (diseases != null)
                {
                    foreach (Disease disease in diseases)
                    {
                        Treatment treatment = session.QueryOver<Treatment>().Where(x => x.ID == disease.Treatment.ID).SingleOrDefault();
                        treatments.Add(treatment);
                    }
                }
            }

            return treatments;
        }

        public List<string> GetTreatmentsDescription()
        {
            IList<string> treatmentsDescription = null;
            
            using (ISession session = _sessionFactory.OpenSession())
            {
                treatmentsDescription = session.QueryOver<Treatment>().Select(treatment => treatment.Description).List<string>();
            }

            return treatmentsDescription.ToList();
        }

        public void SaveToJSON()
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                List<Patient> patientList = session.QueryOver<Patient>().List().ToList();

                foreach (Patient patient in patientList)
                {
                    patient.Doctor = new Doctor()
                    {
                        ID = patient.Doctor.ID,
                        FirstName = patient.Doctor.FirstName,
                        Surname = patient.Doctor.Surname,
                        PWZNumber = patient.Doctor.PWZNumber
                        
                    };
                }
                using (StreamWriter file = File.CreateText(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), @"Results\Patients.json")))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, patientList);
                }
            }
        }

        public void SaveToXML()
        {
            string file = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), @"Results\Patients.json"));

            List<Patient> patientList = JsonConvert.DeserializeObject<List<Patient>>(file);

            XmlSerializer xsSubmit = new XmlSerializer(typeof(List<Patient>));
            string xml = string.Empty;

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, patientList);
                    xml = sww.ToString();
                }
            }

            File.WriteAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), @"Results\Patients.xml"), xml);
        }

        public void ReadFromJSON()
        {
            Console.WriteLine("Read from JSON file\n");
            string file = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), @"Results\Patients.json"));

            List<Patient> patientList = JsonConvert.DeserializeObject<List<Patient>>(file);

            foreach (var item in patientList)
            {
                Console.WriteLine("ID: {0}\tFirst Name: {1}\tSecond Name: {2}\tSurname: {3}\tPESEL: {4}\tAddress: {5}\tDoctor: {6}", item.ID, item.FirstName, item.SecondName, item.Surname, item.PESEL, item.Address, item.Doctor.Surname);
            }
            Console.WriteLine("\n\n\n");
        }

        public void ReadFromXML()
        {
            Console.WriteLine("Read from XML\n");
            string file = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), @"Results\Patients.xml"));
            XmlSerializer serializer = new XmlSerializer(typeof(List<Patient>));
            using (TextReader reader = new StringReader(file))
            {
                List<Patient> result = (List<Patient>)serializer.Deserialize(reader);

                foreach (var item in result)
                {
                    Console.WriteLine("ID: {0}\tFirst Name: {1}\tSecond Name: {2}\tSurname: {3}\tPESEL: {4}\tAddress: {5}\tDoctor: {6}", item.ID, item.FirstName, item.SecondName, item.Surname, item.PESEL, item.Address, item.Doctor.Surname);
                }
            }

            
        }
       
    }
}

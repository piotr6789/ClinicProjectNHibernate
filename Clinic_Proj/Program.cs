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
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Proj
{
    class Program
    {


        static void Main(string[] args)
        {
            printSelectTableData();
            printGetPatientsByDoctorName();
            printGetPatientsByIDForIndex();
            printGetAllPatientTreatments();
            printGetTreatmentsDescription();

            ClinicHandler clinicHandler = new ClinicHandler();
            clinicHandler.SaveToJSON();
            clinicHandler.SaveToXML();
            clinicHandler.ReadFromJSON();
            clinicHandler.ReadFromXML();
        }

        public static void printSelectTableData()
        {
            ClinicHandler clinicHandler = new ClinicHandler();

            Console.WriteLine("List of doctors\n");
            List<Doctor> doctors = clinicHandler.SelectTableData<Doctor>();
            foreach (var item in doctors)
            {
                Console.WriteLine("ID: {0}\tFirst name: {1}\tSurname: {2}\tPWZNumber {3}", item.ID, item.FirstName, item.Surname, item.PWZNumber);
            }
            Console.WriteLine("\n\n\n\n");
        }

        public static void printGetPatientsByDoctorName()
        {
            ClinicHandler clinicHandler = new ClinicHandler();

            Console.WriteLine("List of doctor 'Andrzejczak' patients\n");
            List<Patient> patients = clinicHandler.GetPatientsByDoctorName("Andrzejczak");
            foreach (var item in patients)
            {
                Console.WriteLine("ID: {0}\tFirst name: {1}\tSecond Name: {2}\tSurname: {3}\tPESEL: {4}", item.ID, item.FirstName, item.SecondName, item.Surname, item.PESEL);
            }
            Console.WriteLine("\n\n\n\n");
        }

        public static void printGetPatientsByIDForIndex()
        {
            ClinicHandler clinicHandler = new ClinicHandler();

            Console.WriteLine("Paging patients (2 patients, from 2 index)\n");
            List<Patient> patientsPagination = clinicHandler.GetPatientsByIDForIndex(1, 3);
            foreach (var item in patientsPagination)
            {
                Console.WriteLine("ID: {0}\tFirst name: {1}\tSecond Name: {2}\tSurname: {3}\tPESEL: {4}", item.ID, item.FirstName, item.SecondName, item.Surname, item.PESEL);
            }
            Console.WriteLine("\n\n\n\n");
        }

        public static void printGetAllPatientTreatments()
        {
            ClinicHandler clinicHandler = new ClinicHandler();

            Console.WriteLine("Treatment of a patient with PESEL: 57091170697\n");
            List<Treatment> patientTreatments = clinicHandler.GetAllPatientTreatments("57091170697");
            foreach (var item in patientTreatments)
            {
                Console.WriteLine("ID: {0}\tType: {1}\tDescription: {2}", item.ID, item.Type, item.Description);
            }
            Console.WriteLine("\n\n\n\n");
        }

        public static void printGetTreatmentsDescription()
        {
            ClinicHandler clinicHandler = new ClinicHandler();

            Console.WriteLine("Treatments description\n");
            List<string> treatmentDescriptions = clinicHandler.GetTreatmentsDescription();
            foreach (var item in treatmentDescriptions)
            {
                Console.WriteLine("Description: {0}", item.ToString());
            }
            Console.WriteLine("\n\n");
        }
    }
}

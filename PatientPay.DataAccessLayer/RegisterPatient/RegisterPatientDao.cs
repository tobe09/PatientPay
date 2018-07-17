using PatientPay.BusinessObjects.RegisterPatient;
using PatientPay.DataAccessLayer.Abstractions;
using PatientPay.DataAccessLayer.Context;
using PatientPay.DatabaseEntities.Entities;
using System;
using System.Linq;

namespace PatientPay.DataAccessLayer.RegisterPatient
{
    public class RegisterPatientDao: BaseDao, IRegisterPatientDao
    {
        public RegisterPatientDao() : base() { }
        public RegisterPatientDao(PayContext testContext) : base(testContext) { }

        public int RegisterPatient(PatientData patientData)
        {
            using (var payContext = GetDbContext())
            {
                Patient patient = Mapper.Map<PatientData, Patient>(patientData);
                payContext.Patients.Add(patient);
                return payContext.SaveChanges();
            }
        }

        public bool UsernameExists(string username)
        {
            using (var payContext = GetDbContext())
            {
                return payContext.Patients.Any(p => p.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            }
        }

        public bool EmailExists(string email)
        {
            using (var payContext = GetDbContext())
            {
                return payContext.Patients.Any(p => p.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            }
        }

        public bool PhoneNoExists(long phoneNo)
        {
            using (var payContext = GetDbContext())
            {
                return payContext.Patients.Any(p => p.PhoneNo == phoneNo || p.PhoneNo2 == phoneNo);
            }
        }

        public int GetLastPatientId()
        {
            using(var payContext  = GetDbContext())
            {
                if (payContext.Patients.Count() == 0) return 0;
                return payContext.Patients.Max(patient => patient.Id);
            }
        }
    }
}

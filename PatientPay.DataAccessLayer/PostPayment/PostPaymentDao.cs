  using PatientPay.BusinessObjects.PostPayment;
using PatientPay.DataAccessLayer.Abstractions;
using PatientPay.DataAccessLayer.Context;
using PatientPay.DatabaseEntities.Entities;
using System;
using System.Linq;

namespace PatientPay.DataAccessLayer.PostPayment
{
    public class PostPaymentDao : BaseDao, IPostPaymentDao
    {
        public PostPaymentDao() : base() { }
        public PostPaymentDao(PayContext testContext) : base(testContext) { }

        public int SavePayment(PostPaymentData paymentData)
        {
            using(var payContext = GetDbContext())
            {
                Payment payment = Mapper.Map<PostPaymentData, Payment>(paymentData);
                int patientId = payContext.Patients.FirstOrDefault(pat => pat.PatientGivenId == paymentData.PatientGivenId).Id;
                payment.PatientId = patientId;
                payContext.Payments.Add(payment);
                return payContext.SaveChanges();
            }
        }

        public PatientBasicInfo GetPatientDetailById(string patientId)
        {
            return GetSingleFilteredAsInfo<Patient, PatientBasicInfo>(p => p.PatientGivenId.Equals(patientId, StringComparison.OrdinalIgnoreCase));
            //using (var payContext = GetDbContext())
            //{
            //    var patient = payContext.Patients.FirstOrDefault(p => p.PatientGivenId.Equals(patientId, StringComparison.OrdinalIgnoreCase));
            //    if (patient == null)
            //    {
            //        return null;
            //    }

            //    return new PatientBasicInfo
            //    {
            //        PatientGivenId = patient.PatientGivenId,
            //        FirstName = patient.FirstName,
            //        LastName = patient.LastName,
            //        Username = patient.Username
            //    };
            //}
        }

        public PatientBasicInfo GetPatientDetailByUsername(string username)
        {
            return GetSingleFilteredAsInfo<Patient, PatientBasicInfo>(p => p.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            //using (var payContext = GetDbContext())
            //{
            //    var patient = payContext.Patients.FirstOrDefault(p => p.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            //    if (patient == null)
            //    {
            //        return null;
            //    }

            //    return new PatientBasicInfo
            //    {
            //        PatientGivenId = patient.PatientGivenId,
            //        FirstName = patient.FirstName,
            //        LastName = patient.LastName,
            //        Username = patient.Username
            //    };
            //}
        }
    }
}

using PatientPay.BusinessObjects.FindPayment;
using PatientPay.BusinessObjects.RegisterPatient;
using PatientPay.DataAccessLayer.Abstractions;
using PatientPay.DataAccessLayer.Context;
using PatientPay.DatabaseEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PatientPay.DataAccessLayer.FindPayment
{
    public class FindPaymentDao : BaseDao, IFindPaymentDao
    {
        public FindPaymentDao() : base() { }
        public FindPaymentDao(PayContext testContext) : base(testContext) { }

        public PaymentBreakdownInfo GetPaymentBreakdownInfo(string patientGivenId)
        {
            using (var payContext = GetDbContext())
            {
                var brkDown = (from patient in payContext.Patients
                               where patient.PatientGivenId == patientGivenId
                               select new PaymentBreakdownInfo
                               {
                                   CreatingAdminName = payContext.Administrators.Where(a => a.Id == patient.CreatedBy)
                                   .Select(a => a.LastName + ", " + a.FirstName + " " + a.MiddleName).FirstOrDefault(),  
                                   PatientData = new PatientData
                                   {
                                       Id = patient.Id,
                                       FirstName = patient.FirstName,
                                       LastName = patient.LastName,
                                       MiddleName = patient.MiddleName,
                                       Email = patient.Email,
                                       HomeAddress = patient.HomeAddress,
                                       CreatedDate = patient.CreatedDate,
                                       PatientGivenId = patient.PatientGivenId,
                                       Username = patient.Username,
                                       PhoneNo = patient.PhoneNo,
                                       PhoneNo2 = patient.PhoneNo2
                                   },
                                   Breakdown = patient.Payments.Where(p => p.PatientId == patient.Id).Select(p => new PaymentBreakdown
                                   {
                                       CreatedDate = p.CreatedDate,
                                       Description = p.Description,
                                       Amount = p.Amount
                                   }).ToList()
                               }).FirstOrDefault();

                return brkDown;
            }
        }

    public List<PaymentBreakdown> GetBreakDown(string patientGivenId)
        {

            var patientId = GetSingleFiltered<Patient>(p => p.PatientGivenId == patientGivenId).Id;
            var pbdList = GetAllFilteredAsInfo<Payment, PaymentBreakdown>(p => p.PatientId == patientId);

            return pbdList.ToList();

            //using (var payContext = GetDbContext())
            //{
            //    //var pbd = from patient in payContext.Patients
            //    //          join payment in payContext.Payments
            //    //          on patient.PatientGivenId equals patientGivenId
            //    //          select new PaymentBreakdown { Amount = payment.Amount, Description = payment.Description, CreatedDate = payment.CreatedDate };
            //    //return pbd.ToList();

            //    //var pbdList2 = payContext.Patients.Join(
            //    //    payContext.Payments,
            //    //    patient => patient.PatientGivenId,
            //    //    payment => patientGivenId,
            //    //    (patient, payment) => new PaymentBreakdown { Amount = payment.Amount, Description = payment.Description, CreatedDate = payment.CreatedDate });
            //    //return pbdList2.ToList();

            //    //int patientId = payContext.Patients.First(p => p.PatientGivenId.Equals(patientGivenId, StringComparison.OrdinalIgnoreCase)).Id;

            //    //return payContext.Payments.Where(p => p.PatientId == patientId)
            //    //    .Select(p => new PaymentBreakdown { Amount = p.Amount, Description = p.Description, CreatedDate = p.CreatedDate })
            //    //    .ToList();
            //}
        }

        public List<PatientFoundDetails> GetByDetail(string value)
        {
            //bool func(Patient patient)
            //{
            //    return patient.Email.StartsWith(value, StringComparison.OrdinalIgnoreCase) ||
            //                                    patient.PatientGivenId.StartsWith(value, StringComparison.OrdinalIgnoreCase) ||
            //                                    patient.Username.StartsWith(value, StringComparison.OrdinalIgnoreCase) ||
            //                                    patient.PhoneNo.ToString().StartsWith(value, StringComparison.OrdinalIgnoreCase) ||
            //                                    patient.PhoneNo2.ToString().StartsWith(value, StringComparison.OrdinalIgnoreCase);
            //}

            //return GetAllFilteredAsInfo<Patient, PatientFoundDetails>(func).ToList();

            using (var payContext = GetDbContext())
            {
                var matchingPatients = from patient in payContext.Patients//.AsEnumerable()
                                       where patient.Email.ToUpper().StartsWith(value.ToUpper()) ||//, StringComparison.OrdinalIgnoreCase) ||
                                                patient.PatientGivenId.ToUpper().StartsWith(value.ToUpper()) ||//, StringComparison.OrdinalIgnoreCase) ||
                                                patient.Username.ToUpper().StartsWith(value.ToUpper()) ||//, StringComparison.OrdinalIgnoreCase) ||
                                                ("0" + patient.PhoneNo).StartsWith(value) ||//, StringComparison.OrdinalIgnoreCase) ||
                                                ("0" + patient.PhoneNo2).StartsWith(value)//, StringComparison.OrdinalIgnoreCase)
                                                                                          //select Mapper.Map<Patient, PatientFoundDetails>(patient); 
                                       select new PatientFoundDetails
                                       {
                                           PatientGivenId = patient.PatientGivenId,
                                           FirstName = patient.FirstName,
                                           LastName = patient.LastName,
                                           Username = patient.Username,
                                           TotalAmount = patient.Payments.Count == 0 ? 0 : patient.Payments.Sum(payment => payment.Amount)
                                       };

                return matchingPatients.ToList();
            }
        }

        public string GetCreatingAdminName(string patientId)
        {
            using (var payContext = GetDbContext())
            {
                int creatingAdminid = payContext.Patients.First(p => p.PatientGivenId.Equals(patientId, StringComparison.OrdinalIgnoreCase)).CreatedBy;

                var admin = payContext.Administrators.First(adm => adm.Id == creatingAdminid);

                return $"{admin.LastName}, {admin.FirstName} {admin.MiddleName}";
            }
        }

        public PatientData GetPatientData(string patientId)
        {
            PatientData patientData = GetSingleFilteredAsInfo<Patient, PatientData>(p => p.PatientGivenId.Equals(patientId, StringComparison.OrdinalIgnoreCase));
            return patientData;
            //using (var payContext = GetDbContext())
            //{
            //    Patient patient = payContext.Patients.First(p => p.PatientGivenId.Equals(patientId, StringComparison.OrdinalIgnoreCase));
            //    PatientData patientData = Mapper.Map<Patient, PatientData>(patient);

            //    return patientData;
            //}
        }


        /*//not used
        public List<PatientFoundDetails> GetByEmail(string email)
        {
            using (var payContext = GetDbContext())
            {
                return payContext.Patients.ToList()
                    .Where(p => p.Email.StartsWith(email, StringComparison.OrdinalIgnoreCase))
                    .Select(GetPatientFound)
                    .ToList();
            }
        }

        //not used
        public List<PatientFoundDetails> GetByPatientsId(string patientId)
        {
            using (var payContext = GetDbContext())
            {
                return payContext.Patients.ToList()
                    .Where(p => p.PatientGivenId.StartsWith(patientId, StringComparison.OrdinalIgnoreCase))
                    .Select(GetPatientFound)
                    .ToList();
            }
        }

        //not used
        public List<PatientFoundDetails> GetByPhoneNo(string phoneNo)
        {
            using (var payContext = GetDbContext())
            {
                return payContext.Patients.ToList()
                    .Where(p => p.PhoneNo.ToString().StartsWith(phoneNo, StringComparison.OrdinalIgnoreCase) ||
                                p.PhoneNo2.ToString().StartsWith(phoneNo, StringComparison.OrdinalIgnoreCase))
                    .Select(GetPatientFound)
                    .ToList();
            }
        }

        //not used
        public List<PatientFoundDetails> GetByUsername(string username)
        {
            using (var payContext = GetDbContext())
            {
                return payContext.Patients.ToList()
                    .Where(p => p.Username.StartsWith(username, StringComparison.OrdinalIgnoreCase))
                    .Select(GetPatientFound)
                    .ToList();
            }
        }

        private PatientFoundDetails GetPatientFound(Patient p)
        {
            return new PatientFoundDetails
            {
                PatientGivenId = p.PatientGivenId,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Username = p.Username,
                TotalAmount = p.Payments == null ? 0 : p.Payments.Aggregate(0.0, (seed, payment) => seed + payment.Amount)
            };
        }*/
    }
}

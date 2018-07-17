using PatientPay.BusinessLogicLayer.Abstractions;
using PatientPay.BusinessLogicLayer.Factories;
using PatientPay.BusinessObjects.RegisterPatient;
using PatientPay.DataAccessLayer.RegisterPatient;
using System;

namespace PatientPay.BusinessLogicLayer.RegisterPatient
{
    public class RegisterPatientService : BaseService, IRegisterPatientService
    {
        private IRegisterPatientDao regPatientDao;

        public RegisterPatientService()
        {
            regPatientDao = DaoFactory.GetDao<IRegisterPatientDao>();
        }

        public RegisterPatientService(IRegisterPatientDao testDao)
        {
            regPatientDao = testDao;
        }

        public PatientInfo RegisterPatient(IPatientData iPatientData)
        {            
            PatientData patientData = Mapper.Map<IPatientData, PatientData>(iPatientData);  //map properties into patient data
            if (!patientData.IsValid())
            {
                return GetErrorResponse<PatientInfo>(patientData.ErrorMessages);
            }
            patientData.PatientGivenId = GetNewPatientGivenId();
            patientData.CreatedDate = DateTime.Now;

            string uniqueDataExistMessage = UniqueDataExist(patientData);  
            if (uniqueDataExistMessage != null)
            {
                return GetErrorResponse< PatientInfo>(uniqueDataExistMessage);
            }

            int status = regPatientDao.RegisterPatient(patientData);      //register patient
            if (ExecutionError(status))
            {
                return GetErrorResponse< PatientInfo>("Error occured saving patient details");
            }

            PatientInfo patientInfo = new PatientInfo();
            patientInfo.PatientGivenId = patientData.PatientGivenId;

            return GetSuccessResponse($"User {patientData.Username} has been registered successfully.", patientInfo);
        }

        private string GetNewPatientGivenId()
        {
            string patientId = "PATIENT";

            int lastId = regPatientDao.GetLastPatientId();
            int newId = lastId + 1;
            if (newId < 10) patientId += "000" + newId;
            else if (newId < 100) patientId += "00" + newId;
            else if (newId < 1000) patientId += "0" + newId;
            else patientId += newId;

            return patientId;
        }

        private string UniqueDataExist(PatientData patientData)
        {
            bool usernameExist = regPatientDao.UsernameExists(patientData.Username);
            if (usernameExist)
            {
                return "Username Exists";
            }
            bool emailExist = regPatientDao.EmailExists(patientData.Email);
            if (emailExist)
            {
                return "Email Exists";
            }
            bool phoneNoExist = regPatientDao.PhoneNoExists(patientData.PhoneNo);
            if (phoneNoExist)
            {
                return "First Phone Number Exists";
            }
            bool phoneNo2Exist = patientData.PhoneNo2 != null && regPatientDao.PhoneNoExists((long)patientData.PhoneNo2);
            if (phoneNo2Exist)
            {
                return "Second Phone Number Exists";
            }

            return null;
        }
    }
}

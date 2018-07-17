using PatientPay.BusinessLogicLayer.Abstractions;
using PatientPay.BusinessLogicLayer.Factories;
using PatientPay.BusinessObjects.General;
using PatientPay.BusinessObjects.PostPayment;
using PatientPay.DataAccessLayer.PostPayment;
using System;

namespace PatientPay.BusinessLogicLayer.PostPayment
{
    public class PostPaymentService: BaseService, IPostPaymentService
    {
        private IPostPaymentDao postPaymentDao;

        public PostPaymentService()
        {
            postPaymentDao = DaoFactory.GetDao<IPostPaymentDao>();
        }

        public PostPaymentService(IPostPaymentDao testDao)
        {
            postPaymentDao = testDao;
        }

        public BasicInfo SavePayment(IPostPaymentData iPaymentData)
        {
            BasicInfo paymentInfo = new BasicInfo();

            PostPaymentData paymentData = Mapper.Map<IPostPaymentData, PostPaymentData>(iPaymentData);  //map properties into payment data
            paymentData.CreatedDate = DateTime.Now;
            if (!paymentData.IsValid())
            {
                return GetErrorResponse<BasicInfo>(paymentData.ErrorMessages);
            }

            int status = postPaymentDao.SavePayment(paymentData);               //save payment
            if (ExecutionError(status))
            {
                return GetErrorResponse<BasicInfo>("Error occured making payment");
            }
            
            return GetSuccessResponse($"Payment of {paymentData.Amount} naira by {paymentData.Username} was successful", paymentInfo);
        }

        public PatientBasicInfo GetPatientDetailById(string patientId)
        {
            PatientBasicInfo patientInfo = postPaymentDao.GetPatientDetailById(patientId);

            return SearchResponse(patientInfo, "Patient Id", patientId);
        }

        public PatientBasicInfo GetPatientDetailByUsername(string username)
        {
            PatientBasicInfo patientInfo = postPaymentDao.GetPatientDetailByUsername(username);

            return SearchResponse(patientInfo, "Username", username);
        }

        private PatientBasicInfo SearchResponse(PatientBasicInfo patientInfo, string searchType, string searchValue)
        {
            if (patientInfo == null)
            {
                string example = searchType == "Patient Id" ? "(e.g. PATIENT0001)" : "";

                return GetErrorResponse<PatientBasicInfo>($"{searchType} {searchValue} does not exist. {example}");
            }
            
            return GetSuccessResponse("User found", patientInfo);
        }
    }
}

using PatientPay.BusinessLogicLayer.Abstractions;
using PatientPay.BusinessLogicLayer.Factories;
using PatientPay.BusinessObjects.FindPayment;
using PatientPay.DataAccessLayer.FindPayment;
using System.Collections.Generic;

namespace PatientPay.BusinessLogicLayer.FindPayment
{
    public class FindPaymentService : BaseService, IFindPaymentService
    {
        private IFindPaymentDao findPaymentDao;

        public FindPaymentService()
        {
            findPaymentDao = DaoFactory.GetDao<IFindPaymentDao>();
        }

        public FindPaymentService(IFindPaymentDao testDao)
        {
            findPaymentDao = testDao;
        }

        public FindPaymentInfo GetSearchedPatients(IFindPaymentData iFindPaymentData)
        {
            FindPaymentData findPaymentData = Mapper.Map<IFindPaymentData, FindPaymentData>(iFindPaymentData);
            if (!findPaymentData.IsValid())
            {
                return GetErrorResponse<FindPaymentInfo>(findPaymentData.ErrorMessages);
            }

            List<PatientFoundDetails> patientsFound = findPaymentDao.GetByDetail(findPaymentData.ValueEntered);
            if(patientsFound.Count == 0)
            {
                return GetErrorResponse< FindPaymentInfo>($"No patient matches {iFindPaymentData.ValueEntered}");
            }

            FindPaymentInfo info = new FindPaymentInfo();
            info.PatientsFound = patientsFound;
            string pluralValue = patientsFound.Count > 1 ? "s" : "";

            return GetSuccessResponse($"{patientsFound.Count} patient{pluralValue} found", info);
        }

        public PaymentBreakdownInfo GetPaymentBreakdown(string patientId)
        {
            PaymentBreakdownInfo breakdownInfo = findPaymentDao.GetPaymentBreakdownInfo(patientId);

            if (breakdownInfo == null)
            {
                return GetErrorResponse<PaymentBreakdownInfo>($"Patient with id {patientId} not found.");
            }
            //var patientData = findPaymentDao.GetPatientData(patientId);
            //var breakdown = findPaymentDao.GetBreakDown(patientId);
            //var creatingAdmin = findPaymentDao.GetCreatingAdminName(patientId);

            //breakdownInfo.PatientData = patientData ?? new PatientData();
            //breakdownInfo.Breakdown = breakdown ?? new List<PaymentBreakdown>();
            //breakdownInfo.CreatingAdminName = creatingAdmin;

            return GetSuccessResponse("Patient information successfully loaded.", breakdownInfo);
        }

        /*//not used
        private FindPaymentInfo GetSearchedPatientsOld(IFindPaymentData iFindPaymentData)
        {
            FindPaymentInfo info = new FindPaymentInfo();

            FindPaymentData findPaymentData = Mapper.Map<IFindPaymentData, FindPaymentData>(iFindPaymentData);
            if (!findPaymentData.IsValid())
            {
                return GetErrorResponse(findPaymentData.ErrorMessages, info);
            }

            List<PatientFoundDetails> patientsFound = GetPatientsFound(findPaymentData);
            if (patientsFound.Count == 0)
            {
                return GetErrorResponse("No patient matches selected criteria and value", info);
            }

            info.PatientsFound = patientsFound;
            info.SuccessMessage = $"{patientsFound.Count} patients found";

            return info;
        }

        //not used
        private List<PatientFoundDetails> GetPatientsFound(IFindPaymentData iFindPaymentData)
        {
            List<PatientFoundDetails> patientsFound;

            if (iFindPaymentData.SelectedCriterion.StartsWith("patient", StringComparison.OrdinalIgnoreCase))    //patient id
            {
                patientsFound = findPaymentDao.GetByPatientsId(iFindPaymentData.ValueEntered);
            }
            else if (iFindPaymentData.SelectedCriterion.StartsWith("username", StringComparison.OrdinalIgnoreCase)) //username
            {
                patientsFound = findPaymentDao.GetByUsername(iFindPaymentData.ValueEntered);
            }
            else if (iFindPaymentData.SelectedCriterion.StartsWith("email", StringComparison.OrdinalIgnoreCase)) //email
            {
                patientsFound = findPaymentDao.GetByPhoneNo(iFindPaymentData.ValueEntered);
            }
            else            //phone number
            {
                patientsFound = findPaymentDao.GetByPhoneNo(iFindPaymentData.ValueEntered);
            }

            return patientsFound;
        }*/
    }
}

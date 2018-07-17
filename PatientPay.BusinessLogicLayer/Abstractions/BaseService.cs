using AutoMapper;
using PatientPay.BusinessObjects.Abstractions;
using PatientPay.BusinessObjects.Enumeration;
using PatientPay.BusinessObjects.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientPay.BusinessLogicLayer.Abstractions
{
    public abstract class BaseService : IService
    {
        protected IMapper Mapper
        {
            get { return Mapping.GetMapper(); }
        }

        protected bool ExecutionError(int status)
        {
            return status < 1;      //for data manipulation queries from DAOs
        }

        public static T GetErrorResponse<T>(List<ErrorContainer> errorMessages) where T : IInfo, new()
        {
            T responseInfo = new T();
            responseInfo.ErrorMessages.AddRange(errorMessages);
            responseInfo.StatusCode = StatusCode.Failure;

            return responseInfo;
        }

        public static T GetErrorResponse<T>(string errorMessage, string propertyName = null) where T : IInfo, new()
        {
            T responseInfo = new T();
            var errorResult = new ErrorContainer { ErrorMessage = errorMessage, PropertyName = propertyName };
            responseInfo.ErrorMessages.Add(errorResult);
            responseInfo.StatusCode = StatusCode.Failure;

            return responseInfo;
        }

        public static T GetSuccessResponse<T>(string message, T responseInfo) where T : IInfo
        {
            responseInfo.SuccessMessage = message;
            responseInfo.StatusCode = StatusCode.Success;

            return responseInfo;
        }
    }
}

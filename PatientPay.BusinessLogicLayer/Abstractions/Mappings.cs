using System;
using AutoMapper;
using PatientPay.BusinessObjects.RegisterPatient;
using PatientPay.BusinessObjects.PostPayment;
using PatientPay.BusinessObjects.FindPayment;
using PatientPay.BusinessObjects.AdminLogin;

namespace PatientPay.BusinessLogicLayer.Abstractions
{
    class MappingProfile : Profile
    {
        //Add maps in constructor
        public MappingProfile()
        {
            CreateMap<IPatientData, PatientData>();
            CreateMap<IPostPaymentData, PostPaymentData>();
            CreateMap<IFindPaymentData, FindPaymentData>();
            CreateMap<IAdminLoginData, AdminLoginData>();
        }
    }

    /// <summary>
    /// Performs mappings to abstract the data persistence layer from the business layer
    /// </summary>
    class Mapping
    {
        private static readonly Lazy<IMapper> lazyMapper = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(configExpression => {
                configExpression.ShouldMapProperty = (prop) => prop.GetMethod.IsPublic || prop.GetMethod.IsAssembly;    //include internal properties
                configExpression.AddProfile<MappingProfile>();   //add mapping profile
            });
            var mapper = config.CreateMapper();

            return mapper;
        });

        public static IMapper GetMapper()
        {
            return lazyMapper.Value;
        }
    }
}

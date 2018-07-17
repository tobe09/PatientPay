using AutoMapper;
using PatientPay.BusinessObjects.AdminLogin;
using PatientPay.BusinessObjects.FindPayment;
using PatientPay.BusinessObjects.PostPayment;
using PatientPay.BusinessObjects.RegisterPatient;
using PatientPay.DataAccessLayer.Context;
using PatientPay.DatabaseEntities.Entities;
using System;
using System.Linq;

namespace PatientPay.DataAccessLayer.Abstractions
{
    class MappingProfile : Profile
    {
        //Add maps in constructor
        public MappingProfile()
        {
            CreateMap<PatientData, Patient>();
            CreateMap<Patient, PatientData>();
            CreateMap<Patient, PatientFoundDetails>().AfterMap((p, pfd) =>
                {
                    pfd.TotalAmount = p.Payments == null ? 0 : p.Payments.Aggregate(0.0, (seed, payment) => seed + payment.Amount);
                });
            CreateMap<PostPaymentData, Payment>();
            CreateMap<Administrator, Admin>();
            CreateMap<Patient, PatientBasicInfo>();
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

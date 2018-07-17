using AutoMapper;
using PatientPay.BusinessObjects.FindPayment;
using PatientPay.BusinessObjects.RegisterPatient;
using System;

namespace PatientPay.MvcWebApp.Abstractions
{
    class Mappings : Profile
    {
        //Add maps in constructor
        public Mappings()
        {
            CreateMap<PatientData, PatientFoundDetails>();
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
                configExpression.AddProfile<Mappings>();   //add mapping profile
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
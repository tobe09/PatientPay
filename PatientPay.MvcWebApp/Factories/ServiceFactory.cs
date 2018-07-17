using PatientPay.BusinessLogicLayer.AdminLogin;
using PatientPay.BusinessLogicLayer.FindPayment;
using PatientPay.BusinessLogicLayer.PostPayment;
using PatientPay.BusinessLogicLayer.RegisterPatient;
using System;
using System.Collections.Generic;

namespace PatientPay.MvcWebApp.Factories
{
    public class ServiceFactory
    {
        private ServiceFactory() { }

        static ServiceFactory()
        {
            if (typeToService == null)
            {
                PerformRegistrations();
            }
        }

        private static Dictionary<Type, object> typeToService;
        
        private static void PerformRegistrations()
        {
            typeToService = new Dictionary<Type, object>();
            Register<IAdminLoginService>(typeof(AdminLoginService));
            Register<IFindPaymentService>(typeof(FindPaymentService));
            Register<IPostPaymentService>(typeof(PostPaymentService));
            Register<IRegisterPatientService>(typeof(RegisterPatientService));
        }
        
        public static void Register<T>(Type type)
        {
            if (!typeof(T).IsAssignableFrom(type))
            {
                throw new Exception("Wrong service interface implementation");    
            }
            if (type.GetConstructor(Type.EmptyTypes) == null || type.IsAbstract)
            {
                throw new ArgumentException("Service object being registered cannot be instantiated");
            }

            typeToService[typeof(T)] = Activator.CreateInstance(type);
        }

        public static T GetService<T>()
        {
            return (T)typeToService[typeof(T)];
        }
    }
}
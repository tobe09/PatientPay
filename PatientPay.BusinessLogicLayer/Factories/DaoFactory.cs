using PatientPay.DataAccessLayer.AdminLogin;
using PatientPay.DataAccessLayer.FindPayment;
using PatientPay.DataAccessLayer.PostPayment;
using PatientPay.DataAccessLayer.RegisterPatient;
using System;
using System.Collections.Generic;

namespace PatientPay.BusinessLogicLayer.Factories
{
    public class DaoFactory
    {
        private DaoFactory() { }

        static DaoFactory()
        {
            if (typeToDao == null)
            {
                PerformRegistrations();
            }
        }

        private static Dictionary<Type, object> typeToDao;

        private static void PerformRegistrations()
        {
            typeToDao = new Dictionary<Type, object>();
            Register<IAdminLoginDao>(typeof(AdminLoginDao));
            Register<IFindPaymentDao>(typeof(FindPaymentDao));
            Register<IPostPaymentDao>(typeof(PostPaymentDao));
            Register<IRegisterPatientDao>(typeof(RegisterPatientDao));
        }

        public static void Register<T>(Type type)
        {
            if (!typeof(T).IsAssignableFrom(type))
            {
                throw new Exception("Wrong dao interface implementation");
            }
            if (type.GetConstructor(Type.EmptyTypes) == null || type.IsAbstract)
            {
                throw new ArgumentException("Dao object being registered cannot be instantiated");
            }

            typeToDao[typeof(T)] = Activator.CreateInstance(type);  //to enable overwriting
        }

        public static T GetDao<T>()
        {
            return (T)typeToDao[typeof(T)];
        }
    }
}

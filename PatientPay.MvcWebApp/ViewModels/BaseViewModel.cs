using System;
using System.Reflection;

namespace PatientPay.MvcWebApp.ViewModels
{
    public class BaseViewModel
    {
        public void ClearAllFields()
        {
            PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach(var property in properties)
            {
                Type propType = property.PropertyType;
                dynamic value;
                if (propType.IsValueType)
                {
                    value = Activator.CreateInstance(propType);
                }
                else
                {
                    value = null;
                }

                property.SetMethod.Invoke(this, new[] { value });
            }
        }
    }
}
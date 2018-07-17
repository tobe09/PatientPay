using AutoMapper;
using PatientPay.MvcWebApp.Abstractions;
using System;
using System.Web.Mvc;

namespace PatientPay.MvcWebApp.Extensions
{
    public static class ExtensionClass
    {
        public static string GetDisplayDateString(this HtmlHelper htmlHelper, DateTime date)
        {
            string dayOfWeek = date.DayOfWeek.ToString();
            int day = date.Day;
            string month = new[] { "January", "February", "March", "April", "May", "June", "July",
                "August", "September", "October", "November", "December" }[date.Month - 1];
            int year = date.Year;

            return $"{dayOfWeek}, {day}{DatePostfix(day)} {month}, {year}";
        }

        private static string DatePostfix(int val)
        {
            if (val % 10 == 1 && val != 11) return "st";
            else if (val % 10 == 2 && val != 12) return "nd";
            else if (val % 10 == 3 && val != 13) return "rd";
            return "th";
        }

        public static IMapper GetMapper(this Controller controller)
        {
            return Mapping.GetMapper();
        }
    }
}
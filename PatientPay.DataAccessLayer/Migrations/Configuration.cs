namespace PatientPay.DataAccessLayer.Migrations
{
    using PatientPay.DataAccessLayer.Context;
    using PatientPay.DatabaseEntities.Entities;
    using PatientPay.Utilities.Hashing;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<PayContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PayContext context)
        {
            context.Administrators.AddOrUpdate(
                new Administrator
                {
                    Id = 1,
                    Username = "Femi",
                    FirstName = "Femi",
                    LastName = "Johnson",
                    MiddleName = "Jonathan",
                    Email = "femijohnson@gmail.com",
                    Password = StringSecure.Encrypt("femifemi"),
                    PhoneNo = 8136831102,
                    HomeAddress = "Today's Solution",
                    CreatedDate = new DateTime(2018, 6, 28)
                }
                );
        }
    }
}

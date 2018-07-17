using PatientPay.DatabaseEntities.Entities;
using System.Data.Entity;

namespace PatientPay.DataAccessLayer.Context
{
    public class PayContext : DbContext
    {
        internal PayContext() : base("PayContextDb")
        {
            InitializeInternalSets();
        }
        public PayContext(string integrationTestDbConnString) : base(integrationTestDbConnString)
        {
            InitializeInternalSets();
        }

        //not the best tact, preferably keep entities in a different project
        void InitializeInternalSets()
        {
            //set internal properties using Set<> method
            Administrators = Set<Administrator>();
        }

        internal virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }

        //public static string ConnectionString()
        //{
        //    //const string appName = "PatientPay";
        //    //const string providerName = "System.Data.SqlClient";
        //    //string dataSource = "localhost";
        //    //string initialCatalog = "PayContextDb";
        //    //string metaData = "needed";

        //    //SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
        //    //sqlBuilder.DataSource = dataSource;
        //    //sqlBuilder.InitialCatalog = initialCatalog;
        //    //sqlBuilder.MultipleActiveResultSets = true;
        //    //sqlBuilder.IntegratedSecurity = true;
        //    //sqlBuilder.ApplicationName = appName;

        //    EntityConnectionStringBuilder efBuilder = new EntityConnectionStringBuilder();
        //    efBuilder.Name = "PayContextConnString";
        //    //efBuilder.Metadata = metaData;
        //    //efBuilder.Provider = providerName;
        //    //efBuilder.ProviderConnectionString = sqlBuilder.ConnectionString;

        //    return efBuilder.ConnectionString;
        //}
    }
}

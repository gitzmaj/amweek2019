using SignUp.Core;
using System;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace SignUp.Model
{
    public class SignUpConfiguration : DbConfiguration
    {
        public SignUpConfiguration()
        {
            var maxRetryCount = Config.Current.GetSection("Database:MaxRetryCount").Value;
            var maxDelaySeconds = Config.Current.GetSection("Database:MaxDelaySeconds").Value;

            Console.WriteLine($"- Setting DbConfiguration - maxRetryCount: {maxRetryCount}, maxDelaySeconds: {maxDelaySeconds}");

            SetExecutionStrategy("System.Data.SqlClient", () =>
                new SqlAzureExecutionStrategy(Convert.ToInt32(maxRetryCount), TimeSpan.FromSeconds(Convert.ToInt32(maxDelaySeconds))));
        }
    }
}

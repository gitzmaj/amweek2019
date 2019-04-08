using amweek.messaging;
using amweek.messaging.Messages.Events;
using Dapper;
using NATS.Client;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace amweek.writer
{
    public class Writer
    {
        private static ManualResetEvent _ResetEvent = new ManualResetEvent(false);


        public void Subscribe()
        {
            using (var connection = MessageQueue.CreateConnection())
            {
                var subscription = connection.SubscribeAsync(ProspectSignedUpEvent.MessageSubject, "writehandler");
                subscription.MessageHandler += SaveProspect;
                subscription.Start();

                _ResetEvent.WaitOne();
                connection.Close();
            }
        }

        private static void SaveProspect(object sender, MsgHandlerEventArgs e)
        {
            var eventMessage = MessageHelper.FromData<ProspectSignedUpEvent>(e.Message.Data);
            try
            {
                var prospect = eventMessage.Prospect;

                var connectionString = @"Server=.;Database=amweek;User Id=amweek;Password=AMWeek";

                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string insertQuery = @"INSERT INTO [dbo].[Prospects] ([FirstName], [LastName], [CompanyName], [EmailAddress], [Country_CountryCode], [Role_RoleCode])" +
                        " VALUES (@FirstName, @LastName, @CompanyName, @EmailAddress, @Country_CountryCode, @Role_RoleCode)";

                    var objectToInsert = new
                    {
                        FirstName = prospect.FirstName,
                        LastName = prospect.LastName,
                        CompanyName = prospect.CompanyName,
                        EmailAddress = prospect.EmailAddress,
                        Country_CountryCode = prospect.Country.CountryCode,
                        Role_RoleCode = prospect.Role.RoleCode
                    };

                    var result = db.Execute(insertQuery, objectToInsert);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Save FAILED! Event ID: {eventMessage.CorrelationId}, ex: {ex}");
            }
        }

    }
}

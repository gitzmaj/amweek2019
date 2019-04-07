using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace amweek.writer
{
    public class Writer
    {
        private IBus _bus;

        public Writer()
        {
            _bus = RabbitHutch.CreateBus("host = myServer; virtualHost = /; username = test; password = test");
        }

        public void Subscribe()
        {
            _bus.Subscribe<Entities.Prospect>("prospects", WriteHandler);
        }

        public void WriteHandler(Entities.Prospect prospect)
        {
            var connectionString = @"Server=localhost;Database=DapperDemo;Trusted_Connection=true;";

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string insertQuery = @"INSERT INTO [dbo].[Prospects]" +
                    "([FirstName], [LastName], [CompanyName], [EmailAddress], [Country_CountryCode], [Role_RoleCode]) " +
                    "VALUES (@FirstName, @LastName, @CompanyName, @EmailAdress, @Country, @Role)";

                var result = db.Execute(insertQuery, new
                {
                    prospect.FirstName,
                    prospect.LastName,
                    prospect.CompanyName,
                    prospect.EmailAddress,
                    prospect.Country,
                    prospect.Role
                });
            }
        }

        public void Close()
        {
            _bus.Dispose();
        }
    }
}

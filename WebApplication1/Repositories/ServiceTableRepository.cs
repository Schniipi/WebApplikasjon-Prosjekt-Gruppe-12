using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using WebApplication1.Tables;
using Dapper;
using MySqlConnector;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Repositories
{
    public class ServiceTableRepository
    {
        private readonly IConfiguration _config;

        public ServiceTableRepository(IConfiguration config)
        {
            _config = config;
        }

        //Setter opp en kobling til databasen
        public IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            }


        }

        //Henter all kundedata
        public IEnumerable<ServiceData> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<ServiceData>("SELECT * FROM Service");
            }
        }

        //int KommendeSID
        public void Insert(ServiceData Service, string KundeID)

        {

            using (IDbConnection dbConnection = Connection)
            {

                dbConnection.Open();
                dbConnection.Execute("INSERT INTO Service (KundeID, ServiceBeskrivelse) VALUES (@KundeID, @ServiceBeskrivelse)", Service);
            }
        }
    }
}


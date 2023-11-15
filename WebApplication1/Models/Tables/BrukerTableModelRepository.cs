using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using Dapper;
using MySqlConnector;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Models.Tables
{
    public class BrukerTableModelRepository : Controller
    {
        private readonly IConfiguration _config;

        public BrukerTableModelRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public IEnumerable<BrukerData> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<BrukerData>("SELECT * FROM brukere");
            }
        }

        public void ComparePassword(BrukerData bruker)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("SELECT BrukerNavn FROM brukere WHERE BrukerNavn = @BrukerNavn", bruker);
            }
        }
    }
}

//dbConnection.Execute("SELECT Navn FROM kunde WHERE Navn = @Navn", bruker);
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using Dapper;
using MySqlConnector;
using WebApplication1.Tables;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Repositories
{
    public class BrukerTableRepository : Controller
    {
        private readonly IConfiguration _config;

        public BrukerTableRepository(IConfiguration config)
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
                return dbConnection.Query<BrukerData>("SELECT * FROM Bruker");
            }
        }

        public IEnumerable<BrukerData> ComparePassword(string sjekkNavn)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "SELECT Passord FROM Bruker WHERE BrukerNavn = @BrukerNavn";
                //string query1 = "SELECT Passord FROM Bruker WHERE Passord = @Passord";

                dbConnection.Open();
                return dbConnection.Query<BrukerData>(query, new { BrukerNavn = sjekkNavn });

                //var pet1 = dbConnection.Query<BrukerData>(query1, new { Passord = sjekkPassord });

      
            }
        }
    }
}

//dbConnection.Execute("SELECT Navn FROM kunde WHERE Navn = @Navn", bruker);
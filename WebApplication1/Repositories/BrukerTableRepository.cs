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
using Microsoft.AspNetCore.Identity;
using System.Collections;

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

        //Henter brukeren sin Rolle fra databasen
        public bool GetRole(string sjekkRolle)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string query = "SELECT Rolle FROM Bruker where BrukerNavn = @BrukerNavn";

                //Henter rollen til mottatt brukernavn
                string rolle = dbConnection.QueryFirstOrDefault<string>(query, new { BrukerNavn = sjekkRolle });

                //Sjekker om brukeren er Admin
                return rolle == "Admin";
            }
        }
       
        //Tar i bruk brukernavn fra innlogging for å hente fram passordet knyttet opp mot navnet
        public IEnumerable<BrukerData> ComparePassword(string sjekkNavn)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "SELECT Passord FROM Bruker WHERE BrukerNavn = @BrukerNavn";
                dbConnection.Open();

                return dbConnection.Query<BrukerData>(query, new { BrukerNavn = sjekkNavn });
                


      
            }
        }

        public void LeggTilBruker(BrukerData bruker)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var passwordHasher = new PasswordHasher<BrukerData>();
                string hashedPassword = passwordHasher.HashPassword(bruker, bruker.Passord);

                dbConnection.Open();
                dbConnection.Execute("INSERT INTO Bruker (Rolle, BrukerNavn, Passord) VALUES(@Rolle, @BrukerNavn, @Passord)", new {Rolle = bruker.Rolle, BrukerNavn = bruker.BrukerNavn, Passord = hashedPassword});
            }
        }
    }
}

//dbConnection.Execute("SELECT Navn FROM kunde WHERE Navn = @Navn", bruker);
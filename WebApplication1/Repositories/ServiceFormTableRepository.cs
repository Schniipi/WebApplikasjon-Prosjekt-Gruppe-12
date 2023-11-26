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
using Newtonsoft.Json;


namespace WebApplication1.Repositories
{
    public class ServiceFormTableRepository
    {
        private readonly IConfiguration _config;

        public ServiceFormTableRepository(IConfiguration config)
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

        public IEnumerable<ServiceForm> GetAll()
        {
            //GjennomfortS viser bare serviceskjema til den første servicen.
            //Dette er ikke formålet, men rakk ikke å implementere det lengre
            string sqlString = "SELECT SjekkpunktType, SjekkpunktSvar, Sjekkpunkter FROM ServiceData where serviceID = 1;";

            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var queryResults = dbConnection.Query<dynamic>(sqlString);

                var serviceForms = queryResults.Select(row =>
                {
                    return new ServiceForm
                    {
                        SjekkpunktType = row.SjekkpunktType,
                        SjekkpunktSvar = row.SjekkpunktSvar,
                        Sjekkpunkter = row.Sjekkpunkter
                    };
                });

                return serviceForms;
            }
        }

        public void AddServiceData(ServiceForm data1, string SjekkpunktValues, string SjekkpunktTyper, string SjekkpunktNavn)

        {
            using (IDbConnection dbConnection = Connection)
            {

                

                string sqlQuery = "INSERT INTO ServiceData (ServiceID, Sjekkpunkter, SjekkpunktType, SjekkpunktSvar) " +
                  "VALUES (@ServiceID, @SjekkpunktNavn, @SjekkpunktTyper, @SjekkpunktValues)";

                // Lager et nytt ServiceFormObjekt som kan holde Sjekkpunktverdiene
                var queryParams = new
                {
                    data1.ServiceID,
                    //Verdiene
                    SjekkpunktNavn,
                    SjekkpunktTyper,
                    SjekkpunktValues 
                };

                dbConnection.Open();
                dbConnection.Execute(sqlQuery, queryParams);


            }
        }
    }
}
using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebApplication1.Tables;

namespace WebApplication1.Repositories

{
    public class KundeTableRepository
    {
        private readonly IConfiguration _config;


        public KundeTableRepository(IConfiguration config)
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
        public IEnumerable<KundeData> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<KundeData>("SELECT * FROM Kunde");
            }
        }

        //Registrer ny kunde i tabel "Kunde"
        public void Insert(KundeData kunde)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO Kunde (Fornavn, Etternavn, Bedrift, TelefonNR, Adresse) VALUES (@Fornavn, @Etternavn, @Bedrift, @TelefonNR, @Adresse)", kunde);
            }
        }

        //Fjern en kunde ved å taste inn kunden sin ID
        public void Remove(KundeData kunde)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM Kunde WHERE KundeID = @deleteID", kunde);
            }
        }

    }
}
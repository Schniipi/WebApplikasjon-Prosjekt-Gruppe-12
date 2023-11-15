using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace WebApplication1.Models.Tables

{
    public class KundeTableModelRepository
    {
        private readonly IConfiguration _config;

        public KundeTableModelRepository(IConfiguration config)
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

        public IEnumerable<KundeData> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<KundeData>("SELECT * FROM kunde");
            }
        }

        public void Insert(KundeData kunde)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO kunde (Navn, TelefonNummer, Kommentar) VALUES (@Navn, @TelefonNummer, @Kommentar)", kunde);
            }
        }

        public void Remove(KundeData kunde)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM kunde WHERE id = @deleteID", kunde);
            }
        }

    }
}
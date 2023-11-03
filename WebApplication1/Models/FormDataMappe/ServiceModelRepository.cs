﻿using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace WebApplication1.Models.FormDataMappe.ServiceModel

{
    public class ServiceModelRepository
    {
        private readonly IConfiguration _config;

        public ServiceModelRepository(IConfiguration config)
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

        public IEnumerable<FormData> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<FormData>("SELECT * FROM People");
            }
        }

        public void Insert(FormData bruker)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO People (FirstName, LastName) VALUES (@FirstName, @LastName)", bruker);
            }
        }
    }
}
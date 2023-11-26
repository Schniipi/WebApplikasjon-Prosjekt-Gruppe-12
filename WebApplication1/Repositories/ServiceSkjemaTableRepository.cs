using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MySqlConnector;
using WebApplication1.Tables;
using Dapper;

namespace WebApplication1.Repositories
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ServiceSkjemaTableRepository
    {
        private readonly IConfiguration _config;

        public ServiceSkjemaTableRepository(IConfiguration config)
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

        //Legger inn serviceskjema i databasen
        public void AddSkjema(ServiceSkjema service)
        {
            using (IDbConnection dbconnection = Connection)
            {
                //Kan for øyeblikket bare ha et serviceskjema per service pga mangel på en selvstendig primary key i Serviceskjema Table
                //Har ikke nok tid til å implementere dette
                dbconnection.Open();
                dbconnection.Execute("INSERT INTO ServiceSkjema(ServiceID, ServiceStatus, ServiceKommentar) VALUES (@ServiceID,'Pågående', @ServiceKommentar)", service);
            }
        }
    }
}



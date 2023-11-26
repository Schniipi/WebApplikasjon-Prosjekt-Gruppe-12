using System.Data;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using WebApplication1.Repositories;
using Xunit;

//Har bare opprettet en test, hadde desverre ikke tid til mer
namespace YourProject.Tests.Repositories
{
    public class KundeTableRepositoryTests
    {
        private IConfiguration GetConfiguration()
        {
            //Legger til 'appsettings.json' for å koble opp mot server
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            return configurationBuilder.Build();
        }

        [Fact]
        public void GetAll_ReturnsExpectedData()
        {
            // Arrange
            IConfiguration configuration = GetConfiguration();
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                
                var repository = new KundeTableRepository(configuration);

                //Tar i bruk GetAll() fra KundeTableRepository
                var result = repository.GetAll();

                Assert.NotNull(result);

                //Asserter strenger i kunde table
                Assert.Contains(result, item => item.Fornavn == "KUNDE");
                Assert.Contains(result, item => item.Bedrift == "Tine");


                
                

                
            }
        }
    }
}
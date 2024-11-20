using backend_hf_1.Data;
using backend_hf_1.Endpoint.Controllers;
using backend_hf_1.Entities.Dtos;
using backend_hf_1.Entities.Entity_Models;
using backend_hf_1.Logic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace backend_hf_1.ClientConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            var data = JsonIntoDb(PathInput());
            
            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=DanubeLevelDb;Trusted_Connection=True;TrustServerCertificate=True";
            var optionsBuilder = new DbContextOptionsBuilder<DanubeLevelDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            var controller = new DanubeLevelController(new DanubeLevelLogic(new Repository<DanubeLevel>(new DanubeLevelDbContext(optionsBuilder.Options))));
            foreach (var item in data)
            {
                controller.AddDanubeLevel(item);
            }
            Console.WriteLine("Data was successfully added to the database");
        }

        public static List<DanubeLevelCreateDto> JsonIntoDb(string path)
        {
            string jsonString = File.ReadAllText(path);
        
            List<DanubeLevelCreateDto> danubeLevelData = JsonConvert.DeserializeObject<List<DanubeLevelCreateDto>>(jsonString);

            return danubeLevelData;
        }
        static string PathInput()
        {
            System.Console.Write("Please enter the path of the JSON file: ");
            return System.Console.ReadLine();
        }
    }

}

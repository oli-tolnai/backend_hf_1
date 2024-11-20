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

            using (var context = new DanubeLevelDbContext(optionsBuilder.Options))
            {
                // Adatok feltöltése az adatbázisba
                //data list összes adata feltöltése az adatbázisba
                foreach (var item in data)
                {
                    DanubeLevel danubeLevels = new DanubeLevel(item.Date, item.Value);
                    context.Add(danubeLevels);
                }
                context.SaveChanges();

                /* 
                var danubeLevel = new DanubeLevel(data[0].Date, data[0].Value);
                context.Add(danubeLevel);
                context.SaveChanges();*/

                Console.WriteLine("Adatok sikeresen mentve az adatbázisba.");
            }
            



            /*
            var host = Host.CreateDefaultBuilder()
                    .ConfigureServices((hostContext, services) =>
                    {
                        services.AddDbContext<DanubeLevelDbContext>(options =>
                            options.UseSqlServer("\"Server=(localdb)\\\\MSSQLLocalDB;Database=DanubeLevelDb;Trusted_Connection=True;TrustServerCertificate=True\""));
                        services.AddScoped<DanubeLevelDbContext>();
                        services.AddTransient<Repository<DanubeLevel>>();
                        services.AddTransient<DanubeLevelLogic>();
                        services.AddTransient<DanubeLevelController>();

                    })
                    .Build();
            host.Start();

            using IServiceScope serviceScope = host.Services.CreateScope();

            var controller = host.Services.GetRequiredService<DanubeLevelController>();
            
            
            controller.AddDanubeLevel(data[0]);
            */
        }

        public static List<DanubeLevelCreateDto> JsonIntoDb(string path)
        {
            string jsonString = File.ReadAllText(path);
            //Console.WriteLine(jsonString);

            //deserialize jsonString into a list of DanubeLevelCreateDto            
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

using backend_hf_1.Endpoint.Controllers;
using backend_hf_1.Entities.Dtos;
using Newtonsoft.Json;

namespace backend_hf_1.ClientConsole
{
    public class Program
    {


        static void Main(string[] args)
        {
            var data = JsonIntoDb(PathInput());
        }

        public static List<DanubeLevelCreateDto> JsonIntoDb(string path)
        {
            string jsonString = File.ReadAllText(path);
            Console.WriteLine(jsonString);

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

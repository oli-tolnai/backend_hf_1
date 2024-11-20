using backend_hf_1.Data;
using backend_hf_1.Entities.Entity_Models;
using Microsoft.AspNetCore.Mvc;

namespace backend_hf_1.Endpoint.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DanubeLevelController : ControllerBase
    {

        Repository<DanubeLevel> repo;

        public DanubeLevelController(Repository<DanubeLevel> repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        public void AddDanubeLevel(DanubeLevel danubeLevel)
        {
            repo.Create(danubeLevel);
        }

        
        
    }
}

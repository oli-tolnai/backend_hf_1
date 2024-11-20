using backend_hf_1.Data;
using backend_hf_1.Entities.Entity_Models;
using Microsoft.AspNetCore.Mvc;

namespace backend_hf_1.Endpoint.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DanubeLevelController : ControllerBase
    {
        DanubeLevelDbContext ctx;

        public DanubeLevelController(DanubeLevelDbContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpPost]
        public void AddDanubeLevel(DanubeLevel danubeLevel)
        {
            ctx.DanubeLevels.Add(danubeLevel);
            ctx.SaveChanges();
        }
    }
}

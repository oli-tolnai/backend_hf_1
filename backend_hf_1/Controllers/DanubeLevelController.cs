using backend_hf_1.Data;
using backend_hf_1.Entities.Dtos;
using backend_hf_1.Entities.Entity_Models;
using backend_hf_1.Logic;
using Microsoft.AspNetCore.Mvc;

namespace backend_hf_1.Endpoint.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DanubeLevelController : ControllerBase
    {

        DanubeLevelLogic logic;

        public DanubeLevelController(DanubeLevelLogic logic)
        {
            this.logic = logic;
        }

        [HttpPost]
        public void AddDanubeLevel(DanubeLevelCreateDto dto)
        {
            logic.AddDanubeLevel(dto);
        }

        
        
    }
}

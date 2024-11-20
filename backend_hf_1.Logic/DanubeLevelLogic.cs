using backend_hf_1.Data;
using backend_hf_1.Entities.Dtos;
using backend_hf_1.Entities.Entity_Models;

namespace backend_hf_1.Logic
{
    public class DanubeLevelLogic
    {
        Repository<DanubeLevel> repo;

        public DanubeLevelLogic(Repository<DanubeLevel> repo)
        {
            this.repo = repo;
        }

        public void AddDanubeLevel(DanubeLevelCreateDto dto)
        {
            DanubeLevel d = new DanubeLevel(dto.Date, dto.Value);
            repo.Create(d);
        }


    }
}

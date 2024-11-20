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

            if (repo.GetAll().FirstOrDefault(x => x.Date.Date == d.Date.Date) == null) 
            {
                repo.Create(d);
            }
            else
            {
                //TODO: Implement exception handling
                throw new ArgumentException("There is already a record for this date");
            }
        }

        public IEnumerable<DanubeLevelsMonthlyStatistics> GetDanubeLevelsMonthlyStatistics()
        {
            ;
            var orderedDatas =  repo.GetAll().OrderBy(x => x.Date.Date);
            // order by date
            //var orderedData = allData.OrderBy(x => x.Date.Date);
            List<DanubeLevelsMonthlyStatistics> result = new List<DanubeLevelsMonthlyStatistics>();
            int db = -1;
            int sum = 0;
            int sameMonthCount = 0;
            foreach (var data in orderedDatas)
            {
                //while the date is the same year and month we add the value to the sum and check if it is the min or max value
                //if the date is different we add the average, min and max value to the list and start a new month
                if (db == -1 || result[db].Month != data.Date.ToString("yyyy.MM"))
                {
                    result.Add(new DanubeLevelsMonthlyStatistics(data.Date.ToString("yyyy.MM"), data.Value, data.Value, data.Value));
                    sum = data.Value;
                    sameMonthCount = 1;
                    db++;
                }
                else
                {
                    sum += data.Value;
                    sameMonthCount++;

                    result[db].Average_value = sum / sameMonthCount;
                    //check if the current value is the max or min value
                    if (data.Value > result[db].Maximal_value)
                    {
                        result[db].Maximal_value = data.Value;
                    }
                    if (data.Value < result[db].Minimal_value)
                    {
                        result[db].Minimal_value = data.Value;
                    }

                }
            }
            return result!;
            ;
        }

    }
}

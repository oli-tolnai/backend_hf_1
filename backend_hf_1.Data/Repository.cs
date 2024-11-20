using backend_hf_1.Entities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend_hf_1.Data
{
    public class Repository<T> where T : class, IIdEntity
    {
        DanubeLevelDbContext ctx;

        public Repository(DanubeLevelDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(T entity)
        {
            ctx.Set<T>().Add(entity);
            ctx.SaveChanges();
        }

        public T FindById(string id)
        {
            return ctx.Set<T>().First(t => t.Id == id);
        }


        public void DeleteById(string id)
        {
            var entity = FindById(id);
            ctx.Set<T>().Remove(entity);
            ctx.SaveChanges();
        }

        public void Delete(T entity)
        {
            ctx.Set<T>().Remove(entity);
            ctx.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return ctx.Set<T>();
        }

        public void Update(T entity)
        {
            var old = FindById(entity.Id);
            
            //minden tulajdonság programozott átmásolása
            foreach (var prop in typeof(T).GetProperties())
            {
                prop.SetValue(old, prop.GetValue(entity));
            }
            ctx.Set<T>().Update(old);
            ctx.SaveChanges();
        }
    }
}


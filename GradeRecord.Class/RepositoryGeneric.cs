using GradeRecord.Class.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GradeRecord.Class
{
    
        public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : class, IEntity
        {
            private readonly GradeRecordDB db;
            private readonly DbSet<T> dbSet;

            public RepositoryGeneric(GradeRecordDB db)
            {
                this.db = db;
                dbSet = db.Set<T>();
            }


            public virtual async Task<int> Create(T entity)
            {
                if (entity == null) throw new ArgumentNullException(nameof(entity));
                dbSet.Add(entity);
                await db.SaveChangesAsync();
                return entity.Id;
            }

            public async Task Delete(int id)
            {
                var e = await dbSet.FirstOrDefaultAsync(e => e.Id == id);
                if (e == null) return;
                dbSet.Remove(e);
                await db.SaveChangesAsync();
            }

            public virtual async Task<ICollection<T>> GetAll()
            {
                return await dbSet.ToListAsync() ?? new List<T>().ToList();
            }

            public virtual async Task<T> GetById(int id)
            {
                var e = await dbSet.FirstOrDefaultAsync(e => e.Id == id);
                return e;
            }

            public virtual async Task Update(T entity)
            {
                if (db.Entry(entity).State == EntityState.Detached)
                {
                    dbSet.Attach(entity);
                }
                dbSet.Update(entity);
                await db.SaveChangesAsync();
            }
        }
    
}

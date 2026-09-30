using GradeRecord.Class.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeRecord.Class
{
    
        public interface IRepositoryGeneric<T> where T : class, IEntity
        {
            Task<int> Create(T entity);
            Task Update(T entity);
            Task Delete(int id);
            Task<T> GetById(int id);
            Task<ICollection<T>> GetAll();
            
        }
    
}

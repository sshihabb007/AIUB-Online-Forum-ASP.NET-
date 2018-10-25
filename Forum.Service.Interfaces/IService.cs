using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Interfaces
{
    public interface IService<T> where T : class
    {
        bool Add(T entity);
        bool Edit(T entity);
        bool Delete(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllById(int id);
        T GetById(int id);
    }
}

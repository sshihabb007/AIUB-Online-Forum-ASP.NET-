using Forum.Data;
using Forum.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service
{
    public class Service<T> : IService<T> where T : class
    {
        private Repository<T> _repo;
        public Service(Repository<T> repo)
        {
            _repo = repo;
        }
        public bool Add(T entity)
        {
            return _repo.Add(entity);
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public bool Edit(T entity)
        {
            return _repo.Edit(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _repo.GetAll();
        }

        public IEnumerable<T> GetAllById(int id)
        {
            return _repo.GetAllById(id);
        }

        public T GetById(int id)
        {
            return _repo.GetById(id);
        }
    }
}

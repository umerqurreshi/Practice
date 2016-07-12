using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.MasterRepo
{
    public class MasterRepoTemplate : IMasterRepoTemplate
    {
        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void CreateDatabase()
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T FindOne<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            throw new NotImplementedException();
        }

        public T Get<T>(Guid id) where T : class
        {
            throw new NotImplementedException();
        }

        public T Get<T>(int id) where T : class
        {
            throw new NotImplementedException();
        }

        public List<T> Q<T>(params string[] includeReferences) where T : class
        {
            throw new NotImplementedException();
        }

    }
}

using DbOps;
using DbOps.DtoModels;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.MasterRepo
{
    public class AddEmp : IMasterRepo<Employees>, IAddEmp
    {
        public async Task Add(Employees emp)
        {
            using (var context = new DataContext())
            {
                await Task.Run(() => context.Employees.Add(emp));
                context.SaveChanges();
            }
        }

        public void CreateDatabase()
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Employees emp)
        {
            throw new NotImplementedException();
        }
    }
}

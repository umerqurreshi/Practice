using DbOps;
using DbOps.DtoModels;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.MasterRepo
{
    public class AddEmp : IMasterRepo<Employees>, IAddEmp
    {
        public async Task Add(List<Employees> emp)
        {
            using (var context = new DataContext())
            {
                for (int i = 0; i < emp.Count; i++)
                {
                    await Task.Run(() => context.Employees.Add(emp[i]));
                }
                
                context.SaveChanges();
            }
        }

        public void CreateDatabase()
        {
            throw new NotImplementedException();
        }

        public Task Delete(List<Employees> entity)
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

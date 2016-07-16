using DbOps;
using DbOps.DtoModels;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.MasterRepo
{
    public class AddEmp : IAddEmp
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
    }
}

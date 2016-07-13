using DbOps;
using DbOps.DtoModels;
using Repository.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.MasterRepo
{
    public class DeleteEmp : IDeleteEmp
    {
        public async Task Delete(int id)
        {
            using (var context = new DataContext())
            {
                var employee = context.Employees.Where(x => x.EmployeeId == id).First();
                

                if (employee != null)
                {
                    var perksForEmployee = employee.Perks;

                    foreach (var perk in perksForEmployee.ToList())
                    {
                        context.AddedBonus.Remove(perk.AddedBonus);
                    }

                    await Task.Run(() => context.Employees.Remove(employee));
                    //await Task.WhenAll(context.Employees.Remove(employee), context.AddedBonus.Remove(addedBonus));
                    context.SaveChanges();
                }
            }
        }

        public Task Add(Employees emp)
        {
            throw new NotImplementedException();
        }

        public void CreateDatabase()
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Employees emp)
        {
            throw new NotImplementedException();
        }
    }
}

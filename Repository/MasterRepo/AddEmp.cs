using DbOps;
using DbOps.DtoModels;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
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
                    var employee = emp[i];
                    var existingEmp = context.Employees.Where(x => x.EmployeeId == employee.EmployeeId).ToList();
                    if (existingEmp.Contains(emp[i]))
                    {

                    }
                    else
                    {
                        await Task.Run(() => context.Employees.Add(emp[i]));
                    }
                }
                
                context.SaveChanges();
            }
        }
    }
}

using DbOps;
using Repository.Interfaces;
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
                    foreach (var perk in employee.Perks)
                    {
                        context.AddedBonus.Remove(perk.AddedBonus);
                    }

                    await Task.Run(() => context.Employees.Remove(employee));
                    //await Task.WhenAll(context.Employees.Remove(employee), context.AddedBonus.Remove(addedBonus));
                    context.SaveChanges();
                }
            }
        }
    }
}

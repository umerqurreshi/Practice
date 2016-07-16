using DbOps;
using DbOps.DtoModels;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.MasterRepo
{
    public class UpdateEmp : IUpdateEmp
    {
        public async Task Update(int id, Employees emp)
        {
            using (var context = new DataContext())
            {
                // grab existing employee
                var employee = context.Employees.Where(x => x.EmployeeId == id).First();
                
                // update existing employee
                employee.Age = emp.Age;
                employee.BadgeNumber = emp.BadgeNumber;
                employee.Firstname = emp.Firstname;
                employee.Lastname = emp.Lastname;

                // retrieve perks belonging to employee
                var perks = employee.Perks.ToList();

                // updated perks
                var updatedPerks = emp.Perks.ToList();

                for (int i = 0; i < updatedPerks.Count; i++)
                {
                   // var matchedPerks = perks.Where(x => x.PerkType == updatedPerks[i].PerkType).ToList();
                    perks[i].PerkDuration = updatedPerks[i].PerkDuration;
                    perks[i].PerkType = updatedPerks[i].PerkType;
                    perks[i].AddedBonus.ChildVouchers = updatedPerks[i].AddedBonus.ChildVouchers;
                    perks[i].AddedBonus.CleaningVouchers = updatedPerks[i].AddedBonus.CleaningVouchers;
                    perks[i].AddedBonus.GiftVouchers = updatedPerks[i].AddedBonus.GiftVouchers;
                    perks[i].AddedBonus.ElderlyVouchers = updatedPerks[i].AddedBonus.ElderlyVouchers;

                }

                // context.Entry(employee).State = EntityState.Modified;

                await Task.Run(() => context.SaveChanges());
            }
        }
    }
}

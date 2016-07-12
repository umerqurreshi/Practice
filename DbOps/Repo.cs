using DbOps;
using DbOps.DtoModels;
using System.Collections.Generic;

namespace DbOps
{
    public class Repo
    {
        public void Add()
        {
            using (var context = new DataContext())
            {
                var employees = new Employees
                {
                    Firstname = "Karim", Lastname = "Loton", Age = 54,
                    BadgeNumber = 22912, Perks = new List<Perks>
                    {
                       new Perks
                       {
                           PerkDuration = 4,
                           AddedBonus = new AddedBonus
                           {
                               ElderlyVouchers = "Yes", CleaningVouchers = "Yes"
                               ,ChildVouchers = "Yes", GiftVouchers = "Yes"
                           },
                           PerkType = "Free mobile"
                       } 
                    }
                };

                context.Employees.Add(employees);
                context.SaveChanges();
            }
        }
    }
}

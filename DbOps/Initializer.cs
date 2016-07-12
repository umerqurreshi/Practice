using DbOps;
using DbOps.DtoModels;
using System.Collections.Generic;
using System.Data.Entity;

namespace DbOps
{
    public class Initializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var employees = new List<Employees>
            {
                new Employees
                {
                    Firstname = "Katie", Lastname = "Reeves", Age = 42,
                    BadgeNumber = 11232342, Perks = new List<Perks>
                    {
                        new Perks
                        {
                            AddedBonus = new AddedBonus
                            {
                                ChildVouchers = "Yes",
                                CleaningVouchers = "Yes"
                            }
                            ,
                            PerkType = "Overtime at double-time"
                            ,
                            PerkDuration = 3
                        },
                        new Perks
                        {
                            AddedBonus = new AddedBonus
                            {
                                ElderlyVouchers = "Yes",
                                GiftVouchers = "Yes"
                            }
                            ,
                            PerkType = "Free lunch"
                            ,
                            PerkDuration = 1
                        }
                    }
                }
            };

            employees.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();
        }
    }
}

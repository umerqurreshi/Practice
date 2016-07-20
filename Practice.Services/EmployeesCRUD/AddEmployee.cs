using DbOps.DtoModels;
using Practice.Services.Interfaces;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practice.Services.EmployeesCRUD
{
    public class AddEmployee : IAddEmployee
    {
        private readonly IAddEmp _repo;

        public AddEmployee(IAddEmp repo)
        {
            _repo = repo;
        }

        public async Task Add(List<Employees> emp)
        {
            // Business logic - defensive coding - if succinct, never a bad thing!
            foreach (var employee in emp)
            {
                if (string.IsNullOrEmpty(employee.Firstname))
                {
                    emp.Remove(employee);
                }
            }
           await _repo.Add(emp);
        }
    }
}

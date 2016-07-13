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
            // Business logic
           await _repo.Add(emp);
        }
    }
}

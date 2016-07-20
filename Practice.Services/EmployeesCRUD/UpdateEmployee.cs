using DbOps.DtoModels;
using Practice.Services.Interfaces;
using Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace Practice.Services.EmployeesCRUD
{
    public class UpdateEmployee : IUpdateEmployee
    {
        private readonly IUpdateEmp _repo;

        public UpdateEmployee(IUpdateEmp repo)
        {
            _repo = repo;
        }

        public async Task Update(int id, Employees emp)
        {
           await _repo.Update(id, emp);
        }
    }
}

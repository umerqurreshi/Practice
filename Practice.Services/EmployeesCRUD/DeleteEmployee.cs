using System.Threading.Tasks;
using DbOps.DtoModels;
using Practice.Services.Interfaces;
using Repository.Interfaces;

namespace Practice.Services.EmployeesCRUD
{
    public class DeleteEmployee : IDeleteEmployee
    {
        private readonly IDeleteEmp _repo;

        public DeleteEmployee(IDeleteEmp repo)
        {
            _repo = repo;
        }

        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }
    }
}
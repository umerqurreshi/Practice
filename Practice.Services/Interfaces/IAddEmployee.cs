using DbOps.DtoModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practice.Services.Interfaces
{
    public interface IAddEmployee
    {
        Task AddEmployees(List<Employees> emp);
        Task AddSingleEmployee(Employees emp);
    }
}

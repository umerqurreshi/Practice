using DbOps.DtoModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IAddEmp
    {
        Task AddEmployees(List<Employees> emp);
        Task AddEmployee(Employees emp);
    }
}
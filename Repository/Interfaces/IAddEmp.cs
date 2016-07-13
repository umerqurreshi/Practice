using DbOps.DtoModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IAddEmp
    {
        Task Add(List<Employees> emp);
    }
}
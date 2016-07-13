using DbOps.DtoModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practice.Services.Interfaces
{
    public interface IAddEmployee
    {
        Task Add(List<Employees> emp);
    }
}

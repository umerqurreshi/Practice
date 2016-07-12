using DbOps.DtoModels;
using System.Threading.Tasks;

namespace Practice.Services.Interfaces
{
    public interface IAddEmployee
    {
        Task Add(Employees emp);
    }
}

using DbOps.DtoModels;
using System.Threading.Tasks;

namespace Practice.Services.Interfaces
{
    public interface IUpdateEmployee
    {
        Task Update(int id, Employees emp);
    }
}

using DbOps.DtoModels;
using System.Threading.Tasks;

namespace Practice.Services.Interfaces
{
    public interface IDeleteEmployee
    {
        Task Delete(Employees emp);
        Task Delete(int id);
    }
}

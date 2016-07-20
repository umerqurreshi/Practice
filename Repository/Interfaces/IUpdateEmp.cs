using DbOps.DtoModels;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUpdateEmp
    {
        Task Update(int id, Employees emp);
    }
}

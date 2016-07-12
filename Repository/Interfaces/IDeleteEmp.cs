using DbOps.DtoModels;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IDeleteEmp
    {
        Task Delete(Employees emp);
        Task Delete(int id);
    }
}

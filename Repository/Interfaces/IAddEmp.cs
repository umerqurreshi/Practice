using DbOps.DtoModels;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IAddEmp
    {
        Task Add(Employees emp);
    }
}
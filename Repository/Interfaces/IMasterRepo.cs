using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IMasterRepo<T> where T : class
    {
        Task Add(T entity);
        void CreateDatabase();
        Task Delete(T entity);
        Task Delete(int id);
    }
}

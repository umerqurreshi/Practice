using System.Net.Http;

namespace Repository.Interfaces
{
    public interface IMasterRepoTemplate
    {
        void Add<T>(T entity) where T : class;
        void CreateDatabase();
        void Delete<T>(T entity) where T : class;   
    }
}
    
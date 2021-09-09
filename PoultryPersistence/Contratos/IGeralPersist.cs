using System.Threading.Tasks;
using PoultryDomain;

namespace PoultryPersistence.Contratos
{
    public interface IGeralPersist
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync(); 
    }
}
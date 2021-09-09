using System.Threading.Tasks;
using PoultryPersistence.Contextos;
using PoultryPersistence.Contratos;

namespace PoultryPersistence
{
    public class GeralPersist : IGeralPersist
    {
        private readonly PoultryContext _context;
        public GeralPersist(PoultryContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}
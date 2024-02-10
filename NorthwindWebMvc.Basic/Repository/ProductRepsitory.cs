using Microsoft.EntityFrameworkCore;
using NorthwindWebMvc.Basic.Models;
using NorthwindWebMvc.Basic.RepositoryContext;

namespace NorthwindWebMvc.Basic.Repository
{
    public class ProductRepository : IRepositoryBase<Produk>
    {
        private readonly RepositoryDbContext _context;

        public ProductRepository(RepositoryDbContext context)
        {
            _context = context;
        }

        public void Create(Produk entity)
        {
            _context.Produks.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Produk entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<IQueryable<Produk>> FindAll(bool trackChanges)
        {
            return !trackChanges ? _context.Produks.AsNoTracking() : _context.Produks;
        }

        public async Task<Produk> FindById(int id, bool trackChanges)
        {
            return await _context.Produks.FindAsync(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Produk entity)
        {
            _context.Produks.Update(entity);
        }
    }
}

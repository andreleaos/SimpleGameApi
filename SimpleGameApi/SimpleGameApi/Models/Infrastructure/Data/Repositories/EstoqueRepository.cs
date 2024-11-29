using Microsoft.EntityFrameworkCore;
using SimpleGameApi.Models.Domain.Contracts.Repositories;
using SimpleGameApi.Models.Domain.Entities;
using SimpleGameApi.Models.Infrastructure.Data.Contexts;

namespace SimpleGameApi.Models.Infrastructure.Data.Repositories;
public class EstoqueRepository : IEstoqueRepository
{
    private readonly JogoDbContext _context;

    public EstoqueRepository(JogoDbContext context)
    {
        _context = context;
    }

    public void Add(Estoque entity)
    {
        _context.Estoque.Add(entity);
        _context.SaveChanges();
    }

    public bool Delete(int id)
    {
        var itemEstoque = Get(id);
        if (itemEstoque != null)
        {
            _context.Estoque.Remove(itemEstoque);
            _context.SaveChanges();
            return true;
        }

        return false;
    }

    public Estoque Get(int id)
    {
        var estoque = _context.Estoque
            .AsNoTracking()
            .FirstOrDefault(p => p.Id.Equals(id));
        return estoque;
    }

    public List<Estoque> GetAll()
    {
        var estoque = _context.Estoque
            .AsNoTracking()
            .OrderBy(p => p.Id)
            .ToList();
        return estoque;
    }

    public bool Update(Estoque entity)
    {
        var itemEstoque = Get(entity.Id);
        if (itemEstoque != null)
        {
            _context.Entry(itemEstoque).State = EntityState.Detached;
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        return false;
    }
}

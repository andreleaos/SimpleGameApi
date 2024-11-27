using Microsoft.EntityFrameworkCore;
using SimpleGameApi.Models.Domain.Contracts.Repositories;
using SimpleGameApi.Models.Domain.Entities;
using SimpleGameApi.Models.Infrastructure.Data.Contexts;

namespace SimpleGameApi.Models.Infrastructure.Data.Repositories;
public class JogoRepository : IJogoRepository
{
    private readonly JogoDbContext _context;

    public JogoRepository(JogoDbContext context)
    {
        _context = context;
    }

    public void Add(Jogo entity)
    {
        _context.Jogos.Add(entity);
        _context.SaveChanges();
    }

    public bool Delete(int id)
    {
        var jogoPesquisado = Get(id);
        if(jogoPesquisado != null)
        {
            _context.Jogos.Remove(jogoPesquisado);
            _context.SaveChanges();
            return true;
        }

        return false;
    }

    public Jogo Get(int id)
    {
        var jogo = _context.Jogos
            .FirstOrDefault(p => p.Id.Equals(id));

        return jogo;
    }

    public List<Jogo> GetAll()
    {
        var jogos = _context.Jogos
            .OrderBy(p => p.Nome)
            .ToList();

        return jogos;
    }

    public bool Update(Jogo entity)
    {
        var jogoPesquisado = Get(entity.Id);
        if (jogoPesquisado != null)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        return false;
    }
}

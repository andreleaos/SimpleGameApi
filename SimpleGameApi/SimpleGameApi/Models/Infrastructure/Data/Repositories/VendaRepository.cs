using SimpleGameApi.Models.Domain.Contracts.Repositories;
using SimpleGameApi.Models.Domain.Entities;
using SimpleGameApi.Models.Infrastructure.Data.Contexts;

namespace SimpleGameApi.Models.Infrastructure.Data.Repositories;
public class VendaRepository : IVendaRepository
{
    private readonly ConnectionManager _connectionManager;

    public VendaRepository(IConfiguration configuration)
    {
        _connectionManager = new ConnectionManager(configuration);
    }

    public void Add(Venda entity)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Venda Get(int id)
    {
        throw new NotImplementedException();
    }

    public List<Venda> GetAll()
    {
        throw new NotImplementedException();
    }

    public bool Update(Venda entity)
    {
        throw new NotImplementedException();
    }
}

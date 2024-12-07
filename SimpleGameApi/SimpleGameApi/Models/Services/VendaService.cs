using SimpleGameApi.Models.Domain.Contracts.Repositories;
using SimpleGameApi.Models.Domain.Contracts.Services;
using SimpleGameApi.Models.Domain.Entities;

namespace SimpleGameApi.Models.Services;
public class VendaService : IVendaService
{
    private readonly IVendaRepository _vendaRepository;

    public VendaService(IVendaRepository vendaRepository)
    {
        _vendaRepository = vendaRepository;
    }

    public void Add(Venda entity)
    {
        _vendaRepository.Add(entity);
    }

    public bool Delete(int id)
    {
        return _vendaRepository.Delete(id);
    }

    public Venda Get(int id)
    {
        return _vendaRepository.Get(id);
    }

    public List<Venda> GetAll()
    {
        return _vendaRepository.GetAll();
    }

    public bool Update(Venda entity)
    {
        return _vendaRepository.Update(entity);
    }
}

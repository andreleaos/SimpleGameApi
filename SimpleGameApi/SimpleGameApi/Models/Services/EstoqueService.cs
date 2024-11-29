using SimpleGameApi.Models.Domain.Contracts.Repositories;
using SimpleGameApi.Models.Domain.Contracts.Services;
using SimpleGameApi.Models.Domain.Entities;

namespace SimpleGameApi.Models.Services;
public class EstoqueService : IEstoqueService
{
    private readonly IEstoqueRepository _estoqueRepository;

    public EstoqueService(IEstoqueRepository estoqueRepository)
    {
        _estoqueRepository = estoqueRepository;
    }

    public void Add(Estoque entity)
    {
        _estoqueRepository.Add(entity);
    }

    public bool Delete(int id)
    {
        return _estoqueRepository.Delete(id);
    }

    public Estoque Get(int id)
    {
        return _estoqueRepository.Get(id);
    }

    public List<Estoque> GetAll()
    {
        return _estoqueRepository.GetAll();
    }

    public bool Update(Estoque entity)
    {
        return _estoqueRepository.Update(entity);
    }
}

using SimpleGameApi.Models.Domain.Contracts.Repositories;
using SimpleGameApi.Models.Domain.Contracts.Services;
using SimpleGameApi.Models.Domain.Entities;

namespace SimpleGameApi.Models.Services;
public class AluguelService : IAluguelService
{
    private readonly IAluguelRepository _aluguelRepository;

    public AluguelService(IAluguelRepository aluguelRepository)
    {
        _aluguelRepository = aluguelRepository;
    }

    public void Add(Aluguel entity)
    {
        _aluguelRepository.Add(entity);
    }

    public bool Delete(int id)
    {
        return _aluguelRepository.Delete(id);
    }

    public Aluguel Get(int id)
    {
        return _aluguelRepository.Get(id);
    }

    public List<Aluguel> GetAll()
    {
        return _aluguelRepository.GetAll();

    }

    public bool Update(Aluguel entity)
    {
        return _aluguelRepository.Update(entity);
    }
}

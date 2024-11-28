using SimpleGameApi.Models.Domain.Contracts.Repositories;
using SimpleGameApi.Models.Domain.Contracts.Services;
using SimpleGameApi.Models.Domain.Entities;

namespace SimpleGameApi.Models.Services;

public class JogoService : IJogoService
{
    private readonly IJogoRepository _jogoRepository;

    public JogoService(IJogoRepository jogoRepository)
    {
        _jogoRepository = jogoRepository;
    }

    public void Add(Jogo entity)
    {
        _jogoRepository.Add(entity);
    }

    public bool Delete(int id)
    {
        var result = _jogoRepository.Delete(id);
        return result;
    }

    public Jogo Get(int id)
    {
        return _jogoRepository.Get(id);
    }

    public List<Jogo> GetAll()
    {
        return _jogoRepository.GetAll();
    }

    public bool Update(Jogo entity)
    {
        var result = _jogoRepository.Update(entity);
        return result;
    }
}

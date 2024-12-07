using Dapper;
using Microsoft.Data.SqlClient;
using SimpleGameApi.Models.Domain.Contracts.Repositories;
using SimpleGameApi.Models.Domain.Entities;
using SimpleGameApi.Models.Domain.Enums;
using SimpleGameApi.Models.Infrastructure.Data.Contexts;
using SimpleGameApi.Models.Infrastructure.Data.Queries;

namespace SimpleGameApi.Models.Infrastructure.Data.Repositories;

public class AluguelRepository : IAluguelRepository
{
    private readonly ConnectionManager _connectionManager;

    public AluguelRepository(ConnectionManager connectionManager)
    {
        _connectionManager = connectionManager;
    }

    public void Add(Aluguel entity)
    {
        if (entity == null)
            throw new ArgumentNullException("Dados inválidos");

        var query = SqlManager.GetSql(SqlQueryEnum.CADASTRAR_ALUGUEL);

        using (var connection = _connectionManager.GetConnection() as SqlConnection)
        {
            var id = connection.QuerySingle<int>(query, entity);
            entity.Id = id;
        }
    }

    public bool Delete(int id)
    {
        string query = SqlManager.GetSql(SqlQueryEnum.EXCLUIR_ALUGUEL);

        using (var connection = _connectionManager.GetConnection() as SqlConnection)
        {
            var rowsAffected = connection.Execute(query, new { Id = id });

            if (rowsAffected > 0)
                return true;
        }

        return false;
    }

    public Aluguel Get(int id)
    {
        string query = SqlManager.GetSql(SqlQueryEnum.PESQUISAR_ALUGUEL);

        using (var connection = _connectionManager.GetConnection() as SqlConnection)
        {
            var aluguel = connection.QuerySingleOrDefault<Aluguel>(query, new { Id = id });
            return aluguel;
        }
    }

    public List<Aluguel> GetAll()
    {
        string query = SqlManager.GetSql(SqlQueryEnum.LISTAR_ALUGUEL);

        using (var connection = _connectionManager.GetConnection() as SqlConnection)
        {
            var alugueis = (connection.Query<Aluguel>(query)).ToList();
            return alugueis;
        }
    }

    public bool Update(Aluguel aluguel)
    {
        if (aluguel == null || aluguel.Id == 0)
            throw new Exception("Dados inválidos.");

        string query = SqlManager.GetSql(SqlQueryEnum.ATUALIZAR_ALUGUEL);

        using (var connection = _connectionManager.GetConnection())
        {
            var rowsAffected = connection.Execute(query, aluguel);

            if (rowsAffected > 0)
                return true;
        }

        return false;
    }
}

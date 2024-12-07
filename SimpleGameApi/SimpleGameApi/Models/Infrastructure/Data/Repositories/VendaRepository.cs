using System.Data;
using Microsoft.Data.SqlClient;
using SimpleGameApi.Models.Domain.Contracts.Repositories;
using SimpleGameApi.Models.Domain.Entities;
using SimpleGameApi.Models.Domain.Enums;
using SimpleGameApi.Models.Infrastructure.Data.Contexts;
using SimpleGameApi.Models.Infrastructure.Data.Queries;

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
        using (var connection = _connectionManager.GetConnection() as SqlConnection)
        {
            var query = SqlManager.GetSql(SqlQueryEnum.CADASTRAR_VENDAS);
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdJogo", entity.IdJogo);
                command.Parameters.AddWithValue("@Quantidade", entity.Quantidade);
                command.Parameters.AddWithValue("@Total", entity.Total);
                command.Parameters.AddWithValue("@DataVenda", entity.DataVenda);

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }

    public bool Delete(int id)
    {
        using (var connection = _connectionManager.GetConnection() as SqlConnection)
        {
            var query = SqlManager.GetSql(SqlQueryEnum.EXCLUIR_VENDAS);
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                    return true;
            }
        }

        return false;
    }

    public Venda Get(int id)
    {
        string query = SqlManager.GetSql(SqlQueryEnum.PESQUISAR_VENDAS);

        using (var connection = _connectionManager.GetConnection() as SqlConnection)
        {
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var venda = new Venda
                        {
                            Id = reader.GetInt32(0),
                            IdJogo = reader.GetInt32(1),
                            Quantidade = reader.GetInt32(2),
                            Total = reader.GetDecimal(3),
                            DataVenda = reader.GetDateTime(4)
                        };

                        return venda;
                    }
                }
            }
        }

        return null;
    }

    public List<Venda> GetAll()
    {
        var vendas = new List<Venda>();

        using (var connection = _connectionManager.GetConnection() as SqlConnection)
        {
            var query = SqlManager.GetSql(SqlQueryEnum.LISTAR_VENDAS);
            var command = new SqlCommand(query, connection);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                vendas.Add(new Venda()
                {
                    Id = reader.GetInt32(0),
                    IdJogo = reader.GetInt32(1),
                    Quantidade = reader.GetInt32(2),
                    Total = reader.GetDecimal(3),
                    DataVenda = reader.GetDateTime(4)
                });
            }
        }

        return vendas;
    }

    public bool Update(Venda venda)
    {
        using (var connection = _connectionManager.GetConnection() as SqlConnection)
        {
            var query = SqlManager.GetSql(SqlQueryEnum.ATUALIZAR_VENDAS);
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", venda.Id);
                command.Parameters.AddWithValue("@IdJogo", venda.IdJogo);
                command.Parameters.AddWithValue("@Quantidade", venda.Quantidade);
                command.Parameters.AddWithValue("@Total", venda.Total);
                command.Parameters.AddWithValue("@DataVenda", venda.DataVenda);

                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                    return true;
            }
        }
        return false;
    }
}

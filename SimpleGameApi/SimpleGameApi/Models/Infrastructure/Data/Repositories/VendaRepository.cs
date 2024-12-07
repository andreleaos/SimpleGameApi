using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using SimpleGameApi.Models.Configuration;
using SimpleGameApi.Models.Domain.Contracts.Repositories;
using SimpleGameApi.Models.Domain.Entities;
using SimpleGameApi.Models.Domain.Enums;
using SimpleGameApi.Models.Infrastructure.Data.Contexts;
using SimpleGameApi.Models.Infrastructure.Data.Queries;

namespace SimpleGameApi.Models.Infrastructure.Data.Repositories;
public class VendaRepository : IVendaRepository
{
    private readonly ConnectionManager _connectionManager;
    private readonly bool _enableStoredProcedure;

    public VendaRepository(IConfiguration configuration)
    {
        _connectionManager = new ConnectionManager(configuration);

        var procParameter = configuration
            .GetSection("Flags")?
            .GetSection("Habilitar_Uso_Stored_Procedure")?.Value;

        if (!procParameter.IsNullOrEmpty())
            _enableStoredProcedure = Convert.ToBoolean(procParameter);
    }

    public void Add(Venda entity)
    {
        using (var connection = _connectionManager.GetConnection() as SqlConnection)
        {
            var query = SqlManager.GetSql(SqlQueryEnum.CADASTRAR_VENDAS);
            using (var command = new SqlCommand(query, connection))
            {
                if (_enableStoredProcedure)
                {
                    command.CommandText = ConstantParameters.PROC_CADASTRO_VENDAS;
                    command.CommandType = CommandType.StoredProcedure;
                }

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
                if (_enableStoredProcedure)
                {
                    command.CommandText = ConstantParameters.PROC_EXCLUSAO_VENDAS;
                    command.CommandType = CommandType.StoredProcedure;
                }

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
                if (_enableStoredProcedure)
                {
                    command.CommandText = ConstantParameters.PROC_PESQUISA_VENDAS;
                    command.CommandType = CommandType.StoredProcedure;
                }

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

            if (_enableStoredProcedure)
            {
                command.CommandText = ConstantParameters.PROC_LISTAGEM_VENDAS;
                command.CommandType = CommandType.StoredProcedure;
            }

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
                if (_enableStoredProcedure)
                {
                    command.CommandText = ConstantParameters.PROC_ATUALIZACAO_VENDAS;
                    command.CommandType = CommandType.StoredProcedure;
                }

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

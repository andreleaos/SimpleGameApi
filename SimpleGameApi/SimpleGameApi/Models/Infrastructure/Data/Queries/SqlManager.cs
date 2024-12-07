using SimpleGameApi.Models.Domain.Enums;

namespace SimpleGameApi.Models.Infrastructure.Data.Queries;

public static class SqlManager
{
    public static string GetSql(SqlQueryEnum queryEnum)
    {
        string sql = "";

        switch (queryEnum)
        {
            case SqlQueryEnum.CADASTRAR_VENDAS:
                sql = "INSERT INTO Vendas (IdJogo, Quantidade, Total) VALUES (@IdJogo, @Quantidade, @Total)";
                break;

            case SqlQueryEnum.ATUALIZAR_VENDAS:
                sql = "UPDATE Vendas set IdJogo = @IdJogo, Quantidade = @Quantidade, Total = @Total, " +
                      "DataVenda = @DataVenda WHERE Id = @Id";
                break;

            case SqlQueryEnum.EXCLUIR_VENDAS:
                sql = "DELETE FROM Vendas WHERE Id = @Id";
                break;

            case SqlQueryEnum.PESQUISAR_VENDAS:
                sql = "SELECT Id, IdJogo, Quantidade, Total, DataVenda FROM Vendas WHERE Id = @Id";
                break;

            case SqlQueryEnum.LISTAR_VENDAS:
                sql = "SELECT Id, IdJogo, Quantidade, Total, DataVenda  FROM Vendas";
                break;

            default:
                sql = "SELECT Id, IdJogo, Quantidade, Total, DataVenda  FROM Vendas";
                break;
        }

        return sql;
    }
}

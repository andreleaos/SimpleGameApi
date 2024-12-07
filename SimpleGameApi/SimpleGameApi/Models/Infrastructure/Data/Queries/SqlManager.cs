using SimpleGameApi.Models.Domain.Enums;

namespace SimpleGameApi.Models.Infrastructure.Data.Queries;

public static class SqlManager
{
    public static string GetSql(SqlQueryEnum queryEnum)
    {
        string sql = "";

        switch (queryEnum)
        {
            #region Vendas

            case SqlQueryEnum.CADASTRAR_VENDAS:
                sql = "INSERT INTO Vendas (IdJogo, Quantidade, Total, DataVenda) VALUES (@IdJogo, @Quantidade, @Total, @DataVenda)";
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

            #endregion

            #region Aluguel

            case SqlQueryEnum.CADASTRAR_ALUGUEL:
                sql = "INSERT INTO Aluguel (IdJogo, DataAluguel, DataDevolucao, Preco) " +
                      "VALUES (@IdJogo, @DataAluguel, @DataDevolucao, @Preco);" +
                      "SELECT CAST(SCOPE_IDENTITY() AS INT);";
                break;

            case SqlQueryEnum.ATUALIZAR_ALUGUEL:
                sql = "UPDATE Aluguel SET IdJogo = @IdJogo, DataAluguel = @DataAluguel, " +
                      "DataDevolucao = @DataDevolucao, Preco = @Preco WHERE Id = @Id;";
                break;

            case SqlQueryEnum.EXCLUIR_ALUGUEL:
                sql = " DELETE FROM Aluguel WHERE Id = @Id;";
                break;

            case SqlQueryEnum.LISTAR_ALUGUEL:
                sql = "SELECT Id, IdJogo, DataAluguel, DataDevolucao, Preco FROM Aluguel;";
                break;

            case SqlQueryEnum.PESQUISAR_ALUGUEL:
                sql = "SELECT Id, IdJogo, DataAluguel, DataDevolucao, Preco " + "" +
                      "FROM Aluguel WHERE Id = @Id;";
                break;

            #endregion

            default:
                sql = "SELECT Id, IdJogo, Quantidade, Total, DataVenda  FROM Vendas";
                break;
        }

        return sql;
    }
}

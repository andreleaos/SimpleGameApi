namespace SimpleGameApi.Models.Domain.Entities;
public class Venda
{
    public int Id { get; set; }
    public int IdJogo { get; set; }
    public int Quantidade { get; set; }
    public decimal Total { get; set; }
    public DateTime DataVenda { get; set; }
}

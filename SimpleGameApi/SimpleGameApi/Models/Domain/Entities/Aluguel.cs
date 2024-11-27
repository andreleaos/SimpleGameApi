namespace SimpleGameApi.Models.Domain.Entities;
public class Aluguel
{
    public int Id { get; set; }
    public int IdJogo { get; set; }
    public DateTime DataAluguel { get; set; }
    public DateTime DataDevolucao { get; set; }
    public decimal Preco { get; set; }
}

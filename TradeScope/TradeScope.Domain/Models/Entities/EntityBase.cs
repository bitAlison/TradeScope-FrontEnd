namespace TradeScope.Domain.Models.Entities
{
    public class EntityBase
    {
        public DateTime? DateCreate { get; set; } = default!;

        public DateTime? DateUpdate { get; set; } = default!;
    }
}

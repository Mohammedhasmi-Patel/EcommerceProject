
namespace MegaEcommerce.Domain.Entities
{
    public class Country : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string CountryCode { get; set; } = null!;

        public ICollection<State> States { get; set; } = new List<State>();
    }
}


namespace MegaEcommerce.Domain.Entities
{
    public class Country : BaseEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Iso3 { get; set; } = null!;


        public string Iso2 { get; set; } = null!;
        public string Capital { get; set; } = null!;
        public string Currency { get; set; } = null!;

        public string Region { get; set; } = null!;
        public string Subregion { get; set; } = null!;

        public long? Population { get; set; }
        public ICollection<State> States { get; set; } = new List<State>();
    }
}

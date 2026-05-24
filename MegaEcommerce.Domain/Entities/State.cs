using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaEcommerce.Domain.Entities
{
    public class State : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid CountryId { get; set; }

        public Country Country { get; set; } = null!;
        public ICollection<City> Cities { get; set; } = new List<City>();
    }
}

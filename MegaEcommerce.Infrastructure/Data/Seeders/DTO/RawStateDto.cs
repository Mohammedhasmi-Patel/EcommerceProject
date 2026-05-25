using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaEcommerce.Infrastructure.Data.Seeders.DTO
{
    public class RawStateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Iso2 { get; set; }
        public List<RawCityDto> Cities { get; set; } = new();
    }
}

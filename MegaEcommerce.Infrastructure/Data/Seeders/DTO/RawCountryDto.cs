using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaEcommerce.Infrastructure.Data.Seeders.DTO
{
    public class RawCountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Iso3 { get; set; }
        public string Iso2 { get; set; }
        public string Capital { get; set; }
        public string Currency { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public long? Population { get; set; }
        public List<RawStateDto> States { get; set; } = new();
    }
}

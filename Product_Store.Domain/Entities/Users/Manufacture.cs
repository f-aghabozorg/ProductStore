using Product_Store.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Store.Domain.Entities.Users
{
    public class Manufacture
    {
        public int ManufactureId { get; set; }
        public string ManufactureFirstName { get; set; }
        public string ManufactureLastName { get; set; }
        public string ManufactureEmail { get; set; }
        public string ManufacturePhone { get; set; }
        public string ManufacturePassword { get; set; }

        public ICollection<Product> Product { get; set; }

    }
}

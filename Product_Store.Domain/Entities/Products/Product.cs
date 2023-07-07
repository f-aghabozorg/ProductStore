using Product_Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Store.Domain.Entities.Products
{
    public class Product
    {
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime ProduceDate { get; set; }
        public string ManufactureEmail { get; set; }
        public string ManufacturePhone { get; set; }

        public virtual Manufacture Manufacture { get; set; }
        public int ManufactureId { get; set; }

    }
}

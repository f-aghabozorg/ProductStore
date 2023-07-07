using Microsoft.EntityFrameworkCore;
using Product_Store.Domain.Entities.Products;
using Product_Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Store.Application.Interfaces.Contexts
{
    public interface IDataBaseContext
    {
        public DbSet<Manufacture> Manufactures { get; set; }
        public DbSet<Product> Products { get; set; }

        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}

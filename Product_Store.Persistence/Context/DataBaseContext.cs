using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Store.Persistence.Context
{
    public class DataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

    }
}

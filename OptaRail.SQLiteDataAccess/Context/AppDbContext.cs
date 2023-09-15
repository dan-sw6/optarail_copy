using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using OptaRail.Domain;

namespace OptaRail.SQLiteDataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<RailDocument> RailDocuments { get; set; }

        protected AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

    }
}


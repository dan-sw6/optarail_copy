using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptaRail.Domain;
using OptaRail.Infrastructure.Interfaces;
using OptaRail.SQLiteDataAccess.Context;

namespace OptaRail.SQLiteDataAccess.Repositories
{
    public class RailProjectRepository:GenericRepository<RailDocument>, IRailProjectRepository
    {
        public RailProjectRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

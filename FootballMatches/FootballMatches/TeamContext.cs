using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballMatches
{
    class TeamContext : DbContext
    {
        public TeamContext() : base(Properties.Settings.Default.DbConnect){ }
        
        public DbSet<Team> Teams { get; set; }
    }
}

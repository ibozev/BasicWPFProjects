using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballMatches
{
    class MatchContext : DbContext
    {
        public MatchContext() : base(Properties.Settings.Default.DbConnect) { }

        public DbSet<Match> Matches { get; set; }
    }
}

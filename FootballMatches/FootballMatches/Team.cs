using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FootballMatches
{
    public class Team
    {
        public Team() { }

        public Team(String name)
        {
            Name = name;
        }

        public bool IsValid()
        {
            String regx = "^[\\p{L} .'-]+$";
            if (Name == null || !Regex.Match(Name, regx).Success) return false;
            return true;
        }

        public String Name
        {
            get; set;
        }

        public int TeamId
        {
            get; set;
        }

        public override String ToString()
        {
            return Name;
        }
    }
}

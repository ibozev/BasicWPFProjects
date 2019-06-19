using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FootballMatches
{
    public class Match
    {
        public Match() { }

        public Match(DateTime date, Team firstTeam, Team secondTeam)
        {
            Date = date;
            SecondTeam = secondTeam;
            FirstTeam = firstTeam;
        }

        public bool IsValid()
        {
            String regx = "^[\\p{L} .'-]+$";
            if (FirstTeam.Name == null || !Regex.Match(FirstTeam.Name, regx).Success) return false;        
            if (SecondTeam.Name == null || !Regex.Match(SecondTeam.Name, regx).Success) return false;
            if (Date == null) return false;
            return true;
        }

        public Team FirstTeam
        {
            get; set;
        }

        public DateTime Date
        {
            get; set;
        }

        public Team SecondTeam
        {
            get; set;
        }

        public int MatchId
        {
            get; set;
        }

        public override string ToString()
        {
            return FirstTeam.Name + " - " + SecondTeam.Name + " " + string.Format("{0:G}", Date);
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FootballMatches
{
    public class MatchesVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<Team> teams = new List<Team>();
        private List<Match> matches = new List<Match>();
        private Team chosenTeam;
        private Match chosenMatch;
        private String hoursTillNextMatch;
        private TeamContext teamContext = new TeamContext();

        public ICommand ShowChosenTeamCommand { get; set; }
        public ICommand MakeABetCommand { get; set; }

        public MatchesVM()
        {
            Teams = teamContext.Teams.ToList();
            ShowChosenTeamCommand = new RelayCommand(ShowChosenTeam);
            MakeABetCommand = new RelayCommand(MakeABet);
        }

        private void FillMatches()
        {            
            List<Match> allMatches = new List<Match>();

            Match match1 = new Match(new DateTime(2019, 10, 10, 11, 30, 00), Teams[0], Teams[1]);
            Match match2 = new Match(new DateTime(2019, 10, 11, 20, 00, 00), Teams[1], Teams[2]);
            Match match3 = new Match(new DateTime(2019, 7, 5, 15, 00, 00), Teams[0], Teams[2]);

            allMatches.Add(match1);
            allMatches.Add(match2);
            allMatches.Add(match3);

            Matches = (from m in allMatches where m.FirstTeam.Name == ChosenTeam.Name 
                       || m.SecondTeam.Name == ChosenTeam.Name select m).ToList();
        }

        private void FindHoursTillFirstMatch()
        {
            Match firstMatch = (from m in Matches orderby m.Date ascending select m).First();
            HoursTillNextMatch = "Hours till next match: " + (firstMatch.Date - DateTime.Now).TotalHours.ToString();
        }

        private void ShowChosenTeam(object obj)
        {
            MessageBox.Show("Chosen team: " + ChosenTeam);
            FillMatches();
            FindHoursTillFirstMatch();
        }

        private void MakeABet(object obj)
        {
            if (ChosenMatch == null)
                MessageBox.Show("Choose a team and match first!");
            else
            {
                BetWindow win = new BetWindow() { DataContext = this };
                win.Show();
            }
        }

        public List<Team> Teams
        {
            get { return teams; }
            set
            {
                teams = value;
                NotifyPropertyChanged("Teams");
            }
        }

        public List<Match> Matches
        {
            get { return matches; }
            set
            {
                matches = value;
                NotifyPropertyChanged("Matches");
            }
        }

        public Team ChosenTeam
        {
            get { return chosenTeam; }
            set
            {
                chosenTeam = value;
                NotifyPropertyChanged("ChosenTeam");
            }
        }

        public Match ChosenMatch
        {
            get { return chosenMatch; }
            set
            {
                chosenMatch = value;
                NotifyPropertyChanged("ChosenMatch");
            }
        }

        public String HoursTillNextMatch
        {
            get { return hoursTillNextMatch; }
            set
            {
                hoursTillNextMatch = value;
                NotifyPropertyChanged("HoursTillNextMatch");
            }
        }

        protected void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}

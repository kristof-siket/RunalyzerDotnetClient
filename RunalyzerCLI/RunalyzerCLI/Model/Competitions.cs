using System;
using System.Collections.Generic;

namespace RunalyzerCLI.Model
{
    public partial class Competitions
    {
        public Competitions()
        {
            CompetitionsDistances = new HashSet<CompetitionsDistances>();
            Results = new HashSet<Results>();
        }

        public uint CompId { get; set; }
        public string CompName { get; set; }
        public string CompLocation { get; set; }
        public DateTime CompDate { get; set; }
        public uint CompPromoter { get; set; }
        public uint CompSport { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Users CompPromoterNavigation { get; set; }
        public Sports CompSportNavigation { get; set; }
        public ICollection<CompetitionsDistances> CompetitionsDistances { get; set; }
        public ICollection<Results> Results { get; set; }
    }
}

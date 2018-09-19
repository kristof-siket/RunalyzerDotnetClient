using System;
using System.Collections.Generic;

namespace RunalyzerCLI.Model
{
    public partial class Results
    {
        public Results()
        {
            AnalyzerResults = new HashSet<AnalyzerResults>();
        }

        public uint ResultId { get; set; }
        public sbyte? Disqualified { get; set; }
        public int ResultTime { get; set; }
        public uint ResultAthlete { get; set; }
        public uint ResultCompetition { get; set; }
        public uint ResultDistance { get; set; }
        public uint ResultSport { get; set; }
        public uint? ResultMultisport { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Users ResultAthleteNavigation { get; set; }
        public Competitions ResultCompetitionNavigation { get; set; }
        public Distances ResultDistanceNavigation { get; set; }
        public Sports ResultMultisportNavigation { get; set; }
        public Sports ResultSportNavigation { get; set; }
        public ICollection<AnalyzerResults> AnalyzerResults { get; set; }
    }
}

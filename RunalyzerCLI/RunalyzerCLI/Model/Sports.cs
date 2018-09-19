using System;
using System.Collections.Generic;

namespace RunalyzerCLI.Model
{
    public partial class Sports
    {
        public Sports()
        {
            Competitions = new HashSet<Competitions>();
            DistancesMulti = new HashSet<Distances>();
            DistancesSport = new HashSet<Distances>();
            ResultsResultMultisportNavigation = new HashSet<Results>();
            ResultsResultSportNavigation = new HashSet<Results>();
            TrainingPlans = new HashSet<TrainingPlans>();
        }

        public uint SportId { get; set; }
        public string SportName { get; set; }
        public string Multisport { get; set; }
        public string SportDesc { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Competitions> Competitions { get; set; }
        public ICollection<Distances> DistancesMulti { get; set; }
        public ICollection<Distances> DistancesSport { get; set; }
        public ICollection<Results> ResultsResultMultisportNavigation { get; set; }
        public ICollection<Results> ResultsResultSportNavigation { get; set; }
        public ICollection<TrainingPlans> TrainingPlans { get; set; }
    }
}

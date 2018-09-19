using System;
using System.Collections.Generic;

namespace RunalyzerCLI.Model
{
    public partial class Distances
    {
        public Distances()
        {
            CompetitionsDistances = new HashSet<CompetitionsDistances>();
            Results = new HashSet<Results>();
            TrainingPlans = new HashSet<TrainingPlans>();
        }

        public uint DistanceId { get; set; }
        public string DistanceName { get; set; }
        public double DistanceKilometers { get; set; }
        public uint SportId { get; set; }
        public uint? MultiId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Sports Multi { get; set; }
        public Sports Sport { get; set; }
        public ICollection<CompetitionsDistances> CompetitionsDistances { get; set; }
        public ICollection<Results> Results { get; set; }
        public ICollection<TrainingPlans> TrainingPlans { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RunalyzerCLI.Model
{
    public partial class CompetitionsDistances
    {
        public uint Id { get; set; }
        public uint CompetitionId { get; set; }
        public uint DistanceId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Competitions Competition { get; set; }
        public Distances Distance { get; set; }
    }
}

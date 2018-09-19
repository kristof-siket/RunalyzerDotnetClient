using System;
using System.Collections.Generic;

namespace RunalyzerCLI.Model
{
    public partial class TrainingPlans
    {
        public uint TpId { get; set; }
        public string TpName { get; set; }
        public string TpDesc { get; set; }
        public string TpFilepath { get; set; }
        public uint TpCreator { get; set; }
        public uint TpSport { get; set; }
        public uint TpDistance { get; set; }
        public uint TpLevel { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Users TpCreatorNavigation { get; set; }
        public Distances TpDistanceNavigation { get; set; }
        public Levels TpLevelNavigation { get; set; }
        public Sports TpSportNavigation { get; set; }
    }
}

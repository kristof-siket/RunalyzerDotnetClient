using System;
using System.Collections.Generic;

namespace RunalyzerCLI.Model
{
    public partial class Levels
    {
        public Levels()
        {
            TrainingPlans = new HashSet<TrainingPlans>();
        }

        public uint LevelId { get; set; }
        public uint LevelNum { get; set; }
        public string LevelDesc { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<TrainingPlans> TrainingPlans { get; set; }
    }
}

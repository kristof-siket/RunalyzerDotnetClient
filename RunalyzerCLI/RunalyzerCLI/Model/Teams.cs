using System;
using System.Collections.Generic;

namespace RunalyzerCLI.Model
{
    public partial class Teams
    {
        public Teams()
        {
            Users = new HashSet<Users>();
        }

        public uint TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamLocation { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}

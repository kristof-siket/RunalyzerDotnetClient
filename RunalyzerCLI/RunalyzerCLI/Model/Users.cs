using System;
using System.Collections.Generic;

namespace RunalyzerCLI.Model
{
    public partial class Users
    {
        public Users()
        {
            Competitions = new HashSet<Competitions>();
            Results = new HashSet<Results>();
            TrainingPlans = new HashSet<TrainingPlans>();
        }

        public uint Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Location { get; set; }
        public string RememberToken { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public uint TeamId { get; set; }

        public Teams Team { get; set; }
        public ICollection<Competitions> Competitions { get; set; }
        public ICollection<Results> Results { get; set; }
        public ICollection<TrainingPlans> TrainingPlans { get; set; }
    }
}

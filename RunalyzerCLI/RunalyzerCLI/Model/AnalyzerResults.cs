using System;
using System.Collections.Generic;

namespace RunalyzerCLI.Model
{
    public partial class AnalyzerResults
    {
        public uint AresultId { get; set; }
        public uint AresultResult { get; set; }
        public double AresultTimestamp { get; set; }
        public double? AresultKilometers { get; set; }
        public double AresultPulse { get; set; }

        public Results AresultResultNavigation { get; set; }
    }
}

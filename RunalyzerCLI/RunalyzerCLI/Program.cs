using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RunalyzerCLI.Model;

namespace RunalyzerCLI
{
    class Program
    {
        static sportsdirectorsystemContext context = new sportsdirectorsystemContext();
        const double TIMESTAMP = 0.5;

        static async Task Main(string[] args)
        {
            #region Initialization

            string userMail;

            Console.WriteLine("Email address for Runalyzer:");
            userMail = Console.ReadLine();

            Console.Clear();

            Console.WriteLine($"Welcome to Runalyzer CLI! Feel free to take a service from the list below!");
            Console.WriteLine();

            Console.WriteLine($"1 - Overall stats for a race");
            Console.WriteLine($"2 - My stats for a race");

            int service = int.Parse(Console.ReadLine());

            Console.Write("Competition ID: ");
            int compId = int.Parse(Console.ReadLine());

            #endregion

            #region Switch services
            bool serviceResult = false;
            switch (service)
            {
                case 1:
                    { 
                        serviceResult = await Task.Run(() => StartOverallRaceStatService(compId));
                        break;
                    }
                    
                case 2:
                    {
                        int userId = (int)(context.Users?.SingleOrDefault(x => x.Email == userMail)?.Id);

                        (double maxspd, double maxpls, double avgspd, decimal avgpls) stat = (0,0,0,0);

                        serviceResult = await Task.Run(() => StartPersonalRaceStatService(compId, userId, ref stat));
                       
                        break;
                    }

            }
            #endregion

            if (serviceResult)
            {
                Console.WriteLine("Runalyzer service call was succesful.");
            }
            else
            {
                Console.WriteLine("Runalyzer service call failed.");
            }

            Console.ReadKey();
        }

        #region Service methods
        static bool StartOverallRaceStatService(int compId)
        {
            return false;
        }

        static bool StartPersonalRaceStatService(int compId, int userId, ref (double maxspd, double maxpls, double avgspd, decimal avgpls) stat)
        {
            try
            {

                var query = from res in context.Results
                            where (res.ResultAthlete == userId &&
                                  res.ResultCompetition == compId &&
                                  res.ResultTime != 0)
                            select res.ResultId;

                int result = (int)query.Single();

                List<double> tempos = ((Func<IEnumerable<double>>)(() =>
               {
                   List<double> coll = new List<double>();


                   var prev = context.AnalyzerResults.Where(x => x.AresultResult == result).First();
                   int i = 0;

                   foreach (var ares in context.AnalyzerResults.Where(x => x.AresultResult == result))
                   {
                       if (i == 0) { i++; continue; }

                       double tempo = (double)(ares.AresultKilometers - prev.AresultKilometers) * (3600 / TIMESTAMP);

                       coll.Add(tempo);
                       prev = ares;
                       i++;
                   }

                   return coll;
               }))().ToList();

                double maxPulse = context.AnalyzerResults.Where(x => x.AresultResult == result).Max(x => x.AresultPulse);
                decimal avgPulse = context.AnalyzerResults.Where(x => x.AresultResult == result).Average(x => (decimal)(x.AresultPulse));
                double maxTempo = tempos.Max();
                double avgTempo = tempos.Average();

                stat = (maxTempo, maxPulse, avgTempo, avgPulse);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}

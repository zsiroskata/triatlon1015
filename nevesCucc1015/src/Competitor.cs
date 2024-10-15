using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nevesCucc1015.src
{
    internal class Competitor
    {
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        public int RaceNumber { get; set; }
        public bool Gender { get; set; }
        public string AgeCategory { get; set; }
        public Dictionary<string, TimeSpan> RaceTimes { get; set; }
        public double TotalTime => RaceTimes.Values.Sum(x=> x.TotalSeconds);
        public override string ToString()
        {
            return $"[{RaceNumber}] - {Name} {AgeCategory} {(Gender ? "férfi" : "nő")}";
        }

        public Competitor(string row)
        {
            var data = row.Split(';');
            Name = data[0];
            YearOfBirth = int.Parse(data[1]);
            RaceNumber = int.Parse(data[2]);
            Gender = data[3] == "f";
            AgeCategory = data[4];
            RaceTimes = new()
            {
                { "swimming", TimeSpan.Parse(data[5]) },
                { "1st depot", TimeSpan.Parse(data[6])},
                { "cycling", TimeSpan.Parse(data[7])},
                { "2nd depot", TimeSpan.Parse(data[8])},
                { "running", TimeSpan.Parse(data[9])},
            };

        }
    }
}

using CovidDashboard.Entities;

namespace CovidDashboard.Services;

public class CovidService
{
    private readonly List<Timeline> timelines = new List<Timeline>();

    public List<Timeline> GetTimeline()
    {
        return timelines;
    }

    public void ParseTimeline()
    {
        timelines.AddRange(File.ReadAllLines("../CSVs/CovidFaelle_Timeline").Select((line) =>
        {
            var props = line.Split(";");
            return new Timeline
            {
                Date = DateTime.Parse(props[0]),
                County = props[1],
                Residents = int.Parse(props[3]),
                CasesDaily = int.Parse(props[4]),
                Cases = int.Parse(props[5]),
                Cases7Days = int.Parse(props[6]),
                SevenIncidence = double.Parse(props[7]),
                DeathDaily = int.Parse(props[8]),
                Death = int.Parse(props[9]),
                RecoveredDaily = int.Parse(props[10]),
                Recovered = int.Parse(props[11]),
            };
        }).ToList());
    }
}

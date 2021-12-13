using CovidDashboard.DTOs;
using CovidDashboard.Entities;

namespace CovidDashboard.Services;

public class CovidService
{
    private readonly List<Timeline> timelines = new List<Timeline>();
    private readonly List<Agegroup> agegroups = new List<Agegroup>();

    public List<Timeline> GetTimeline()
    {
        return timelines;
    }

    public TimelineDailyDTO GetTimelineDaily()
    {
        var labels = new List<string>();
        var data = new List<int>();

        timelines.ForEach(x =>
        {
            if (labels.Contains(x.Date.ToString("dd.MM.yyyy"))
                || !x.County.Equals("Österreich"))
            {
                Console.WriteLine(x.Date.ToString());
                return;
            }

            labels.Add(x.Date.ToString("dd.MM.yyyy"));
            data.Add(x.CasesDaily);
        });

        return new TimelineDailyDTO
        {
            Labels = labels,
            Data = data,
        };
    }
    public AgeGroupDTO GetAgeGroup()
    {
        var labels = new List<string>();
        var group = new Group();
        group.Data = new List<int>();

        var latestDate = agegroups[^1].Date;

        agegroups.ForEach(x =>
        {
            if (!x.County.Equals("Österreich") || !x.Date.Equals(latestDate))
            {
                return;
            }

            if(labels.Contains(x.Name))
            {
                var index = labels.IndexOf(x.Name);
                if (index >= 0)
                {
                    group.Data[index] += x.Count;
                }
            } 
            else
            {
                labels.Add(x.Name);
            }

            group.Data.Add(x.Count);
        });
        group.Label = "Count";

        return new AgeGroupDTO
        {
            Labels = labels,
            Datasets = new List<Group>
            {
                group
            }
        };
    }

    public AgeGroupDTO GetAgegroupGendered()
    {
        var labels = new List<string>();
        var groupM = new Group();
        groupM.Data = new List<int>();
        groupM.Label = "Count Male";
        var groupF = new Group();
        groupF.Data = new List<int>();
        groupF.Label = "Count Female";

        var latestDate = agegroups[^1].Date;

        agegroups.ForEach(x =>
        {
            if (!x.County.Equals("Österreich") || !x.Date.Equals(latestDate))
            {
                return;
            }

            if (x.Gender.Equals("M"))
            {
                groupM.Data.Add(x.Count);
            }
            else
            {
                groupF.Data.Add(x.Count);
            }

            if (!labels.Contains(x.Name))
            {
                labels.Add(x.Name);
            }
        });

        return new AgeGroupDTO
        {
            Labels = labels,
            Datasets = new List<Group>
            {
                groupM, groupF,
            }
        };
    }

    #region file parsing -------------------------------------------

    public void ParseTimeline()
    {
        timelines.AddRange(File.ReadAllLines("./CSVs/CovidFaelle_Timeline.csv").Skip(1).Select((line) =>
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

    public void ParseAgeGroup()
    {
        agegroups.AddRange(File.ReadAllLines("./CSVs/CovidFaelle_Altersgruppe.csv").Skip(1).Select((line) =>
        {
            var props = line.Split(";");
            return new Agegroup()
            {
                Date = DateTime.Parse(props[0]),
                Id = int.Parse(props[1]),
                Name = props[2],
                County = props[3],
                Residents = int.Parse(props[5]),
                Gender = props[6],
                Count = int.Parse(props[7]),
                CountHealed = int.Parse(props[8]),
                CountDead = int.Parse(props[9]),
            };
        }).ToList());

    }

    #endregion

}

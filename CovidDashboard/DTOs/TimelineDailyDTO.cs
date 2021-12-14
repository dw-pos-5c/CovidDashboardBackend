namespace CovidDashboard.DTOs;

public class TimelineDailyDTO
{
    public List<string> Labels { get; set; }
    public List<Group> Datasets { get; set; }
}

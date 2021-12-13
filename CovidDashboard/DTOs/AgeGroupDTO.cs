namespace CovidDashboard.DTOs;

public class AgeGroupDTO
{
    public List<string> Labels { get; set; }
    public List<Group> Datasets { get; set; }
}

public class Group
{
    public List<int> Data { get; set; }
    public string Label { get; set; }
}

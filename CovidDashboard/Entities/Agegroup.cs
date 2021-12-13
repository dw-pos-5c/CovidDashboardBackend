namespace CovidDashboard.Entities;

public class Agegroup
{
    public DateTime Date { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public string County { get; set; }
    public int Residents { get; set; }
    public string Gender { get; set; }
    public int Count { get; set; }
    public int CountHealed { get; set; }
    public int CountDead { get; set; }
}

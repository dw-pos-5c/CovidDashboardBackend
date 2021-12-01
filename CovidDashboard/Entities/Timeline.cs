namespace CovidDashboard.Entities;

public class Timeline
{
    public DateTime Date { get; set; }
    public string County { get; set; }
    public int Residents { get; set; }
    public int CasesDaily { get; set; }
    public int Cases { get; set; }
    public int Cases7Days { get; set; }
    public double SevenIncidence { get; set; }
    public int DeathDaily { get; set; }
    public int Death { get; set; }
    public int RecoveredDaily { get; set; }
    public int Recovered { get; set; }
}

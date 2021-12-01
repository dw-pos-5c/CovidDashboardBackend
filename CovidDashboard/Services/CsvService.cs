namespace CovidDashboard.Services;

public class CsvService: IHostedService
{
    private readonly CovidService covidService;

    public CsvService(CovidService covidService)
    {
        this.covidService = covidService;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("StartAsync");
        return new Task(ParseFiles, cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private void ParseFiles()
    {
        Console.WriteLine("ParseFiles");
        covidService.ParseTimeline();
    }
}

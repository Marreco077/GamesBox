namespace GamesBox.Entities;

public class Game
{
    public Guid Id { get; set; } 
    public string Name { get; set; } = String.Empty;
    public string Summary { get; set; } = String.Empty;
    public DateTime Date { get; set; }
    public decimal Score { get; set; } = 0.0m;
    public string Director { get; set; } = String.Empty;
    public string? Writers { get; set; }
    public string? Company { get; set; }
    
    public Game() { }

    public Game(string name, string summary, DateTime date, decimal score, string director, string? writers, string? company)
    {
        Name = name;
        Summary = summary;
        Date = date;
        Score = score;
        Director = director;
        Writers = writers;
        Company = company;
    }
    
}
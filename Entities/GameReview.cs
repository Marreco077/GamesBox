namespace GamesBox.Entities;

public class GameReview
{   
    public Guid Id { get; set; }
    public string Review { get; set; } = String.Empty;
    public double Score { get; set; }
    public bool Like { get; set; }
    public bool Finished { get; set; }

    public Guid GameId { get; set; } // FK
    public Game? Game { get; set; } // Navigation property
    
    public Guid UserId { get; set; } // FK
    public User? User { get; set; } // Navigation property
    
    public GameReview () {}

    public GameReview(string review, double score, bool like, bool finished, Guid gameId, Guid userId)
    {
        Review = review;
        Score = score;
        Like = like;
        Finished = finished;
        GameId = gameId;
        UserId = userId;
    }
}
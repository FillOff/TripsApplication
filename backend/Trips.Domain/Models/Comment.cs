namespace Trips.Domain.Models;

public class Comment
{
    public Guid Id { get; set; }
    public string Content { get; set; } = string.Empty;

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public Guid TripId { get; set; }
    public Trip? Trip { get; set; }
}
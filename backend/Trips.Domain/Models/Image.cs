namespace Trips.Domain.Models;

public class Image
{
    public Guid Id { get; set; }
    public string Url { get; set; } = string.Empty;

    public int TripId { get; set; }
    public Trip? Trip { get; set; }
}
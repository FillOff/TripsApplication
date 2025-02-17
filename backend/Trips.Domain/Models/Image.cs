namespace Trips.Domain.Models;

public class Image
{
    public Guid Id { get; set; }
    public string Url { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;

    public Guid TripId { get; set; }
    public Trip? Trip { get; set; }
}
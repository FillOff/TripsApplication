using Trips.Domain.Enums;

namespace Trips.Domain.Models;

public class Trip
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public DateTime RelativeTime { get; set; }
    public TripStatus TripStatus { get; set; }

    public Guid RouteId { get; set; }
    public Route? Route { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public List<Comment> Comments { get; set; } = [];
    public List<Image> Images { get; set; } = [];
}
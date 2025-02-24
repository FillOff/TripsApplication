using System.Text.Json.Serialization;
using Trips.Domain.Enums;

namespace Trips.Domain.Models;

public class Trip
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public long RelativeDateTime { get; set; }
    public TripStatus TripStatus { get; set; }

    public Guid RouteId { get; set; }
    [JsonIgnore]
    public Route? Route { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }

    [JsonIgnore]
    public List<Comment> Comments { get; set; } = [];
    [JsonIgnore]
    public List<Image> Images { get; set; } = [];
}
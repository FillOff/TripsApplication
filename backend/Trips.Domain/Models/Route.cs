using System.Text.Json.Serialization;

namespace Trips.Domain.Models;

public class Route
{
    public Guid Id { get; set; }
    public string StartPlace { get; set; } = string.Empty;
    public string EndPlace { get; set; } = string.Empty;
    public double Length { get; set; }
    public long Duration { get; set; }

    [JsonIgnore]
    public Trip? Trip { get; set; }
}
namespace Trips.API.Contracts.Images;

public record class GetImageResponse(
    Guid Id,
    string Url,
    string FilePath,
    Guid TripId);
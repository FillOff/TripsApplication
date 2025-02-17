namespace Trips.API.Contracts.Images;

public record class CreateImageRequest(
    Guid TripId,
    IFormFile File);

namespace Trips.API.Contracts.Comments;

public record class CreateCommentsRequest(
    string Content,
    Guid UserId,
    Guid TripId);

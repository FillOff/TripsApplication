namespace Trips.API.Contracts.Comments;

public record class UpdateCommentsRequest(
    Guid Id,
    string Content,
    Guid UserId,
    Guid TripId);

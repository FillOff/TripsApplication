namespace Trips.API.Contracts.Comments;

public record class CommentsResponse(
    Guid Id,
    string Content,
    Guid UserId,
    Guid TripId);

namespace Trips.API.Contracts.Comments;

public record class CreateCommentRequest(
    string Content,
    Guid UserId,
    Guid TripId);

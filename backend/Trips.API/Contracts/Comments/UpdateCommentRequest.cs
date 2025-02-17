namespace Trips.API.Contracts.Comments;

public record class UpdateCommentRequest(
    Guid Id,
    string Content,
    Guid UserId,
    Guid TripId);

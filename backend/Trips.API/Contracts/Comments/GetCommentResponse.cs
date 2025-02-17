namespace Trips.API.Contracts.Comments;

public record class GetCommentResponse(
    Guid Id,
    string Content,
    Guid UserId,
    Guid TripId);

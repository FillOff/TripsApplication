namespace Trips.API.Contracts.Users;

public record class GetUserResponse(
    Guid Id,
    string Name);
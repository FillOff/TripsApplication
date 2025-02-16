namespace Trips.API.Contracts.Users;

public record class RegisterUsersRequest(
    string Name,
    string Email,
    string Password);

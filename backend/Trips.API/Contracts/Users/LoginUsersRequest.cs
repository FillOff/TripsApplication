namespace Trips.API.Contracts.Users;

public record class LoginUsersRequest(
    string Email,
    string Password);

using System.ComponentModel.DataAnnotations;

namespace Trips.API.Contracts.Users;

public record class LoginUserRequest(
    [Required] string Email,
    [Required] string Password);

namespace Trips.Domain.Models;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash {  get; set; } = string.Empty;

    public List<Trip> Trips { get; set; } = [];

    public List<Comment> Comments { get; set; } = [];
}
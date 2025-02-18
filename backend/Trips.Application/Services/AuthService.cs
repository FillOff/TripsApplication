using Trips.Domain.Models;
using Trips.Interfaces.Auth;
using Trips.Interfaces.Repositories;
using Trips.Interfaces.Services;

namespace Trips.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;

    public AuthService(
        IUsersRepository usersRepository,
        IPasswordHasher passwordHasher,
        IJwtProvider jwtProvider)
    {
        _usersRepository = usersRepository;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
    }

    public async Task Register(string name, string email, string password)
    {
        var hashedPassword = _passwordHasher.Generate(password);

        await _usersRepository.Add(Guid.NewGuid(), name, email, hashedPassword);
    }

    public async Task<string> Login(string email, string password)
    {
        var user = await _usersRepository.GetByEmail(email) ?? throw new Exception();

        var result = _passwordHasher.Verify(password, user.PasswordHash);

        if (result == false)
        {
            throw new Exception("Login failed");
        }

        var token = _jwtProvider.GenerateToken(user);

        return token;
    }

    public async Task<List<User>> Get()
    {
        return await _usersRepository.Get();
    }

    public async Task<Guid> UpdateUserAsync(
        Guid id,
        string name,
        string email,
        string passwordHash)
    {
        return await _usersRepository.Update(
            id,
            name,
            email,
            passwordHash);
    }

    public async Task<Guid> DeleteUserAsync(Guid id)
    {
        return await _usersRepository.Delete(id);
    }
}
using Microsoft.AspNetCore.Http;
using Trips.Domain.Models;

namespace Trips.Interfaces.Services;

public interface IImagesService
{
    Task<Guid> CreateImageAsync(Guid tripId, IFormFile file);
    Task<Guid> DeleteImageAsync(Guid id);
    Task<List<Image>> GetImagesAsync();
}
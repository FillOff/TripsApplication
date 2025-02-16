using Trips.Domain.Models;

namespace Trips.Interfaces.Services;

public interface IImagesService
{
    Task<Guid> CreateImageAsync(string url, Guid tripId);
    Task<Guid> DeleteImageAsync(Guid id);
    Task<List<Image>> GetImagesAsync();
    Task<Guid> UpdateImageAsync(Guid id, string url, Guid tripId);
}
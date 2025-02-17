using Trips.Domain.Models;

namespace Trips.Interfaces.Repositories;

public interface IImagesRepository
{
    Task<Guid> Add(Guid id, string url, string filePath, Guid tripId);
    Task<Guid> Delete(Guid id);
    Task<List<Image>> Get();
    Task<Image?> GetById(Guid id);
    Task<List<Image>> GetWithTrip();
    Task<Guid> Update(Guid id, string url, string filePath, Guid tripId);
}
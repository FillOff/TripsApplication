using Trips.Domain.Models;
using Trips.Interfaces.Repositories;
using Trips.Interfaces.Services;

namespace Trips.Application.Services;

public class ImagesService : IImagesService
{
    private readonly IImagesRepository _imagesRepository;

    public ImagesService(IImagesRepository imagesRepository)
    {
        _imagesRepository = imagesRepository;
    }

    public async Task<List<Image>> GetImagesAsync()
    {
        return await _imagesRepository.Get();
    }

    public async Task<Guid> CreateImageAsync(
        string url,
        Guid tripId)
    {
        return await _imagesRepository.Add(
            Guid.NewGuid(),
            url,
            tripId);
    }

    public async Task<Guid> UpdateImageAsync(
        Guid id,
        string url,
        Guid tripId)
    {
        return await _imagesRepository.Update(
            id,
            url,
            tripId);
    }

    public async Task<Guid> DeleteImageAsync(Guid id)
    {
        return await _imagesRepository.Delete(id);
    }
}

using Microsoft.AspNetCore.Http;
using Trips.Domain.Models;
using Trips.Interfaces.Repositories;
using Trips.Interfaces.Services;

namespace Trips.Application.Services;

public class ImagesService : IImagesService
{
    private readonly string _storagePath = Path.Combine(Directory.GetCurrentDirectory(), "images");
    private readonly IHttpContextAccessor _httpContextAccessor;

    private readonly IImagesRepository _imagesRepository;

    public ImagesService(
        IImagesRepository imagesRepository,
        IHttpContextAccessor httpContextAccessor)
    {
        _imagesRepository = imagesRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<List<Image>> GetImagesAsync()
    {
        return await _imagesRepository.Get();
    }

    public async Task<Guid> CreateImageAsync(
        Guid tripId,
        IFormFile file)
    {
        Guid id = Guid.NewGuid();
        string contentType = file.ContentType;
        string fileName = id.ToString() + "." + contentType.Split("/")[1];
        string filePath = Path.Combine(_storagePath, fileName);

        Directory.CreateDirectory(_storagePath);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        var request = _httpContextAccessor.HttpContext?.Request;
        string url = $"{request?.Scheme}://{request?.Host}/images/{fileName}";

        return await _imagesRepository.Add(
            id,
            url,
            filePath,
            tripId);
    }

    public async Task<Guid> DeleteImageAsync(Guid id)
    {
        var image = await _imagesRepository.GetById(id);

        if (image == null)
        {
            throw new Exception("Image not found");
        }

        File.Delete(image.FilePath);

        return await _imagesRepository.Delete(id);
    }
}

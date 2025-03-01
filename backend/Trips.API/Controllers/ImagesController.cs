﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trips.API.Contracts.Images;
using Trips.Interfaces.Services;

namespace Trips.API.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class ImagesController : ControllerBase
{
    private readonly IImagesService _imagesService;
    private readonly IMapper _mapper;

    public ImagesController(
        IImagesService imagesService,
        IMapper mapper)
    {
        _imagesService = imagesService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetImageResponse>>> GetImages()
    {
        var images = await _imagesService.GetImagesAsync();
        var response = _mapper.Map<List<GetImageResponse>>(images);

        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateImage([FromForm] CreateImageRequest image)
    {
        Guid id = await _imagesService.CreateImageAsync(image.TripId, image.File);

        return Ok(id);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteImage([FromRoute] Guid id)
    {
        return await _imagesService.DeleteImageAsync(id);
    }
}

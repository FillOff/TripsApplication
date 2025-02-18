using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trips.API.Contracts.Comments;
using Trips.API.Contracts.Trips;
using Trips.Interfaces.Services;

namespace Trips.API.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly ICommentsService _commentsService;
    private readonly IMapper _mapper;

    public CommentsController(
        ICommentsService commentsService,
        IMapper mapper)
    {
        _commentsService = commentsService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetCommentResponse>>> GetComments()
    {
        var comments = await _commentsService.GetCommentsAsync();
        var response = _mapper.Map<List<GetCommentResponse>>(comments);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateComment([FromBody] CreateCommentRequest comment)
    {
        Guid id = await _commentsService.CreateCommentAsync(
            comment.Content,
            comment.UserId,
            comment.TripId);

        return Ok(id);
    }

    [HttpPut]
    public async Task<ActionResult<Guid>> UpdateComment([FromBody] UpdateCommentRequest comment)
    {
        Guid id = await _commentsService.UpdateCommentAsync(
            comment.Id,
            comment.Content,
            comment.UserId,
            comment.TripId);

        return Ok(id);
    }

    [HttpDelete]
    public async Task<ActionResult<Guid>> DeleteComment(Guid id)
    {
        return Ok(await _commentsService.DeleteCommentAsync(id));
    }
}

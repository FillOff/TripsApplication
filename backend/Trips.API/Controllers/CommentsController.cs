using Microsoft.AspNetCore.Mvc;
using Trips.API.Contracts.Comments;
using Trips.API.Contracts.Trips;
using Trips.Interfaces.Services;

namespace Trips.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly ICommentsService _commentsService;
    public CommentsController(ICommentsService commentsService)
    {
        _commentsService = commentsService;
    }

    [HttpGet]
    public async Task<ActionResult<List<TripsResponse>>> GetComments()
    {
        var response = (await _commentsService.GetCommentsAsync())
            .Select(c => new CommentsResponse(
                c.Id,
                c.Content,
                c.UserId,
                c.TripId))
            .ToList();

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateComment([FromBody] CreateCommentsRequest comment)
    {
        Guid id = await _commentsService.CreateCommentAsync(
            comment.Content,
            comment.UserId,
            comment.TripId);

        return Ok(id);
    }

    [HttpPut]
    public async Task<ActionResult<Guid>> UpdateComment([FromBody] UpdateCommentsRequest comment)
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

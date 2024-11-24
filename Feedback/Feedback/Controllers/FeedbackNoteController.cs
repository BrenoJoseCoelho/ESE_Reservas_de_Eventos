using Feedback.Dtos;
using Feedback.Request;
using Feedback.Services;
using Microsoft.AspNetCore.Mvc;

namespace Feedback.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeedbackNoteController : ControllerBase
{
    private readonly IFeedbackNoteService _feedbackNoteService;

    public FeedbackNoteController(IFeedbackNoteService feedbackNoteService)
    {
        _feedbackNoteService = feedbackNoteService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FeedbackNoteDto>>> Get()
    {
        var FeedbackNotesDto = await _feedbackNoteService.GetFeedbackNotes();

        if (FeedbackNotesDto is null)
            return NotFound("FeedbackNotes not found");

        return Ok(FeedbackNotesDto);
    }

    [HttpGet("{id:Guid}", Name = "GetFeedbackNote")]
    public async Task<ActionResult<FeedbackNoteDto>> Get(Guid id)
    {
        var feedbackNoteDto = await _feedbackNoteService.GetFeedbackNoteById(id);
        if (feedbackNoteDto == null)
        {
            return NotFound("FeedbackNote not found");
        }
        return Ok(feedbackNoteDto);
    }
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateFeedbackNoteRequest feedbackNoteDto)
    {
        if (feedbackNoteDto == null)
            return BadRequest("Invalid Data");

        await _feedbackNoteService.AddFeedbackNote(feedbackNoteDto);

        return new CreatedAtRouteResult("GetFeedbackNote",
            feedbackNoteDto);
    }

    [HttpPut("{id:Guid}")]
    public async Task<ActionResult> Put(Guid id, [FromBody] UpdateFeedbackNoteRequest feedbackNoteDto)
    {
        if (id != feedbackNoteDto.Id)
            return BadRequest();

        if (feedbackNoteDto is null)
            return BadRequest();

        await _feedbackNoteService.UpdateFeedbackNote(feedbackNoteDto);

        return Ok(feedbackNoteDto);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult<FeedbackNoteDto>> Delete(Guid id)
    {
        var feedbackNoteDto = await _feedbackNoteService.GetFeedbackNoteById(id);
        if (feedbackNoteDto == null)
        {
            return NotFound("FeedbackNote not found");
        }

        await _feedbackNoteService.RemoveFeedbackNote(id);

        return Ok(feedbackNoteDto);
    }
}
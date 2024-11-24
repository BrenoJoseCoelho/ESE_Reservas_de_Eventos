using Feedback.Context;
using Feedback.Dtos;
using Feedback.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Feedback.Repositories;

public class FeedbackNoteRepository : IFeedbackNoteRepository
{
    private readonly AppDbContext _context;
    private readonly HttpClient _httpClient;

    public FeedbackNoteRepository(AppDbContext context, HttpClient httpClient)
    {
        _context = context;
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<FeedbackNoteDto>> GetAll()
    {
        var feedbacks = await _context.FeedbackNotes.ToListAsync();
        List<FeedbackNoteDto> feedbackDto = new List<FeedbackNoteDto>();
        foreach (var feedback in feedbacks)
        {
            var feedbackResult = new FeedbackNoteDto
            {
                Id = feedback.Id,
                Note = feedback.Note,
                Observation = feedback.Observation,
            };

            var responseEvent = await _httpClient.GetAsync($"http://host.docker.internal:8081/api/event/{feedback.EventId}");

            if (responseEvent.IsSuccessStatusCode)
            {
                var jsonString = await responseEvent.Content.ReadAsStringAsync();
                var eventDto = JsonSerializer.Deserialize<EventDto>(jsonString);
                feedbackResult.Event = eventDto;
            }


            var responseUser = await _httpClient.GetAsync($"http://host.docker.internal:8083/api/user/{feedback.UserId}");

            if (responseUser.IsSuccessStatusCode)
            {
                var jsonString = await responseUser.Content.ReadAsStringAsync();
                var userDto = JsonSerializer.Deserialize<UserDto>(jsonString);
                feedbackResult.User = userDto;
            }

            feedbackDto.Add(feedbackResult);
        }
        return feedbackDto;
    }
    public async Task<FeedbackNote> GetById(Guid id)
    {
        return await _context.FeedbackNotes.Where(c => c.Id == id).FirstOrDefaultAsync();
    }
    public async Task<FeedbackNote> Create(FeedbackNote feedbackNote)
    {
        _context.FeedbackNotes.Add(feedbackNote);
        await _context.SaveChangesAsync();
        return feedbackNote;
    }
    public async Task<FeedbackNote> Update(FeedbackNote feedbackNote)
    {
        _context.Entry(feedbackNote).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return feedbackNote;
    }
    public async Task<FeedbackNote> Delete(Guid id)
    {
        var feedbackNote = await GetById(id);
        _context.FeedbackNotes.Remove(feedbackNote);
        await _context.SaveChangesAsync();
        return feedbackNote;
    }
}


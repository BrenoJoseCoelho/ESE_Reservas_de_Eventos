using Feedback.Dtos;
using Feedback.Request;

namespace Feedback.Services;

public interface IFeedbackNoteService
{
    Task<IEnumerable<FeedbackNoteDto>> GetFeedbackNotes();
    Task<FeedbackNoteDto> GetFeedbackNoteById(Guid id);
    Task AddFeedbackNote(CreateFeedbackNoteRequest feedbackNoteDto);
    Task UpdateFeedbackNote(UpdateFeedbackNoteRequest feedbackNoteDto);
    Task RemoveFeedbackNote(Guid id);
}
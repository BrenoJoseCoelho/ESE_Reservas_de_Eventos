using Feedback.Dtos;

namespace Feedback.Services;

public interface IFeedbackNoteService
{
    Task<IEnumerable<FeedbackNoteDto>> GetFeedbackNotes();
    Task<FeedbackNoteDto> GetFeedbackNoteById(Guid id);
    Task AddFeedbackNote(FeedbackNoteDto feedbackNoteDto);
    Task UpdateFeedbackNote(FeedbackNoteDto feedbackNoteDto);
    Task RemoveFeedbackNote(Guid id);
}
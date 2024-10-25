using Feedback.Models;

namespace Feedback.Repositories;

public interface IFeedbackNoteRepository
{
    Task<IEnumerable<FeedbackNote>> GetAll();
    Task<FeedbackNote> GetById(Guid id);
    Task<FeedbackNote> Create(FeedbackNote feedbackNote);
    Task<FeedbackNote> Update(FeedbackNote feedbackNote);
    Task<FeedbackNote> Delete(Guid id);
}
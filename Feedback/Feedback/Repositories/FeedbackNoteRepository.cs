using Feedback.Context;
using Feedback.Models;
using Microsoft.EntityFrameworkCore;

namespace Feedback.Repositories;

public class FeedbackNoteRepository : IFeedbackNoteRepository
{
    private readonly AppDbContext _context;
    public FeedbackNoteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<FeedbackNote>> GetAll()
    {
        return await _context.FeedbackNotes.ToListAsync();
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


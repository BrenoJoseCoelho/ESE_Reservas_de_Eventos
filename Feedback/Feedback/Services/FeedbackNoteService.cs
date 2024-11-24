using AutoMapper;
using Feedback.Dtos;
using Feedback.Models;
using Feedback.Repositories;
using Feedback.Request;

namespace Feedback.Services;

public class FeedbackNoteService : IFeedbackNoteService
{
    private readonly IFeedbackNoteRepository _feedbackNoteRepository;
    private readonly IMapper _mapper;
    public FeedbackNoteService(IFeedbackNoteRepository feedbackNoteRepository, IMapper mapper)
    {
        _feedbackNoteRepository = feedbackNoteRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FeedbackNoteDto>> GetFeedbackNotes()
    {
        var feedbackNotesEntity = await _feedbackNoteRepository.GetAll();
        return _mapper.Map<IEnumerable<FeedbackNoteDto>>(feedbackNotesEntity);
    }
    public async Task<FeedbackNoteDto> GetFeedbackNoteById(Guid id)
    {
        var feedbackNoteEntity = await _feedbackNoteRepository.GetById(id);
        return _mapper.Map<FeedbackNoteDto>(feedbackNoteEntity);
    }
    public async Task AddFeedbackNote(CreateFeedbackNoteRequest feedbackNoteDto)
    {
        var feedbackNoteEntity = _mapper.Map<FeedbackNote>(feedbackNoteDto);
        await _feedbackNoteRepository.Create(feedbackNoteEntity);
    }
    public async Task UpdateFeedbackNote(UpdateFeedbackNoteRequest feedbackNoteDto)
    {
        var feedbackNoteEntity = _mapper.Map<FeedbackNote>(feedbackNoteDto);
        await _feedbackNoteRepository.Update(feedbackNoteEntity);
    }
    public async Task RemoveFeedbackNote(Guid id)
    {
        var feedbackNoteEntity = _feedbackNoteRepository.GetById(id).Result;
        await _feedbackNoteRepository.Delete(feedbackNoteEntity.Id);
    }

}


using AutoMapper;
using Feedback.Models;
using Feedback.Request;

namespace Feedback.Dtos.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FeedbackNote, FeedbackNoteDto>().ReverseMap();
            CreateMap<CreateFeedbackNoteRequest, FeedbackNote>().ReverseMap();
            CreateMap<UpdateFeedbackNoteRequest, FeedbackNote>().ReverseMap();
        }
    }
}

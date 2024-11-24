namespace Feedback.Dtos
{
    public class FeedbackNoteDto
    {
        public Guid Id { get; set; }
        public int Note { get; set; }
        public string Observation { get; set; }
        public UserDto User { get; set; }
        public EventDto Event { get; set; }
    }
}

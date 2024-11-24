namespace Feedback.Request
{
    public class UpdateFeedbackNoteRequest
    {
        public Guid Id { get; set; }
        public int Note { get; set; }
        public string Observation { get; set; }
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }
    }
}

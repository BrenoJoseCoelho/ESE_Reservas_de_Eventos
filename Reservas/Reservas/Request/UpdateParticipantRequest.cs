namespace ReservasApi.Request
{
    public class UpdateParticipantRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public Guid UserId { get; set; }
    }
}

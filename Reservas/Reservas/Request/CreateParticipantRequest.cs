namespace ReservasApi.Request
{
    public class CreateParticipantRequest
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public Guid UserId { get; set; }

    }
}

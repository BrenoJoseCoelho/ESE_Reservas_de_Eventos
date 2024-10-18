namespace ReservasApi.Models
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public Guid ParticipantId { get; set; }
        public Participant Participant { get; set; }
    }
}

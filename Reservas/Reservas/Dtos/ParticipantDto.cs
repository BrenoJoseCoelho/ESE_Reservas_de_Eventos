namespace ReservasApi.Dtos
{
    public class ParticipantDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }
        public int QtdIngresso { get; set; }

    }
}

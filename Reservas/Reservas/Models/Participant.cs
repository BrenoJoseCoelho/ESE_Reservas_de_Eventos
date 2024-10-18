namespace ReservasApi.Models
{
    public class Participant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public Guid UserId { get; set; }
    }
}

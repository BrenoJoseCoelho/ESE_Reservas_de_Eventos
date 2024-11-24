namespace ReservasApi.Dtos
{
    public class ParticipantDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public UserDto? User { get; set; }

    }
}
